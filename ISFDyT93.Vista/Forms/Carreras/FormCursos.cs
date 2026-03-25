using System;
using System.Linq;
using System.Windows.Forms;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormCursos : FormBase
    {
        #region Propiedades Públicas
        public int AnioCarreraId { get; set; }
        #endregion

        #region Propiedades Privadas
        private CursosLogica cursosLogica { get; set; }
        private AniosCarreraLogica aniosLogica { get; set; }
        private CarrerasLogica carrerasLogica { get; set; }

        private AniosCarrerasModelo anioCarrera { get; set; }

        private int CursoId { get; set; }
        private string CursoAnio { get; set; }
        private string CursoNombre { get; set; }
        #endregion

        public FormCursos()
        {
            this.cursosLogica = new CursosLogica();
            this.aniosLogica = new AniosCarreraLogica();
            this.carrerasLogica = new CarrerasLogica();

            InitializeComponent();
        }

        private void FormCursos_Load(object sender, EventArgs e)
        {
            //lblTituloCursos.Text = "Cursos de " + AnioCarrera + " Año - " + descripcion;
            this.CargarGrilla();

            // Si la carrera esta inactiva, no permite asignar curso
            this.anioCarrera = aniosLogica.ObtenerAnioCarrera(AnioCarreraId);
            if (anioCarrera.CarreraEstadoId == 2)
            {
                tsmAsignarCurso.Visible = false;
            }

            this.Contenedor.SetVolver(() => {
                this.Contenedor.AbrirFormulario<FormAniosCarreras>(form =>
                {
                    form.CarreraId = this.anioCarrera.CarreraId;
                });
            });

            this.Contenedor.SetTitulo($"Cursos de { anioCarrera.AnioCarrera } - { anioCarrera.NombreCarrera }");
        }

        private void dgvCursos_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                DataGridView.HitTestInfo info = dgvCursos.HitTest(e.X, e.Y);

                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {
                    if (rbInactivos.Checked == true)
                    {
                        tsmAsignarCurso.Visible = false;
                        tsmModificarCurso.Visible = false;
                        tsmEliminarCursos.Visible = false;
                        tsmCursoDarAlta.Visible = true;
                    }
                    else if (rbActivos.Checked == true)
                    {
                        tsmCursoDarAlta.Visible = false;
                        tsmAsignarCurso.Visible = true;
                        tsmModificarCurso.Visible = true;
                        tsmEliminarCursos.Visible = true;
                    }
                    cmsCursos.Show(dgvCursos, e.X - cmsCursos.Width / 2, e.Y);
                    AnioCarreraId = Convert.ToInt32(dgvCursos["AnioCarreraId", info.RowIndex].Value.ToString());
                    CursoId = Convert.ToInt32(dgvCursos["CursoId", info.RowIndex].Value.ToString());
                    CursoNombre = this.dgvCursos["NombreCurso", info.RowIndex].Value.ToString();


                }
                else
                {
                    tsmModificarCurso.Visible = false;
                    tsmEliminarCursos.Visible = false;
                    tsmCursoDarAlta.Visible = false;
                    cmsCursos.Show(dgvCursos, e.X - cmsCursos.Width / 2, e.Y);

                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = dgvCursos.HitTest(e.X, e.Y);

                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {

                }
            }
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if(rbActivos.Checked)
            {
                this.CargarGrilla();
            }
        }

        private void rbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInactivos.Checked)
            {
                this.CargarGrilla();
            }
        }

        private void tsmAsignarCurso_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("¿Desea asignar un nuevo curso?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (Resultado == DialogResult.Yes)
            {
                this.cursosLogica.AgregarCurso(this.AnioCarreraId, this.dgvCursos.RowCount);

                this.CargarGrilla();
            }
        }

        private void tsmModificarCurso_Click(object sender, EventArgs e)
        {

        }

        private void tsmEliminarCursos_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de dar de baja este curso?",
           "Eliminar Curso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.cursosLogica.EliminarCurso(this.CursoId);

                this.CargarGrilla();
            }
        }

        private void tsmCursoDarAlta_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de dar de alta este curso?",
           "Alta de Curso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.cursosLogica.DarAltaCurso(this.CursoId);
                Notificar(TipoNotificacion.Success, "Curso dado de alta con exito");
                rbActivos.Checked = true;
            }
        }

        private void CargarGrilla()
        {
            if (this.rbActivos.Checked)
            {
                dgvCursos.DataSource = this.cursosLogica.ConsultarCursos(this.AnioCarreraId);
            }
            else
            {
                dgvCursos.DataSource = this.cursosLogica.CursosInactivos(this.AnioCarreraId);
            }

            dgvCursos.Columns["CursoId"].Visible = false;
            //dgvCursos.Columns["CicloLectivoId"].Visible = false;
            dgvCursos.Columns["AnioCarreraId"].Visible = false;
        }

        private void tsmVerMaterias_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormCursoMaterias>(form =>
            {
                form.CursoId = this.CursoId;
            });
        }
    }
}