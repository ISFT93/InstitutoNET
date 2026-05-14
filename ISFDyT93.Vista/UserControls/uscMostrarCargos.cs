using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class uscMostrarCargos : UserControl
    {
        public uscMostrarCargos()
        {
            InitializeComponent();
        }
        private void uscMostrarTabla_Load(object sender, EventArgs e)
        {
            flpContenedor.Visible = false; //hace que el contenedor sea invisible
            this.Height = 60; //reduce la altura de entrada
        }
        private void chkCargos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarOcultar();
        }
        //hace aparecer o desaparecer el control de abajo si el check está activo o no
        private void MostrarOcultar() 
        {
            if (chkCargos.Checked == true)
            {
                this.Height = 616; //agranda la altura del usercontrol para cargar bien la tabla
                flpContenedor.Visible = true; //hace que el contenedor sea visible
                CargarTabla();
            }
            else
            {
                flpContenedor.Visible = false; //hace invisible el contenedor de abajo
                this.Height = 60;
            }
        }
        private void CargarTabla()
        {
            uscCargos cargos = new uscCargos();
            flpContenedor.Controls.Clear();
            flpContenedor.Controls.Add(cargos); //carga el user control de la tabla dentro del contenedor
        }
        public void GuardarCargos()
        {
            if (chkCargos.Checked)
            {
                foreach (var control in flpContenedor.Controls)
                {
                    if (control.GetType() == typeof(uscCargos)) //si el contenedor tiene adentro un usercontrol de tipo uscCargos
                        ((uscCargos)control).Guardar(); //entonces accede a su propio método de guardar
                }
            }
        }
        private void panelCabecera_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
