using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Carreras;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Forms.Parametros;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ISFDyT93.Vista.UserControls
{
    public abstract class uscModuloExamen : UserControl
    {
        protected readonly EsquemaEvaluacionLogica logica = new EsquemaEvaluacionLogica();
        private readonly CheckBox chkMostrar = new CheckBox();
        private readonly FlowLayoutPanel contenido = new FlowLayoutPanel();
        private readonly ContextMenuStrip menu = new ContextMenuStrip();
        private readonly ComponentResourceManager iconos = new ComponentResourceManager(typeof(uscCargos));
        private readonly Color colorTabla = ThemeColor.GetColor();
        private readonly string descripcion;
        private uscPersonalGrid grilla;
        private DataRow seleccionada;

        protected uscModuloExamen(string titulo, string descripcion)
        {
            this.descripcion = descripcion;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Width = 1283;
            Height = 60;

            var cabecera = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(51, 51, 76)
            };
            chkMostrar.Text = titulo;
            chkMostrar.AutoSize = true;
            chkMostrar.ForeColor = Color.White;
            chkMostrar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            chkMostrar.Location = new Point(13, 13);
            cabecera.Controls.Add(chkMostrar);

            menu.ImageScalingSize = new Size(24, 24);
            contenido.BackColor = Color.White;
            contenido.Dock = DockStyle.Fill;
            contenido.AutoScroll = true;
            contenido.Visible = false;
            contenido.ContextMenuStrip = menu;
            Controls.Add(contenido);
            Controls.Add(cabecera);

            chkMostrar.CheckedChanged += (s, e) =>
            {
                if (chkMostrar.Checked)
                {
                    try
                    {
                        Recargar();
                        Height = 616;
                        contenido.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        chkMostrar.Checked = false;
                        MostrarError(ex);
                    }
                }
                else
                {
                    contenido.Visible = false;
                    Height = 60;
                }
            };
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            var referencia = Parent == null ? null : Parent.Controls.OfType<uscMostrarCargos>().FirstOrDefault();
            if (referencia != null) Width = referencia.Width;
        }

        protected void AgregarAccion(string texto, string icono, Action accion, Type recurso = null)
        {
            var opcion = new ToolStripMenuItem(texto)
            {
                BackColor = Color.FromArgb(51, 51, 76),
                ForeColor = Color.White,
                Font = new Font("Tahoma", 12F),
                Image = (recurso == null ? iconos : new ComponentResourceManager(recurso)).GetObject(icono) as Image
            };
            opcion.Click += (s, e) => Ejecutar(accion);
            menu.Items.Add(opcion);
        }

        protected void CargarGrilla(DataTable datos, string[] cabeceras, Action<uscPersonalGrid, DataRow> agregarFila)
        {
            int anchoAnterior = uscPersonalGrid.AnchoCelda;
            uscPersonalGrid nueva;
            try
            {
                uscPersonalGrid.AnchoCelda = 170;
                nueva = new uscPersonalGrid(cabeceras);
                foreach (DataRow fila in datos.Rows)
                {
                    int inicio = nueva.Cells.Count;
                    agregarFila(nueva, fila);
                    foreach (var celda in nueva.Cells.Skip(inicio))
                        VincularFila(celda, fila);
                }
            }
            finally
            {
                uscPersonalGrid.AnchoCelda = anchoAnterior;
            }

            seleccionada = null;
            grilla = nueva;
            var marco = new Panel
            {
                BackColor = colorTabla,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(nueva.Width + 48, nueva.Height + 44),
                Padding = new Padding(22, 30, 22, 10),
                Margin = Padding.Empty
            };
            var titulo = new Label
            {
                Text = chkMostrar.Text,
                Font = new Font("Tahoma", 12F),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(22, 0),
                Size = new Size(nueva.Width, 30)
            };
            var referencia = new PictureBox
            {
                Cursor = Cursors.Help,
                Image = iconos.GetObject("picMover.Image") as Image,
                Location = new Point(2, 2),
                Size = new Size(18, 25),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            referencia.Click += (s, e) => FormNotificacion.Mensaje(TipoNotificacion.Message,
                chkMostrar.Text + "\n" + descripcion);
            nueva.Location = new Point(22, 30);
            marco.Controls.Add(nueva);
            marco.Controls.Add(titulo);
            marco.Controls.Add(referencia);
            AsignarMenu(marco);
            var anterior = contenido.Controls.Count == 0 ? null : contenido.Controls[0];
            contenido.Controls.Clear();
            if (anterior != null) anterior.Dispose();
            contenido.Controls.Add(marco);
            if (grilla.Cells.Count > 0) contenido.AutoScrollPosition = Point.Empty;
        }

        private void AsignarMenu(Control control)
        {
            control.ContextMenuStrip = menu;
            foreach (Control hijo in control.Controls) AsignarMenu(hijo);
        }

        private void VincularFila(Control control, DataRow fila)
        {
            control.ContextMenuStrip = menu;
            control.MouseDown += (s, e) =>
            {
                seleccionada = fila;
                if (e.Button == MouseButtons.Right && grilla != null)
                    foreach (var celda in grilla.Cells)
                        celda.BorderStyle = celda.Tag == fila ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            };
            if (control is uscPersonalGrid.Cell) control.Tag = fila;
            foreach (Control hijo in control.Controls) VincularFila(hijo, fila);
        }

        protected DataRow Seleccion()
        {
            if (seleccionada == null)
                throw new InvalidOperationException("Hacé clic derecho sobre el componente que querés modificar.");
            return seleccionada;
        }

        protected static string Valor(DataRow fila, string campo)
        {
            return fila.IsNull(campo) ? "" : Convert.ToString(fila[campo]);
        }

        protected static void MostrarError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Esquemas de examen", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        protected static void Ejecutar(Action accion)
        {
            try { accion(); }
            catch (Exception ex) { MostrarError(ex); }
        }

        protected abstract void Recargar();
    }

    public class uscMostrarTiposExamen : uscModuloExamen
    {
        public uscMostrarTiposExamen() : base("Tipos de examen",
            "Permite configurar los tipos utilizados por los esquemas de examen")
        {
            AgregarAccion("Agregar tipo", "agregarCargos.Image", AgregarTipo);
            AgregarAccion("Editar tipo", "tsmModificarMateria.Image", EditarTipo, typeof(FormMateriasAnioCarrera));
        }

        protected override void Recargar()
        {
            CargarGrilla(logica.ObtenerTipos(),
                new[] { "Descripción", "Planilla", "Tipo de dato", "Requerido", "Activo" },
                (tabla, fila) =>
                {
                    tabla.AgregarCelda(Valor(fila, "Descripcion"));
                    tabla.AgregarCelda(Valor(fila, "DescripcionPlanilla"));
                    tabla.AgregarCelda(Valor(fila, "TipoDato"));
                    tabla.AgregarCelda(Convert.ToBoolean(fila["Requerido"]));
                    tabla.AgregarCelda(Convert.ToBoolean(fila["Activo"]));
                });
        }

        private void AgregarTipo()
        {
            using (var formulario = new FormTipoExamen(logica))
                if (formulario.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

        private void EditarTipo()
        {
            var fila = Seleccion();
            var modelo = new TipoExamenModelo
            {
                TipoExamenId = Convert.ToInt32(fila["TipoExamenId"]),
                Descripcion = Valor(fila, "Descripcion"),
                DescripcionPlanilla = Valor(fila, "DescripcionPlanilla"),
                TipoDato = Valor(fila, "TipoDato"),
                Requerido = Convert.ToBoolean(fila["Requerido"]),
                Activo = Convert.ToBoolean(fila["Activo"])
            };
            using (var formulario = new FormTipoExamen(logica, modelo))
                if (formulario.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }
    }

    public class uscMostrarEsquemaEvaluacion : uscModuloExamen
    {
        private DataTable esquemas;

        public uscMostrarEsquemaEvaluacion() : base("Esquemas Disponibles",
            "Permite configurar los componentes y el estado de los esquemas de examen")
        {
            AgregarAccion("Nuevo esquema", "agregarCargos.Image", NuevoEsquema);
            AgregarAccion("Agregar componente", "agregarCargos.Image", AgregarComponente);
            AgregarAccion("Editar componente", "tsmModificarMateria.Image", EditarComponente, typeof(FormMateriasAnioCarrera));
            AgregarAccion("Habilitar", "habilitarCargo.Image", () => CambiarEstado(true));
            AgregarAccion("Deshabilitar", "deshabilitarCargo.Image", () => CambiarEstado(false));
        }

        protected override void Recargar()
        {
            esquemas = logica.ObtenerEsquemas();
            CargarGrilla(esquemas,
                new[] { "Índice", "Esquema", "Descripción", "Descripción planilla", "Tipo de dato", "Requerido", "Activo" },
                (tabla, fila) =>
                {
                    tabla.AgregarCelda(Valor(fila, "Indice"));
                    tabla.AgregarCelda(Valor(fila, "Esquema"));
                    tabla.AgregarCelda(Valor(fila, "Descripcion"));
                    tabla.AgregarCelda(Valor(fila, "DescripcionPlanilla"));
                    tabla.AgregarCelda(Valor(fila, "TipoDato"));
                    tabla.AgregarCelda(!fila.IsNull("Requerido") && Convert.ToBoolean(fila["Requerido"]));
                    tabla.AgregarCelda(Convert.ToBoolean(fila["Activo"]));
                });
        }

        private void NuevoEsquema()
        {
            Recargar();
            if (esquemas.Rows.Cast<DataRow>().Any(r => Convert.ToBoolean(r["Activo"])))
                throw new InvalidOperationException(
                    "Primero deshabilitá el esquema activo. Después podrás crear uno nuevo.");

            var tipos = logica.ObtenerTipos();
            if (!tipos.Rows.Cast<DataRow>().Any(t => Convert.ToBoolean(t["Activo"])))
                throw new InvalidOperationException("Primero agregá un tipo de examen activo.");

            int siguiente = 1;
            var nombres = esquemas.Rows.Cast<DataRow>().Select(r => Convert.ToString(r["Esquema"])).ToList();
            while (nombres.Any(n => string.Equals(n, "Esqu" + siguiente, StringComparison.OrdinalIgnoreCase)))
                siguiente++;

            using (var formulario = new FormComponenteEsquema(logica, tipos,
                "Esqu" + siguiente, 1, true, true))
                if (formulario.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

        private void AgregarComponente()
        {
            var fila = Seleccion();
            string nombre = Convert.ToString(fila["Esquema"]);
            int siguiente = esquemas.Rows.Cast<DataRow>()
                .Where(r => string.Equals(Convert.ToString(r["Esquema"]), nombre,
                    StringComparison.OrdinalIgnoreCase))
                .Max(r => Convert.ToInt32(r["Indice"])) + 1;
            using (var formulario = new FormComponenteEsquema(logica, logica.ObtenerTipos(),
                nombre, siguiente, Convert.ToBoolean(fila["Activo"]), false))
                if (formulario.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

        private void EditarComponente()
        {
            var fila = Seleccion();
            using (var formulario = new FormComponenteEsquema(logica, logica.ObtenerTipos(),
                Convert.ToString(fila["Esquema"]), Convert.ToInt32(fila["Indice"]),
                Convert.ToBoolean(fila["Activo"]), false,
                Convert.ToInt32(fila["CodEsq"]),
                fila.IsNull("TipoExamenId") ? 0 : Convert.ToInt32(fila["TipoExamenId"])))
                if (formulario.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

        private void CambiarEstado(bool habilitar)
        {
            Recargar();
            using (var formulario = new FormEstadoEsquema(logica, esquemas, habilitar))
                if (formulario.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }
    }
}
