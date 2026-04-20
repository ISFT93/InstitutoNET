using System;
using System.Data;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Vista.Forms.Common;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormControlAsistencias : FormBase
    {

        #region Propiedades Publicas
        public int CursadaId { get; set; }
        #endregion

        #region Propiedades Privadas

        int buttonAceptar;
        ControlAsistenciasLogica controlAsistenciasLogica { get; set; }
        CursadasLogica cursadasLogica { get; set; }
        CursadasModelo Cursada { get; set; }

        int fila = 0;

        #endregion

        public FormControlAsistencias()
        {
            this.controlAsistenciasLogica = new ControlAsistenciasLogica();
            this.cursadasLogica = new CursadasLogica();

            InitializeComponent();
        }

        private void ControlAsistencias_Load(object sender, EventArgs e)
        {
            this.PropiedadesFormPrincipal();

            this.Cursada = this.cursadasLogica.ObtenerCursada(this.CursadaId);
            this.MapToForm<CursadasModelo>(this.Cursada);

            var dr = controlAsistenciasLogica.CargarProfesor();
            txtProfesor.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();

            this.RellenarGrilla();
        }

        private void RellenarGrilla()
        {
            var FechaAsistenciaStr = new AsistenciasModelo
            {
                FechaAsistencia = dtpFechaAsistencia.Value,
            };

            dgvAsistencias.DataSource = controlAsistenciasLogica.CargarAsistenciasAnteriores(FechaAsistenciaStr);
            dgvAsistencias.Columns["AlumnoId"].Visible = false;
            dgvAsistencias.Columns["CursadaId"].Visible = false;
            dgvAsistencias.Columns["AlumnoCarreraId"].Visible = false;
            dgvAsistencias.Columns["CursadaAlumnoCarreraId"].Visible = false;


            if (dgvAsistencias.Rows.Count > 0)
            {
                var asistencia = dgvAsistencias.Rows[0].Cells["Asistencia"].Value;

                tsmP.Enabled = string.IsNullOrEmpty(asistencia.ToString());
                tsmA.Enabled = string.IsNullOrEmpty(asistencia.ToString());
            }



            this.CalcularPorcentajeActual();
        }

        private void dgvAsistencias_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvAsistencias.HitTest(e.X, e.Y);
                tsmP.Visible = true;
                tsmA.Visible = true;
                tsmHistorialAsistenciasAlumnos.Visible = true;

                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {
                    fila = info.RowIndex;
                    dgvAsistencias.Rows[info.RowIndex].Selected = true;

                    if (dtpFechaAsistencia.Value < DateTime.Now.Date)
                    {
                        tsmA.Visible = true;
                        tsmP.Visible = true;
                    }
                    if (dgvAsistencias.Columns[info.ColumnIndex].Name == "Asistencia")
                    {
                        tsmP.Visible = true;
                        tsmA.Visible = true;
                        tsmHistorialAsistenciasAlumnos.Visible = false;
                    }
                    else
                    {
                        tsmP.Visible = false;
                        tsmA.Visible = false;
                        tsmHistorialAsistenciasAlumnos.Visible = true;
                    }

                    cmsPyA.Show(dgvAsistencias, e.X - cmsPyA.Width / 2, e.Y);
                }
            }
        }

        private void PropiedadesFormPrincipal()
        {
            this.Contenedor.SetVolver(() =>
               Contenedor.AbrirFormulario<FormCursoMaterias>(form =>
               {
                   form.CursoId = this.Cursada.CursoId;
               }));
        }

        private void tsmP_Click(object sender, EventArgs e)
        {
            dgvAsistencias.Rows[fila].Cells["Asistencia"].Value = "P";

            CalcularPorcentajeActual();
        }

        private void tsmA_Click(object sender, EventArgs e)
        {
            dgvAsistencias.Rows[fila].Cells["Asistencia"].Value = "A";

            CalcularPorcentajeActual();
        }

        private void CalcularPorcentajeActual()
        {
            int alumnos = 0;

            for (int i = 0; i < dgvAsistencias.Rows.Count; i++)
            {
                if (dgvAsistencias.Rows[i].Cells["Asistencia"].Value.ToString() == "P")
                {
                    alumnos++;
                }
            }

            double porcentaje = 0;

            if (dgvAsistencias.Rows.Count > 0)
                porcentaje = alumnos * 100 / dgvAsistencias.Rows.Count;

            txtPorcentajePresente.Text = Math.Round(porcentaje, 2).ToString();
        }

        private void dtpFechaAsistencia_ValueChanged(object sender, EventArgs e)
        {
            RellenarGrilla();
        }

        private bool Validar()
        {
            bool resultado = true;

            for (int i = 0; i < dgvAsistencias.Rows.Count; i++)
            {
                var value = dgvAsistencias.Rows[i].Cells["Asistencia"].Value;

                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                {
                    if (!value.ToString().Equals("P") && !value.ToString().Equals("A"))
                    {
                        resultado = false;
                    }
                }
                else
                {
                    resultado = false;
                }
            }

            if (!cmsPyA.Enabled)
            {
                resultado = false;
            }

            return resultado;
        }

        private void btnAceptarAsistencia_Click_1(object sender, EventArgs e)
        {
            if (Validar())
            {
                DialogResult dr;
                dr = MessageBox.Show("Guardar lista de asistencias", "¿Está seguro de guardar los cambios?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    int totalModulos = this.Cursada.HoraCatedra + this.Cursada.ModulosMateria;
                    int cursantes = 0;
                    double totalPorcentajes = 0;
                    for (int i = 0; i <= dgvAsistencias.Rows.Count - 1; i++)
                    {
                        if (dgvAsistencias.Rows[i].Cells["Asistencia"].Value != null)
                        {
                            int modulosCursadas = Convert.ToInt32(dgvAsistencias.Rows[i].Cells["Módulos"].Value);

                            if (dgvAsistencias.Rows[i].Cells["Asistencia"].Value.ToString() == "P")
                            {
                                modulosCursadas += this.Cursada.ModulosMateria;
                                cursantes++;

                            }

                            double porcentaje = modulosCursadas * 100 / totalModulos;
                            totalPorcentajes += porcentaje;

                            var Modelo = new AsistenciasModelo
                            {
                                HorasCursadas = modulosCursadas,
                                PorcentajeAsistencia = porcentaje,
                                UltimoPresentismo = dtpFechaAsistencia.Value,
                                Asistencia = Convert.ToChar(dgvAsistencias.Rows[i].Cells["Asistencia"].Value),
                                CursadaAlumnoCarreraId = Convert.ToInt32(dgvAsistencias.Rows[i].Cells["CursadaAlumnoCarreraId"].Value),
                            };

                            if (Modelo.Asistencia == 'P')
                            {
                                controlAsistenciasLogica.ActualizoUltimaFechaAsistencia(Modelo);
                            }

                            controlAsistenciasLogica.AgregarAsistencia(Modelo);
                        }
                    }

                    double promedioCursada = totalPorcentajes / dgvAsistencias.Rows.Count;

                    var cursada = new AsistenciasModelo
                    {
                        HorasCursadas = totalModulos,
                        FechaAsistencia = dtpFechaAsistencia.Value,
                        PorcentajeAsistencia = promedioCursada,
                        CursadaId = this.CursadaId
                    };

                    controlAsistenciasLogica.ActualizarCursada(cursada);

                    this.RellenarGrilla();
                    Notificar(TipoNotificacion.Success, "Asistencias agregada con éxito");
                    //this.LimpiarColumnaAsistencia();
                }
            }
            else
            {
                if (cmsPyA.Enabled)
                {
                    Notificar(TipoNotificacion.Warning, "Por favor, cargue las asistencias correctamente");
                }
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            var modelo = new AsistenciasModelo
            {
                FechaAsistencia = dtpFechaAsistencia.Value,

            };
            var datos = this.controlAsistenciasLogica.CargarAsistenciasAlumnosReporte(modelo);

            this.Contenedor.AbrirFormulario<FormReporte>(form =>
            {
                form.SetReporte("Diseño.Reports.ControlAsistencias.rdlc")
                .AddDataSource(datos, "DSListaAsistencia")
                .AddParameter("Materia", txtNombreMateria.Text)
                .AddParameter("Profesor", txtProfesor.Text)
                .AddParameter("Modulos", txtHoraCatedra.Text)
                .AddParameter("PorcentajeAsis", txtPorcentajeAsistencia.Text)
                .AddParameter("TotalDeAlumnos", lblTotalAlumnosI.Text)
                .AddParameter("POrcAlPres", lblPorcentajeAlumnosI.Text)
                .AddParameter("Fecha", Convert.ToString(dtpFechaAsistencia.Value));
            });
        }
    }
}
