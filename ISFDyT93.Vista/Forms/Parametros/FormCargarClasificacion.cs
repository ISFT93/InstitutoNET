using System;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Parametro
{
    public partial class FormCargarClasificacion : Form
    {
        private string tipoAccion; // "Familia" o "Variable"

        // Propiedades públicas para devolver los valores ingresados al UserControl principal
        public string DescripcionSeleccionada { get; private set; }
        public string DescripcionCortaSeleccionada { get; private set; }

        public FormCargarClasificacion(string accion)
        {
            InitializeComponent();
            tipoAccion = accion;
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Ocultamos el ComboBox ya que se escribe de forma manual
            if (cmbOpciones != null) cmbOpciones.Visible = false;

            // Configuramos los textos según lo que se vaya a cargar
            if (tipoAccion == "Familia")
            {
                //lblTipo.Text = "Escribir Nueva Familia";
                lblNombre.Text = "Nombre de la Familia";
            }
            else
            {
                //lblTipo.Text = "Escribir Nueva Variable";
                lblNombre.Text = "Escribir Nueva Variable";
            }

            if (txtNombre != null)
            {
                txtNombre.Visible = true;
                txtNombre.Clear();
                txtNombre.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string textoIngresado = txtNombre.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(textoIngresado))
            {
                MessageBox.Show("El campo no puede estar vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (tipoAccion == "Variable")
            {
                DescripcionSeleccionada = "";
                DescripcionCortaSeleccionada = textoIngresado;
            }
            else
            {
                DescripcionSeleccionada = textoIngresado;
                DescripcionCortaSeleccionada = "";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}