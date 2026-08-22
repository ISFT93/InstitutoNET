using System.Windows.Forms;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscLicencias : UserControl
    {
        public uscLicencias()
        {
            InitializeComponent();
        }

        private void uscLicencias_Load(object sender, System.EventArgs e)
        {
            Height = 60;
            panel1.Visible = false;
        }

        private void CargarTabla()
        {
            uscTiposLicencias licencias = new uscTiposLicencias();
            flpContenedor.Controls.Clear();
            flpContenedor.Controls.Add(licencias);
        }

        private void MostrarOcultar()
        {
            if (chkLicencias.Checked)
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

        private void chkLicencias_CheckedChanged(object sender, System.EventArgs e)
        {
            MostrarOcultar();
        }
    }
}
