using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormCursoMaterias : FormBase
    {
        #region Propiedades Publicas
        public int CursoId { get; set; }
        #endregion

        #region Propiedades Privadas
        private CicloLectivosLogica cicloLectivosLogica { get; set; }
        private MateriasLogica materiasLogica { get; set; }
        private CursosLogica cursosLogica { get; set; }

        private CursosModelo Curso { get; set; }

        private int CursadaId { get; set; }

        #endregion
        public FormCursoMaterias()
        {
            this.cicloLectivosLogica = new CicloLectivosLogica();

            this.materiasLogica = new MateriasLogica();

            this.cursosLogica = new CursosLogica(); 

            InitializeComponent();
        }

        private void CargarGrilla()
        {
            if (cmbCicloLectivo.Items.Count > 0)
            {
                dgvCursoMaterias.DataSource = materiasLogica.ObtenerMateriasByCursoAndAnioLectivo(Convert.ToInt32(this.cmbCicloLectivo.Text), CursoId);

                if (dgvCursoMaterias.Rows.Count > 0)
                {
                    dgvCursoMaterias.Columns["CursadaId"].Visible = false;
                }
            }
        }

        private void CargarPropiedadesFormPrincipal()
        {
            this.Curso = this.cursosLogica.ObtenerCurso(this.CursoId);

            this.Contenedor.SetTitulo($"CURSO { this.Curso.AnioCarrera } - {this.Curso.NombreCurso }");

            this.Contenedor.SetVolver(() =>
               Contenedor.AbrirFormulario<FormCursos>(form =>
               {
                   form.AnioCarreraId = this.Curso.AnioCarreraId;
               }));
        }

        private void CargarDatos()
        {
            var anioLectivo = cicloLectivosLogica.ObtenerAniosCiclosLectivos();

            if (anioLectivo != null)
            {
                cmbCicloLectivo.DisplayMember = "AnioLectivo";
                cmbCicloLectivo.DataSource = anioLectivo;                
                if(cmbCicloLectivo.Items.Count > 0) cmbCicloLectivo.SelectedIndex = 0;
                this.CargarGrilla();
            }
        }

        private void FormCursoMaterias_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
            this.CargarPropiedadesFormPrincipal();
        }

        private void dgvCursoMaterias_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tsmVerAlumnos.Visible = true;
                tsmControlarAsistencia.Visible = true;
            }
        }

        private void cmbCicloLectivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarGrilla();
        }

        private void dgvCursoMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCursoMaterias.Columns[e.ColumnIndex].Name == "Acciones" && e.RowIndex != -1)
            {
                cmsCursoMaterias.Show(Cursor.Position);
                this.CursadaId = Convert.ToInt32(dgvCursoMaterias.Rows[e.RowIndex].Cells["CursadaId"].Value);
            }
        }

        private void tsmControlarAsistencia_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormControlAsistencias>(form =>
            {
                form.CursadaId = this.CursadaId;
            });
        }

        private void tsmVerAlumnos_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormCursoMateriasAlumnos>(form =>
            {
                form.CursadaId = this.CursadaId;
            });
        }
    }
}
