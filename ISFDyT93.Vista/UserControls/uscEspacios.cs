using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ISFDyT93.Vista.Forms.Parametros;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscEspacios : UserControl
    {
        public uscEspacios()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            CrearMenuContextual();
            AsignarMenuAControles(this);
            OpcionDeshabilitar();
            OpcionHabilitar();
        }

        EspaciosLogica espaciosLogica = new EspaciosLogica();

        uscPersonalGrid usc;

        public IList<EspaciosModelo> espacios;

        private void uscEspacios_Load(object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);
            this.BackColor = ThemeColor.GetColor();
            CargarGrilla();
        }

        #region MenuContextual

        private void CrearMenuContextual()
        {
            agregarEspacio.Click += (s, e) =>
            {
                using (FormAgregarEspacios frmAgregarEspacios = new FormAgregarEspacios())
                {
                    frmAgregarEspacios.StartPosition = FormStartPosition.CenterParent;

                    if (frmAgregarEspacios.ShowDialog() == DialogResult.OK)
                    {
                        RecargarTabla();
                    }
                }
            };

            deshabilitarEspacio.Click += (s, e) =>
            {
                using (FormEspaciosEstado frmEspaciosEstado = new FormEspaciosEstado(false))
                {
                    frmEspaciosEstado.StartPosition = FormStartPosition.CenterParent;

                    if (frmEspaciosEstado.ShowDialog() == DialogResult.OK)
                        RecargarTabla();
                }
            };

            habilitarEspacio.Click += (s, e) =>
            {
                using (FormEspaciosEstado frmEspaciosEstado = new FormEspaciosEstado(true))
                {
                    frmEspaciosEstado.StartPosition = FormStartPosition.CenterParent;

                    if (frmEspaciosEstado.ShowDialog() == DialogResult.OK)
                        RecargarTabla();
                }
            };
        }

        private void OpcionDeshabilitar()
        {
            if (espaciosLogica.EspaciosActivos() == true)
                MostrarOpcion(deshabilitarEspacio);
            else
                OcultarOpcion(deshabilitarEspacio);
        }

        private void OpcionHabilitar()
        {
            if (espaciosLogica.EspaciosInactivos() == true)
                MostrarOpcion(habilitarEspacio);
            else
                OcultarOpcion(habilitarEspacio);
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

            usc = new uscPersonalGrid(new string[] { "Descripcion","SumaHoras","CalculaPorcentaje", "Activo" });
            pnlContenedor.Controls.Add(usc);

            espacios = espaciosLogica.ObtenerEspacios();
            
            

            foreach (EspaciosModelo espacio in espacios)
            {
                usc.AgregarCelda(espacio.Descripcion, espacio.EspacioId);
                usc.AgregarCelda(espacio.SumaHoras.ToString());
                usc.AgregarCelda(espacio.CalculaPorcentaje.ToString());
                usc.AgregarCelda(espacio.Activo);
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
            FormNotificacion.Mensaje(
                TipoNotificacion.Message,
                "Espacios Disponibles\nPermite gestionar todos los espacios disponibles"
            );
        }

        public void Guardar()
        {
            IList<EspaciosModelo> actualizarEspacios =
                new List<EspaciosModelo>();

            foreach (var row in usc.Rows)
            {
                actualizarEspacios.Add(new EspaciosModelo()
                {
                    EspacioId = row[0].Id,
                    Descripcion = row[0].Value,
                    Activo = Convert.ToBoolean(row[1].Value)
                });
            }

            if (espaciosLogica.ActualizarEspacios(actualizarEspacios) > 0)
                FormNotificacion.Mensaje(
                    TipoNotificacion.Success,
                    "Espacios actualizados"
                );
            else
                FormNotificacion.Mensaje(
                    TipoNotificacion.Error,
                    "Error al actualizar"
                );
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void pnlContenedor_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
