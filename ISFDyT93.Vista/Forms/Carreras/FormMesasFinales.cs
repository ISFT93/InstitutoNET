using System;
using System.Data;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Forms.Common;
using ISFDyT93.Vista;
using ISFDyT93.Datos.Daos;
using System.Diagnostics;

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
            if (this.CarreraId > 0)
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
        }

        private void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            int carreraSeleccionada = this.CarreraId;
            if (cmbCarrera.SelectedValue != null && int.TryParse(cmbCarrera.SelectedValue.ToString(), out int cid))
                carreraSeleccionada = cid;

            Contenedor.AbrirFormulario<FormAgregarFechasFinales>(form =>
            {
                form.Accion = TipoAccion.Agregar;
                form.CarreraId = carreraSeleccionada;
                form.NombreCarrera = this.NombreCarrera;
                form.AnioLectivoId = Convert.ToInt32(cmbAnioLectivo.SelectedValue);
            });
        }

        private void CargarTurnos()
        {
            cmbTurno.DataSource = mesasFinalesLogica.ObtenerTurnos(true);
            cmbTurno.DisplayMember = "Descripcion";
            cmbTurno.ValueMember = "TurnoId";
            if (TurnoId != 0)
                cmbTurno.SelectedValue = this.TurnoId;
            turnoId = (int)cmbTurno.SelectedValue;
        }

        private void CargarLlamados(bool fechaUnica)
        {
            cmbLlamados.DataSource = mesasFinalesLogica.ObtenerLlamados(fechaUnica);
            cmbLlamados.DisplayMember = "Descripcion";
            cmbLlamados.ValueMember = "LlamadoId";

            if (LlamadoId != 0)
            {
                cmbLlamados.SelectedValue = this.LlamadoId;
                cmbLlamados.Text = "Text";
                this.LlamadoId = 0;
            }

            llamadoId = (int)cmbLlamados.SelectedValue;
        }

        private void CargarAniosLectivos()
        {
            cmbAnioLectivo.DataSource = mesasFinalesLogica.ObtenerAniosLectivos();
            cmbAnioLectivo.DisplayMember = "CicloLectivoId";
            cmbAnioLectivo.ValueMember = "CicloLectivoId";
            if (AnioLectivoId != 0)
                cmbLlamados.SelectedValue = this.AnioLectivoId;
            anioLectivoId = (int)cmbAnioLectivo.SelectedValue;
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
            int carreraSeleccionada = this.CarreraId;
            if (cmbCarrera.SelectedValue != null && int.TryParse(cmbCarrera.SelectedValue.ToString(), out int cid))
                carreraSeleccionada = cid;

            var data = this.mesasFinalesLogica.ObtenerMesasReporte(carreraSeleccionada, anioLectivoId, turnoId, llamadoId);

            this.Contenedor.SetTitulo("Imprimir Fechas Finales").AbrirFormulario<FormReporte>(form => {
                form.SetReporte("ISFDyT93.Vista.Reports.MesasFinales.rdlc")
                .AddDataSource(data, "DSMesasFinales")
                .AddParameter("Carrera", this.NombreCarrera)
                .AddParameter("Turno", cmbTurno.Text)
                .AddParameter("Llamado", cmbLlamados.Text)
                .AddParameter("AnioLectivo", cmbAnioLectivo.Text);
            });
        }

        private void dgvMesasFinales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int carreraSeleccionada = this.CarreraId;
            if (cmbCarrera.SelectedValue != null && int.TryParse(cmbCarrera.SelectedValue.ToString(), out int cid))
                carreraSeleccionada = cid;

            Contenedor.AbrirFormulario<FormAgregarFechasFinales>(form =>
            {
                form.Accion = TipoAccion.Modificar;
                form.CarreraId = carreraSeleccionada;
                form.NombreCarrera = this.NombreCarrera;
                form.MesaFinalId = (int)dgvMesasFinales.Rows[e.RowIndex].Cells["MesaFinalId"].Value;
                form.Fecha = DateTime.Now;
                form.AnioLectivoId = (int)cmbAnioLectivo.SelectedValue;
                form.TurnoId = (int)cmbTurno.SelectedValue;
                form.LlamadoId = (int)cmbLlamados.SelectedValue;
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
        }

        private void ControlLlamados()
        {
            if ((int)cmbTurno.SelectedValue != 3)
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

            cmbMateria.DataSource = dv.ToTable();
            cmbMateria.ValueMember = "CursoMateriaId";
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
