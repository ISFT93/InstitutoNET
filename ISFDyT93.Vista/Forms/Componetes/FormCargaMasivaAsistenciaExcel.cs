using ISFDyT93.Datos.Daos;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Carreras;
using ISFDyT93.Vista.Forms.Common;
using ISFDyT93.Vista.Forms.Componetes;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace ISFDyT93.Vista.Forms.Componentes
{
    // Formulario unificado para la carga masiva de asistencias y altas desde cualquier formato de Excel
    // Cecilia
    public partial class FormCargaMasivaAsistenciasExcel : FormBase
    {
        #region Componentes Visuales y Variables
        public int CursoMateriaId { get; set; }
        public int CursoId { get; set; }
        public int CicloLectivo { get; set; }
        public int CarreraId { get; set; }
        public int AnioCarreraId { get; set; }

        private DataTable dtExcel;
        private string _rutaArchivoExcel = "";
        private bool _cargandoComboHojas = false;
        #endregion

        #region Constructor e Inicialización
        public FormCargaMasivaAsistenciasExcel()
        {
            InitializeComponent();

            // Forzamos la conexión del evento del ComboBox aquí para garantizar que funcione siempre
            this.cboHojasExcel.SelectedIndexChanged += new System.EventHandler(this.cboHojasExcel_SelectedIndexChanged);
        }

        private void FormCargaMasivaAsistenciasExcel_Load(object sender, EventArgs e)
        {
            if (this.Contenedor != null)
            {
                this.Contenedor.SetTitulo("Asistencias / Carga Masiva");
            }
        }
        #endregion

        #region Eventos de Botones y Controles
        private void BtnSeleccionarExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivoExcel = new OpenFileDialog();
            archivoExcel.Filter = "Archivos Excel|*.xls;*.xlsx|Archivos .csv (*.csv)|*.csv";
            archivoExcel.Title = "Seleccionar listado de alumnos o asistencias";
            archivoExcel.InitialDirectory = "C://";

            if (archivoExcel.ShowDialog() != DialogResult.OK)
                return;

            _rutaArchivoExcel = archivoExcel.FileName;
            CargarNombresHojas();
        }

        private void btnAceptarCargaMasiva_Click(object sender, EventArgs e)
        {
            if (dtExcel == null || dtExcel.Rows.Count == 0)
            {
                FormNotificacion.Mensaje(TipoNotificacion.Warning, "Debe cargar un archivo Excel válido con datos antes de procesar.");
                return;
            }

            if (this.CursoMateriaId <= 0 && this.CursoId <= 0)
            {
                FormNotificacion.Mensaje(TipoNotificacion.Warning, "Por favor, seleccione un curso o una materia específica antes de continuar con la carga.");
                return;
            }

            CargaMasivaAlumnosCursada();
        }
        #endregion

        #region Métodos de Negocio y Lectura Flexible de Excel
        private void CargarNombresHojas()
        {
            _cargandoComboHojas = true;
            cboHojasExcel.Visible = false;
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
                    {
                        cboHojasExcel.SelectedIndex = 0;
                    }
                }

                _cargandoComboHojas = false;
                cboHojasExcel.Visible = cboHojasExcel.Items.Count > 0;

                if (cboHojasExcel.Items.Count > 0)
                {
                    CargarHojaExcel(0);
                }
            }
            catch (Exception ex)
            {
                _cargandoComboHojas = false;
                MessageBox.Show($"No se pudo abrir el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboHojasExcel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargandoComboHojas) return;

            if (cboHojasExcel.SelectedIndex >= 0)
            {
                CargarHojaExcel(cboHojasExcel.SelectedIndex);
            }
        }

        private void CargarHojaExcel(int indiceHoja)
        {
            if (string.IsNullOrEmpty(_rutaArchivoExcel) || indiceHoja < 0) return;

            try
            {
                DataTable dtRaw = null;

                using (Stream inputStream = File.OpenRead(_rutaArchivoExcel))
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);
                    if (indiceHoja >= workbook.Worksheets.Count) return;

                    IWorksheet worksheet = workbook.Worksheets[indiceHoja];
                    var usedRange = worksheet.UsedRange;
                    dtRaw = worksheet.ExportDataTable(usedRange, ExcelExportDataTableOptions.None);
                }

                if (dtRaw == null || dtRaw.Rows.Count == 0)
                {
                    dgvCargaMasiva.DataSource = null;
                    FormNotificacion.Mensaje(TipoNotificacion.Warning, "La hoja seleccionada no contiene datos.");
                    return;
                }

                // Eliminar filas completamente vacías
                var filasVacias = dtRaw.AsEnumerable()
                    .Where(r => r.ItemArray.All(v => v == null || string.IsNullOrWhiteSpace(v?.ToString())))
                    .ToList();
                foreach (var fila in filasVacias)
                    dtRaw.Rows.Remove(fila);

                // Buscar la fila de cabecera dinámicamente
                int filaCabecera = -1;

                for (int i = 0; i < Math.Min(dtRaw.Rows.Count, 15); i++)
                {
                    for (int j = 0; j < dtRaw.Columns.Count; j++)
                    {
                        string valor = dtRaw.Rows[i][j] == DBNull.Value
                            ? ""
                            : dtRaw.Rows[i][j].ToString().Trim().ToUpper();

                        bool esEncabezadoValido = (valor.Contains("DNI")
                            || valor.Contains("DOCUMENTO")
                            || valor.Contains("APELLIDO")
                            || valor.Contains("ALUMNO"))
                            && !valor.Contains("/");

                        if (esEncabezadoValido)
                        {
                            filaCabecera = i;
                            break;
                        }
                    }

                    if (filaCabecera != -1)
                        break;
                }

                if (filaCabecera == -1)
                {
                    dgvCargaMasiva.DataSource = null;
                    FormNotificacion.Mensaje(TipoNotificacion.Warning, "No se encontró la fila de encabezados en esta hoja.");
                    return;
                }

                string columnaNombreCompleto = "";
                string columnaApellido = "";
                string columnaNombre = "";
                string columnaDni = "";

                for (int j = 0; j < dtRaw.Columns.Count; j++)
                {
                    string nombreColumna = dtRaw.Rows[filaCabecera][j]?.ToString()?.Trim()?.ToUpper() ?? "";

                    if (nombreColumna == "APELLIDO" || nombreColumna == "APELLIDOS")
                        columnaApellido = j.ToString();

                    if (nombreColumna == "NOMBRE" || nombreColumna == "NOMBRES")
                        columnaNombre = j.ToString();

                    if ((nombreColumna.Contains("APELLIDO") && nombreColumna.Contains("NOMBRE")) || nombreColumna == "ALUMNO")
                        columnaNombreCompleto = j.ToString();

                    if ((nombreColumna.Contains("DNI") || nombreColumna.Contains("DOCUMENTO")) && !nombreColumna.Contains("/"))
                        columnaDni = j.ToString();
                }

                if (string.IsNullOrWhiteSpace(columnaDni))
                {
                    dgvCargaMasiva.DataSource = null;
                    FormNotificacion.Mensaje(TipoNotificacion.Warning, "No se encontró una columna válida de DNI en esta hoja.");
                    return;
                }

                // Crear DataTable limpio de dos columnas para asistencias
                dtExcel = new DataTable();
                dtExcel.Columns.Add("Apellido y Nombre", typeof(string));
                dtExcel.Columns.Add("DNI", typeof(string));

                for (int i = filaCabecera + 1; i < dtRaw.Rows.Count; i++)
                {
                    DataRow filaOriginal = dtRaw.Rows[i];
                    string dni = "";

                    if (!string.IsNullOrWhiteSpace(columnaDni))
                    {
                        dni = filaOriginal[Convert.ToInt32(columnaDni)]?.ToString()?.Trim() ?? "";
                    }

                    dni = new string(dni.Where(char.IsDigit).ToArray());

                    if (string.IsNullOrWhiteSpace(dni))
                        continue;

                    string nombreCompleto = "";

                    if (!string.IsNullOrWhiteSpace(columnaApellido) && !string.IsNullOrWhiteSpace(columnaNombre))
                    {
                        string apellido = filaOriginal[Convert.ToInt32(columnaApellido)]?.ToString()?.Trim() ?? "";
                        string nombre = filaOriginal[Convert.ToInt32(columnaNombre)]?.ToString()?.Trim() ?? "";
                        nombreCompleto = (apellido + " " + nombre).Trim();
                    }
                    else if (!string.IsNullOrWhiteSpace(columnaNombreCompleto))
                    {
                        nombreCompleto = filaOriginal[Convert.ToInt32(columnaNombreCompleto)]?.ToString()?.Trim() ?? "";
                    }

                    if (string.IsNullOrWhiteSpace(nombreCompleto))
                        nombreCompleto = "SIN NOMBRE";

                    DataRow nuevaFila = dtExcel.NewRow();
                    nuevaFila["Apellido y Nombre"] = nombreCompleto;
                    nuevaFila["DNI"] = dni;
                    dtExcel.Rows.Add(nuevaFila);
                }

                if (dtExcel == null || dtExcel.Rows.Count == 0)
                {
                    dgvCargaMasiva.DataSource = null;
                    FormNotificacion.Mensaje(TipoNotificacion.Warning, "No se encontraron registros válidos en esta hoja.");
                    return;
                }

                // Refrescar la grilla de forma segura
                dgvCargaMasiva.DataSource = null;
                dgvCargaMasiva.DataSource = dtExcel;
                dgvCargaMasiva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn col in dgvCargaMasiva.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar la hoja seleccionada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Método auxiliar rápido para comparar nombres de columnas
        private bool nombreColumnaIgual(string texto, string busqueda)
        {
            return texto.Equals(busqueda, StringComparison.OrdinalIgnoreCase);
        }

        private void CargaMasivaAlumnosCursada()
        {
            if (this.CicloLectivo <= 0 || this.CarreraId <= 0 || (this.CursoMateriaId <= 0 && this.CursoId <= 0))
            {
                MessageBox.Show($"Faltan datos de contexto:\nCiclo: {this.CicloLectivo}\nCarrera: {this.CarreraId}\nCurso: {this.CursoId}\nMateria: {this.CursoMateriaId}",
                    "Error de Parámetros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dniActual = "";

            try
            {
                int cargados = 0;
                int inexistentes = 0;
                int duplicados = 0;

                var dao = new CursadasDao();

                if (dtExcel == null || dtExcel.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos en la grilla para procesar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataRow fila in dtExcel.Rows)
                {
                    dniActual = fila["DNI"]?.ToString()?.Trim() ?? "";

                    if (string.IsNullOrWhiteSpace(dniActual) || !dniActual.All(char.IsDigit))
                        continue;

                    int resultado = 0;

                    if (this.CursoMateriaId > 0)
                    {
                        resultado = dao.CargarAlumnoEnMateriaEspecifica(
                            this.CicloLectivo,
                            this.CarreraId,
                            this.CursoMateriaId,
                            dniActual
                        );
                    }
                    else if (this.CursoId > 0)
                    {
                        resultado = dao.CargarAlumnoEnCursoMasivo(
                            this.CicloLectivo,
                            this.CarreraId,
                            this.CursoId,
                            dniActual
                        );
                    }
                    else
                    {
                        FormNotificacion.Mensaje(TipoNotificacion.Warning, "Debe seleccionar al menos un Curso o una Materia específica antes de realizar la carga.");
                        return;
                    }

                    switch (resultado)
                    {
                        case 1:
                            cargados++;
                            break;
                        case -1:
                            inexistentes++;
                            break;
                        case -2:
                            duplicados++;
                            break;
                    }
                }

                FormNotificacion.Mensaje(
                    TipoNotificacion.Success,
                    $"Carga finalizada. Cargados: {cargados} | Duplicados/Omitidos: {duplicados} | Inexistentes: {inexistentes}"
                );

                if (this.Contenedor != null)
                {
                    this.Contenedor.AbrirFormulario<FormControlAsistencias>();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error detallado: {ex.Message}\nIntentando procesar DNI: '{dniActual}'", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}