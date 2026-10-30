using System;
using ISFDyT93.Vista.Core;

namespace ISFDyT93.Vista.Forms.Alumnos
{
    public partial class FormVerAnalitico : FormBase
    {
        public int AlumnoId { get; set; }

        public FormVerAnalitico()
        {
            InitializeComponent();
        }

        private void FormVerAnalitico_Load(object sender, EventArgs e)
        {
            this.Contenedor.SetTitulo("Ver Analitico");
            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormAlumnos>();
            });
        }


    }
}
