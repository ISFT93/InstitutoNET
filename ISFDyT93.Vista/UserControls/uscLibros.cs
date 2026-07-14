using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Forms.Personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISFDyT93.Datos.Core;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscLibros : UserControl
    {
        public uscLibros()
        {
            DoubleBuffered = true;
            InitializeComponent();

            MenuContextual();
        }
        LibroActasLogica libroActasLogica = new LibroActasLogica();
        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void uscLibros_Load(object sender, EventArgs e)
        {
            this.BackColor = ThemeColor.GetColor();
            CargarDGV(dgvLibros);
        }

        private void CargarDGV(DataGridView dgv)
        {
            DataTable dt = libroActasLogica.ObtenerLibros();

            dgv.DataSource = dt;
            dgv.Columns["TipoLibroId"].Visible = false;
            dgv.Columns["CarreraID"].Visible = false;
        }

        private void AbrirNuevoLibro(bool nuevaRelacion)
        {
            using (FormCargarNumLibro frm = new FormCargarNumLibro(nuevaRelacion))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarDGV(dgvLibros);
                    if (libroActasLogica.ActualizacionPosible() == true)
                        opcionActualizarLibro.Visible = true;
                    else
                        opcionActualizarLibro.Visible = false;

                    if (libroActasLogica.RelacionNuevaPosible() == true)
                        opcionAgregarNuevoLibro.Visible = true;
                    else
                        opcionAgregarNuevoLibro.Visible = false;
                }
            }
        }
        
        private void MenuContextual()
        {
            dgvLibros.ContextMenuStrip = menu;

            if (libroActasLogica.ActualizacionPosible() == true)
                opcionActualizarLibro.Visible = true;
            else
                opcionActualizarLibro.Visible = false;

            if (libroActasLogica.RelacionNuevaPosible() == true)
                opcionAgregarNuevoLibro.Visible = true;
            else
                opcionAgregarNuevoLibro.Visible = false;

            opcionActualizarLibro.Click += (s, e) => { AbrirNuevoLibro(false); };
            opcionAgregarNuevoLibro.Click += (s, e) => { AbrirNuevoLibro(true); };
        }

        private void picMover_Click(object sender, EventArgs e)
        {
            FormNotificacion.Mensaje(TipoNotificacion.Message, "Libros de actas\nPermite gestionar los libros de actas y sus carreras");
        }
    }
}
