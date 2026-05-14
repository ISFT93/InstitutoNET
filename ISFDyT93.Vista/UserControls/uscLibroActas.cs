using ISFDyT93.Datos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                CargarDGV(dgvLibros);
            }
            else
            {
                this.Height = 60;
                panel1.Visible = false;
            }
        }
        private void chkCargos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarOcultar();
        }

        private void uscLibroActas_Load(object sender, EventArgs e)
        {
            this.Height = 60;
        }

        private void CargarDGV(DataGridView dgv)
        {
            string query = "SELECT tl.Descripcion, la.LibroNumero, la.FolioNumero, la.FolioMaximo, la.FechaAlta, la.FechaBaja, la.Activo FROM TipoLibros tl INNER JOIN LibroActas la on tl.TipoLibroId = la.TipoLibroId";
            Conexion conexion = new Conexion();
            DataTable dt = conexion.ObtenerRegistros(query);

            dgv.DataSource = dt;
        }

        private void panelCabecera_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
