using ISFDyT93.Datos.Core.Attributes.Validaciones;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using Syncfusion.XlsIO;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ISFDyT93.Negocio;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ISFDyT93.Vista.Forms.Componentes
{
    public partial class FormCargaMasivaExcel : Form
    {
        CarrerasLogica carrerasLogica = new CarrerasLogica();

        public FormPrincipal Contenedor { get; set; }
        public string Accion { get; set; }
        public int AlumnoId { get; set; }
        public int AlumnoCarreraId { get; set; }

        DataTable dtExcel;
        HashSet<int> _columnasNoMapeadas = new HashSet<int>();
        List<string> _propiedades;
        //string _carrerasColumnName = string.Format(nameof(CarrerasModelo.Nombre)); // -> Nombre
        string _carrerasColumnName = "Carrera";
        string _carrerasXMLColumnName = "Carreras";

        HashSet<string> _celdasCarreraInvalidas = new HashSet<string>();
        int _columnaCarreraIndex = -1;
        DataTable _dtCarreras;

        public FormCargaMasivaExcel()
        {
            InitializeComponent();
            dgvCargaMasiva.CellPainting += PintarHeaderNoMapeado;
            dgvCargaMasiva.ColumnHeaderMouseClick += MostrarMenuMapeo;
            dgvCargaMasiva.CellClick += MostrarMenuCarrera;
        }

        private void btnBuscarArchivoExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivoExcel = new OpenFileDialog();
            archivoExcel.Filter = "Archivos Excel|*.xls;*.xlsx|Archivos .csv (*.csv)|*.csv";
            archivoExcel.InitialDirectory = "C://";

            if (archivoExcel.ShowDialog() == DialogResult.OK)
            {
                string rutaCvs = archivoExcel.FileName;
                using (Stream inputStream = File.OpenRead(rutaCvs))
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IWorksheet worksheet = excelEngine.Excel.Workbooks.Open(inputStream).Worksheets[0];
                    dtExcel = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
                }
                dgvCargaMasiva.DataSource = dtExcel;
                ProcesarHeaders();
            }
        }

        public void ProcesarHeaders()
        {
            _columnasNoMapeadas.Clear();
            _celdasCarreraInvalidas.Clear();
            _columnaCarreraIndex = -1;
            _propiedades = typeof(AlumnosModelo).GetProperties().Select(p => p.Name).ToList();

            foreach (DataColumn column in dtExcel.Columns.Cast<DataColumn>().ToList())
            {
                bool matched = false;
                foreach (var prop in typeof(AlumnosModelo).GetProperties())
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

            foreach (DataColumn col in dtExcel.Columns.Cast<DataColumn>().ToList())
            {
                if (BuscarCoincidencia(_carrerasXMLColumnName, col.ColumnName))
                {
                    if (!dtExcel.Columns.Contains(_carrerasColumnName))
                        col.ColumnName = _carrerasColumnName;

                    var dgvCol = dgvCargaMasiva.Columns[_carrerasColumnName];
                    if (dgvCol != null)
                    {
                        _columnaCarreraIndex = dgvCol.Index;
                        _columnasNoMapeadas.Remove(dgvCol.Index);
                    }
                    break;
                }
            }

            if (_columnaCarreraIndex >= 0)
                ValidarColumnasCarrera();

            dgvCargaMasiva.Invalidate();
        }

        private void PintarHeaderNoMapeado(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && _columnasNoMapeadas.Contains(e.ColumnIndex))
            {
                e.PaintBackground(e.CellBounds, false);
                using (var brush = new SolidBrush(Color.Crimson))
                    e.Graphics.FillRectangle(brush, e.CellBounds);

                string texto = e.Value?.ToString() ?? "";
                texto = (texto.Length > 10 ? texto.Substring(0, 10) + "..." : texto) + "  ▼";
                var formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                using (var brush = new SolidBrush(Color.White))
                    e.Graphics.DrawString(texto, e.CellStyle.Font, brush, e.CellBounds, formato);
                e.Handled = true;
                return;
            }

            if (e.RowIndex >= 0 && _celdasCarreraInvalidas.Contains($"{e.RowIndex},{e.ColumnIndex}"))
            {
                e.PaintBackground(e.CellBounds, false);
                using (var brush = new SolidBrush(Color.Crimson))
                    e.Graphics.FillRectangle(brush, e.CellBounds);

                string texto = e.Value?.ToString() ?? "";
                texto = texto.Length > 8 ? texto.Substring(0, 8) + "..." : texto;
                var formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                using (var brush = new SolidBrush(Color.White))
                {
                    e.Graphics.DrawString(texto, e.CellStyle.Font, brush, e.CellBounds, formato);
                    e.Graphics.DrawLine(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                }


                e.Handled = true;
            }
        }

        private void MostrarMenuMapeo(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_propiedades == null) return;

            var menu = new ContextMenuStrip();
            int colIndex = e.ColumnIndex;

            foreach (var prop in _propiedades)
            {
                var item = new ToolStripMenuItem(prop);
                item.Click += (s, args) => AplicarMapeo(colIndex, prop);
                menu.Items.Add(item);
            }
            var carreraItem = new ToolStripMenuItem(_carrerasColumnName);
            carreraItem.Click += (s, args) => AplicarMapeo(colIndex, _carrerasColumnName);
            menu.Items.Add(carreraItem);

            Rectangle rect = dgvCargaMasiva.GetCellDisplayRectangle(colIndex, -1, true);
            menu.Show(dgvCargaMasiva.PointToScreen(new Point(rect.Left, rect.Bottom)));
        }

        private void AplicarMapeo(int colIndex, string propiedadSeleccionada)
        {
            var dgvCol = dgvCargaMasiva.Columns[colIndex];
            if (dgvCol == null) return;

            string nombreActual = dgvCol.HeaderText;
            if (nombreActual == propiedadSeleccionada)
            {
                // Mismo nombre, solo limpiar el estado rojo si estaba sin mapear
                _columnasNoMapeadas.Remove(colIndex);
                dgvCargaMasiva.InvalidateCell(colIndex, -1);
                return;
            }

            if (dtExcel.Columns.Contains(propiedadSeleccionada))
            {
                MessageBox.Show($"Ya hay una columna asignada como '{propiedadSeleccionada}'.", "Mapeo duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtExcel.Columns.Contains(nombreActual))
                dtExcel.Columns[nombreActual].ColumnName = propiedadSeleccionada;

            dgvCol.HeaderText = propiedadSeleccionada;
            _columnasNoMapeadas.Remove(colIndex);
            dgvCargaMasiva.InvalidateCell(colIndex, -1);
        }

        public bool BuscarCoincidencia(string nombrePropiedad, string nombreExcel)
        {
            XDocument doc = XDocument.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "CargaMasivaMap.xml"));
            var dic = doc.Root.Elements()
                .ToDictionary(
                    n => Validaciones.CrearSlug(n.Name.LocalName),
                    n => n.Elements().Select(x => x.Value).ToList()
                );

            nombrePropiedad = Validaciones.CrearSlug(nombrePropiedad);
            nombreExcel = Validaciones.CrearSlug(nombreExcel);

            return dic.ContainsKey(nombrePropiedad) && dic[nombrePropiedad].Any(c => nombreExcel == Validaciones.CrearSlug(c));
        }

        private void ValidarColumnasCarrera()
        {
            _celdasCarreraInvalidas.Clear();
            _dtCarreras = carrerasLogica.ObtenerCarreras();
            var nombresCarreras = new HashSet<string>(
                _dtCarreras.AsEnumerable().Select(r => r["Nombre"].ToString().Trim()),
                StringComparer.OrdinalIgnoreCase
            );

            for (int row = 0; row < dtExcel.Rows.Count; row++)
            {
                string valor = dtExcel.Rows[row][_carrerasColumnName]?.ToString()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(valor) && !nombresCarreras.Contains(valor))
                    _celdasCarreraInvalidas.Add($"{row},{_columnaCarreraIndex}");
            }
        }

        private void MostrarMenuCarrera(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !_celdasCarreraInvalidas.Contains($"{e.RowIndex},{e.ColumnIndex}")) return;
            if (_dtCarreras == null) return;

            var menu = new ContextMenuStrip();
            int rowIndex = e.RowIndex;

            foreach (DataRow dr in _dtCarreras.Rows)
            {
                string nombre = dr["Nombre"].ToString();
                var item = new ToolStripMenuItem(nombre);
                item.Click += (s, args) => AplicarCarrera(rowIndex, nombre);
                menu.Items.Add(item);
            }

            Rectangle rect = dgvCargaMasiva.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(dgvCargaMasiva.PointToScreen(new Point(rect.Left, rect.Bottom)));
        }

        private void AplicarCarrera(int rowIndex, string nombreCarrera)
        {
            dtExcel.Rows[rowIndex][_carrerasColumnName] = nombreCarrera;
            _celdasCarreraInvalidas.Remove($"{rowIndex},{_columnaCarreraIndex}");
            dgvCargaMasiva.InvalidateCell(_columnaCarreraIndex, rowIndex);
        }

        private void btnAceptarCargaMasiva_Click(object sender, EventArgs e)
        {
            if (dtExcel == null) return;

            if (_columnasNoMapeadas.Count > 0)
            {
                MessageBox.Show(
                    $"Mapee las siguientes columnas:\n{string.Join("\n", _columnasNoMapeadas.Select(i => dgvCargaMasiva.Columns[i].HeaderText))}",
                    "Columnas sin mapear", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var columnasMapeadas = new HashSet<string>(dtExcel.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            var condicionProp = typeof(Obligatorio).GetProperty("Condicion", BindingFlags.NonPublic | BindingFlags.Instance);

            var camposFaltantes = typeof(AlumnosModelo)
                .GetProperties()
                .Where(p => p.GetCustomAttributes<Obligatorio>(false)
                    .Any(attr => string.IsNullOrEmpty(condicionProp?.GetValue(attr)?.ToString())))
                .Select(p => p.Name)
                .Where(nombre => !columnasMapeadas.Contains(nombre))
                .ToList();

            if (camposFaltantes.Count > 0)
            {
                MessageBox.Show(
                    $"Faltan los siguientes campos obligatorios para dar el alta:\n\n{string.Join("\n", camposFaltantes)}",
                    "Campos obligatorios faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_celdasCarreraInvalidas.Count > 0)
            {
                MessageBox.Show(
                    $"Hay {_celdasCarreraInvalidas.Count} filas con carreras inválidas (marcadas en rojo). Corrija los valores antes de continuar.",
                    "Carreras inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
