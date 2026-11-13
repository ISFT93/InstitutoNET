using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormAgregarEsquema : Form
    {
        EsquemaEvaluacionLogica esquemasLogica =
            new EsquemaEvaluacionLogica();

        public FormAgregarEsquema()
        {
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            int indice;

            if (!int.TryParse(txtIndice.Text, out indice))
            {
                MessageBox.Show("El índice debe ser un número entero.");
                txtIndice.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEsquema.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtPlanilla.Text) ||
                string.IsNullOrWhiteSpace(txtTipoDato.Text))
            {
                MessageBox.Show(
                    "Complete todos los campos obligatorios."
                );
                return;
            }

            EsquemaEvaluacionModelo modelo = new EsquemaEvaluacionModelo()
                {
                    indice = indice,
                    esquema = txtEsquema.Text.Trim(),
                    ex_descripc = txtDescripcion.Text.Trim(),
                    ex_descripcion_planilla =
                        txtPlanilla.Text.Trim(),
                    ex_tipo_dat = txtTipoDato.Text.Trim(),
                    ex_requeric = chkRequerido.Checked,
                    Activo = false
                };

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea guardar el esquema?\n\n" +
                "Esquema: " + modelo.esquema + "\n" +
                "Índice: " + modelo.indice + "\n" +
                "Descripción: " + modelo.ex_descripc + "\n" +
                "Descripción Planilla: " +
                    modelo.ex_descripcion_planilla + "\n" +
                "Tipo de dato: " + modelo.ex_tipo_dat + "\n" +
                "Requerido: " +
                    (modelo.ex_requeric ? "Sí" : "No"),
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                esquemasLogica.AgregarEsquema(modelo);

                FormNotificacion.Mensaje(
                    TipoNotificacion.Success,
                    "Esquema creado correctamente"
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al agregar el esquema: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
