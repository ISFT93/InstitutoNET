using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Configuraciones
{
    public partial class FormAgregarLibroActas : Form
    {
        public FormAgregarLibroActas()
        {
            InitializeComponent();
        }
        private LibrosActasLogica logica = new LibrosActasLogica();

        private void FormAgregarLibroActas_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Today;

            txtFechaAlta.Text = fechaActual.ToString("dd/MM/yyyy");

            cmbTipoLibro.Enabled = false;

            CargarCarreras();
            cmbCarreras.SelectedIndex = -1;
        }

        
        private bool ValidarCampos()
        {
            // Verificamos los TextBox 

            if (string.IsNullOrWhiteSpace(txtFolioMax.Text) || string.IsNullOrWhiteSpace(txtFechaAlta.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos de texto.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (cmbTipoLibro.SelectedIndex == -1 || cmbCarreras.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una opción en los menús desplegables.", "Selección pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CargarTiposLibroDisponibles(int carreraId)
        {
            var tiposLibro = logica.ObtenerTiposLibroDisponibles(carreraId);

            cmbTipoLibro.DataSource = tiposLibro;

            cmbTipoLibro.DisplayMember = "Descripcion";

            cmbTipoLibro.ValueMember = "TipoLibroId";
        }

        private void CargarCarreras()
        {
            var carreras = logica.ObtenerCarrerasDisponibles();

            cmbCarreras.DataSource = carreras;

            cmbCarreras.DisplayMember = "Carrera";

            cmbCarreras.ValueMember = "CarreraId";


        }

        private void FormAgregarLibroActas_Load_1(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Today;

            txtFechaAlta.Text = fechaActual.ToString("dd/MM/yyyy");

            cmbTipoLibro.Enabled = false;

            CargarCarreras();
            cmbCarreras.SelectedIndex = -1;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            if ((Convert.ToInt32(txtFolioMax.Text) > 250) || (Convert.ToInt32(txtFolioMax.Text) < 50) ) 
            {
                MessageBox.Show("El número máximo de folios debe ser entre 50 y 250", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        


            int tipoLibroId =
            Convert.ToInt32(cmbTipoLibro.SelectedValue);

            int carreraId =
                Convert.ToInt32(cmbCarreras.SelectedValue);

            int folioMaximo =
                Convert.ToInt32(txtFolioMax.Text);

            logica.CrearLibroActa(
                tipoLibroId,
                carreraId,
                folioMaximo);

            MessageBox.Show("Libro creado correctamente", "Éxito",MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCarreras.SelectedItem is LibroActasModelo carreraSeleccionada)
            {
                cmbTipoLibro.Enabled = true;

                int carreraId = carreraSeleccionada.CarreraId;

                CargarTiposLibroDisponibles(carreraId);
            }

            cmbTipoLibro.SelectedIndex = -1;
        }

        private void txtFolioMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
