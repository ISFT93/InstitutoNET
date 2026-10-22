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
    public partial class uscHorarios : UserControl
    {
        public uscHorarios()
        {
            InitializeComponent();
        }

        private void chkHorarios_CheckedChanged(object sender, EventArgs e)
        {
            MostrarOcultar();
        }





        //METODOS

        private void MostrarOcultar()
        {
            if (chkHorarios.Checked)
            {
                Height = 616;
                panel1.Visible = true;
                CargarTabla();
            }
            else
            {
                Height = 60;
                panel1.Visible = false;
            }
        }

        private void uscHorarios_Load(object sender, EventArgs e)
        {
            Height = 60;
            panel1.Visible = false;
        }

        private void CargarTabla()
        {
            uscTiposHorarios horarios = new uscTiposHorarios();
            flpContenedor.Controls.Clear();
            flpContenedor.Controls.Add(horarios);
        }
    }
}
