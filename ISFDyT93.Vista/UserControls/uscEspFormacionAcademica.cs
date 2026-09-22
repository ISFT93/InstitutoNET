using System.Windows.Forms;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscEspaciosFormacion : UserControl
    {
        public uscEspaciosFormacion()
        {
            InitializeComponent();
        }

        private void uscEspaciosFormacion_Load(object sender, System.EventArgs e)
        {
            Height = 60;
            panel1.Visible = false;
        }

        private void CargarTabla()
        {
            uscCargarFormacion cargForm = new uscCargarFormacion();
            flpContenedor.Controls.Clear();
            flpContenedor.Controls.Add(cargForm);
        }

        private void MostrarOcultar()
        {
            if (chkEspaciosFormacion.Checked)
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

        private void chkEspaciosFormacion_CheckedChanged(object sender, System.EventArgs e)
        {
            MostrarOcultar();
        }
    }
}
