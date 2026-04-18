using ISFDyT93.Datos.Core.Attributes.Validaciones;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using Syncfusion.XlsIO;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ISFDyT93.Negocio;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using ISFDyT93.Vista.Forms.Alumnos;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using Syncfusion.XlsIO.Implementation;


namespace ISFDyT93.Vista.Forms.Componentes
{
    public partial class FormCargaMasivaExcel : Form
    {
        CarrerasLogica carrerasLogica = new CarrerasLogica();
        AlumnosLogica alumnosLogica = new AlumnosLogica();

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
                    IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);
                    IWorksheet worksheet = workbook.Worksheets[0];
                    var usedRange = worksheet.UsedRange;
                    dtExcel = worksheet.ExportDataTable(usedRange, ExcelExportDataTableOptions.ColumnNames);

                    // Eliminar filas completamente vacías
                    var filasVacias = dtExcel.AsEnumerable()
                        .Where(r => r.ItemArray.All(v => v == null || string.IsNullOrWhiteSpace(v?.ToString())))
                        .ToList();
                    foreach (var fila in filasVacias)
                        dtExcel.Rows.Remove(fila);
                }
                dgvCargaMasiva.DataSource = dtExcel;

                // Deshabilitar sort para evitar que las filas se reordenen al editar valores
                foreach (DataGridViewColumn col in dgvCargaMasiva.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;

                ProcesarHeaders();
            }
        }

        public void ProcesarHeaders()
        {
            _columnasNoMapeadas.Clear();
            _celdasCarreraInvalidas.Clear();
            _columnaCarreraIndex = -1;
            _propiedades = typeof(AlumnosModelo).GetProperties().Select(p => p.Name).OrderBy(name => name).ToList()
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

                string texto = (e.Value?.ToString() ?? "") + "  ▼";
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
            menu.MaximumSize = new Size(200, 400);
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

        // Valida que las carreras ingresadas existan en la base de datos, marcando en rojo las celdas con valores no válidos
        private void ValidarColumnasCarrera()
        {
            _celdasCarreraInvalidas.Clear();
            _dtCarreras = carrerasLogica.ObtenerCarreras();
            var nombresCarreras = new HashSet<string>(
                _dtCarreras.AsEnumerable().Select(r => r["Nombre"].ToString().Trim()),
                System.StringComparer.OrdinalIgnoreCase
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
            menu.MaximumSize = new Size(600, 400);
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

        // Al seleccionar una carrera válida del menú, actualizar el valor de la celda y eliminarla del conjunto de celdas inválidas
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
                var result = MessageBox.Show(
                    $"Hay columnas sin clasificar, estos datos no quedarán guardados:" +
                    $"\n- {string.Join("\n- ", _columnasNoMapeadas.Select(i => dgvCargaMasiva.Columns[i].HeaderText))}" +
                    "\n¿Está seguro de querer continuar?",
                    "Columnas sin clasificar",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (result != DialogResult.OK)
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

            var carrerasPorNombre = _dtCarreras.AsEnumerable()
                .GroupBy(r => r["Nombre"].ToString().Trim(), System.StringComparer.OrdinalIgnoreCase)
                .ToDictionary(
                    g => g.Key,
                    g => Convert.ToInt32(g.First()["CarreraId"]),
                    System.StringComparer.OrdinalIgnoreCase
                );

            var titleCase = CultureInfo.CurrentCulture.TextInfo;
            int agregados = 0;
            int omitidos = 0;

            foreach (DataRow dr in dtExcel.Rows)
            {
                string dni = GetColumnaValor(dr, nameof(AlumnosModelo.NumeroDocumento));
                if (string.IsNullOrWhiteSpace(dni) || alumnosLogica.AlumnoExiste(dni))
                {
                    omitidos++;
                    continue;
                }

                string carreraNombre = GetColumnaValor(dr, _carrerasColumnName);
                if (!carrerasPorNombre.TryGetValue(carreraNombre, out int carreraId))
                {
                    omitidos++;
                    continue;
                }

                char sexo = NormalizarSexo(GetColumnaValor(dr, nameof(AlumnosModelo.Sexo)));
                DateTime.TryParse(GetColumnaValor(dr, nameof(AlumnosModelo.FechaNacimiento)), out DateTime fechaNacimiento);

                var modelo = new AlumnosModelo
                {
                    Apellido = titleCase.ToTitleCase(GetColumnaValor(dr, nameof(AlumnosModelo.Apellido)).ToLower()),
                    Nombre = titleCase.ToTitleCase(GetColumnaValor(dr, nameof(AlumnosModelo.Nombre)).ToLower()),
                    TipoDocumento = "Dni",
                    NumeroDocumento = dni,
                    EstadoCivil = GetColumnaValor(dr, nameof(AlumnosModelo.EstadoCivil)),
                    Sexo = sexo,
                    FechaNacimiento = fechaNacimiento,
                    LocalidadNacimiento = titleCase.ToTitleCase(GetColumnaValor(dr, nameof(AlumnosModelo.LocalidadNacimiento)).ToLower()),
                    Calle = titleCase.ToTitleCase(GetColumnaValor(dr, nameof(AlumnosModelo.Calle)).ToLower()),
                    Provincia = titleCase.ToTitleCase(GetColumnaValor(dr, nameof(AlumnosModelo.Provincia)).ToLower()),
                    Distrito = titleCase.ToTitleCase(GetColumnaValor(dr, nameof(AlumnosModelo.Distrito)).ToLower()),
                    Localidad = titleCase.ToTitleCase(GetColumnaValor(dr, nameof(AlumnosModelo.Localidad)).ToLower()),
                    CodigoPostal = GetColumnaValor(dr, nameof(AlumnosModelo.CodigoPostal)),
                    Celular = GetColumnaValor(dr, nameof(AlumnosModelo.Celular)),
                    Email = GetColumnaValor(dr, nameof(AlumnosModelo.Email)),
                    FotoUrl = GetColumnaValor(dr, nameof(AlumnosModelo.FotoUrl)),
                    Activo = true,
                };

                int nuevoAlumnoId = alumnosLogica.AgregarAlumnoCargaMasiva(modelo);
                if (nuevoAlumnoId <= 0)
                {
                    omitidos++;
                    continue;
                }

                alumnosLogica.AgregarAlumnoCarrera(new AlumnosCarrerasModelo
                {
                    AlumnoId = nuevoAlumnoId,
                    CarreraId = carreraId,
                    FechaAlta = DateTime.Now,
                    Activo = true,
                });

                agregados++;
            }

            if (agregados > 0)
            {
                Contenedor.AbrirFormulario<FormAlumnos>();
                FormNotificacion.Mensaje(TipoNotificacion.Success,
                    $"{agregados} alumno{(agregados > 1 ? "s agregados" : " agregado")} con éxito" +
                    (omitidos > 0 ? $" ({omitidos} omitidos por DNI duplicado o carrera inválida)" : ""));
            }
            else
            {
                FormNotificacion.Mensaje(TipoNotificacion.Warning,
                    omitidos > 0
                        ? $"No se agregó ningún alumno. {omitidos} fila{(omitidos > 1 ? "s omitidas" : " omitida")} por DNI duplicado."
                        : "No se encontraron alumnos para agregar.");
            }
        }

        private string GetColumnaValor(DataRow dr, string columna)
        {
            return dtExcel.Columns.Contains(columna) ? dr[columna]?.ToString()?.Trim() ?? "" : "";
        }

        private char NormalizarSexo(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return 'M';
            valor = valor.Trim().ToLower();
            if (valor == "femenino" || valor == "f") return 'F';
            return 'M';
        }
    }
}
