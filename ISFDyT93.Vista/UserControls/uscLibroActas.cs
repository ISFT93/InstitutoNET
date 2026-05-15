using ISFDyT93.Datos.Core;
using ISFDyT93.Entidades.Enums;
using ISFDyT93.Vista.Forms.Personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscLibroActas : UserControl
    {
        public uscLibroActas()
        {
            InitializeComponent();
        }
        private void MostrarOcultar()
        {
            if (chkLibros.Checked == true)
            {
                this.Height = 616;
                panel1.Visible = true;
                CargarTabla();
            }
            else
            {
                this.Height = 60;
                panel1.Visible = false;
            }
        }
        private void CargarTabla()
        {
            uscLibros libros = new uscLibros();
            flpContenedor.Controls.Clear();
            flpContenedor.Controls.Add(libros); //carga el user control de la tabla dentro del contenedor
        }
        private void chkCargos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarOcultar();
        }

        private void uscLibroActas_Load(object sender, EventArgs e)
        {
            this.Height = 60;
        }

        private void dgvLibros_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelCabecera_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
