using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormAgregarEspacios : Form
    {
        EspaciosLogica espaciosLogica = new EspaciosLogica();

        public FormAgregarEspacios()
        {
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Complete el campo descripción.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea guardar el siguiente espacio?\n\n" +
                $"Descripción: {txtDescripcion.Text}",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
                return;

            espaciosLogica.AgregarEspacio(txtDescripcion.Text);

            this.DialogResult = DialogResult.OK;

            FormNotificacion.Mensaje(
                TipoNotificacion.Success,
                $"Espacio {txtDescripcion.Text} creado correctamente"
            );

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Permitir letras
            if (char.IsLetter(e.KeyChar))
                return;

            // Permitir números
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir Backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Permitir espacio
            if (e.KeyChar == ' ')
            {
                // Evitar doble espacio
                if (txt.Text.Length > 0 && txt.Text.EndsWith(" "))
                {
                    e.Handled = true;
                }

                return;
            }

            // Bloquear todo lo demás
            e.Handled = true;
        }

        private void txtHoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir Backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Bloquear todo lo demás
            e.Handled = true;
        }
    }
}
