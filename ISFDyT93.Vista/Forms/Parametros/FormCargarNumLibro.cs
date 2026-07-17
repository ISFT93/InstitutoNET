using ISFDyT93.Datos.Core;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormCargarNumLibro : Form
    {
        private bool AgregarNuevaRelacion;
        public FormCargarNumLibro(bool agregarNuevaRelacion)
        {
            InitializeComponent();
            this.AgregarNuevaRelacion = agregarNuevaRelacion;
            this.dtpFechaAlta.MinDate = DateTime.Now;
            //CargarLibros(AgregarNuevaRelacion);
            cbxLibro.SelectedIndexChanged += cbxLibro_SelectedIndexChanged;
        }

        LibroActasLogica libroActasLogica = new LibroActasLogica();
        private void FormCargarNumLibro_Load(object sender, EventArgs e)
        {
            int? TomaPosicionId = libroActasLogica.ObtenerTomaPosicion();

            if (AgregarNuevaRelacion == true)
                libroActasLogica.LibrosSinRelacionar(cbxLibro, TomaPosicionId);
            else
                libroActasLogica.LibrosSinActualizar(cbxLibro);

            cbxCarrera.Enabled = false;
            txtFolioMax.Enabled = false;
            dtpFechaAlta.Enabled = false;
            btnGuardar.Enabled = false;

            if (AgregarNuevaRelacion == true)
                lblTitulo.Text = "Cargar nuevo Libro";
            else
                lblTitulo.Text = "Actualizar Libro";
        }
        public void CerrarForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == (char)Keys.Back)
                return;

            e.Handled = true;
        }
        private void ActualizarLibro()
        {
            if (!int.TryParse(txtFolioMax.Text, out int folioMaximo))
            {
                MessageBox.Show("Ingrese un número válido para el folio máximo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int TipoLibroID = Convert.ToInt32(cbxLibro.SelectedValue);
            int? tomaPosicion = libroActasLogica.ObtenerTomaPosicion();
            int CarreraID = Convert.ToInt32(cbxCarrera.SelectedValue);

            DateTime fechaAlta = dtpFechaAlta.Value.Date;
            DialogResult confirm;

            if (TipoLibroID == tomaPosicion)
            {
                confirm = MessageBox.Show(
                $"¿Está seguro que desea actualizar el libro con los siguientes datos?\n\nLibro de acta: {cbxLibro.Text}\nFolio máximo: {folioMaximo}\nFecha de alta: {fechaAlta.Date.ToString("dd/MM/yyyy")}",
                "Confirmar",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

                if (confirm != DialogResult.OK)
                    return;
                else
                {
                    libroActasLogica.SumarNumeroLibro(TipoLibroID, null, folioMaximo, fechaAlta);
                    FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha actualizado el {cbxLibro.Text}");
                    CerrarForm();
                }
            }
            else
            {
                confirm = MessageBox.Show(
                    $"¿Está seguro que desea actualizar el libro con los siguientes datos?\n\nLibro de acta: {cbxLibro.Text}\nCarrera: {cbxCarrera.Text}\nFolio máximo: {folioMaximo}\nFecha de alta: {fechaAlta.Date.ToString("dd/MM/yyyy")}",
                    "Confirmar",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.OK)
                    return;
                else
                {
                    libroActasLogica.SumarNumeroLibro(TipoLibroID, CarreraID, folioMaximo, fechaAlta);
                    FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha actualizado el {cbxLibro.Text} de {cbxCarrera.Text}");
                    CerrarForm();
                }
            }
        }
        private void ValidarFormulario()
        {
            int libro = Convert.ToInt32(cbxLibro.SelectedValue);
            int? tomaPosicion = libroActasLogica.ObtenerTomaPosicion();

            bool libroOk;
            bool carreraOk;

            if (libro == tomaPosicion)
            {
                libroOk =
                cbxLibro.SelectedValue != null &&
                cbxLibro.SelectedValue is int;

                btnGuardar.Enabled = libroOk;
            }
            else 
            {
                libroOk =
                    cbxLibro.SelectedValue != null &&
                    cbxLibro.SelectedValue is int;

                carreraOk =
                    cbxCarrera.SelectedValue != null &&
                    cbxCarrera.SelectedValue is int;

                btnGuardar.Enabled = libroOk && carreraOk;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarLibro();
        }



        private void cbxLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLibro.SelectedValue == null || cbxLibro.SelectedValue is DataRowView)
                return;

            int libro = Convert.ToInt32(cbxLibro.SelectedValue);
            int? tomaPosicion = libroActasLogica.ObtenerTomaPosicion();

            if (AgregarNuevaRelacion)
                libroActasLogica.CarrerasSinRelacionar(cbxCarrera, libro);
            else
                libroActasLogica.CarrerasSinActualizar(cbxCarrera, libro);

            if (libro == tomaPosicion)
            {
                cbxCarrera.Enabled = false;
                cbxCarrera.DataSource = null;
                txtFolioMax.Enabled = true;
                dtpFechaAlta.Enabled = true;
            }
            else
            { 
                cbxCarrera.Enabled = true;
                txtFolioMax.Enabled = true;
                dtpFechaAlta.Enabled = true;
            }

            ValidarFormulario();
        }

        private void cbxCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
