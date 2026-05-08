using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ISFDyT93.Entidades.Modelos;
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
        private CicloLectivosLogica cicloLectivosLogica { get; set; }

        private int CursoId { get; set; }
        private string CursoAnio { get; set; }
        private string CursoNombre { get; set; }
        #endregion

        public FormCursos()
        {
            this.cursosLogica = new CursosLogica();
            this.aniosLogica = new AniosCarreraLogica();
            this.carrerasLogica = new CarrerasLogica();
            this.cicloLectivosLogica = new CicloLectivosLogica();

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

            tsmEliminarCursos.Enabled = !cicloLectivosLogica.CicloLectivoActivo();

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

            if (Resultado != DialogResult.Yes)
                return;

            // revisar antes cursos inactivos, si hay inactivos no dejar agregar curso hasta activar todos los inactivos.
            if (this.cursosLogica.ConsultarCursosInactivo(this.AnioCarreraId))
            {
                DataTable dt = this.cursosLogica.CursosInactivos(this.AnioCarreraId);

                int idCurso = Convert.ToInt32(dt.Rows[0]["CursoId"]);
                this.cursosLogica.DarAltaCurso(idCurso);
                Notificar(TipoNotificacion.Success, "Curso dado de alta con exito");
                this.CargarGrilla();
                return;
            }

            this.cursosLogica.AgregarCurso(this.AnioCarreraId, this.dgvCursos.RowCount);

            this.CargarGrilla();

        }

        private void tsmModificarCurso_Click(object sender, EventArgs e)
        {

        }

        private void tsmEliminarCursos_Click(object sender, EventArgs e)
        {
            //======================================

            var listaid = DevolverListaOrdenada();

            int indiceCurso = this.dgvCursos.Rows.Count;
            int idCurso = listaid[indiceCurso-1].CursoId;
            string cursoSeleccionado = listaid[indiceCurso - 1].NombreCurso.ToString();

            // usar una vez la tabla curso contenga el codigo de materia,carrera, año y curso ej:08104A
            //string letraCurso = cursoSellecionado[cursoSellecionado.Length - 1].ToString();

            //======================================

            DialogResult resultado = MessageBox.Show("¿Esta seguro de dar de baja el curso "+cursoSeleccionado+" ?",
            "Desactivar Curso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(resultado != DialogResult.Yes)
                return;

            this.cursosLogica.EliminarCurso(idCurso);
            this.CargarGrilla();

        }

        private void tsmCursoDarAlta_Click(object sender, EventArgs e)
        {
            var listaid = DevolverListaOrdenada();

            int idCurso = listaid[0].CursoId;
            string cursoSeleccionado = listaid[0].NombreCurso.ToString();


            DialogResult resultado = MessageBox.Show("¿Esta seguro de dar de alta este curso " + cursoSeleccionado + " ?",
           "Alta de Curso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado != DialogResult.Yes)
                return;



            this.cursosLogica.DarAltaCurso(idCurso);
            Notificar(TipoNotificacion.Success, "Curso dado de alta con exito");
            rbActivos.Checked = true;
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

            // Ordenar la grilla
            dgvCursos.Sort(dgvCursos.Columns["CursoId"], ListSortDirection.Ascending);

            dgvCursos.Columns["CursoId"].Visible = false;
            //dgvCursos.Columns["CicloLectivoId"].Visible = false;
            dgvCursos.Columns["AnioCarreraId"].Visible = false;
            dgvCursos.Columns["AdmiteCurso"].Visible = false;
        }

        private List<CursoItem> DevolverListaOrdenada()
        {
             var listaid = this.dgvCursos.Rows
                .Cast<DataGridViewRow>()
                .Where(f => !f.IsNewRow)
                .Select(f => new CursoItem
                {
                    CursoId = Convert.ToInt32(f.Cells["CursoId"].Value),
                    NombreCurso = f.Cells["NombreCurso"].Value.ToString()
                })
                .OrderBy(f => f.CursoId)
                .ToList();

             return listaid;

        }

        private void tsmVerMaterias_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormCursoMaterias>(form =>
            {
                form.CursoId = this.CursoId;
            });
        }

        private class CursoItem
        {
            public int CursoId { get; set; }
            public string NombreCurso { get; set; }
        }
    }
}