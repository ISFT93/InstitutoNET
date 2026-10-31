using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Alumnos
{
    public partial class FormVerAnalitico : FormBase
    {
        private readonly AlumnosLogica alumnosLogica = new AlumnosLogica();

        public int AlumnoId { get; set; }
        public int AlumnoCarreraId { get; set; }

        public FormVerAnalitico()
        {
            InitializeComponent();
            ConfigurarGrilla();

            typeof(DataGridView)
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(dgvAnaliticoDetalle, true, null);
        }

        private void FormVerAnalitico_Load(object sender, EventArgs e)
        {
            this.Contenedor.SetTitulo("Ver Analitico");
            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormAlumnos>();
            });

            CargarDatosAlumno();
            CargarAnalitico();
        }

        private void CargarDatosAlumno()
        {
            if (this.AlumnoId <= 0)
                return;

            DataRow datos = alumnosLogica.ObtenerDatosAnaliticoAlumno(this.AlumnoId);

            if (datos == null)
                return;

            string apellido = datos["Apellido"] == DBNull.Value ? "" : datos["Apellido"].ToString();
            string nombre = datos["Nombre"] == DBNull.Value ? "" : datos["Nombre"].ToString();
            string nomYApe = $"{apellido}, {nombre}".Trim(' ', ',');

            txtNomYApe.Text = string.IsNullOrWhiteSpace(nomYApe) ? "-" : nomYApe;

            txtDNI.Text = datos["NumeroDocumento"] == DBNull.Value
                ? "-"
                : datos["NumeroDocumento"].ToString();

            txtLocalidad.Text = datos["LocalidadNacimiento"] == DBNull.Value
                ? "-"
                : datos["LocalidadNacimiento"].ToString();

            if (datos["FechaNacimiento"] != DBNull.Value)
            {
                DateTime fechaNacimiento = Convert.ToDateTime(datos["FechaNacimiento"]);

                lblDia.Text = $"el día: {fechaNacimiento.Day}";
                lblMes.Text = $"de: {fechaNacimiento.ToString("MMMM", new CultureInfo("es-AR"))}";
                lblAnio.Text = $"de: {fechaNacimiento.Year}";
            }
            else
            {
                lblDia.Text = "el día: -";
                lblMes.Text = "de: -";
                lblAnio.Text = "de: -";
            }

            lblAnioIngreso.Text = datos["AnioIngreso"] == DBNull.Value
                ? "Año de Ingreso: -"
                : $"Año de Ingreso: {datos["AnioIngreso"]}";

            lblNroLibro.Text = datos["LibroNumero"] == DBNull.Value
                ? "Libro Nro: -"
                : $"Libro Nro: {datos["LibroNumero"]}";

            lblNroFolio.Text = datos["NroFolio"] == DBNull.Value
                ? "Folio Nro: -"
                : $"Folio Nro: {datos["NroFolio"].ToString().Trim()}";
        }

        private void CargarAnalitico()
        {
            int alumnoCarreraId = this.AlumnoCarreraId;

            if (alumnoCarreraId <= 0 && this.AlumnoId > 0)
            {
                var alumnoCarrera = alumnosLogica.TraerAlumnoCarrera(this.AlumnoId);

                if (alumnoCarrera != null)
                    alumnoCarreraId = alumnoCarrera.AlumnoCarreraId;
            }

            if (alumnoCarreraId <= 0)
                return;

            CargarGrilla(alumnosLogica.ObtenerAnaliticoAlumno(alumnoCarreraId));
        }

        private void ConfigurarGrilla()
        {
            dgvAnaliticoDetalle.AllowUserToAddRows = false;
            dgvAnaliticoDetalle.AllowUserToDeleteRows = false;
            dgvAnaliticoDetalle.AllowUserToResizeRows = false;
            dgvAnaliticoDetalle.ReadOnly = false;
            dgvAnaliticoDetalle.RowHeadersVisible = false;
            dgvAnaliticoDetalle.BackgroundColor = Color.White;
            dgvAnaliticoDetalle.EnableHeadersVisualStyles = false;
            dgvAnaliticoDetalle.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAnaliticoDetalle.ColumnHeadersHeight = 48;
            dgvAnaliticoDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnaliticoDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnaliticoDetalle.MultiSelect = false;
            dgvAnaliticoDetalle.RowTemplate.Height = 28;
            dgvAnaliticoDetalle.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvAnaliticoDetalle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAnaliticoDetalle.GridColor = Color.Black;
            dgvAnaliticoDetalle.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvAnaliticoDetalle.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvAnaliticoDetalle.Columns.Clear();

            AgregarColumna("Orden", "Nº de Orden", 50, DataGridViewContentAlignment.MiddleCenter);
            AgregarColumna("Materia", "MATERIA", 300, DataGridViewContentAlignment.MiddleLeft);
            AgregarColumna("AnioCursada", "Año de Cursada", 70, DataGridViewContentAlignment.MiddleCenter);
            AgregarColumna("Nota", "Nº", 40, DataGridViewContentAlignment.MiddleCenter);
            AgregarColumna("NotaLetras", "LETRAS", 90, DataGridViewContentAlignment.MiddleCenter);
            AgregarColumna("Condicion", "Condición y Establecimiento", 220, DataGridViewContentAlignment.MiddleCenter);
            AgregarColumna("Libro", "Libro", 50, DataGridViewContentAlignment.MiddleCenter);
            AgregarColumna("Folio", "Folio", 50, DataGridViewContentAlignment.MiddleCenter);
            AgregarColumna("Fecha", "Fecha", 80, DataGridViewContentAlignment.MiddleCenter);

            dgvAnaliticoDetalle.Columns["Nota"].DefaultCellStyle.Format = "0.##";
            dgvAnaliticoDetalle.Columns["Folio"].DefaultCellStyle.Format = "000";
            dgvAnaliticoDetalle.Columns["Fecha"].DefaultCellStyle.Format = "dd.MM.yy";

            foreach (DataGridViewColumn columna in dgvAnaliticoDetalle.Columns)
                columna.ReadOnly = true;

            dgvAnaliticoDetalle.Columns["Nota"].ReadOnly = false;
            dgvAnaliticoDetalle.Columns["NotaLetras"].ReadOnly = false;
            dgvAnaliticoDetalle.Columns["Condicion"].ReadOnly = false;

            dgvAnaliticoDetalle.CellPainting += dgvAnaliticoDetalle_CellPainting;
            dgvAnaliticoDetalle.CellEndEdit += dgvAnaliticoDetalle_CellEndEdit;
        }

        private void AgregarColumna(string name, string header, float peso, DataGridViewContentAlignment align)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = peso,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            col.DefaultCellStyle.Alignment = align;
            dgvAnaliticoDetalle.Columns.Add(col);
        }

        private void CargarGrilla(IEnumerable<AnaliticoItem> items)
        {
            dgvAnaliticoDetalle.Rows.Clear();

            foreach (var grupo in items.GroupBy(i => i.AnioCarrera))
            {
                int idx = dgvAnaliticoDetalle.Rows.Add();
                dgvAnaliticoDetalle.Rows[idx].Tag = grupo.Key;
                dgvAnaliticoDetalle.Rows[idx].Height = 26;
                dgvAnaliticoDetalle.Rows[idx].ReadOnly = true;

                foreach (var m in grupo.OrderBy(i => i.Orden))
                {
                    int rowIndex = dgvAnaliticoDetalle.Rows.Add(
                        m.Orden,
                        m.Materia,
                        m.AnioCursada,
                        m.Nota,
                        m.NotaLetras,
                        m.Condicion,
                        m.Libro,
                        m.Folio,
                        m.Fecha);

                    DataGridViewRow fila = dgvAnaliticoDetalle.Rows[rowIndex];
                    fila.Tag = m;

                    if (m.CursadaAlumnoCarreraId <= 0)
                    {
                        string mensaje = "La materia todavía no tiene cursada. " +
                                         "Los datos se completarán automáticamente.";

                        foreach (string columna in new[] { "Nota", "NotaLetras", "Condicion" })
                        {
                            fila.Cells[columna].ReadOnly = true;
                            fila.Cells[columna].Style.BackColor = Color.WhiteSmoke;
                            fila.Cells[columna].ToolTipText = mensaje;
                        }
                    }
                }
            }

            dgvAnaliticoDetalle.ClearSelection();
        }

        private void dgvAnaliticoDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columna = dgvAnaliticoDetalle.Columns[e.ColumnIndex].Name;

            if (columna != "Nota" && columna != "NotaLetras" && columna != "Condicion")
                return;

            DataGridViewRow fila = dgvAnaliticoDetalle.Rows[e.RowIndex];
            var item = fila.Tag as AnaliticoItem;

            if (item == null)
                return;

            if (item.CursadaAlumnoCarreraId <= 0)
            {
                Notificar(TipoNotificacion.Warning,
                    "La materia todavía no tiene cursada; no se pueden guardar datos.");
                RestaurarValorCelda(fila, item, columna, e.ColumnIndex);
                return;
            }

            decimal? nota = item.Nota;

            if (columna == "Nota")
            {
                object valor = fila.Cells[e.ColumnIndex].Value;

                if (valor == null || string.IsNullOrWhiteSpace(valor.ToString()))
                {
                    nota = null;
                }
                else
                {
                    string textoNota = valor.ToString().Trim().Replace(",", ".");

                    if (!decimal.TryParse(textoNota, NumberStyles.AllowDecimalPoint,
                            CultureInfo.InvariantCulture, out decimal notaEditada))
                    {
                        Notificar(TipoNotificacion.Error, "La nota debe ser un número.");
                        RestaurarValorCelda(fila, item, columna, e.ColumnIndex);
                        return;
                    }

                    if (notaEditada < 0 || notaEditada > 10)
                    {
                        Notificar(TipoNotificacion.Error, "La nota debe estar entre 0 y 10.");
                        RestaurarValorCelda(fila, item, columna, e.ColumnIndex);
                        return;
                    }

                    nota = notaEditada;
                }
            }

            string notaLetras = item.NotaLetras;

            if (columna == "NotaLetras")
            {
                notaLetras = Convert.ToString(fila.Cells[e.ColumnIndex].Value)?.Trim();

                if (!string.IsNullOrWhiteSpace(notaLetras) && notaLetras.Length > 50)
                {
                    Notificar(TipoNotificacion.Error,
                        "La nota en letras no puede superar los 50 caracteres.");
                    RestaurarValorCelda(fila, item, columna, e.ColumnIndex);
                    return;
                }
            }

            string condicion = columna == "Condicion"
                ? Convert.ToString(fila.Cells[e.ColumnIndex].Value)?.Trim()
                : item.Condicion;

            if (columna == "Condicion" && !string.IsNullOrWhiteSpace(condicion) && condicion.Length > 100)
            {
                Notificar(TipoNotificacion.Error,
                    "La condición y establecimiento no puede superar los 100 caracteres.");
                RestaurarValorCelda(fila, item, columna, e.ColumnIndex);
                return;
            }

            var itemEditado = new AnaliticoItem
            {
                AnaliticoId = item.AnaliticoId,
                CursadaAlumnoCarreraId = item.CursadaAlumnoCarreraId,
                AlumnoCarreraId = item.AlumnoCarreraId,
                CodigoBloqueMateria = item.CodigoBloqueMateria,
                AnioCicloLectivo = item.AnioCicloLectivo,
                AnioCursada = item.AnioCursada,
                Orden = item.Orden,
                Nota = nota,
                NotaLetras = notaLetras,
                Condicion = condicion
            };

            int resultado;

            try
            {
                resultado = alumnosLogica.GuardarNotaEquivalencia(itemEditado);
            }
            catch (Exception ex)
            {
                Notificar(TipoNotificacion.Error,
                    "No se pudieron guardar los datos: " + ex.Message);
                RestaurarValorCelda(fila, item, columna, e.ColumnIndex);
                return;
            }

            if (resultado > 0)
            {
                item.AnaliticoId = resultado;
                item.Nota = nota;
                item.NotaLetras = notaLetras;
                item.Condicion = condicion;
                Notificar(TipoNotificacion.Success, "Datos guardados correctamente.");
            }
            else
            {
                Notificar(TipoNotificacion.Error, "No se pudieron guardar los datos.");
                RestaurarValorCelda(fila, item, columna, e.ColumnIndex);
            }
        }

        private void RestaurarValorCelda(DataGridViewRow fila, AnaliticoItem item,
            string columna, int columnIndex)
        {
            if (columna == "Nota")
                fila.Cells[columnIndex].Value = item.Nota;
            else if (columna == "NotaLetras")
                fila.Cells[columnIndex].Value = item.NotaLetras;
            else
                fila.Cells[columnIndex].Value = item.Condicion;
        }

        private void dgvAnaliticoDetalle_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Graphics g = e.Graphics;

            // Cabecera de dos niveles
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.Handled = true;

                Rectangle r = e.CellBounds;
                string nombre = dgvAnaliticoDetalle.Columns[e.ColumnIndex].Name;

                var flags = TextFormatFlags.HorizontalCenter
                          | TextFormatFlags.VerticalCenter
                          | TextFormatFlags.WordBreak;

                using (var pen = new Pen(Color.White))
                using (var fondo = new SolidBrush(Color.FromArgb(51, 51, 76)))
                using (var fuente = new Font("Tahoma", 9F, FontStyle.Bold))
                {
                    g.FillRectangle(fondo, r);

                    if (nombre == "Nota" || nombre == "NotaLetras")
                    {
                        Rectangle a = dgvAnaliticoDetalle.GetColumnDisplayRectangle(
                            dgvAnaliticoDetalle.Columns["Nota"].Index, false);
                        Rectangle b = dgvAnaliticoDetalle.GetColumnDisplayRectangle(
                            dgvAnaliticoDetalle.Columns["NotaLetras"].Index, false);
                        Rectangle union = Rectangle.Union(a, b);
                        int mitad = r.Height / 2;

                        var arriba = new Rectangle(union.X, r.Y, union.Width, mitad);
                        var abajo = new Rectangle(r.X, r.Y + mitad, r.Width, r.Height - mitad);

                        TextRenderer.DrawText(g, "CALIFICACIÓN FINAL", fuente, arriba,
                            Color.White, flags);
                        TextRenderer.DrawText(g, e.Value?.ToString(), fuente, abajo,
                            Color.White, flags);

                        g.DrawLine(pen, r.Left, r.Top, r.Right, r.Top);
                        g.DrawLine(pen, r.Left, r.Y + mitad, r.Right, r.Y + mitad);
                        g.DrawLine(pen, r.Left, r.Bottom - 1, r.Right, r.Bottom - 1);
                        g.DrawLine(pen, r.Left, r.Y + mitad, r.Left, r.Bottom - 1);
                        g.DrawLine(pen, r.Right - 1, r.Y + mitad, r.Right - 1, r.Bottom - 1);

                        if (nombre == "Nota")
                            g.DrawLine(pen, r.Left, r.Top, r.Left, r.Y + mitad);
                        else
                            g.DrawLine(pen, r.Right - 1, r.Top, r.Right - 1, r.Y + mitad);
                    }
                    else
                    {
                        TextRenderer.DrawText(g, e.Value?.ToString(), fuente, r,
                            Color.White, flags);
                        g.DrawRectangle(pen, r.X, r.Y, r.Width - 1, r.Height - 1);
                    }
                }

                return;
            }

            // Filas separadoras: PRIMER AÑO, SEGUNDO AÑO...
            if (e.RowIndex >= 0 && dgvAnaliticoDetalle.Rows[e.RowIndex].Tag is string textoAnio)
            {
                e.Handled = true;

                Rectangle fila = dgvAnaliticoDetalle.GetRowDisplayRectangle(e.RowIndex, false);

                using (var pen = new Pen(Color.Black))
                using (var fuente = new Font("Tahoma", 10F, FontStyle.Bold))
                {
                    g.FillRectangle(Brushes.White, e.CellBounds);
                    TextRenderer.DrawText(g, textoAnio, fuente, fila, Color.Black,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    g.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top,
                        e.CellBounds.Right, e.CellBounds.Top);
                    g.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                        e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
            }
        }
    }
}
