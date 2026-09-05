using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormAgregarTipoLicencia : Form
    {
        private readonly LicenciaServicioLogica licenciaLogica = new LicenciaServicioLogica();
        private bool modificar;

        public FormAgregarTipoLicencia()
        {
            InitializeComponent();
        }

        public void CargarDatos(string codigo, string descripcion, int? dias, bool fechaFinObligatoria)
        {
            modificar = true;
            txtCodigo.Text = codigo;
            txtCodigo.ReadOnly = true;
            txtDescripcion.Text = descripcion;
            txtDias.Text = dias.HasValue ? dias.Value.ToString() : string.Empty;
            chkFechaFinObligatoria.Checked = fechaFinObligatoria;
            lblTitulo.Text = "Modificar tipo de licencia";
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            int diasIngresados;
            int? dias = null;
            if (!string.IsNullOrWhiteSpace(txtDias.Text))
            {
                if (!int.TryParse(txtDias.Text, out diasIngresados) || diasIngresados < 0)
                {
                    MessageBox.Show("La cantidad de días debe ser un número válido.");
                    return;
                }

                dias = diasIngresados;
            }

            if (chkFechaFinObligatoria.Checked && !dias.HasValue)
            {
                MessageBox.Show("Debe ingresar la cantidad de días si la fecha fin es obligatoria.");
                return;
            }

            string accion = modificar ? "modificar" : "guardar";
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea {accion} los siguientes datos?\nCódigo: {codigo}\nDescripción: {descripcion}\nDías: {(dias.HasValue ? dias.Value.ToString() : "Sin definir")}\nFecha fin obligatoria: {(chkFechaFinObligatoria.Checked ? "Sí" : "No")}",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                int resultado = modificar
                    ? licenciaLogica.ModificarTipoLicencia(codigo, descripcion, dias, chkFechaFinObligatoria.Checked)
                    : licenciaLogica.AgregarTipoLicencia(codigo, descripcion, dias, chkFechaFinObligatoria.Checked);

                if (resultado > 0)
                {
                    DialogResult = DialogResult.OK;
                    string mensaje = modificar ? "modificado" : "creado";
                    FormNotificacion.Mensaje(TipoNotificacion.Success, $"Tipo de licencia {descripcion} {mensaje} correctamente");
                    Close();
                }
                else
                {
                    FormNotificacion.Mensaje(TipoNotificacion.Error, "No se pudo guardar el tipo de licencia");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"No se pudo guardar el tipo de licencia.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                return;

            e.Handled = true;
        }
    }
}
