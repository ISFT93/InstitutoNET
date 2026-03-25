using System;
using System.Windows.Forms;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Forms.Common;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormAniosCarreras : Form
    {
        #region Propiedades Públicas
        public FormPrincipal Contenedor { get; set; }
        public int CarreraId { get; set; }

        #endregion

        #region Propiedades Privadas

        private int AnioCarreraId { get; set; }
        private CarrerasModelo Carrera { get; set; }

        private CarrerasLogica CarrerasLogica { get; set; }
        private AniosCarreraLogica AniosLogica { get; set; }

        #endregion

        private void tsmVerCursos_Click(object sender, EventArgs e)
        {
            if (AnioCarreraId > 0)
            {
                Contenedor.AbrirFormulario<FormCursos>(form =>
                {
                    form.AnioCarreraId = this.AnioCarreraId;
                });
            }
        }

        private void dgvCarreras_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tsmVerCursos.Visible = true;
                tsmVerHorarios.Visible = true;
                tsmVerMaterias.Visible = true;
                tsmVerCorrelativas.Visible = true;
                tsmDesactivarAnio.Visible = false;

                DataGridView.HitTestInfo info = dgvAniosCarrera.HitTest(e.X, e.Y);

                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {
                    dgvAniosCarrera.Rows[info.RowIndex].Selected = true;
                    cmsAniosCarreras.Show(dgvAniosCarrera, e.X - cmsAniosCarreras.Width / 2, e.Y);

                    this.AnioCarreraId = Convert.ToInt32(dgvAniosCarrera["AnioCarreraId", info.RowIndex].Value.ToString());

                    int anio = Convert.ToInt32( dgvAniosCarrera.Rows[0].Cells[0].Selected);
                    if (anio== 1)
                    {
                        tsmVerCorrelativas.Visible = false;
                    }

                    if (this.Carrera.CarreraEstadoId == (int)CarreraEstado.Activa)
                    {
                        tsmVerCursos.Text = "Asignar Cursos";
                    }
                    if (this.Carrera.CarreraEstadoId == (int)CarreraEstado.Inactiva)
                    {
                        tsmVerCursos.Text = "ver Cursos";
                    }
                    if (this.Carrera.CarreraEstadoId == (int)CarreraEstado.Borrador)
                    {
                        tsmVerMaterias.Text = "Asignar Materias";
                        tsmVerHorarios.Visible = false;
                        tsmVerCursos.Visible = false;
                    } 
                    if (this.Carrera.CarreraEstadoId == (int)CarreraEstado.Bloqueado && info.RowIndex == dgvAniosCarrera.RowCount - 1)
                    {
                        tsmVerMaterias.Visible = false;
                        tsmVerCorrelativas.Visible = false;
                        tsmVerHorarios.Visible = false;
                        tsmVerCursos.Visible = false;
                        tsmDesactivarAnio.Visible = true;
                    }
                }
                else
                {
                    tsmVerCursos.Visible = false;
                    tsmVerHorarios.Visible = false;
                    tsmVerMaterias.Visible = false;
                    tsmVerCorrelativas.Visible = false;
                    cmsAniosCarreras.Show(dgvAniosCarrera, e.X - cmsAniosCarreras.Width / 2, e.Y);
                }
            }
        }

        private void tsmVerMaterias_Click(object sender, EventArgs e)
        {
            if(this.AnioCarreraId > 0)
            {
                Contenedor.AbrirFormulario<FormMateriasAnioCarrera>(form => {
                    form.AnioCarreraId = this.AnioCarreraId;
                });
            }
        }

        private void tsmVerHorarios_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAsignarHorario>(form =>
            {
                form.AnioCarreraId = this.AnioCarreraId;
            });
        }

        private void tsmVerCorrelativas_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormVerCorrelativas>(form =>
            {
                form.AnioCarreraId = this.AnioCarreraId;
            });
        }

        public FormAniosCarreras()
        { 
            this.CarrerasLogica = new CarrerasLogica();
            this.AniosLogica = new AniosCarreraLogica();
          
            InitializeComponent();
        }

        public void RecargarGrilla()
        {
            this.Carrera = this.CarrerasLogica.ObtenerCarrera(CarreraId);

            dgvAniosCarrera.DataSource = AniosLogica.ObtenerAniosCarrera(CarreraId);
            dgvAniosCarrera.Columns["AnioCarreraId"].Visible = false;

            this.Contenedor.SetTitulo($"Años de { this.Carrera.DescripcionCorta }")
                .SetVolver(() => {
                    this.Contenedor.AbrirFormulario<FormCarreras>(form =>
                    {
                        form.CarreraId = this.CarreraId;
                    });
                });
        }
       
        private void FormAniosCarreras_Load(object sender, EventArgs e)
        {
            this.RecargarGrilla();
            CalcularCargaHorariaTotal();
        }

        private void CalcularCargaHorariaTotal()
        {
            int cargaHorariaTotal = 0;

            if (dgvAniosCarrera.RowCount> 0)
            {
                for (int i = 0; i < dgvAniosCarrera.RowCount; i++)
                {
                    cargaHorariaTotal += Convert.ToInt32(dgvAniosCarrera.Rows[i].Cells["Carga Horaria Completa"].Value);
                   
                }
                lblCargaHorariaTotal.Text = "Carga horaria total: " + cargaHorariaTotal.ToString();
            }
        }

        private void tsmDesactivarAnio_Click(object sender, EventArgs e)
        {
            AniosLogica.EliminarAnios(AnioCarreraId);
            this.RecargarGrilla();
        }
    }
}
