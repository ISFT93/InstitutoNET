
using System;
using System.Windows.Forms;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscMostrarEsquemaEvaluacion : UserControl
    {
        public uscMostrarEsquemaEvaluacion()
        {
            InitializeComponent();

            this.Load += uscMostrarEsquemaEvaluacion_Load;

            chkEsquemas.CheckedChanged +=
                chkEsquemas_CheckedChanged;
        }

        private void uscMostrarEsquemaEvaluacion_Load(
            object sender, EventArgs e)
        {
            flpContenedor.Visible = false;
            flpContenedor.AutoScroll = true;

            this.Height = 60;
        }

        private void chkEsquemas_CheckedChanged(
            object sender, EventArgs e)
        {
            MostrarOcultar();
        }

        private void MostrarOcultar()
        {
            if (chkEsquemas.Checked)
            {
                this.Height = 616;

                flpContenedor.Visible = true;

                CargarTabla();
            }
            else
            {
                flpContenedor.Visible = false;

                this.Height = 60;
            }
        }

        private void CargarTabla()
        {
            while (flpContenedor.Controls.Count > 0)
            {
                Control control = flpContenedor.Controls[0];

                flpContenedor.Controls.Remove(control);
                control.Dispose();
            }

            uscEsquemaEvaluacion esquemas =
                new uscEsquemaEvaluacion();

            flpContenedor.Controls.Add(esquemas);
        }

        public void GuardarEsquemas()
        {
            if (chkEsquemas.Checked)
            {
                foreach (Control control in
                    flpContenedor.Controls)
                {
                    if (control is uscEsquemaEvaluacion)
                    {
                        ((uscEsquemaEvaluacion)control).Guardar();
                    }
                }
            }
        }
        private void panelCabecera_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flpContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
