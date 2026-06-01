using ISFDyT93.Datos.Core;
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
            CargarTipoAsignacion();
            CargarTipoAplicacion();
        }

        private void CargarTipoAsignacion()  //busca las asignaciones en la base de datos y rellena el combobox
        {
            string query = "SELECT TipoAsignacionId, Descripcion FROM TipoAsignacion";
            DataTable tipoAsignacion = conexion.ObtenerRegistros(query);

            cmbTipoAsignacion.DataSource = tipoAsignacion;
            cmbTipoAsignacion.DisplayMember = "Descripcion";
            cmbTipoAsignacion.ValueMember = "TipoAsignacionId"; 
        }
        private void CargarTipoAplicacion() //busca las aplicaciones en la base de datos y rellena el combobox
        {
            string query = "SELECT TipoAplicacionId, Descripcion FROM TipoAplicacion";
            DataTable tipoAplicacion = conexion.ObtenerRegistros(query);

            cmbTipoAplicacion.DataSource = tipoAplicacion;
            cmbTipoAplicacion.DisplayMember = "Descripcion";
            cmbTipoAplicacion.ValueMember = "TipoAplicacionId";
        }
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
            {
                // Si el usuario elige No, no hace nada
                return;
            }
            //crea una lista de parametros de sql para despues usarse en un store procedure en sql
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Descripcion", txtNombre.Text),
                new SqlParameter("@CargaHoraria", cargaHoraria),
                new SqlParameter("@TipoAsignacionId", cmbTipoAsignacion.SelectedValue),
                new SqlParameter("@TipoAplicacionId", cmbTipoAplicacion.SelectedValue)
            };
            //usa el metodo de la clase conexion para ejecutar el store
            conexion.EjecutarStore("InsertarCargo", parametros); 

            this.DialogResult = DialogResult.OK;   //agreguen esto
            this.Close(); //agrueguen esto

            DialogResult resultado = MessageBox.Show($"Cargo {txtNombre.Text} agregado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (resultado == DialogResult.OK)
            {
                //cierra todo el formulario cuando se le da a "ok" en el cartelito despues de introducir un dato
                this.Close();
            }
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
