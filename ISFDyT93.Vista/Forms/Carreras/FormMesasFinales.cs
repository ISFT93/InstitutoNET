using ISFDyT93.Datos.Daos;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Interfaces;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Common;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormMesasFinales : FormBase
    {
        #region Publics

        public int CarreraId { get; set; }
        public string NombreCarrera { get; set; }
        public int AnioLectivoId { get; set; }
        public int TurnoId { get; set; }
        public bool FechaUnica { get; set; }
        public int LlamadoId { get; set; }
        #endregion

        #region Privates
        MesasFinalesLogica mesasFinalesLogica;
        private int MesaFinalId, anioLectivoId, turnoId, llamadoId;
        private DateTime Fecha;

        // DAOs para filtros
        private CarrerasDao _carrerasDao = new CarrerasDao();
        private PersonalDao _personalDao = new PersonalDao();
        private AniosCarreraDao _aniosCarrerasDao = new AniosCarreraDao();
        private CursosDao _cursosDao = new CursosDao();
        private MateriasDao _materiasDao = new MateriasDao();
        private ServiciosDao _serviciosDao = new ServiciosDao();

        private bool carrerasCargadas = false;
        private bool profesoresCargados = false;
        private bool _enCambioCombos = false;

        #endregion
        public FormMesasFinales()
        {
            InitializeComponent();
            mesasFinalesLogica = new MesasFinalesLogica();
        }

        private void FormMesasFinales_Load(object sender, EventArgs e)
        {
            if (this.CarreraId > 0)
            {
                Contenedor.SetTitulo($"Mesas Finales de {NombreCarrera}").SetVolver(() =>
                {
                    this.Contenedor.AbrirFormulario<FormCarreras>();
                });
            }
            else
            {
                Contenedor.SetTitulo("Mesas Finales").SetVolver(() =>
                {
                    this.Contenedor.AbrirFormulario<FormHome>();
                });
            }



            // Inicializar combos de filtros en vacío
            cmbCarrera.DataSource = null;
            cmbCarrera.Items.Clear();
            cmbCarrera.Text = "";
            cmbCarrera.SelectedIndex = -1;

            cmbProfesor.DataSource = null;
            cmbProfesor.Items.Clear();
            cmbProfesor.Text = "";
            cmbProfesor.SelectedIndex = -1;

            cmbAnio.DataSource = null;
            cmbAnio.Items.Clear();
            cmbAnio.Text = "";
            cmbAnio.SelectedIndex = -1;

            cmbCurso.DataSource = null;
            cmbCurso.Items.Clear();
            cmbCurso.Text = "";
            cmbCurso.SelectedIndex = -1;

            cmbMateria.DataSource = null;
            cmbMateria.Items.Clear();
            cmbMateria.Text = "";
            cmbMateria.SelectedIndex = -1;

            cmbAnio.Enabled = false;
            cmbCurso.Enabled = false;
            cmbMateria.Enabled = false;

            // Si viene con CarreraId preseleccionado, cargarlo
            if (this.CarreraId == 0)
            {
                CargarCarreras();
                cmbCarrera.SelectedValue = this.CarreraId;
            }

            CargarTurnos();
            if (LlamadoId != 0 && !FechaUnica)
                CargarLlamados(false);
            else
                CargarLlamados(true);
            CargarAniosLectivos();
            ControlLlamados();

            // Grilla vacía al inicio
            dgvMesasFinales.DataSource = null;
            dgvMesasFinales.Rows.Clear();

            cmbCarrera.SelectedValue = 1;
        }

        LibroActasLogica libroActasLogica = new LibroActasLogica();
        public int obtenerFolio(int idcarrera)
        {
            foreach (DataRow row in libroActasLogica.ObtenerLibros().Rows)
            {
                if (row["CarreraID"] != DBNull.Value &&
                    Convert.ToInt32(row["CarreraID"]) == idcarrera)
                {
                    return Convert.ToInt32(row["FolioNumero"]);
                }
            }
            return 0;
        }
        private void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            int carreraSeleccionada = this.CarreraId;
            if (cmbCarrera.SelectedValue != null && int.TryParse(cmbCarrera.SelectedValue.ToString(), out int cid))
                carreraSeleccionada = cid;

            if (carreraSeleccionada <= 0)
            {
                Notificar(TipoNotificacion.Warning, "Debe seleccionar una carrera para agregar una mesa especial");
                return;
            }

            if (cmbAnioLectivo.SelectedValue == null || !int.TryParse(cmbAnioLectivo.SelectedValue.ToString(), out int anioLectivoSeleccionado))
            {
                Notificar(TipoNotificacion.Warning, "Debe seleccionar un ciclo lectivo válido para agregar una mesa especial");
                return;
            }

            Contenedor.AbrirFormulario<FormAgregarFechasFinales>(form =>
            {
                form.Accion = TipoAccion.Agregar;
                form.CarreraId = carreraSeleccionada;
                form.NombreCarrera = this.NombreCarrera;
                form.AnioLectivoId = anioLectivoSeleccionado;
            });
        }

        private void CargarTurnos()
        {
            DataTable dt= mesasFinalesLogica.ObtenerTurnos(true);
            if(dt.Rows.Count>0)
            {  
            cmbTurno.DataSource = dt;
            cmbTurno.DisplayMember = "Descripcion";
            cmbTurno.ValueMember = "TurnoId";
            if (TurnoId != 0)
            {
                cmbTurno.SelectedValue = this.TurnoId;
                if (cmbTurno.SelectedValue != null && int.TryParse(cmbTurno.SelectedValue.ToString(), out int tid))
                    turnoId = tid;
            }
            else
            {
                cmbTurno.SelectedIndex = -1;
                turnoId = 0;
            }
            }
        }

        private void CargarLlamados(bool fechaUnica)
        {
            DataTable dt=new DataTable();
            try
            { 
             dt = mesasFinalesLogica.ObtenerLlamados(fechaUnica);
            }
            catch (Exception ex)
             {
              }
            if (dt.Rows.Count > 0)
            {
                cmbLlamados.DataSource = dt;
                cmbLlamados.DisplayMember = "Descripcion";
                cmbLlamados.ValueMember = "LlamadoId";
            }
            if (LlamadoId != 0)
            {
                cmbLlamados.SelectedValue = this.LlamadoId;
                this.LlamadoId = 0;
                if (cmbLlamados.SelectedValue != null && int.TryParse(cmbLlamados.SelectedValue.ToString(), out int lid))
                    llamadoId = lid;
            }
            else
            {
                cmbLlamados.SelectedIndex = -1;
                llamadoId = 0;
            }
        }

        private void CargarAniosLectivos()
        {
            DataTable dt = mesasFinalesLogica.ObtenerAniosLectivos();
            if (dt.Rows.Count > 0)
            {
                cmbAnioLectivo.DataSource = dt;
                cmbAnioLectivo.DisplayMember = "CicloLectivoId";
                cmbAnioLectivo.ValueMember = "CicloLectivoId";
                if (AnioLectivoId != 0)
                    cmbAnioLectivo.SelectedValue = this.AnioLectivoId;
                if (cmbAnioLectivo.SelectedValue != null && int.TryParse(cmbAnioLectivo.SelectedValue.ToString(), out int aid))
                    anioLectivoId = aid;
            }
        }

        private void cmbAnioLectivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            anioLectivoId = (int)cmbAnioLectivo.SelectedValue;
        }

        private void cmbLlamados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            llamadoId = (int)cmbLlamados.SelectedValue;
        }

        private void cmbTurno_SelectionChangeCommitted(object sender, EventArgs e)
        {
            turnoId = (int)cmbTurno.SelectedValue;
            ControlLlamados();
        }

        private void btnReporteMesas_Click(object sender, EventArgs e)
        {
            if (dgvMesasFinales.CurrentRow == null)
            {
                Notificar(TipoNotificacion.Warning, "Debe seleccionar una mesa para imprimir");
                return;
            }

            int mesaFinalId = Convert.ToInt32(dgvMesasFinales.CurrentRow.Cells["MesaFinalId"].Value);
            var data = this.mesasFinalesLogica.ObtenerMesaReporte(mesaFinalId);
            string carreraReporte = data.Rows.Count > 0 ? Convert.ToString(data.Rows[0]["Carrera"]) : string.Empty;

            this.Contenedor.SetTitulo("Imprimir Fechas Finales").AbrirFormulario<FormReporte>(form => {
                form.SetReporte("ISFDyT93.Vista.Reports.MesasFinales.rdlc")
                .AddDataSource(data, "DSMesasFinales")
                .AddParameter("Carrera", carreraReporte)
                .AddParameter("Turno", Convert.ToString(dgvMesasFinales.CurrentRow.Cells["Turno"].Value))
                .AddParameter("Llamado", Convert.ToString(dgvMesasFinales.CurrentRow.Cells["Llamado"].Value))
                .AddParameter("AnioLectivo", cmbAnioLectivo.Text);
            });
        }

        private void dgvMesasFinales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int carreraSeleccionada = this.CarreraId;
            if (cmbCarrera.SelectedValue != null && int.TryParse(cmbCarrera.SelectedValue.ToString(), out int cid))
                carreraSeleccionada = cid;

            
            if (cmbTurno.SelectedValue == null)
            {
                this.Notificar(TipoNotificacion.Error, "debe de seleccionar un turno para poder agregar una nuevo mesa final");
                return;
            }
            if ((int)cmbTurno.SelectedValue == 3)
            {
                if (cmbLlamados.SelectedValue == null)
                {
                    this.Notificar(TipoNotificacion.Error, "debe de seleccionar un llamado para poder agregar una nuevo mesa final");
                    return;
                }
            }
            Contenedor.AbrirFormulario<FormAgregarFechasFinales>(form =>
            {
                form.Accion = TipoAccion.Modificar;
                form.CarreraId = carreraSeleccionada;
                form.NombreCarrera = this.NombreCarrera;
                form.MesaFinalId = (int)dgvMesasFinales.Rows[e.RowIndex].Cells["MesaFinalId"].Value;
                form.Fecha = DateTime.Now;
                form.AnioLectivoId = (int)cmbAnioLectivo.SelectedValue;
                form.TurnoId = (int)cmbTurno.SelectedValue;
                if (cmbLlamados.SelectedValue != null)
                    {
                form.LlamadoId = (int)cmbLlamados.SelectedValue; }
            });
        }

        private void DGVRefresh()
        {
            int filtroCarreraId = 0;
            int filtroAnioCarreraId = 0;
            int filtroCursoId = 0;
            int filtroMateriaId = 0;
            int filtroProfesorId = 0;

            if (cmbCarrera.SelectedValue != null && int.TryParse(cmbCarrera.SelectedValue.ToString(), out int cid))
                filtroCarreraId = cid;
            if (cmbAnio.SelectedValue != null && int.TryParse(cmbAnio.SelectedValue.ToString(), out int aid))
                filtroAnioCarreraId = aid;
            if (cmbCurso.SelectedValue != null && int.TryParse(cmbCurso.SelectedValue.ToString(), out int cuid))
                filtroCursoId = cuid;
            if (cmbMateria.SelectedValue != null && int.TryParse(cmbMateria.SelectedValue.ToString(), out int mid))
                filtroMateriaId = mid;
            if (cmbProfesor.SelectedValue != null && int.TryParse(cmbProfesor.SelectedValue.ToString(), out int pid))
                filtroProfesorId = pid;

            dgvMesasFinales.DataSource = mesasFinalesLogica.ObtenerMesasFiltro(
                filtroCarreraId, anioLectivoId, turnoId, llamadoId,
                filtroAnioCarreraId, filtroCursoId, filtroMateriaId, filtroProfesorId);

            if (dgvMesasFinales.Columns["MesaFinalId"] != null)
                dgvMesasFinales.Columns["MesaFinalId"].Visible = false;
            if (dgvMesasFinales.Columns["Turno"] != null)
                dgvMesasFinales.Columns["Turno"].Visible = false;
            if (dgvMesasFinales.Columns["Llamado"] != null)
                dgvMesasFinales.Columns["Llamado"].Visible = false;

            if (dgvMesasFinales.Rows.Count > 0)
            {
                btnReporteMesas.Enabled = true;
                btnReporteMesas.BackColor = System.Drawing.Color.FromArgb(39, 39, 58);
            }
        }

        private void ControlLlamados()
        {
            if (cmbTurno.SelectedValue == null || !int.TryParse(cmbTurno.SelectedValue.ToString(), out int turnoSeleccionado))
            {
                CargarLlamados(true);
                cmbLlamados.SelectedIndex = -1;
                cmbLlamados.Enabled = true;
                llamadoId = 0;
                return;
            }

            turnoId = turnoSeleccionado;

            if (turnoSeleccionado != 3)
            {
                CargarLlamados(true);
                cmbLlamados.Enabled = false;
            }
            else
            {
                CargarLlamados(false);
                cmbLlamados.Enabled = true;
            }
        }
        private void dgvMesasFinales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMesasFinales.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();

                Color foreColor = Color.Black; // Color por defecto
                Color backColor = Color.White; // Fondo por defecto

                switch (estado)
                {
                    case "Activo":
                        foreColor = Color.Green;
                        break;

                    case "Inactivo":
                        foreColor = Color.FromArgb(230, 250, 0);
                        break;

                    case "Borrador":
                        foreColor = Color.Red;
                        break;
                }

                e.CellStyle.BackColor = backColor;
                e.CellStyle.ForeColor = foreColor;

                // Esto mantiene los colores aunque la celda esté seleccionada
                e.CellStyle.SelectionBackColor = Color.LightGray;
                e.CellStyle.SelectionForeColor = foreColor;
            }
        }

        #region Filtros en cascada

        private void CargarCarreras()
        {
            DataTable dt = _carrerasDao.CarrerasActivas();
            cmbCarrera.DataSource = dt;
            cmbCarrera.ValueMember = "CarreraId";
            cmbCarrera.DisplayMember = "Nombre";
            cmbCarrera.SelectedIndex = -1;
        }

        private void cmbCarrera_DropDown(object sender, EventArgs e)
        {
            if (carrerasCargadas) return;
            CargarCarreras();
            carrerasCargadas = true;
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

            this.CarreraId = carreraId;
            this.NombreCarrera = cmbCarrera.Text;
            CargarAniosPorCarrera(carreraId);
            cmbAnio.Enabled = true;

            _enCambioCombos = false;
        }

        private void CargarAniosPorCarrera(int carreraId)
        {
            DataTable dt = _aniosCarrerasDao.ObtenerAniosCarrera(carreraId);
            cmbAnio.DataSource = dt;
            cmbAnio.ValueMember = "AnioCarreraId";
            cmbAnio.DisplayMember = "Año";
            cmbAnio.SelectedIndex = -1;
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCurso.DataSource = null;
            cmbCurso.SelectedIndex = -1;
            cmbCurso.Enabled = false;

            cmbMateria.DataSource = null;
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = false;

            if (cmbAnio.SelectedValue == null) return;

            int anioCarreraId;
            if (!int.TryParse(cmbAnio.SelectedValue.ToString(), out anioCarreraId)) return;

            CargarCursosPorAnio(anioCarreraId);
            cmbCurso.Enabled = true;
        }

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

        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.DataSource = null;
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = false;

            if (cmbCurso.SelectedValue == null) return;
            if (cmbAnio.SelectedValue == null) return;

            int anioCarreraId;
            if (!int.TryParse(cmbAnio.SelectedValue.ToString(), out anioCarreraId)) return;

            CargarMateriasPorAnio(anioCarreraId);
            cmbMateria.Enabled = true;
        }

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

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No hay más combos dependientes
        }

        private void CargarProfesores()
        {
            DataTable dt = _personalDao.ObtenerProfesoresParaCombo(1);
            cmbProfesor.DataSource = dt;
            cmbProfesor.ValueMember = "PersonalId";
            cmbProfesor.DisplayMember = "NombreCompleto";
            cmbProfesor.SelectedIndex = -1;
        }

        private void cmbProfesor_DropDown(object sender, EventArgs e)
        {
            if (profesoresCargados) return;
            CargarProfesores();
            profesoresCargados = true;
        }

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

            cmbMateria.DataSource = dv.ToTable(true, "MateriaId", "Servicio");
            cmbMateria.ValueMember = "MateriaId";
            cmbMateria.DisplayMember = "Servicio";
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = true;

            _enCambioCombos = false;
        }

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
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            DGVRefresh();
            int id = Convert.ToInt32(cmbCarrera.SelectedValue);
            if(obtenerFolio(id) >= 170)
            {
            this.Contenedor.AbrirUserControlEmergente<FolioExamenControl>(control =>
            {
                control.CargarDatos(id);
            }); 
            }


        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
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

            carrerasCargadas = false;
            profesoresCargados = false;

            _enCambioCombos = false;

            dgvMesasFinales.DataSource = null;
            dgvMesasFinales.Rows.Clear();
        }

        #endregion
    }
}
