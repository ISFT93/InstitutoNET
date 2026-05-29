using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormModificacionActa : Form
    {
        #region Publics
        public FormPrincipal Contenedor { get; set; }
        public int MesaFinalId { get; set; }
        public int MateriaId { get; set; }
        public string NombreMateria { get; set; }
        public int CarreraId { get; set; }
        public string NombreCarrera { get; set; }
        public string AnioCurso { get; set; }
        public int CicloLectivoId { get; set; }
        public DateTime FechaMesa { get; set; }
        public string NombreProfesor { get; set; }
        public string NombreVocal { get; set; }
        public string Hora { get; set; }
        #endregion

        #region Privates
        private MesasFinalesLogica _mesasFinalesLogica;
        private DataTable _alumnos;
        #endregion

        public FormModificacionActa()
        {
            InitializeComponent();
            _mesasFinalesLogica = new MesasFinalesLogica();
        }

        private void FormModificacionActa_Load(object sender, EventArgs e)
        {
            if (FechaMesa != DateTime.MinValue)
                dtpFechaModiActa.Value = FechaMesa;
            else
                dtpFechaModiActa.Value = DateTime.Now;

            txtFirma.Text = NombreProfesor ?? string.Empty;

            CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            if (MateriaId <= 0 || CicloLectivoId <= 0)
            {
                MessageBox.Show("No se ha seleccionado una materia v\u00e1lida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _alumnos = _mesasFinalesLogica.ObtenerAlumnosPorMateria(MateriaId, CicloLectivoId);

            dgvActa.Rows.Clear();
            foreach (DataRow row in _alumnos.Rows)
            {
                string nombreCompleto = $"{row["Apellido"]}, {row["Nombre"]}";
                dgvActa.Rows.Add(nombreCompleto, string.Empty);
            }
        }

        private void btn_Siguiente_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarExcelActa();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el acta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarExcelActa()
        {
            string templatePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Assets", "acta_mesas_finales.template.xlsx");

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("No se encontr\u00f3 el template del acta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string safeNombreMateria = string.Join("_", (NombreMateria ?? "SinMateria").Split(Path.GetInvalidFileNameChars()));
            string nombreDefault = $"Acta_{safeNombreMateria}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                saveDialog.FileName = nombreDefault;
                saveDialog.Title = "Guardar acta de examen";
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                string outputPath = saveDialog.FileName;
                File.Copy(templatePath, outputPath, true);

                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(outputPath, true))
                {
                    WorkbookPart wbPart = doc.WorkbookPart;

                    // Eliminar c\u00e1lculo forzado para evitar inconsistencias
                    if (wbPart.CalculationChainPart != null)
                        wbPart.DeletePart(wbPart.CalculationChainPart);

                    SharedStringTablePart sstPart = wbPart.SharedStringTablePart;
                    if (sstPart == null)
                    {
                        sstPart = wbPart.AddNewPart<SharedStringTablePart>();
                        sstPart.SharedStringTable = new SharedStringTable();
                    }

                    Sheet sheet = wbPart.Workbook.Sheets.Elements<Sheet>()
                        .FirstOrDefault(s => s.Name == "SISTEMAS");

                    if (sheet == null)
                    {
                        MessageBox.Show("No se encontr\u00f3 la hoja 'SISTEMAS'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    WorksheetPart wsPart = (WorksheetPart)wbPart.GetPartById(sheet.Id);
                    Worksheet worksheet = wsPart.Worksheet;
                    SheetData sheetData = worksheet.GetFirstChild<SheetData>();

                    int totalAlumnos = dgvActa.Rows.Count;
                    int filaInicio = 15;
                    int filasTemplate = 33; // filas 15 a 47 inclusive
                    int extraRows = Math.Max(0, totalAlumnos - filasTemplate);

                    if (extraRows > 0)
                    {
                        Row templateRow = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex.Value == filaInicio);
                        if (templateRow != null)
                        {
                            InsertExtraRows(sheetData, worksheet, wsPart, templateRow, 47, extraRows);
                        }
                    }

                    // Reemplazar placeholders
                    foreach (Row row in sheetData.Elements<Row>())
                    {
                        uint rowIndex = row.RowIndex.Value;
                        foreach (Cell cell in row.Elements<Cell>())
                        {
                            string cellValue = GetCellValue(cell, sstPart);
                            if (string.IsNullOrEmpty(cellValue) || !cellValue.Contains("{"))
                                continue;

                            string placeholder = cellValue;
                            string newValue = placeholder;

                            // Placeholders del encabezado
                            newValue = newValue.Replace("{libro}", "");
                            newValue = newValue.Replace("{folio}", "");
                            newValue = newValue.Replace("{nombre_profesor}", NombreProfesor ?? "");
                            newValue = newValue.Replace("{nombre_acompa\u00f1ante}", NombreVocal ?? "");
                            newValue = newValue.Replace("{hora}", Hora ?? FechaMesa.ToString("HH:mm"));
                            newValue = newValue.Replace("{espacio_curricular}", NombreMateria ?? "");
                            newValue = newValue.Replace("{anio_curso}", AnioCurso ?? "");
                            newValue = newValue.Replace("{nombre_carrera_sin_tecnicatura_superior_en}", NombreCarrera ?? "");
                            newValue = newValue.Replace("{fecha_primer_llamado}", dtpFechaModiActa.Value.ToString("dd/MM/yyyy"));
                            newValue = newValue.Replace("{fecha}", DateTime.Now.ToString("dd/MM/yyyy"));
                            newValue = newValue.Replace("{firma_profesor}", txtFirma.Text ?? "");
                            newValue = newValue.Replace("{total_alumnos}", totalAlumnos.ToString());
                            newValue = newValue.Replace("{total_aprobados}", "");
                            newValue = newValue.Replace("{total_aplazados}", "");
                            newValue = newValue.Replace("{total_ausentes}", "");

                            // Placeholders de alumnos (filas 15 en adelante)
                            if (rowIndex >= filaInicio)
                            {
                                int alumnoIndex = (int)(rowIndex - filaInicio);
                                if (alumnoIndex < totalAlumnos)
                                {
                                    DataGridViewRow dgvRow = dgvActa.Rows[alumnoIndex];
                                    string nombreAlumno = dgvRow.Cells["Alumno"].Value?.ToString() ?? "";
                                    string calificacion = dgvRow.Cells["CalificacionDefinitiva"].Value?.ToString() ?? "";

                                    string apellido = "";
                                    string nombre = "";
                                    if (nombreAlumno.Contains(","))
                                    {
                                        var partes = nombreAlumno.Split(new[] { ',' }, 2);
                                        apellido = partes[0].Trim();
                                        nombre = partes[1].Trim();
                                    }
                                    else
                                    {
                                        apellido = nombreAlumno;
                                    }

                                    DataRow alumnoRow = _alumnos.Rows[alumnoIndex];
                                    string dni = alumnoRow["NumeroDocumento"]?.ToString() ?? "";
                                    string email = alumnoRow["Email"]?.ToString() ?? "";
                                    string telefono = alumnoRow["Telefono"]?.ToString() ?? "";

                                    newValue = newValue.Replace("{dni_alumno}", dni);
                                    newValue = newValue.Replace("{apellido_alumno}", apellido);
                                    newValue = newValue.Replace("{nombre_alumno}", nombre);
                                    newValue = newValue.Replace("{correo_alumno}", email);
                                    newValue = newValue.Replace("{telefono_alumno}", telefono);
                                    newValue = newValue.Replace("{calificacion}", calificacion);
                                    newValue = newValue.Replace("{presente}", "");
                                }
                                else
                                {
                                    newValue = newValue.Replace("{dni_alumno}", "");
                                    newValue = newValue.Replace("{apellido_alumno}", "");
                                    newValue = newValue.Replace("{nombre_alumno}", "");
                                    newValue = newValue.Replace("{correo_alumno}", "");
                                    newValue = newValue.Replace("{telefono_alumno}", "");
                                    newValue = newValue.Replace("{calificacion}", "");
                                    newValue = newValue.Replace("{presente}", "");
                                }
                            }

                            if (newValue != placeholder)
                            {
                                SetCellValue(cell, newValue, sstPart);
                            }
                        }
                    }

                    worksheet.Save();
                    wbPart.Workbook.Save();
                }

                MessageBox.Show($"El acta se guard\u00f3 correctamente en:\n{outputPath}", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo(outputPath) { UseShellExecute = true });
            }
        }

        private void InsertExtraRows(SheetData sheetData, Worksheet worksheet, WorksheetPart wsPart, Row templateRow, uint insertAfterRow, int count)
        {
            uint templateRowIndex = templateRow.RowIndex.Value;

            // Insertar nuevas filas despu\u00e9s de insertAfterRow
            for (int i = 1; i <= count; i++)
            {
                uint newRowIndex = insertAfterRow + (uint)i;
                Row newRow = (Row)templateRow.CloneNode(true);
                newRow.RowIndex = newRowIndex;

                foreach (Cell cell in newRow.Elements<Cell>())
                {
                    string oldRef = cell.CellReference.Value;
                    string colLetters = GetColumnLetters(oldRef);
                    cell.CellReference = colLetters + newRowIndex;
                }

                var nextRow = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex > newRowIndex);
                if (nextRow != null)
                    sheetData.InsertBefore(newRow, nextRow);
                else
                    sheetData.Append(newRow);
            }

            // Desplazar filas existentes despu\u00e9s de insertAfterRow + count
            uint shiftStart = insertAfterRow + (uint)count + 1;
            var rowsToShift = sheetData.Elements<Row>()
                .Where(r => r.RowIndex >= shiftStart)
                .OrderByDescending(r => r.RowIndex.Value)
                .ToList();

            foreach (Row row in rowsToShift)
            {
                uint oldIndex = row.RowIndex.Value;
                uint newIndex = oldIndex + (uint)count;
                row.RowIndex = newIndex;

                foreach (Cell cell in row.Elements<Cell>())
                {
                    string oldRef = cell.CellReference.Value;
                    string colLetters = GetColumnLetters(oldRef);
                    cell.CellReference = colLetters + newIndex;
                }
            }

            // Actualizar SheetDimension
            var dimension = worksheet.SheetDimension;
            if (dimension != null && dimension.Reference != null)
            {
                string refAttr = dimension.Reference.Value;
                var parts = refAttr.Split(':');
                if (parts.Length == 2)
                {
                    string endCol = GetColumnLetters(parts[1]);
                    int endRow = int.Parse(GetRowNumber(parts[1]));
                    endRow += count;
                    dimension.Reference = new StringValue(parts[0] + ":" + endCol + endRow);
                }
            }

            // Actualizar MergeCells
            var mergeCells = worksheet.GetFirstChild<MergeCells>();
            if (mergeCells != null)
            {
                foreach (MergeCell mc in mergeCells.Elements<MergeCell>())
                {
                    mc.Reference = ShiftCellRange(mc.Reference.Value, insertAfterRow, count);
                }
            }

            // Actualizar Drawings (anclajes de im\u00e1genes)
            if (wsPart.DrawingsPart != null)
            {
                var wsDrawing = wsPart.DrawingsPart.WorksheetDrawing;
                foreach (var anchor in wsDrawing.Descendants<DocumentFormat.OpenXml.Drawing.Spreadsheet.OneCellAnchor>())
                {
                    var from = anchor.FromMarker;
                    if (from != null && from.RowId != null && uint.Parse(from.RowId.Text) >= insertAfterRow)
                    {
                        uint newRow = uint.Parse(from.RowId.Text) + (uint)count;
                        from.RowId = new DocumentFormat.OpenXml.Drawing.Spreadsheet.RowId(newRow.ToString());
                    }
                }
                foreach (var anchor in wsDrawing.Descendants<DocumentFormat.OpenXml.Drawing.Spreadsheet.TwoCellAnchor>())
                {
                    if (anchor.FromMarker != null && anchor.FromMarker.RowId != null && uint.Parse(anchor.FromMarker.RowId.Text) >= insertAfterRow)
                    {
                        uint newRow = uint.Parse(anchor.FromMarker.RowId.Text) + (uint)count;
                        anchor.FromMarker.RowId = new DocumentFormat.OpenXml.Drawing.Spreadsheet.RowId(newRow.ToString());
                    }
                    if (anchor.ToMarker != null && anchor.ToMarker.RowId != null && uint.Parse(anchor.ToMarker.RowId.Text) >= insertAfterRow)
                    {
                        uint newRow = uint.Parse(anchor.ToMarker.RowId.Text) + (uint)count;
                        anchor.ToMarker.RowId = new DocumentFormat.OpenXml.Drawing.Spreadsheet.RowId(newRow.ToString());
                    }
                }
            }
        }

        private string GetCellValue(Cell cell, SharedStringTablePart sstPart)
        {
            if (cell == null) return string.Empty;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString && cell.CellValue != null)
            {
                int index = int.Parse(cell.CellValue.Text);
                if (sstPart != null && sstPart.SharedStringTable != null && index < sstPart.SharedStringTable.Count())
                {
                    var item = sstPart.SharedStringTable.ElementAt(index);
                    return item.InnerText;
                }
            }
            else if (cell.CellValue != null)
            {
                return cell.CellValue.Text;
            }
            return string.Empty;
        }

        private void SetCellValue(Cell cell, string value, SharedStringTablePart sstPart)
        {
            // Eliminar f\u00f3rmula existente
            var formula = cell.GetFirstChild<CellFormula>();
            if (formula != null) formula.Remove();

            if (string.IsNullOrEmpty(value))
            {
                cell.DataType = null;
                cell.CellValue = null;
                return;
            }

            if (sstPart != null)
            {
                int index = InsertSharedStringItem(value, sstPart);
                cell.CellValue = new CellValue(index.ToString());
                cell.DataType = CellValues.SharedString;
            }
            else
            {
                cell.CellValue = new CellValue(value);
                cell.DataType = CellValues.String;
            }
        }

        private int InsertSharedStringItem(string text, SharedStringTablePart sstPart)
        {
            if (sstPart.SharedStringTable == null)
                sstPart.SharedStringTable = new SharedStringTable();

            int i = 0;
            foreach (SharedStringItem item in sstPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                    return i;
                i++;
            }

            sstPart.SharedStringTable.Append(new SharedStringItem(new Text(text)));
            sstPart.SharedStringTable.Save();
            return i;
        }

        private string GetColumnLetters(string cellRef)
        {
            return new string(cellRef.TakeWhile(char.IsLetter).ToArray());
        }

        private string GetRowNumber(string cellRef)
        {
            return new string(cellRef.SkipWhile(char.IsLetter).ToArray());
        }

        private string ShiftCellRange(string range, uint insertAfterRow, int count)
        {
            if (string.IsNullOrEmpty(range)) return range;
            var parts = range.Split(':');
            if (parts.Length == 1)
            {
                return ShiftCellRef(parts[0], insertAfterRow, count);
            }
            else if (parts.Length == 2)
            {
                return ShiftCellRef(parts[0], insertAfterRow, count) + ":" + ShiftCellRef(parts[1], insertAfterRow, count);
            }
            return range;
        }

        private string ShiftCellRef(string cellRef, uint insertAfterRow, int count)
        {
            string col = GetColumnLetters(cellRef);
            int row = int.Parse(GetRowNumber(cellRef));
            if (row >= insertAfterRow)
                row += count;
            return col + row;
        }
    }
}
