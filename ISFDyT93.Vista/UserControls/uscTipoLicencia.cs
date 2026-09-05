using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Forms.Parametros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscTipoLicencia : UserControl
    {
        private TipoLicenciaLogica licenciaLogica = new TipoLicenciaLogica();
        private uscPersonalGrid usc;

        public uscTipoLicencia()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            CrearMenuContextual();
            AsignarMenuAControles(this);
            OpcionDeshabilitar();
            OpcionHabilitar();
        }

        private void uscTipoLicencia_Load(object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);
            this.BackColor = ThemeColor.GetColor();
            CargarGrilla();
        }

        #region MenuContextual
        private void CrearMenuContextual()
        {
            agregarTipoLicencia.Click += (s, e) =>
            {
                using (FormAgregarTipoLicencia frmAgregar = new FormAgregarTipoLicencia(true))
                {
                    frmAgregar.StartPosition = FormStartPosition.CenterParent;
                    if (frmAgregar.ShowDialog() == DialogResult.OK)
                    {
                        RecargarTabla();
                    }
                }
            };

            deshabilitarTipoLicencia.Click += (s, e) =>
            {
                using (FormLicenciaEstado frmEstado = new FormLicenciaEstado(false))
                {
                    frmEstado.StartPosition = FormStartPosition.CenterParent;
                    if (frmEstado.ShowDialog() == DialogResult.OK)
                        RecargarTabla();
                }
            };

            habilitarTipoLicencia.Click += (s, e) =>
            {
                using (FormLicenciaEstado frmEstado = new FormLicenciaEstado(true))
                {
                    frmEstado.StartPosition = FormStartPosition.CenterParent;
                    if (frmEstado.ShowDialog() == DialogResult.OK)
                        RecargarTabla();
                }
            };
        }

        private void OpcionDeshabilitar()
        {
            if (licenciaLogica.LicenciasActivas())
                MostrarOpcion(deshabilitarTipoLicencia);
            else
                OcultarOpcion(deshabilitarTipoLicencia);
        }

        private void OpcionHabilitar()
        {
            if (licenciaLogica.LicenciasInactivas())
                MostrarOpcion(habilitarTipoLicencia);
            else
                OcultarOpcion(habilitarTipoLicencia);
        }

        private void OcultarOpcion(ToolStripMenuItem item)
        {
            item.Visible = false;
        }

        private void MostrarOpcion(ToolStripMenuItem item)
        {
            item.Visible = true;
        }

        private void RecargarTabla()
        {
            pnlContenedor.Controls.Clear();
            CargarGrilla();
            OpcionDeshabilitar();
            OpcionHabilitar();
        }

        private void AsignarMenuAControles(Control control)
        {
            control.ContextMenuStrip = menu;

            foreach (Control hijo in control.Controls)
            {
                AsignarMenuAControles(hijo);
            }
        }
        #endregion

        private void CargarGrilla()
        {
            uscPersonalGrid.AnchoCelda = 200;
            usc = new uscPersonalGrid(new string[] { "TipoLicenciaId", "Descripcion", "Dias", "FechaFinObligatoria", "Activo" });
            pnlContenedor.Controls.Add(usc);

            IList<TipoLicenciaModelo> licencias = licenciaLogica.ObtenerLicencias();

            foreach (TipoLicenciaModelo lic in licencias)
            {
                usc.AgregarCelda(lic.TipoLicenciaId);
                usc.AgregarCelda(lic.Descripcion);
                usc.AgregarCelda(lic.Dias.HasValue ? lic.Dias.ToString() : "");
                usc.AgregarCelda(lic.FechaFinObligatoria);
                usc.AgregarCelda(lic.Activo);
            }
            Dimensionar();
        }

        private void Dimensionar()
        {
            this.Width = usc.Width + 50;
            this.Height = usc.Height + 45;
            usc.Dock = DockStyle.Fill;
        }

        private void picMover_Click(object sender, EventArgs e)
        {
            FormNotificacion.Mensaje(TipoNotificacion.Message, "Licencias Disponibles\nPermite gestionar los tipos de licencias");
        }

        private void picAgregar_Click(object sender, EventArgs e)
        {
            usc.Dock = DockStyle.None;
            usc.AgregarCelda("");
            usc.AgregarCelda("");
            usc.AgregarCelda("");
            usc.AgregarCelda(false);
            usc.AgregarCelda(true);
            Dimensionar();
        }

        public void Guardar()
        {
            IList<TipoLicenciaModelo> actualizarLicencias = new List<TipoLicenciaModelo>();

            foreach (var row in usc.Rows)
            {
                if (row[0].Value == null || string.IsNullOrWhiteSpace(row[0].Value.ToString()))
                {
                    MessageBox.Show("Debe ingresar un Identificador de Licencia válido");
                    return;
                }

                int? diasVal = null;
                if (row[2].Value != null && !string.IsNullOrWhiteSpace(row[2].Value.ToString()))
                {
                    if (!int.TryParse(row[2].Value.ToString(), out int tempDias))
                    {
                        MessageBox.Show("La cantidad de días debe ser un número entero válido o estar vacía");
                        return;
                    }
                    diasVal = tempDias;
                }

                actualizarLicencias.Add(new TipoLicenciaModelo()
                {
                    TipoLicenciaId = row[0].Value.ToString(),
                    Descripcion = row[1].Value != null ? row[1].Value.ToString() : "",
                    Dias = diasVal,
                    FechaFinObligatoria = Convert.ToBoolean(row[3].Value),
                    Activo = Convert.ToBoolean(row[4].Value)
                });
            }

            if (licenciaLogica.ActualizarLicencias(actualizarLicencias) > 0)
                FormNotificacion.Mensaje(TipoNotificacion.Success, "Licencias actualizadas");
            else
                FormNotificacion.Mensaje(TipoNotificacion.Error, "Error al actualizar");
        }

        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void pnlContenedor_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e) { }
        private void lblTitulo_MouseDown(object sender, MouseEventArgs e) { }
        private void pnlContenedor_MouseDown(object sender, MouseEventArgs e) { }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}