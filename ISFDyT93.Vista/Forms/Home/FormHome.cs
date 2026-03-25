using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;

namespace ISFDyT93.Vista
{
    public partial class FormHome : FormBase
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.Contenedor.SetTitulo("Home");
            ActualizarInformacion();
        }

        private void ActualizarInformacion()
        {
            int anio = new CicloLectivosLogica().ObtenerCicloLectivoActual();
            lblInformacion.Text = "I.S.F.D. y T.Nº 93" +
                                  $"\n\nCiclo: {anio}";
        }
    }
}
