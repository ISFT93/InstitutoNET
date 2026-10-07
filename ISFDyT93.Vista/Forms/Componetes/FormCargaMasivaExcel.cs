using ISFDyT93.Entidades.Core.Attributes.Validaciones;
using ISFDyT93.Entidades.Modelos;
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
using System.Text.RegularExpressions;


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

        string _rutaArchivoExcel;
        bool _cargandoComboHojas;

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

            if (archivoExcel.ShowDialog() != DialogResult.OK)
                return;

            _rutaArchivoExcel = archivoExcel.FileName;
            CargarNombresHojas();
        }

        // Lee los nombres de las hojas del archivo y llena el combo; luego carga la primera hoja
        private void CargarNombresHojas()
        {
            _cargandoComboHojas = true;
            cboHojasExcel.Visible = false;
            lblHojaExcel.Visible = false;
            cboHojasExcel.Items.Clear();

            try
            {
                using (Stream inputStream = File.OpenRead(_rutaArchivoExcel))
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);

                    for (int i = 0; i < workbook.Worksheets.Count; i++)
                        cboHojasExcel.Items.Add(workbook.Worksheets[i].Name);

                    if (cboHojasExcel.Items.Count > 0)
                        cboHojasExcel.SelectedIndex = 0;
                }

                _cargandoComboHojas = false;

                cboHojasExcel.Visible = cboHojasExcel.Items.Count > 0;
                lblHojaExcel.Visible = cboHojasExcel.Visible;

                if (cboHojasExcel.Items.Count > 0)
                    CargarHojaExcel(0);
            }
            catch (Exception ex)
            {
                _cargandoComboHojas = false;
                MessageBox.Show($"No se pudo abrir el archivo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboHojasExcel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargandoComboHojas) return;
            CargarHojaExcel(cboHojasExcel.SelectedIndex);
        }

        private void CargarHojaExcel(int indiceHoja)
        {
            if (string.IsNullOrEmpty(_rutaArchivoExcel) || indiceHoja < 0) return;

            try
            {
                using (Stream inputStream = File.OpenRead(_rutaArchivoExcel))
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);
                    if (indiceHoja >= workbook.Worksheets.Count) return;

                    IWorksheet worksheet = workbook.Worksheets[indiceHoja];
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
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar la hoja seleccionada: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ProcesarHeaders()
        {
            _columnasNoMapeadas.Clear();
            _celdasCarreraInvalidas.Clear();
            _columnaCarreraIndex = -1;
            _propiedades = typeof(AlumnosModelo).GetProperties().Select(p => p.Name).OrderBy(name => name).ToList();
            foreach (DataColumn column in dtExcel.Columns.Cast<DataColumn>().ToList())
            {
                bool matched = false;
                foreach (var prop in typeof(AlumnosModelo).GetProperties())
                {
                    if (BuscarCoincidencia(prop.Name, column.ColumnName))
                    {
                        RenombrarColumnaACanonical(column, prop.Name);
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
                    RenombrarColumnaACanonical(col, _carrerasColumnName);

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

            actualizarLabelCamposFaltantes();
            dgvCargaMasiva.Invalidate();
        }

        // Renombra la columna al nombre canónico de la propiedad (ej. "APELLIDO" -> "Apellido"),
        // salvo que ya exista otra columna con ese nombre exacto (evita colisiones).
        private void RenombrarColumnaACanonical(DataColumn column, string nombreCanonical)
        {
            if (column.ColumnName == nombreCanonical)
                return;

            bool existeExacta = dtExcel.Columns.Cast<DataColumn>()
                .Any(c => string.Equals(c.ColumnName, nombreCanonical, StringComparison.Ordinal));

            if (!existeExacta)
                column.ColumnName = nombreCanonical;
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

            menu.Items.Add(new ToolStripSeparator());
            var desvincularItem = new ToolStripMenuItem("Desvincular");
            desvincularItem.Click += (s, args) => DesvincularMapeo(colIndex);
            menu.Items.Add(desvincularItem);

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
                actualizarLabelCamposFaltantes();
                dgvCargaMasiva.InvalidateCell(colIndex, -1);
                return;
            }

            if (dtExcel.Columns.Contains(propiedadSeleccionada))
            {
                var columnaAnterior = dtExcel.Columns[propiedadSeleccionada];
                int indiceAnterior = columnaAnterior.Ordinal;
                columnaAnterior.ColumnName = CrearNombreColumnaSinMapear(nombreActual);
                _columnasNoMapeadas.Add(indiceAnterior);
            }

            if (dtExcel.Columns.Contains(nombreActual))
                dtExcel.Columns[nombreActual].ColumnName = propiedadSeleccionada;

            dgvCol.HeaderText = propiedadSeleccionada;
            _columnasNoMapeadas.Remove(colIndex);
            actualizarLabelCamposFaltantes();
            dgvCargaMasiva.InvalidateCell(colIndex, -1);
        }

        private void DesvincularMapeo(int colIndex)
        {
            var dgvCol = dgvCargaMasiva.Columns[colIndex];
            if (dgvCol == null) return;

            string nombreActual = dgvCol.HeaderText;
            string nombreNuevo = CrearNombreColumnaSinMapear(nombreActual);

            if (dtExcel.Columns.Contains(nombreActual))
                dtExcel.Columns[nombreActual].ColumnName = nombreNuevo;

            dgvCol.HeaderText = nombreNuevo;
            _columnasNoMapeadas.Add(colIndex);

            if (nombreActual == _carrerasColumnName)
            {
                _columnaCarreraIndex = -1;
                _celdasCarreraInvalidas.Clear();
            }

            actualizarLabelCamposFaltantes();
            dgvCargaMasiva.Invalidate();
        }

        private string CrearNombreColumnaSinMapear(string nombreBase)
        {
            if (string.IsNullOrWhiteSpace(nombreBase))
                nombreBase = "Columna";

            string nombre = nombreBase;
            int contador = 1;
            while (dtExcel.Columns.Contains(nombre))
            {
                nombre = $"{nombreBase} ({contador})";
                contador++;
            }

            return nombre;
        }

        private static readonly HashSet<string> _camposAutoCompletados = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase)
        {
            "TipoDocumento"
        };

        private List<string> ObtenerCamposFaltantes()
        {
            if (dtExcel == null)
                return new List<string>();

            var columnasMapeadas = new HashSet<string>(
                dtExcel.Columns.Cast<DataColumn>().Select(c => c.ColumnName),
                System.StringComparer.OrdinalIgnoreCase);
            var condicionProp = typeof(Obligatorio).GetProperty("Condicion", BindingFlags.NonPublic | BindingFlags.Instance);

            return typeof(AlumnosModelo)
                .GetProperties()
                .Where(p => p.GetCustomAttributes<Obligatorio>(false)
                    .Any(attr => string.IsNullOrEmpty(condicionProp?.GetValue(attr)?.ToString())))
                .Select(p => p.Name)
                .Where(nombre => !columnasMapeadas.Contains(nombre) && !_camposAutoCompletados.Contains(nombre))
                .ToList();
        }

        private void btnCrearCamposFaltantes_Click(object sender, EventArgs e)
        {
            if (dtExcel == null) return;

            var camposFaltantes = ObtenerCamposFaltantes();
            foreach (string campo in camposFaltantes)
            {
                var columna = new DataColumn(campo, typeof(string))
                {
                    DefaultValue = "No declarado"
                };
                dtExcel.Columns.Add(columna);

                foreach (DataRow fila in dtExcel.Rows)
                    fila[campo] = "No declarado";
            }

            foreach (DataGridViewColumn columna in dgvCargaMasiva.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;

            ProcesarHeaders();

            if (camposFaltantes.Count > 0)
            {
                FormNotificacion.Mensaje(TipoNotificacion.Information,
                    $"Se agregaron {camposFaltantes.Count} campo{(camposFaltantes.Count == 1 ? "" : "s")} faltante{(camposFaltantes.Count == 1 ? "" : "s")}. Puede editarlos en la grilla.");
            }
        }

        private void actualizarLabelCamposFaltantes()
        {
            var camposFaltantes = ObtenerCamposFaltantes();
            btnCrearCamposFaltantes.Visible = camposFaltantes.Any();

            if (camposFaltantes.Any())
            {
                lblCamposFaltantes.Text = "Campos obligatorios que faltan mapear: " + string.Join(", ", camposFaltantes);
                lblCamposFaltantes.Visible = true;
            }
            else
            {
                lblCamposFaltantes.Visible = false;
            }
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
            if (e.RowIndex < 0 || e.ColumnIndex != _columnaCarreraIndex) return;
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

            menu.Items.Add(new ToolStripSeparator());
            var desvincularItem = new ToolStripMenuItem("Desvincular");
            desvincularItem.Click += (s, args) => DesvincularCarrera(rowIndex);
            menu.Items.Add(desvincularItem);

            Rectangle rect = dgvCargaMasiva.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(dgvCargaMasiva.PointToScreen(new Point(rect.Left, rect.Bottom)));
        }

        // Al seleccionar una carrera válida del menú, actualizar el valor de la celda y eliminarla del conjunto de celdas inválidas
        private void AplicarCarrera(int rowIndex, string nombreCarrera)
        {
            string valorOriginal = dtExcel.Rows[rowIndex][_carrerasColumnName]?.ToString()?.Trim() ?? "";

            for (int row = 0; row < dtExcel.Rows.Count; row++)
            {
                string valorActual = dtExcel.Rows[row][_carrerasColumnName]?.ToString()?.Trim() ?? "";
                if (!string.Equals(valorActual, valorOriginal, StringComparison.OrdinalIgnoreCase))
                    continue;

                dtExcel.Rows[row][_carrerasColumnName] = nombreCarrera;
                _celdasCarreraInvalidas.Remove($"{row},{_columnaCarreraIndex}");
                dgvCargaMasiva.InvalidateCell(_columnaCarreraIndex, row);
            }
        }

        private void DesvincularCarrera(int rowIndex)
        {
            string valorOriginal = dtExcel.Rows[rowIndex][_carrerasColumnName]?.ToString()?.Trim() ?? "";

            for (int row = 0; row < dtExcel.Rows.Count; row++)
            {
                string valorActual = dtExcel.Rows[row][_carrerasColumnName]?.ToString()?.Trim() ?? "";
                if (!string.Equals(valorActual, valorOriginal, StringComparison.OrdinalIgnoreCase))
                    continue;

                dtExcel.Rows[row][_carrerasColumnName] = "";
                _celdasCarreraInvalidas.Remove($"{row},{_columnaCarreraIndex}");
                dgvCargaMasiva.InvalidateCell(_columnaCarreraIndex, row);
            }
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

            var camposFaltantes = ObtenerCamposFaltantes();

            if (camposFaltantes.Count > 0)
            {
                actualizarLabelCamposFaltantes();
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

            var errores = new List<string>();
            var filasValidas = new List<Tuple<DataRow, AlumnosModelo, int>>();

            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                DataRow dr = dtExcel.Rows[i];
                int numeroFila = i + 2;
                string dni = GetColumnaValor(dr, nameof(AlumnosModelo.NumeroDocumento));

                if (alumnosLogica.AlumnoExiste(dni))
                {
                    errores.Add($"Fila {numeroFila}: el documento '{dni}' ya existe.");
                    continue;
                }

                string carreraNombre = GetColumnaValor(dr, _carrerasColumnName);
                if (!carrerasPorNombre.TryGetValue(carreraNombre, out int carreraId))
                {
                    errores.Add($"Fila {numeroFila}: la carrera '{carreraNombre}' no existe.");
                    continue;
                }

                AlumnosModelo modelo = CrearModeloDesdeFila(dr, numeroFila, errores);
                ValidarModelo(modelo, numeroFila, errores);

                filasValidas.Add(Tuple.Create(dr, modelo, carreraId));
            }

            if (errores.Count > 0)
            {
                MessageBox.Show(
                    "No se puede realizar la carga masiva porque hay datos inválidos:\n\n" + string.Join("\n", errores.Take(20)) +
                    (errores.Count > 20 ? $"\n\nY {errores.Count - 20} error(es) más." : ""),
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int agregados = 0;
            int omitidos = 0;

            foreach (var fila in filasValidas)
            {
                AlumnosModelo modelo = fila.Item2;

                int nuevoAlumnoId = alumnosLogica.AgregarAlumnoCargaMasiva(modelo);
                if (nuevoAlumnoId <= 0)
                {
                    omitidos++;
                    continue;
                }

                alumnosLogica.AgregarAlumnoCarrera(new AlumnosCarrerasModelo
                {
                    AlumnoId = nuevoAlumnoId,
                    CarreraId = fila.Item3,
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

        private AlumnosModelo CrearModeloDesdeFila(DataRow dr, int numeroFila, List<string> errores)
        {
            var modelo = new AlumnosModelo { Activo = true };
            var titleCase = CultureInfo.CurrentCulture.TextInfo;

            foreach (var propiedad in typeof(AlumnosModelo).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!propiedad.CanWrite || !dtExcel.Columns.Contains(propiedad.Name))
                    continue;

                string valor = GetColumnaValor(dr, propiedad.Name);
                if (!TryConvertirValor(valor, propiedad.PropertyType, out object valorConvertido))
                {
                    errores.Add($"Fila {numeroFila}, {propiedad.Name}: el valor '{valor}' no tiene un formato válido.");
                    continue;
                }

                if (valorConvertido is string texto && !string.IsNullOrWhiteSpace(texto))
                {
                    if (propiedad.GetCustomAttributes<SoloNumeros>(false).Any())
                        valorConvertido = NormalizarSoloNumeros(texto);
                    else
                        valorConvertido = titleCase.ToTitleCase(texto.ToLower());
                }

                propiedad.SetValue(modelo, valorConvertido);
            }

            if (string.IsNullOrWhiteSpace(modelo.TipoDocumento))
                modelo.TipoDocumento = "Dni";

            CompletarLocalidades(modelo);
            modelo.Sexo = NormalizarSexo(GetColumnaValor(dr, nameof(AlumnosModelo.Sexo)));
            CompletarDefaultsCargaMasiva(modelo);
            return modelo;
        }

        private void CompletarLocalidades(AlumnosModelo modelo)
        {
            if ((!dtExcel.Columns.Contains(nameof(AlumnosModelo.LocalidadNacimiento))
                || string.IsNullOrWhiteSpace(modelo.LocalidadNacimiento)
                || modelo.LocalidadNacimiento.Length > 15)
                && !string.IsNullOrWhiteSpace(modelo.Localidad))
            {
                modelo.LocalidadNacimiento = modelo.Localidad;
            }

            if (string.IsNullOrWhiteSpace(modelo.Localidad) && !string.IsNullOrWhiteSpace(modelo.LocalidadNacimiento))
                modelo.Localidad = modelo.LocalidadNacimiento;
        }

        private string NormalizarSoloNumeros(string valor)
        {
            return Regex.Replace(valor, @"\D", "");
        }

        private void CompletarDefaultsCargaMasiva(AlumnosModelo modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo.FotoUrl))
                modelo.FotoUrl = "Sin foto";

            if (string.IsNullOrWhiteSpace(modelo.MayorTitulo))
                modelo.MayorTitulo = "Ninguno";

            if (string.IsNullOrWhiteSpace(modelo.Orientacion))
                modelo.Orientacion = "No especificado";
        }

        private bool TryConvertirValor(string valor, Type tipo, out object valorConvertido)
        {
            valorConvertido = null;

            if (tipo == typeof(string))
            {
                valorConvertido = valor;
                return true;
            }

            if (tipo == typeof(char))
            {
                valorConvertido = NormalizarSexo(valor);
                return true;
            }

            if (tipo == typeof(DateTime))
            {
                if (string.IsNullOrWhiteSpace(valor))
                {
                    valorConvertido = DateTime.MinValue;
                    return true;
                }

                DateTime fechaResultado;
                if (DateTime.TryParse(valor, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaResultado) ||
                    DateTime.TryParse(valor, CultureInfo.CurrentCulture, DateTimeStyles.None, out fechaResultado))
                {
                    valorConvertido = fechaResultado;
                    return true;
                }

                if (double.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out double serialExcel) &&
                    serialExcel > 59 && serialExcel < 2958466)
                {
                    valorConvertido = DateTime.FromOADate(serialExcel);
                    return true;
                }

                return false;
            }

            if (tipo == typeof(bool))
            {
                if (string.IsNullOrWhiteSpace(valor))
                {
                    valorConvertido = false;
                    return true;
                }

                valor = valor.Trim().ToLower();
                valorConvertido = valor == "si" || valor == "sí" || valor == "s" || valor == "true" || valor == "1";
                return true;
            }

            if (tipo == typeof(int))
            {
                if (string.IsNullOrWhiteSpace(valor))
                {
                    valorConvertido = 0;
                    return true;
                }

                if (int.TryParse(valor, out int entero))
                {
                    valorConvertido = entero;
                    return true;
                }

                return false;
            }

            if (tipo == typeof(decimal))
            {
                if (string.IsNullOrWhiteSpace(valor))
                {
                    valorConvertido = 0m;
                    return true;
                }

                if (decimal.TryParse(valor, out decimal decimalValue))
                {
                    valorConvertido = decimalValue;
                    return true;
                }

                return false;
            }

            valorConvertido = valor;
            return true;
        }

        private void ValidarModelo(AlumnosModelo modelo, int numeroFila, List<string> errores)
        {
            foreach (var propiedad in typeof(AlumnosModelo).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!dtExcel.Columns.Contains(propiedad.Name) && TieneObligatorioCondicional(propiedad))
                    continue;

                object value = propiedad.GetValue(modelo);

                foreach (var atributo in propiedad.GetCustomAttributes(true))
                {
                    if (!(atributo is Validacion validacion))
                        continue;

                    bool valido;
                    try
                    {
                        valido = validacion.Validar(value, modelo);
                    }
                    catch
                    {
                        valido = false;
                    }

                    if (!valido)
                    {
                        string mensaje = string.IsNullOrWhiteSpace(validacion.Mensaje) ? "valor inválido" : validacion.Mensaje;
                        errores.Add($"Fila {numeroFila}, {propiedad.Name}: {mensaje}.");
                        break;
                    }
                }
            }
        }

        private bool TieneObligatorioCondicional(PropertyInfo propiedad)
        {
            var condicionProp = typeof(Obligatorio).GetProperty("Condicion", BindingFlags.NonPublic | BindingFlags.Instance);
            return propiedad.GetCustomAttributes<Obligatorio>(false)
                .Any(attr => !string.IsNullOrEmpty(condicionProp?.GetValue(attr)?.ToString()));
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
