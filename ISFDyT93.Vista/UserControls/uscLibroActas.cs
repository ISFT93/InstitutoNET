using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Forms.Configuraciones;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscLibroActas : UserControl
    {
        public uscLibroActas()
        {
            InitializeComponent();
        }

        private LibrosActasLogica librosActasLogica = new LibrosActasLogica();

        private void uscLibroActas_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Height = 60;

            chkLibros.Checked = false;

            cmnuLibroActasGrilla.ForeColor = Color.White;
            agregarMenuContx.ForeColor = Color.White;
            agregarMenuContx.Image = global::ISFDyT93.Vista.Properties.Resources.plus_square_solid;
            panel1.Visible = false;
            this.Height = 60;
        }


        private void chkLibros_CheckedChanged(object sender, EventArgs e)
        {
            MostrarOcultar();
        }

        private void MostrarOcultar()
        {
            if (chkLibros.Checked)
            {
                this.Height = 616;
                panel1.Visible = true;

                CargarDGV(dgvLibros);
            }
            else
            {
                panel1.Visible = false;
                this.Height = 60;
            }
        }

        private void CargarDGV(DataGridView dgv)
        {
           

            dgv.DataSource = null;
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            // 1. Encabezados nuevos
            dgv.Columns.Add("Tipo", "Tipo de Libro"); // Nombre cambiado
            dgv.Columns.Add("Numero", "N°");           // Nombre cambiado
            dgv.Columns.Add("Carrera", "Carrera");
            dgv.Columns.Add("Folio", "Folio");
            dgv.Columns.Add("FolioMax", "Máximo");
            dgv.Columns.Add("Fecha", "Alta");
            dgv.Columns.Add("Baja", "Baja");

            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "Activo";
            colCheck.HeaderText = "Activo";
            colCheck.ReadOnly = true;
            dgv.Columns.Add(colCheck);

            var libros = librosActasLogica.ObtenerTodosLosLibros();

            foreach (var libro in libros)
            {
             
                string tipoLimpio = libro.Descripcion.Replace("Libro de ", "").Trim();

                
                string carreraTexto = libro.Carrera ?? "General";
                string carreraLimpia = carreraTexto; 
                string prefijo = "tecnicatura superior en ";

                if (carreraTexto.ToLower().StartsWith(prefijo))
                {
           
                    carreraLimpia = carreraTexto.Substring(prefijo.Length).Trim();
                }

                if (carreraLimpia.Length > 0)
                    carreraLimpia = char.ToUpper(carreraLimpia[0]) + carreraLimpia.Substring(1);

     
                dgv.Rows.Add(
                    tipoLimpio,
                    libro.LibroNumero,
                    carreraLimpia,
                    libro.FolioNumero,
                    libro.FolioMaximo,
                    libro.FechaAlta.ToShortDateString(),
                    libro.FechaBaja?.ToShortDateString() ?? "-",
                    libro.Activo
                );
            }

   


            dgv.Columns["Carrera"].FillWeight = 500;


            dgv.Columns["Numero"].FillWeight = 40;


            dgv.Columns["Tipo"].FillWeight = 200;


            dgv.Columns["Fecha"].FillWeight = 125;

            dgv.Columns["Baja"].FillWeight = 125;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }

        //private void agregarMenuContx_Click(object sender, EventArgs e)
        //{

        //}

        private void RecargarTabla()
        {
            dgvLibros.DataSource = null;

            dgvLibros.Rows.Clear();
            dgvLibros.Columns.Clear();

            CargarDGV(dgvLibros);
        }

        private void agregarMenuContx_Click_1(object sender, EventArgs e)
        {
            using (FormAgregarLibroActas frmlibroActas = new FormAgregarLibroActas())
            {
                frmlibroActas.StartPosition = FormStartPosition.CenterParent;

                
                if (frmlibroActas.ShowDialog() == DialogResult.OK)
                {
                    RecargarTabla();
                }
            }
        }

        private void cmnuLibroActasGrilla_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmnuLibroActasGrilla.ForeColor = Color.White;
            agregarMenuContx.ForeColor = Color.White;
            agregarMenuContx.Image = Properties.Resources.plus_square_solid;
        }
    }
}
