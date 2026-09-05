using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormAgregarTipoLicencia : Form
    {
        private bool EsNuevo;
        // CORREGIDO: Ambas partes deben ser TipoLicenciaLogica
        private TipoLicenciaLogica licenciaLogica = new TipoLicenciaLogica();

        public FormAgregarTipoLicencia(bool esNuevo = true)
        {
            InitializeComponent();
            this.EsNuevo = esNuevo;
        }

        private void FormAgregarTipoLicencia_Load(object sender, EventArgs e)
        {
            if (EsNuevo)
            {
                lblTitulo.Text = "Cargar nueva Licencia";
                txtTipoLicenciaId.Enabled = true; // Ej: "114 a1"
                chkActivo.Checked = true;
            }
            else
            {
                lblTitulo.Text = "Actualizar Licencia";
                txtTipoLicenciaId.Enabled = false; // La Primary Key no se edita al actualizar
            }

            ValidarFormulario();
        }

        public void CerrarForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                return;

            e.Handled = true;
        }

        private void GuardarLicencia()
        {
            TipoLicenciaModelo modelo = new TipoLicenciaModelo
            {
                TipoLicenciaId = txtTipoLicenciaId.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Dias = string.IsNullOrEmpty(txtDias.Text.Trim()) ? (int?)null : Convert.ToInt32(txtDias.Text),
                FechaFinObligatoria = chkFechaFinObligatoria.Checked,
                Activo = chkActivo.Checked
            };

            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro que desea guardar la licencia con los siguientes datos?\n\n" +
                $"Tipo ID: {modelo.TipoLicenciaId}\n" +
                $"Descripción: {modelo.Descripcion}\n" +
                $"Días: {(modelo.Dias.HasValue ? modelo.Dias.ToString() : "Sin límite")}\n" +
                $"Fecha Fin Obligatoria: {(modelo.FechaFinObligatoria ? "Sí" : "No")}",
                "Confirmar",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.OK)
                return;

            int resultado = licenciaLogica.GuardarLicencia(modelo);

            if (resultado > 0)
            {
                FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha registrado la licencia {modelo.TipoLicenciaId}");
                CerrarForm();
            }
            else
            {
                FormNotificacion.Mensaje(TipoNotificacion.Error, "Error al guardar la licencia en la base de datos");
            }
        }

        private void ValidarFormulario()
        {
            bool idOk = !string.IsNullOrWhiteSpace(txtTipoLicenciaId.Text);
            bool descOk = !string.IsNullOrWhiteSpace(txtDescripcion.Text);

            btnGuardar.Enabled = idOk && descOk;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarLicencia();
        }

        private void txtTipoLicenciaId_TextChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}