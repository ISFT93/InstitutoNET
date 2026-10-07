using ISFDyT93.Datos.Core;
using ISFDyT93.Entidades.Core.Attributes.Validaciones;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio;
using ISFDyT93.Negocio.Logica;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormPersonalCargaMasivaExcel : FormBase
    {
        public FormPersonalCargaMasivaExcel()
        {
            InitializeComponent();
            dgvCargaMasiva.CellPainting += PintarHeaderNoMapeado;
        }
        HashSet<int> _columnasNoMapeadas = new HashSet<int>();
        List<string> _propiedades;
        DataTable dtExcel;
        PersonalLogica personalLogica = new PersonalLogica();
        #region columnasDGV
        public void ProcesarHeaders()
        {
            _columnasNoMapeadas.Clear();
            _propiedades = typeof(PersonalModelo).GetProperties().Select(p => p.Name).OrderBy(name => name).ToList();
            foreach (DataColumn column in dtExcel.Columns.Cast<DataColumn>().ToList())
            {
                bool matched = false;
                foreach (var prop in typeof(PersonalModelo).GetProperties())
                {
                    if (BuscarCoincidencia(prop.Name, column.ColumnName))
                    {
                        if (!dtExcel.Columns.Contains(prop.Name))
                            column.ColumnName = prop.Name;
                        matched = true;
                        break;
                    }
                }

                if (!matched)
                {
                    var dgvCol = dgvCargaMasiva.Columns[column.ColumnName];
                    if (dgvCol != null)
                        _columnasNoMapeadas.Add(dgvCol.Index);
                }
            }

            dgvCargaMasiva.Invalidate();
        }
        public bool BuscarCoincidencia(string nombrePropiedad, string nombreExcel)
        {
            return string.Equals(nombrePropiedad, nombreExcel, StringComparison.OrdinalIgnoreCase);
        }
        private void PintarHeaderNoMapeado(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && _columnasNoMapeadas.Contains(e.ColumnIndex))
            {
                e.PaintBackground(e.CellBounds, false);
                using (var brush = new SolidBrush(Color.Crimson))
                    e.Graphics.FillRectangle(brush, e.CellBounds);

                string texto = (e.Value?.ToString() ?? "") + "  ▼";
                var formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                using (var brush = new SolidBrush(Color.White))
                    e.Graphics.DrawString(texto, e.CellStyle.Font, brush, e.CellBounds, formato);
                e.Handled = true;
                return;
            }
        }
        private bool ValidarFormatoTabla(IWorksheet worksheet)
        {
            var usedRange = worksheet.UsedRange;
            if (usedRange.Row != 1 || usedRange.Column != 1)
                return false;

            int colCount = usedRange.LastColumn;
            for (int col = 1; col <= colCount; col++)
            {
                var headerValue = worksheet[1, col].Text;
                if (string.IsNullOrWhiteSpace(headerValue))
                    return false;
            }

            return true;
        }
        #endregion
        #region MetodosAuxiliares
        private string GetCellValue(DataGridViewRow fila, string columnName)
        {
            if (fila.DataGridView.Columns.Contains(columnName))
                return fila.Cells[columnName].Value?.ToString() ?? string.Empty;
            return string.Empty;
        }

        private DateTime GetDateCellValue(DataGridViewRow fila, string columnName)
        {
            if (fila.DataGridView.Columns.Contains(columnName) &&
                DateTime.TryParse(fila.Cells[columnName].Value?.ToString(), out var fecha))
                return fecha;
            return DateTime.MinValue;
        }

        private int GetIntCellValue(DataGridViewRow fila, string columnName)
        {
            if (fila.DataGridView.Columns.Contains(columnName) &&
                int.TryParse(fila.Cells[columnName].Value?.ToString(), out var numero))
                return numero;
            return 0;
        }
        #endregion
        #region ValidacionDatos
        private bool EsBitValido(DataGridViewRow fila, string columna)
        {
            if (!fila.DataGridView.Columns.Contains(columna)) return true;
            string valor = fila.Cells[columna].Value?.ToString()?.Trim().ToLower();

            return valor == "0" || valor == "1" || valor == "true" || valor == "false";
        }
        private bool EsFechaValida(DataGridViewRow fila, string columna)
        {
            if (!fila.DataGridView.Columns.Contains(columna)) return true;
            string valor = fila.Cells[columna].Value?.ToString();
            return DateTime.TryParse(valor, out _);
        }
        private bool ValidarLongitudColumnas(DataGridViewRow fila, Dictionary<string, int> columnas)
        {
            foreach (var columna in columnas)
            {
                if (!fila.DataGridView.Columns.Contains(columna.Key))
                    continue;

                string valor = fila.Cells[columna.Key].Value?.ToString()?.Trim() ?? "";

                if (valor.Length > columna.Value)
                {
                    MessageBox.Show($"Uno de los datos de la columna '{columna.Key}' contiene una cantidad de caracteres muy grande para la misma.\n" +
                        $"Asegurese de que no supere los {columna.Value} caracteres.","Error de formato",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private bool EsNumeroValido(DataGridViewRow fila, string columna)
        {
            if (!fila.DataGridView.Columns.Contains(columna)) return true;
            string valor = fila.Cells[columna].Value?.ToString();
            return long.TryParse(valor, out _);
        }
        private char ValidarSexoChar(DataGridViewRow fila, string columna)
        {
            if (!fila.DataGridView.Columns.Contains(columna))
                return 'M';

            string valor = fila.Cells[columna].Value?.ToString()?.Trim().ToLower();

            if (string.IsNullOrEmpty(valor))
                return 'M';

            if (valor == "femenino" || valor == "F")
                return 'F';

            return 'M';
        }
        private bool ValidarTiposDeColumnas(DataGridView dgv)
        {
            var limiteColumnas = new Dictionary<string, int>
            {
                {"Nombre", 50 },{"Apellido", 50 }, {"Direccion", 250 },
                {"Piso", 10 }, {"Departamento", 50}, {"Localidad", 250 },
                {"Celular", 50 }, {"Telefono", 50 }, {"Nacionalidad", 150 },
                {"Email", 250 }, {"EstadoCivil", 50 }, {"Titulo", 50 }
            };
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (fila.IsNewRow) continue;

                if (!EsFechaValida(fila, "FechaNacimiento"))
                {
                    MessageBox.Show("La columna 'FechaNacimiento' contiene un valor inválido.\n" +"Por favor, corrija el formato antes de continuar.",
                        "Error de formato",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                if (!EsBitValido(fila, "TramoPedagogico"))
                {
                    MessageBox.Show("La columna 'TramoPedagogico' contiene un valor inválido.\n" + "Por favor, corrija el formato a 0/1 o true/false para continuar",
                        "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!ValidarLongitudColumnas(fila, limiteColumnas))
                    return false;
            }
            return true;
        }
        #endregion
        private void btnBuscarArchivoExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "Archivos Excel|*.xls;*.xlsx|Archivos .csv (*.csv)|*.csv";
            archivo.InitialDirectory = "C://";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                string rutaCvs = archivo.FileName;
                try
                {
                    using (Stream inputStream = File.OpenRead(rutaCvs))
                    using (ExcelEngine excelEngine = new ExcelEngine())
                    {
                        IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);
                        IWorksheet worksheet = workbook.Worksheets[0];

                        if (!ValidarFormatoTabla(worksheet))
                        {
                            MessageBox.Show("El formato del Excel no es válido. Debe contener una única tabla que comience en la celda A1 con cabeceras consecutivas sin espacios vacíos.",
                                "Formato no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var usedRange = worksheet.UsedRange;
                        dtExcel = worksheet.ExportDataTable(usedRange, ExcelExportDataTableOptions.ColumnNames);

                        var filasVacias = dtExcel.AsEnumerable().Where(r => r.ItemArray.All(v => v == null || string.IsNullOrWhiteSpace(v?.ToString()))).ToList();
                        foreach (var fila in filasVacias)
                            dtExcel.Rows.Remove(fila);
                    }

                    dgvCargaMasiva.DataSource = dtExcel;

                    foreach (DataGridViewColumn col in dgvCargaMasiva.Columns)
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;

                    ProcesarHeaders();
                }
                catch (IOException)
                {
                    MessageBox.Show("El archivo Excel está abierto en otra aplicación. Por favor ciérrelo antes de cargarlo.", "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnAceptarCargaMasiva_Click(object sender, EventArgs e)
        {
            if (!ValidarColumnasObligatorias(dgvCargaMasiva))
                return;

            if (!ValidarTiposDeColumnas(dgvCargaMasiva))
                return;

            List<PersonalModelo> listaValidos = new List<PersonalModelo>();
            List<PersonalModelo> listaInvalidos = new List<PersonalModelo>();
            HashSet<string> documentosProcesados = new HashSet<string>();

            foreach (DataGridViewRow dgvRow in dgvCargaMasiva.Rows)
            {
                if (dgvRow.IsNewRow) continue;
                PersonalModelo modelo = CargarPersonalModelo(dgvRow);

                if (documentosProcesados.Contains(modelo.NumeroDocumento))
                {
                    listaInvalidos.Add(modelo);
                    continue;
                }

                documentosProcesados.Add(modelo.NumeroDocumento);

                if (personalLogica.ExisteDocumentoEnBD(modelo.NumeroDocumento))
                    listaInvalidos.Add(modelo);
                else
                    listaValidos.Add(modelo);
            }

            if (listaInvalidos.Any())
            {
                DialogResult dr = MessageBox.Show("Se encontraron documentos ya existentes en la base de datos o repetidos en el archivo. Estos no se agregarán.\n" +"¿Desea continuar con la carga de los válidos?",
                    "Advertencia",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if (dr == DialogResult.No)
                    return;
            }

            DialogResult dr2 = MessageBox.Show("Está seguro de que desea agregar los datos?", "CONFIRMACIÓN", MessageBoxButtons.YesNo);
            if (dr2 == DialogResult.Yes)
            {
                foreach (var modelo in listaValidos)
                    personalLogica.AgregarPersonal(modelo);

                FormNotificacion.Mensaje(TipoNotificacion.Success, "Carga masiva finalizada. " + $"\n{listaValidos.Count} registros agregados. \n{listaInvalidos.Count} rechazados.");
                Contenedor.AbrirFormulario<FormPersonal>();
                this.Close();
            }
            else
                return;
        }

        private PersonalModelo CargarPersonalModelo(DataGridViewRow dgvFila)
        {
            PersonalModelo pm = new PersonalModelo()
            {
                Apellido = GetCellValue(dgvFila, "Apellido"),
                Nombre = GetCellValue(dgvFila, "Nombre"),
                NumeroDocumento = GetCellValue(dgvFila, "NumeroDocumento"),
                FechaNacimiento = GetDateCellValue(dgvFila, "FechaNacimiento"),
                Sexo = ValidarSexoChar(dgvFila, "Sexo"),
                Direccion = GetCellValue(dgvFila, "Direccion"),
                Piso = GetCellValue(dgvFila, "Piso"),
                Departamento = GetCellValue(dgvFila, "Departamento"),
                Localidad = GetCellValue(dgvFila, "Localidad"),
                Celular = GetCellValue(dgvFila, "Celular"),
                Telefono = GetCellValue(dgvFila, "Telefono"),
                Nacionalidad = GetCellValue(dgvFila, "Nacionalidad"),
                Email = GetCellValue(dgvFila, "Email"),
                EstadoCivil = GetCellValue(dgvFila, "EstadoCivil"),
                Foto = GetCellValue(dgvFila, "Foto"),
                Titulo = GetCellValue(dgvFila, "Titulo"),
                TramoPedagogico = GetCellValue(dgvFila, "TramoPedagogico"),
                FechaAlta = GetDateCellValue(dgvFila, "FechaAlta"),
                FechaBaja = GetDateCellValue(dgvFila, "FechaBaja"),
                PersonalEstadoId = GetIntCellValue(dgvFila, "PersonalEstadoId")
            };
            return pm;
        }

        private bool ValidarColumnasObligatorias(DataGridView dgv)
        {
            var obligatorias = typeof(PersonalModelo).GetProperties().Where(
                p => Attribute.IsDefined(p, typeof(Obligatorio))).Select(p => p.Name).ToList();

            List<string> obligatoriosFaltantes = new List<string>();

            foreach (var propiedadObligatoria in obligatorias)
            {
                if (!dgv.Columns.Contains(propiedadObligatoria))
                {
                    obligatoriosFaltantes.Add(propiedadObligatoria);
                }
            }

            if (obligatoriosFaltantes.Any())
            {
                string faltantes = string.Join(", ", obligatoriosFaltantes);
                MessageBox.Show($"Faltan las siguientes columnas obligatorias: {faltantes}\nAsegúrese de que existan o estén escritas correctamente.",
                    "Error en la carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormPersonal>();
            this.Close();
        }
    }
}
