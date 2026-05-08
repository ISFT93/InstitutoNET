using System;
using System.Data;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Vista.Forms.Common;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Datos.Daos;
using System.Diagnostics;


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
            this.Contenedor.SetTitulo("Control Asustencias/Evaluaciones");


            var dr = controlAsistenciasLogica.CargarProfesor();
            txtProfesor.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();

            this.RellenarGrilla();
            ///
            cmbCarrera.DataSource = null;
            cmbCarrera.Items.Clear();
            cmbCarrera.Text = "";
            cmbCarrera.SelectedIndex = -1;
            ///
            cmbProfesor.DataSource = null;
            cmbProfesor.Items.Clear();
            cmbProfesor.Text = "";
            cmbProfesor.SelectedIndex = -1;
            //
            cmbAnio.DataSource = null;
            cmbAnio.Items.Clear();
            cmbAnio.Text = "";
            cmbAnio.SelectedIndex = -1;
            //
            cmbCurso.DataSource = null;
            cmbCurso.Items.Clear();
            cmbCurso.Text = "";
            cmbCurso.Text = "";
            cmbCurso.SelectedIndex = -1;
            //
            cmbAnio.Enabled = false;
            cmbCurso.Enabled = false;
            cmbMateria.Enabled = false;
            cmbCicloLectivo.Enabled = false;

        }

        private void RellenarGrilla()
        {
            var modelo = new AsistenciasModelo
            {
                FechaAsistencia = dtpFechaAsistencia.Value,
                CursadaId = this.CursadaId
            };

            // Leer filtros de los combos
            int filtro;
            if (cmbCarrera.SelectedValue != null && int.TryParse(cmbCarrera.SelectedValue.ToString(), out filtro))
                modelo.CarreraId = filtro;
            if (cmbAnio.SelectedValue != null && int.TryParse(cmbAnio.SelectedValue.ToString(), out filtro))
                modelo.AnioCarreraId = filtro;
            if (cmbCurso.SelectedValue != null && int.TryParse(cmbCurso.SelectedValue.ToString(), out filtro))
                modelo.CursoId = filtro;
            if (cmbMateria.SelectedValue != null && int.TryParse(cmbMateria.SelectedValue.ToString(), out filtro))
                modelo.MateriaId = filtro;
            if (cmbCicloLectivo.SelectedValue != null && int.TryParse(cmbCicloLectivo.SelectedValue.ToString(), out filtro))
                modelo.AnioLectivo = filtro;
            if (cmbProfesor.SelectedValue != null && int.TryParse(cmbProfesor.SelectedValue.ToString(), out filtro))
                modelo.PersonalId = filtro;

            Debug.WriteLine($"[FILTROS] Carrera={modelo.CarreraId}, Anio={modelo.AnioCarreraId}, Curso={modelo.CursoId}, Materia={modelo.MateriaId}, Ciclo={modelo.AnioLectivo}, Profesor={modelo.PersonalId}, Cursada={modelo.CursadaId}");

            dgvAsistencias.DataSource = controlAsistenciasLogica.CargarAsistenciasAnteriores(modelo);
            dgvAsistencias.Columns["AlumnoId"].Visible = false;
            dgvAsistencias.Columns["CursadaId"].Visible = false;
            dgvAsistencias.Columns["AlumnoCarreraId"].Visible = false;
            dgvAsistencias.Columns["CursadaAlumnoCarreraId"].Visible = false;

            if (dgvAsistencias.Columns["Materia"] != null)
            {
                dgvAsistencias.Columns["Materia"].Visible = true;
                dgvAsistencias.Columns["Materia"].DisplayIndex = 1;
            }
            if (dgvAsistencias.Columns["Profesor"] != null)
            {
                dgvAsistencias.Columns["Profesor"].Visible = true;
                dgvAsistencias.Columns["Profesor"].DisplayIndex = 2;
            }


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
                CursadaId = this.CursadaId
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

        private CarrerasDao _carrerasDao= new CarrerasDao();

        private void CargarCarreras()
        {

            DataTable dt = _carrerasDao.CarrerasActivas();

            cmbCarrera.DataSource = dt;
            cmbCarrera.ValueMember = "CarreraId";
            cmbCarrera.DisplayMember = "Nombre";
            cmbCarrera.SelectedIndex = -1;

        }
        private bool carrerasCargadas = false;
        private void cmbCarrera_DropDown(object sender, EventArgs e)
        {

            if (carrerasCargadas) return;
            CargarCarreras();
            carrerasCargadas = true;
        }
        //profesor
        private PersonalDao _personalDao = new PersonalDao();

        private void CargarProfesores()
        {
            DataTable dt = _personalDao.ObtenerProfesoresParaCombo(1);

            cmbProfesor.DataSource = dt;
            cmbProfesor.ValueMember = "PersonalId";
            cmbProfesor.DisplayMember = "NombreCompleto";
            cmbProfesor.SelectedIndex = -1;
        }
        private bool profesoresCargados = false;
        private void cmbProfesor_DropDown(object sender, EventArgs e)
        {
            if (profesoresCargados) return;
            CargarProfesores();
            profesoresCargados = true;
        }
        // año
        private AniosCarreraDao _aniosCarrerasDao = new AniosCarreraDao();
        
        private void CargarAniosPorCarrera(int carreraId)
        {
            DataTable dt = _aniosCarrerasDao.ObtenerAniosCarrera(carreraId);

            cmbAnio.DataSource = dt;
            cmbAnio.ValueMember = "AnioCarreraId";
            cmbAnio.DisplayMember = "Año";
            cmbAnio.SelectedIndex = -1;
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_enCambioCombos) return;
            _enCambioCombos = true;

            cmbProfesor.SelectedIndex = -1;

            ResetCadenaCarrera();

            if (cmbCarrera.SelectedValue == null)
            {
                _enCambioCombos = false;
                return;
            }

            int carreraId;
            if (!int.TryParse(cmbCarrera.SelectedValue.ToString(), out carreraId))
            {
                _enCambioCombos = false;
                return;
            }

            CargarAniosPorCarrera(carreraId);
            cmbAnio.Enabled = true;

            _enCambioCombos = false;
        }

        private CursosDao _cursosDao = new CursosDao();

        private void CargarCursosPorAnio(int anioCarreraId)
        {

            cmbCurso.DataSource = null;
            cmbCurso.Items.Clear();

            DataTable dt = _cursosDao.ConsultarCursos(anioCarreraId);
            cmbCurso.DataSource = dt;
            cmbCurso.ValueMember = "CursoId";
            cmbCurso.DisplayMember = "NombreCurso";
            cmbCurso.SelectedIndex = -1;
         
            Debug.Write(dt.Rows.Count);

        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbCurso.DataSource = null;
            cmbCurso.SelectedIndex = -1;
            cmbCurso.Enabled = false;

            cmbMateria.DataSource = null;
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = false;

            cmbCicloLectivo.DataSource = null;
            cmbCicloLectivo.SelectedIndex = -1;
            cmbCicloLectivo.Enabled = false;

            if (cmbAnio.SelectedValue == null) return;

            int anioCarreraId;
            if (!int.TryParse(cmbAnio.SelectedValue.ToString(), out anioCarreraId)) return;

            CargarCursosPorAnio(anioCarreraId);
            cmbCurso.Enabled = true; 
        }

        private MateriasDao _materiasDao = new MateriasDao();
      
        private void CargarMateriasPorAnio(int anioCarreraId)
        {

            cmbMateria.DataSource = null;
            cmbMateria.Items.Clear();

            DataTable dt = _materiasDao.CargarMaterias(anioCarreraId, true); 
            cmbMateria.DataSource = dt;
            cmbMateria.ValueMember = "MateriaId";
            cmbMateria.DisplayMember = "Nombre";
            cmbMateria.SelectedIndex = -1;
        }

        private CiclosLectivosDao _ciclosLectivosDao = new CiclosLectivosDao();
        private bool ciclosLectivosCargados = false;

        private void CargarCiclosLectivos()
        {
            DataTable dt = _ciclosLectivosDao.ObtenerCicloLectivo();

            cmbCicloLectivo.DataSource = dt;
            cmbCicloLectivo.ValueMember = "AnioLectivo";
            cmbCicloLectivo.DisplayMember = "AnioLectivo";
            cmbCicloLectivo.SelectedIndex = -1;
        }

        private void cmbCicloLectivo_DropDown(object sender, EventArgs e)
        {
            if (ciclosLectivosCargados) return;
            CargarCiclosLectivos();
            ciclosLectivosCargados = true;
        }

        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.DataSource = null;
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = false;

            cmbCicloLectivo.DataSource = null;
            cmbCicloLectivo.SelectedIndex = -1;
            cmbCicloLectivo.Enabled = false;

            if (cmbCurso.SelectedValue == null) return;

            if (cmbAnio.SelectedValue == null) return;

            int anioCarreraId;
            if (!int.TryParse(cmbAnio.SelectedValue.ToString(), out anioCarreraId)) return;

            CargarMateriasPorAnio(anioCarreraId);
            cmbMateria.Enabled = true;
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMateria.SelectedValue == null) return;

            int materiaId;
            if (!int.TryParse(cmbMateria.SelectedValue.ToString(), out materiaId)) return;

            cmbCicloLectivo.Enabled = true;
        }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            this.RellenarGrilla();
        }

        private ServiciosDao _serviciosDao = new ServiciosDao();

        private void cmbProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_enCambioCombos) return;
            _enCambioCombos = true;

            ResetCadenaCarrera();

            cmbCarrera.SelectedIndex = -1;

            if (cmbCarrera.DataSource == null)
            {
                carrerasCargadas = false;
                CargarCarreras();
            }

            cmbCarrera.SelectedIndex = -1;

            if (cmbProfesor.SelectedValue == null)
            {
                _enCambioCombos = false;
                return;
            }

            int personalId;
            if (!int.TryParse(cmbProfesor.SelectedValue.ToString(), out personalId))
            {
                _enCambioCombos = false;
                return;
            }

            var dt = _serviciosDao.ObtenerServicioPersonalAmpliado(personalId, 1);
            var dv = dt.DefaultView;
            dv.RowFilter = "CursoMateriaId IS NOT NULL";

            cmbMateria.DataSource = dv.ToTable();
            cmbMateria.ValueMember = "CursoMateriaId";
            cmbMateria.DisplayMember = "Servicio";
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = true;

            _enCambioCombos = false;
        }
  
        private bool _enCambioCombos = false;
        private void ResetCadenaCarrera()
        {
            cmbAnio.DataSource = null;
            cmbAnio.SelectedIndex = -1;
            cmbAnio.Enabled = false;

            cmbCurso.DataSource = null;
            cmbCurso.SelectedIndex = -1;
            cmbCurso.Enabled = false;

            cmbMateria.DataSource = null;
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = false;

            cmbCicloLectivo.DataSource = null;
            cmbCicloLectivo.SelectedIndex = -1;
            cmbCicloLectivo.Enabled = false;
        }
    }
}
