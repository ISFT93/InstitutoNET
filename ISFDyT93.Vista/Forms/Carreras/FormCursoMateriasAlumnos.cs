using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using System;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormCursoMateriasAlumnos : FormBase
    {

        #region Propiedades Publicas
        public int CursadaId { get; set; }
        #endregion

        #region Propiedades Privadas
        private CursosLogica cursosLogica { get; set; }
        private CursadasLogica cursadasLogica { get; set; }
        private CursadasModelo Cursada { get; set; }
        private int CursadaAlumnoCarreraId { get; set; }
        #endregion

        public FormCursoMateriasAlumnos()
        {
            InitializeComponent();
            this.cursosLogica = new CursosLogica();
            this.cursadasLogica = new CursadasLogica();
        }

        private void FormCursoMateriasAlumnos_Load(object sender, EventArgs e)
        {
            this.CargarGrilla();
            this.CargarPropiedadesFormPrincipal();
        }

        private void CargarGrilla()
        {
            var cursoMateria = this.cursosLogica.ObtenerCursoMateria(CursadaId);
            dgvCursoMateriasAlumnos.DataSource = cursoMateria;
            dgvCursoMateriasAlumnos.Columns["CursadaAlumnoCarreraId"].Visible = false;
            dgvCursoMateriasAlumnos.Columns["CursoId"].Visible = false;

            this.Cursada = this.cursadasLogica.ObtenerCursada(this.CursadaId);
        }

        private void CargarPropiedadesFormPrincipal()
        {
            this.Contenedor.SetVolver(() =>
            this.Contenedor.AbrirFormulario<FormCursoMaterias>(form =>
            {
                form.CursoId = this.Cursada.CursoId;
            }));
        }

        private void tsmVerHistorialAsistencia_Click(object sender, EventArgs e)
        {
            this.Contenedor.AbrirFormulario<FormHistorialAsistencias>(form =>
            {
                form.CursadaAlumnoCarreraId = this.CursadaAlumnoCarreraId;
            });
        }

        private void dgvCursoMateriasAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCursoMateriasAlumnos.Columns[e.ColumnIndex].Name == "Acciones" && e.RowIndex != -1)
            {
                cmsCursoMateriaAlumnos.Show(Cursor.Position);
                this.CursadaAlumnoCarreraId = Convert.ToInt32(dgvCursoMateriasAlumnos.Rows[e.RowIndex].Cells["CursadaAlumnoCarreraId"].Value);
            }
        }
    }
}
