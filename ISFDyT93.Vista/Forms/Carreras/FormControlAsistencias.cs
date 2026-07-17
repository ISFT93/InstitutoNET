using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Vista.Forms.Common;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Datos.Daos;
using System.Diagnostics;
using Microsoft.ReportingServices.Diagnostics.Internal;


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
        DataTable _dtResumenAlumnos;
        DataTable _dtResumenCursada;
        bool _enVistaDetalle = false;

        #endregion

        public FormControlAsistencias()
        {
            this.controlAsistenciasLogica = new ControlAsistenciasLogica();
            this.cursadasLogica = new CursadasLogica();

            InitializeComponent();
        }

        private void ControlAsistencias_Load(object sender, EventArgs e)
        {
            dgvAsistencias.CellDoubleClick += dgvAsistencias_CellDoubleClick;

            this.PropiedadesFormPrincipal();
            this.Cursada = this.cursadasLogica.ObtenerCursada(this.CursadaId);
            this.MapToForm<CursadasModelo>(this.Cursada);
            this.Contenedor.SetTitulo("Avance Academico");


            var dr = controlAsistenciasLogica.CargarProfesor();
            if (dr != null)
            { 
                txtProfesor.Text = dr["Nombre"].ToString();
                txtProfesor.Text +=  " " + dr["Apellido"].ToString();
            }
            //this.RellenarGrilla();
       
           
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
           

        }

        private AsistenciasModelo BuildModelo()
        {
            var modelo = new AsistenciasModelo
            {
                FechaAsistencia = dtpFechaAsistencia.Value,
                CursadaId = this.CursadaId
            };

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

            return modelo;
        }

        private void RellenarGrilla()
        {
            var modelo = BuildModelo();

            _dtResumenAlumnos = controlAsistenciasLogica.ObtenerResumenAsistenciasAlumnos(modelo);
            _dtResumenCursada = controlAsistenciasLogica.ObtenerResumenCursada(modelo);
            _enVistaDetalle = false;
            MostrarResumenCursada();

            this.CalcularPorcentajeActual();
            this.ActualizarDatosInformativos();
        }

        private void ActualizarDatosInformativos()
        {
            if (dgvAsistencias.Rows.Count > 0)
            {
                int cursadaId = Convert.ToInt32(dgvAsistencias.Rows[0].Cells["CursadaId"].Value);
                this.Cursada = this.cursadasLogica.ObtenerCursada(cursadaId);
                this.MapToForm<CursadasModelo>(this.Cursada);

                var dr = controlAsistenciasLogica.CargarProfesor();
                txtProfesor.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
            }
            else
            {
                this.LimpiarControlesInformativos();
            }
        }

        private void LimpiarControlesInformativos()
        {
            txtNombreMateria.Text = string.Empty;
            txtProfesor.Text = string.Empty;
            txtPorcentajeAsistencia.Text = string.Empty;
            txtHoraCatedra.Text = string.Empty;
            txtCantidadAlumnos.Text = string.Empty;
            txtCantidadAlumnosRecursantes.Text = string.Empty;
            txtCantidadAlumnosDesertores.Text = string.Empty;
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

                    bool esFilaResumen = dgvAsistencias.Columns["__EsResumen__"] != null
                        && dgvAsistencias.Rows[info.RowIndex].Cells["__EsResumen__"].Value != null
                        && Convert.ToBoolean(dgvAsistencias.Rows[info.RowIndex].Cells["__EsResumen__"].Value);
                    bool puedeEditarAsistencia = _enVistaDetalle
                        && !esFilaResumen
                        && dgvAsistencias.Columns["Asistencia"] != null
                        && dgvAsistencias.Columns[info.ColumnIndex].Name == "Asistencia";

                    var asistenciaValue = puedeEditarAsistencia
                        ? dgvAsistencias.Rows[info.RowIndex].Cells["Asistencia"].Value
                        : null;
                    bool yaTieneAsistencia = asistenciaValue != null && !string.IsNullOrEmpty(asistenciaValue.ToString());

                    if (puedeEditarAsistencia)
                    {
                        tsmP.Visible = !yaTieneAsistencia;
                        tsmA.Visible = !yaTieneAsistencia;
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
            if (dgvAsistencias.Columns["Asistencia"] is null) return;

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

            if (dgvAsistencias.Columns["Asistencia"] is null) return false;

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
                    // Agrupar filas por CursadaId para soportar múltiples cursadas
                    var filasPorCursada = new System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<int>>();

                    for (int i = 0; i < dgvAsistencias.Rows.Count; i++)
                    {
                        int cursadaId = Convert.ToInt32(dgvAsistencias.Rows[i].Cells["CursadaId"].Value);
                        if (!filasPorCursada.ContainsKey(cursadaId))
                            filasPorCursada[cursadaId] = new System.Collections.Generic.List<int>();
                        filasPorCursada[cursadaId].Add(i);
                    }

                    foreach (var grupo in filasPorCursada)
                    {
                        int cursadaId = grupo.Key;
                        var indices = grupo.Value;

                        var cursadaActual = this.cursadasLogica.ObtenerCursada(cursadaId);
                        if (cursadaActual == null) continue;

                        int totalModulos = cursadaActual.HoraCatedra + cursadaActual.ModulosMateria;
                        double totalPorcentajes = 0;

                        foreach (int i in indices)
                        {
                            if (dgvAsistencias.Rows[i].Cells["Asistencia"].Value == null) continue;

                            int modulosCursadas = Convert.ToInt32(dgvAsistencias.Rows[i].Cells["Modulos"].Value);

                            if (dgvAsistencias.Rows[i].Cells["Asistencia"].Value.ToString() == "P")
                            {
                                modulosCursadas += cursadaActual.ModulosMateria;
                            }

                            double porcentaje = totalModulos > 0 ? modulosCursadas * 100.0 / totalModulos : 0;
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

                        double promedioCursada = indices.Count > 0 ? totalPorcentajes / indices.Count : 0;

                        var cursadaModelo = new AsistenciasModelo
                        {
                            HorasCursadas = totalModulos,
                            FechaAsistencia = dtpFechaAsistencia.Value,
                            PorcentajeAsistencia = promedioCursada,
                            CursadaId = cursadaId
                        };

                        controlAsistenciasLogica.ActualizarCursada(cursadaModelo);
                    }

                    this.RellenarGrilla();
                    Notificar(TipoNotificacion.Success, "Asistencias agregadas con éxito");
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

            //cmbCicloLectivo.DataSource = null;
            //cmbCicloLectivo.SelectedIndex = -1;
            //cmbCicloLectivo.Enabled = false;

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

            //cmbCicloLectivo.DataSource = null;
            //cmbCicloLectivo.SelectedIndex = -1;
            //cmbCicloLectivo.Enabled = false;

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
        //
        //private void btnAplicarFiltros_Click(object sender, EventArgs e)
        //{
        //    this.RellenarGrilla();
        //}

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

            //cmbCicloLectivo.DataSource = null;
            //cmbCicloLectivo.SelectedIndex = -1;
            //cmbCicloLectivo.Enabled = false;
        }

        private void btnFiltrarAsistencias_Click(object sender, EventArgs e)
        {
            if(cmbCarrera.SelectedValue == null )
            {
                Notificar(TipoNotificacion.Warning, "Seleccione al menos un filtro para aplicar");
                return;
            }
            this.RellenarGrilla();
        }

        private void btnFiltrarEvaluaciones_Click(object sender, EventArgs e)
        {
            this.LimpiarGrilla();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            this.LimpiarFiltros();
            this.LimpiarGrilla();
        }

        private void LimpiarGrilla()
        {
            
            dgvAsistencias.DataSource = null;
            dgvAsistencias.Rows.Clear();
            dgvAsistencias.ClearSelection();

            this.LimpiarControlesInformativos();
        }

        private void LimpiarFiltros()
        {
            _enCambioCombos = true;

            cmbCarrera.DataSource = null;
            cmbCarrera.Items.Clear();
            cmbCarrera.Text = string.Empty;
            cmbCarrera.SelectedIndex = -1;

            cmbProfesor.DataSource = null;
            cmbProfesor.Items.Clear();
            cmbProfesor.Text = string.Empty;
            cmbProfesor.SelectedIndex = -1;

            cmbAnio.DataSource = null;
            cmbAnio.Items.Clear();
            cmbAnio.Text = string.Empty;
            cmbAnio.SelectedIndex = -1;
            cmbAnio.Enabled = false;

            cmbCurso.DataSource = null;
            cmbCurso.Items.Clear();
            cmbCurso.Text = string.Empty;
            cmbCurso.SelectedIndex = -1;
            cmbCurso.Enabled = false;

            cmbMateria.DataSource = null;
            cmbMateria.Items.Clear();
            cmbMateria.Text = string.Empty;
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = false;

            //cmbCicloLectivo.DataSource = null;
            //cmbCicloLectivo.Items.Clear();
            //cmbCicloLectivo.Text = string.Empty;
            //cmbCicloLectivo.SelectedIndex = -1;
            //cmbCicloLectivo.Enabled = false;

            carrerasCargadas = false;
            profesoresCargados = false;
            ciclosLectivosCargados = false;

            _enCambioCombos = false;
        }

        private void FormControlAsistencias_Shown(object sender, EventArgs e)
        {
            CargarCiclosLectivos();

            //cmbCicloLectivo.SelectedIndex = 0;
        }

        private void MostrarResumenCursada()
        {
            dgvAsistencias.DataSource = _dtResumenCursada;

            if (dgvAsistencias.Columns["CursadaId"] != null)
            {
                dgvAsistencias.Columns["CursadaId"].Visible = true;
                dgvAsistencias.Columns["CursadaId"].HeaderText = "Numero";
            }

            foreach (DataGridViewRow row in dgvAsistencias.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(235, 228, 252);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(27, 1, 124);
                row.DefaultCellStyle.Font = new Font(dgvAsistencias.Font, FontStyle.Bold);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(27, 1, 124);
                row.DefaultCellStyle.SelectionForeColor = Color.White;
            }

            _enVistaDetalle = false;
        }


        private void dgvAsistencias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (_enVistaDetalle)
            {
                MostrarResumenCursada();
                return;
            }

            if (_dtResumenAlumnos is null || _dtResumenCursada is null) return;

            var celdaCursada = dgvAsistencias.Rows[e.RowIndex].Cells["CursadaId"];
            if (celdaCursada is null || celdaCursada.Value is null) return;

            int cursadaId = Convert.ToInt32(celdaCursada.Value);

            var filasAlumnos = _dtResumenAlumnos.AsEnumerable()
                .Where(r => r.Field<int>("CursadaId") == cursadaId)
                .ToList();

            if (filasAlumnos.Count == 0) return;

            var dtDetalle = filasAlumnos.CopyToDataTable();
            dtDetalle.Columns.Add("__EsResumen__", typeof(bool));
            foreach (DataRow row in dtDetalle.Rows)
                row["__EsResumen__"] = false;

            var resumen = _dtResumenCursada.AsEnumerable()
                .FirstOrDefault(r => r.Field<int>("CursadaId") == cursadaId);

            if (resumen != null)
            {
                var header = dtDetalle.NewRow();
                header["CursadaId"] = cursadaId;
                header["Nro"] = 0L;
                header["Apellidos y Nombres"] = resumen["Materia"].ToString();
                header["DNI"] = $"{resumen["Cant/Alumnos"]} alumnos";
                header["Condicion"] = $"Rec: {resumen["Cant/Recursantes"]}  Des: {resumen["Cant/Desertores"]}";
                header["H/Cursadas"] = resumen["H/Catedras"];
                header["Ult/Presentismo"] = resumen.IsNull("Fech/Asistencia") ? DBNull.Value : resumen["Fech/Asistencia"];
                header["% Asistencia"] = resumen["Porcentaje"];
                header["__EsResumen__"] = true;
                dtDetalle.Rows.InsertAt(header, 0);
            }

            dgvAsistencias.DataSource = dtDetalle;

            if (dgvAsistencias.Columns["CursadaId"] != null)
                dgvAsistencias.Columns["CursadaId"].Visible = false;
            if (dgvAsistencias.Columns["CursadaAlumnoCarreraId"] != null)
                dgvAsistencias.Columns["CursadaAlumnoCarreraId"].Visible = false;
            if (dgvAsistencias.Columns["Modulos"] != null)
                dgvAsistencias.Columns["Modulos"].Visible = false;
            if (dgvAsistencias.Columns["__EsResumen__"] != null)
                dgvAsistencias.Columns["__EsResumen__"].Visible = false;
            if (dgvAsistencias.Columns["Nro"] != null)
                dgvAsistencias.Columns["Nro"].Visible = false;

            
            if (dgvAsistencias.Rows.Count > 0)
            {
                var filaHeader = dgvAsistencias.Rows[0];
                filaHeader.DefaultCellStyle.BackColor = Color.FromArgb(27, 1, 124);
                filaHeader.DefaultCellStyle.ForeColor = Color.White;
                filaHeader.DefaultCellStyle.Font = new Font(dgvAsistencias.Font, FontStyle.Bold);
                filaHeader.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 20, 160);
                filaHeader.DefaultCellStyle.SelectionForeColor = Color.White;
            }

            _enVistaDetalle = true;
        }

    }
}
