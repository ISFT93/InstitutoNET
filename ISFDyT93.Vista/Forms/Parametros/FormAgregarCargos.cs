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
    public partial class FormAgregarCargos : Form
    {
        Conexion conexion = new Conexion();
        public FormAgregarCargos()
        {
            InitializeComponent();
            
            //cuando inicia el programa, carga los textboxes
            cargosLogica.CargarTipoAsignacion(cmbTipoAsignacion);
            cargosLogica.CargarTipoAplicacion(cmbTipoAplicacion);
        }
        CargosLogica cargosLogica = new CargosLogica();
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            //si algun textbox está vacio te impide continuar hasta que lo rellenes
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCargaHoraria.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }
            //intenta convertir en numero, lo que sea que haya en el textbox de numero
            int cargaHoraria = Convert.ToInt32(txtCargaHoraria.Text);
            int tipoAplicacionId = Convert.ToInt32(cmbTipoAplicacion.SelectedValue);
            int tipoAsignacionId = Convert.ToInt32(cmbTipoAsignacion.SelectedValue);
            //si el numero leido en el textbox es mayor que 20, te detiene hasta que lo reduzcas
            if (cargaHoraria > 20)
            {
                MessageBox.Show("La cantidad carga horaria maxima es de 20");
                return;
            }
            // **Mensaje de confirmación antes de guardar**
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea guardar los siguientes datos?\nCargo: {txtNombre.Text}\nCarga horaria:{cargaHoraria}\nAsignación: {cmbTipoAsignacion.Text}\nAplicación: {cmbTipoAplicacion.Text}",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
                return;

            cargosLogica.AgregarCargo(txtNombre.Text, cargaHoraria, tipoAplicacionId, tipoAsignacionId);
            this.DialogResult = DialogResult.OK;
            FormNotificacion.Mensaje(TipoNotificacion.Success, $"Cargo {txtNombre.Text} creado correctamente");
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //cierra el formulario si le das a cancelar
            this.Close();
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Permitir letras
            if (char.IsLetter(e.KeyChar))
                return;

            // Permitir barra "/"
            if (e.KeyChar == '/')
                return;

            // Permitir Backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Manejo de espacio
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
        private void txtCargaHoraria_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == (char)Keys.Back)
                return;

            e.Handled = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void FormAgregarCargos_Load(object sender, EventArgs e)
        {

        }
    }
}
