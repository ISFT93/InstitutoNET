using ISFDyT93.Datos.Core;
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
            CargarLibros(AgregarNuevaRelacion);
            cbxLibro.SelectedIndexChanged += cbxLibro_SelectedIndexChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        #region ComboBoxes

        private void LibrosSinActualizar(ComboBox cmb)
        {
            string query = "SELECT DISTINCT t.TipoLibroID, t.Descripcion FROM TipoLibros t INNER JOIN LibroActas l ON t.TipoLibroID = l.TipoLibroID INNER JOIN (SELECT TipoLibroID, CarreraID, MAX(LibroNumero) AS UltimoLibroNumero FROM LibroActas GROUP BY TipoLibroID, CarreraID) ultimos ON l.TipoLibroID = ultimos.TipoLibroID AND l.CarreraID = ultimos.CarreraID AND l.LibroNumero = ultimos.UltimoLibroNumero WHERE l.Activo = 0";
            Conexion conexion = new Conexion();
            DataTable librosDesactualizados = conexion.ObtenerRegistros(query);

            cmb.DataSource = librosDesactualizados;
            cmb.DisplayMember = "Descripcion";
            cmb.ValueMember = "TipoLibroID";
        }

        private void CarrerasSinActualizar(ComboBox cmb, int Libro)
        {
            string query = $"SELECT c.CarreraID, c.DescripcionCorta FROM Carreras c INNER JOIN LibroActas l ON c.CarreraID = l.CarreraID INNER JOIN (SELECT TipoLibroID, CarreraID, MAX(LibroNumero) AS UltimoLibroNumero FROM LibroActas WHERE TipoLibroID = {Libro} GROUP BY TipoLibroID, CarreraID) ultimos ON l.TipoLibroID = ultimos.TipoLibroID AND l.CarreraID = ultimos.CarreraID AND l.LibroNumero = ultimos.UltimoLibroNumero WHERE l.Activo = 0";
            Conexion conexion = new Conexion();
            DataTable librosDesactualizados = conexion.ObtenerRegistros(query);

            cmb.DataSource = librosDesactualizados;
            cmb.DisplayMember = "DescripcionCorta";
            cmb.ValueMember = "CarreraID";
        }

        private void LibrosSinRelacionar(ComboBox cmb)
        {
            string query = "SELECT t.TipoLibroID, t.Descripcion FROM TipoLibros t WHERE EXISTS (SELECT 1 FROM Carreras c WHERE NOT EXISTS (SELECT 1 FROM LibroActas l WHERE l.TipoLibroID = t.TipoLibroID AND l.CarreraID = c.CarreraID))";
            Conexion conexion = new Conexion();
            DataTable librosSinRelacionar = conexion.ObtenerRegistros(query);

            cmb.DataSource = librosSinRelacionar;
            cmb.DisplayMember = "Descripcion";
            cmb.ValueMember = "TipoLibroID";
        }

        private void CarrerasSinAgregar(ComboBox cmb, int libro)
        {
            string query = $"SELECT c.CarreraID, c.DescripcionCorta FROM Carreras c WHERE NOT EXISTS (SELECT 1 FROM LibroActas l WHERE l.CarreraID = c.CarreraID AND l.TipoLibroID = {libro})";
            Conexion conexion = new Conexion();
            DataTable carrerasSinRelacionar = conexion.ObtenerRegistros(query);

            cmb.DataSource = carrerasSinRelacionar;
            cmb.DisplayMember = "DescripcionCorta";
            cmb.ValueMember = "CarreraID";
        }

        private void CargarLibros(bool agregarNuevaRelacion)
        {
            if (agregarNuevaRelacion == true)
                LibrosSinRelacionar(cbxLibro);
            else
                LibrosSinActualizar(cbxLibro);
        }
        #endregion

        private void CrearNuevaRelacion()
        {
            int carreraID = Convert.ToInt32(cbxCarrera.SelectedValue);
            int tipoLibroID = Convert.ToInt32(cbxLibro.SelectedValue);

            string query = $"SELECT * FROM LibroActas WHERE CarreraID = {carreraID} AND TipoLibroID = {tipoLibroID}";
            Conexion conexion = new Conexion();
            DataTable registros = conexion.ObtenerRegistros(query);

            if (registros.Rows.Count > 0)
            {
                MessageBox.Show("No se puede crear esa relación porque ya existe", "Aviso", MessageBoxButtons.OK);
            }
            else 
            {
                if (!int.TryParse(txtFolioMax.Text, out int folioMaximo))
                {
                    MessageBox.Show("Ingrese un número válido para el folio máximo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime fechaAlta = dtpFechaAlta.Value.Date;

                DialogResult confirm = MessageBox.Show(
                $"¿Está seguro que desea cargar los datos?\n\nLibro de acta: {cbxLibro.Text}\nCarrera: {cbxCarrera.Text}\nFolio máximo: {folioMaximo}\nFecha de alta: {fechaAlta.Date.ToString("dd/MM/yyyy")}",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
                if (confirm != DialogResult.Yes)
                    return;

                try
                {
                    // Obtener el siguiente número de libro
                    SqlCommand cmdNumeroLibro = new SqlCommand("SELECT ISNULL(MAX(LibroNumero), 0) + 1 FROM LibroActas WHERE TipoLibroID = @TipoLibroID", conexion.Conector);
                    cmdNumeroLibro.Parameters.AddWithValue("@TipoLibroID", tipoLibroID);
                    conexion.Conector.Close();
                    conexion.Conector.Open();
                    int nuevoNumeroLibro = (int)cmdNumeroLibro.ExecuteScalar();
                    conexion.Conector.Close();
                    // Ejecutar stored procedure para crear el libro
                    SqlParameter[] parametros = new SqlParameter[]
                    {
                        new SqlParameter("@TipoLibroID", tipoLibroID),
                        new SqlParameter("@CarreraID", carreraID),
                        new SqlParameter("@LibroNumero", nuevoNumeroLibro),
                        new SqlParameter("@FolioMaximo", folioMaximo),
                        new SqlParameter("@FechaAlta", fechaAlta)
                    };

                    conexion.EjecutarStore("AgregarNumeroLibro", parametros);

                    MessageBox.Show($"Se ha añadido el {cbxLibro.Text} en la carrera {cbxCarrera.Text} con {folioMaximo} folios y fecha de alta {fechaAlta.Date.ToString("dd/MM/yyyy")} y número de folio {nuevoNumeroLibro} correctamente", "Éxito", MessageBoxButtons.OK);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                finally
                {
                    if (conexion.Conector.State != ConnectionState.Closed)
                        conexion.Conector.Close();
                }

            }
        }
        private void ActualizarLibro()
        {
            if (!int.TryParse(txtFolioMax.Text, out int folioMaximo))
            {
                MessageBox.Show("Ingrese un número válido para el folio máximo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int TipoLibroID = Convert.ToInt32(cbxLibro.SelectedValue);
            int CarreraID = Convert.ToInt32(cbxCarrera.SelectedValue);
            DateTime fechaAlta = dtpFechaAlta.Value.Date;

            //Confirmación antes de guardar
            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro que desea actualizar el libro con los siguientes datos?\n\nLibro de acta: {cbxLibro.Text}\nCarrera: {cbxCarrera.Text}\nFolio máximo: {folioMaximo}\nFecha de alta: {fechaAlta.Date.ToString("dd/MM/yyyy")}",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            Conexion conexion = new Conexion();
            conexion.Conector.Open();
            try
            {
                // Obtener el siguiente número de libro
                SqlCommand cmdNumeroLibro = new SqlCommand("SELECT ISNULL(MAX(LibroNumero), 0) + 1 FROM LibroActas WHERE TipoLibroID = @TipoLibroID", conexion.Conector);
                cmdNumeroLibro.Parameters.AddWithValue("@TipoLibroID", TipoLibroID);
                int nuevoNumeroLibro = (int)cmdNumeroLibro.ExecuteScalar();
                conexion.Conector.Close();
                // Ejecutar stored procedure para crear el libro
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@TipoLibroID", TipoLibroID),
                    new SqlParameter("@CarreraID", CarreraID),
                    new SqlParameter("@LibroNumero", nuevoNumeroLibro),
                    new SqlParameter("@FolioMaximo", folioMaximo),
                    new SqlParameter("@FechaAlta", fechaAlta)
                };

                conexion.EjecutarStore("AgregarNumeroLibro", parametros);

                MessageBox.Show($"Se ha actualizado el {cbxLibro.Text} en la carrera {cbxCarrera.Text} con {folioMaximo} folios, fecha de alta {fechaAlta.Date.ToString("dd/MM/yyyy")} y numero de folio {nuevoNumeroLibro} correctamente", "Éxito", MessageBoxButtons.OK);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            finally
            {
                if (conexion.Conector.State != ConnectionState.Closed)
                    conexion.Conector.Close();
            }
        }
        private void ValidarFormulario()
        {
            bool libroOk =
                cbxLibro.SelectedValue != null &&
                cbxLibro.SelectedValue is int;

            bool carreraOk =
                cbxCarrera.SelectedValue != null &&
                cbxCarrera.SelectedValue is int;

            btnGuardar.Enabled = libroOk && carreraOk;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (AgregarNuevaRelacion == true)
                CrearNuevaRelacion();
            else
                ActualizarLibro();
        }

        private void FormCargarNumLibro_Load(object sender, EventArgs e)
        {

        }

        private void cbxLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLibro.SelectedValue == null || cbxLibro.SelectedValue is DataRowView)
                return;

            int libro = Convert.ToInt32(cbxLibro.SelectedValue);

            if (AgregarNuevaRelacion)
                CarrerasSinAgregar(cbxCarrera, libro);
            else
                CarrerasSinActualizar(cbxCarrera, libro);

            ValidarFormulario();
        }

        private void cbxCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }
    }
}
