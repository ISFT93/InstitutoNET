using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
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
    public partial class uscLicenciasDisponibles : UserControl
    {
        public uscLicenciasDisponibles()
        {
            InitializeComponent();
        }

        private void uscMostrarTabla_Load(object sender, EventArgs e)
        {
            flpContenedor.Visible = false; // Hace que el contenedor sea invisible
            this.Height = 60; // Reduce la altura de entrada
        }

        private void chkLicencias_CheckedChanged(object sender, EventArgs e)
        {
            MostrarOcultar();
        }

        // Hace aparecer o desaparecer el control de abajo si el check está activo o no
        private void MostrarOcultar()
        {
            if (chkLicencias.Checked)
            {
                this.Height = 616; // Agranda la altura del usercontrol para cargar bien la tabla
                flpContenedor.Visible = true; // Hace que el contenedor sea visible
                CargarTabla();
            }
            else
            {
                flpContenedor.Visible = false; // Hace invisible el contenedor de abajo
                this.Height = 60;
            }
        }

        private void CargarTabla()
        {
            // Instancia el control de Tipo Licencia
            uscTipoLicencia licencias = new uscTipoLicencia();
            flpContenedor.Controls.Clear();
            flpContenedor.Controls.Add(licencias); // Carga el UserControl de TipoLicencia dentro del contenedor
        }

        public void GuardarLicencias()
        {
            if (chkLicencias.Checked)
            {
                foreach (var control in flpContenedor.Controls)
                {
                    if (control.GetType() == typeof(uscTipoLicencia)) // Si el contenedor tiene adentro un usercontrol de tipo uscTipoLicencia
                    {
                        ((uscTipoLicencia)control).Guardar(); // Accede a su propio método de guardar
                    }
                }
            }
        }

        private void panelCabecera_Paint(object sender, PaintEventArgs e) { }
        private void flpContenedor_Paint(object sender, PaintEventArgs e) { }
    }
}