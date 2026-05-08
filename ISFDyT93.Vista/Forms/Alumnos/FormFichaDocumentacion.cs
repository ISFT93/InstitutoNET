using System;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Alumnos
{
    public partial class FormFichaDocumentacion : FormBase
    {
        private int _alumnoId;
        private AlumnosLogica _logica = new AlumnosLogica();

        public FormFichaDocumentacion()
        {
            InitializeComponent();
        }

        public void SetAlumnoId(int id)
        {
            this._alumnoId = id;
            CargarDatos();
        }

        private void FormFichaDocumentacion_Load(object sender, EventArgs e)
        {
            if (this.Contenedor != null)
            {
                this.Contenedor.SetTitulo("Ficha de Documentación");
                // Definimos qué hace el botón físico del FormPrincipal cuando se presiona
                this.Contenedor.SetVolver(() => this.Contenedor.AbrirFormulario<ControlDocumentacion>());
            }
            textBox1.BringToFront();
        }

        private void CargarDatos()
        {
            try
            {
                var alumno = _logica.ObtenerAlumno(_alumnoId);
                if (alumno != null)
                {
                    textBox1.Text = $"{alumno.Apellido}, {alumno.Nombre} - DNI: {alumno.NumeroDocumento}";
                    textBox1.ReadOnly = true;
                    this.MapToForm(alumno);
                }

                var rel = _logica.TraerAlumnoCarrera(_alumnoId);
                if (rel != null && rel.Inicializado == 2)
                {
                    this.DeshabilitarControles();
                    this.Text = "FICHA VALIDADA - [SOLO LECTURA]";
                }
            }
            catch (Exception ex) { this.Notificar(TipoNotificacion.Success, "Error: " + ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lógica de guardado...
            this.Notificar(TipoNotificacion.Success, "Cambios guardados.");

            this.Contenedor?.AbrirFormulario<ControlDocumentacion>();
        }

        private void btnDocumentacionOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Validar definitivamente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _logica.ActualizarEstadoInicializado(_alumnoId, 2);
                this.Notificar(TipoNotificacion.Success, "Documentación validada.");

                // Regresamos a la grilla abriéndola de nuevo en el panel
                this.Contenedor?.AbrirFormulario<ControlDocumentacion>();
            }
        }
    }
}