using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
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
    public partial class FormAgregarFechasFinales : FormBase
    {
        #region Publics
        public int CarreraId { get; set; }
        public string NombreCarrera { get; set; }
        public int MesaFinalId { get; set; }
        public DateTime Fecha { get; set; }
        public TipoAccion Accion { get; set; }

        public int AnioLectivoId { get; set; }
        public int TurnoId { get; set; }
        public int LlamadoId { get; set; }
        #endregion

        #region Privates
        private MateriasLogica materiasLogica;

        private CarrerasDao _carrerasDao;
        private MesasFinalesLogica mesasFinalesLogica;
        private DateTime fecha;
        private string title;
        #endregion

        public FormAgregarFechasFinales()
        {
            InitializeComponent();
            
            _carrerasDao = new CarrerasDao();
            materiasLogica = new MateriasLogica();
            mesasFinalesLogica = new MesasFinalesLogica(); 
            cmbMateria.SelectedIndexChanged += cmbMateria_SelectedIndexChanged;
            //cmbPresidenteMesa.SelectedIndexChanged += cmbPresidenteMesa_SelectedIndexChanged;
        }

        private void FormAgregarMesas_Load(object sender, EventArgs e)
        {
            //dtpFechaMesa.MinDate = DateTime.Today.AddDays(1);
            //dtpFechaMesa.Value = DateTime.Today.AddDays(1);

            CargarCarreras();
            if (this.Accion == TipoAccion.Agregar)
            {
                CargarMaterias();
                CargarTurnoMateria(true);
                cmbMateria.Enabled = true;
                title = "Agregar fecha especial";
            }

            if (this.Accion == TipoAccion.Modificar)
            {
                cmbCarrera.SelectedValue = this.CarreraId;
                CargarTurnoMateria(false);
                CargarProfesorTitular();
                CargarVocales(0);
                title = "Asignar fecha y vocal";
            }

            Contenedor.SetTitulo(title).SetVolver(() =>
            {
                Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                {
                    form.CarreraId = this.CarreraId;
                    form.NombreCarrera = this.NombreCarrera;
                    form.AnioLectivoId = this.AnioLectivoId;
                    form.TurnoId = this.TurnoId;
                    form.LlamadoId = this.LlamadoId;
                    if (this.LlamadoId == 3)
                        form.FechaUnica = true;
                });
            });
        }
        private void CargarCarreras()
        {
            DataTable dt = _carrerasDao.CarrerasActivas();

            DataRow fila = dt.NewRow();
            fila["CarreraId"] = 0;
            fila["Nombre"] = "Seleccione una carrera";
            fila["CarreraEstadoId"] = 0;

            dt.Rows.InsertAt(fila, 0);

            // IMPORTANTE: primero estos
            cmbCarrera.ValueMember = "CarreraId";
            cmbCarrera.DisplayMember = "Nombre";

            // DataSource al final
            cmbCarrera.DataSource = dt;

            cmbCarrera.SelectedIndex = 0;

            cmbMateria.Enabled = true;
        }
        private void CargarMaterias()
        {
            if (cmbCarrera.SelectedValue == null ||
        !int.TryParse(cmbCarrera.SelectedValue.ToString(), out int carreraId))
                return;

            if (carreraId == 0)
            {
                cmbMateria.Enabled = cmbMateria.Items.Count < 0;
                cmbMateria.DataSource = null;
                return;
            }

            cmbMateria.DataSource = materiasLogica.MateriasId(carreraId);
            cmbMateria.ValueMember = "MateriaId";
            cmbMateria.DisplayMember = "Nombre";
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = cmbMateria.Items.Count > 0;

            ValidarCampos();
        }

        private void CargarProfesorTitular()
        {
            if (cmbMateria.SelectedValue == null || !int.TryParse(cmbMateria.SelectedValue.ToString(), out int materiaId)) return;

            //cmbPresidenteMesa.DataSource = mesasFinalesLogica.ObtenerProfesorTitular(materiaId);
           // cmbPresidenteMesa.ValueMember = "PersonalId";
            //cmbPresidenteMesa.DisplayMember = "Nombre";
            //cmbPresidenteMesa.SelectedIndex = -1;
            //cmbPresidenteMesa.Enabled = cmbPresidenteMesa.Items.Count > 0;
            ValidarCampos();
        }
        private void CargarVocales(int PersonalId)
        {
            //cmbVocalMesa.DataSource = mesasFinalesLogica.ObtenerVocales(this.CarreraId, PersonalId);
            //cmbVocalMesa.ValueMember = "PersonalId";
            //cmbVocalMesa.DisplayMember = "Nombre";
            //cmbVocalMesa.SelectedIndex = -1;
            //cmbVocalMesa.Enabled = cmbVocalMesa.Items.Count > 0;
            ValidarCampos();
        }

        private void dtpFechaMesa_ValueChanged(object sender, EventArgs e)
        {
            //dtpFechaMesa.CustomFormat = "dd/MM/yyyy";
            ValidarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (this.Accion == TipoAccion.Modificar)
            {
                int res = mesasFinalesLogica.ModificarMesa(fecha, Convert.ToInt32(cmbTurno.SelectedValue), 0, 0, this.MesaFinalId);
                if (res > 0)
                {
                    Notificar(TipoNotificacion.Success, "Mesa modificada correctamente");
                    Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                    {
                        form.CarreraId = this.CarreraId;
                        form.NombreCarrera = this.NombreCarrera;
                        form.AnioLectivoId = this.AnioLectivoId;
                        form.TurnoId = this.TurnoId;
                        form.LlamadoId = this.LlamadoId;
                        if (this.LlamadoId == 3)
                            form.FechaUnica = true;
                    });
                }
                else
                    Notificar(TipoNotificacion.Error, "Ocurrió un error");
            }
            if (this.Accion == TipoAccion.Agregar)
            {
                int res = mesasFinalesLogica.AgregarMesa(Convert.ToInt32(cmbCarrera.SelectedValue), fecha, 4, 3, Convert.ToInt32(cmbMateria.SelectedValue), 0, 0, this.AnioLectivoId);
                if (res > 0)
                {
                    Notificar(TipoNotificacion.Success, "Mesa agregada correctamente");
                    Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                    {
                        form.CarreraId = this.CarreraId;
                        form.NombreCarrera = this.NombreCarrera;
                        form.AnioLectivoId = this.AnioLectivoId;
                        form.TurnoId = this.TurnoId;
                        form.LlamadoId = this.LlamadoId;
                        if (this.LlamadoId == 3)
                            form.FechaUnica = true;
                    });
                }
                else
                    Notificar(TipoNotificacion.Error, "Ocurrió un error");
            }

        }
        private void ValidarCampos()
        {
            bool carreraValida =
                cmbCarrera.SelectedValue != null &&
                int.TryParse(cmbCarrera.SelectedValue.ToString(), out int carreraId) &&
                carreraId > 0;

            bool turnoValido =
                cmbTurno.SelectedIndex >= 0;

            bool materiaValida =
                cmbMateria.Enabled &&
                cmbMateria.SelectedValue != null &&
                int.TryParse(cmbMateria.SelectedValue.ToString(), out int materiaId) &&
                materiaId > 0;

            btnAgregar.Enabled =
                carreraValida &&
                turnoValido &&
                materiaValida;
        }

        private void CargarTurnoMateria(bool especial)
        {
            switch (this.Accion)
            {
                case TipoAccion.Agregar:
                    {
                        DataTable turnos = mesasFinalesLogica.ObtenerTurnos(especial);
                        cmbTurno.DataSource = turnos;
                        cmbTurno.DisplayMember = "Descripcion";
                        cmbTurno.ValueMember = "TurnoId";
                        cmbTurno.Enabled = turnos.Rows.Count > 0;
                        if (turnos.Rows.Count > 0)
                        {
                            cmbTurno.SelectedValue = 4;
                            if (cmbTurno.SelectedIndex < 0)
                                cmbTurno.SelectedIndex = 0;
                        }
                        ValidarCampos();
                        break;
                    }
                case TipoAccion.Modificar:
                    {
                        cmbTurno.DataSource = mesasFinalesLogica.ObtenerTurnoMesa(this.MesaFinalId);
                        cmbTurno.DisplayMember = "Descripcion";
                        cmbTurno.ValueMember = "TurnoId";
                        cmbMateria.DataSource = mesasFinalesLogica.ObtenerMateriaFinal(this.MesaFinalId);
                        cmbMateria.DisplayMember = "Nombre";
                        cmbMateria.ValueMember = "MateriaId";
                        break;
                    }
            }
        }

        private void cmbPresidenteMesa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (cmbPresidenteMesa.SelectedValue != null && int.TryParse(cmbPresidenteMesa.SelectedValue.ToString(), out int personalId))
                CargarVocales(0);

            ValidarCampos();
        }

        private void cmbVocalMesa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void cmbMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarDatosMateriaSeleccionada();
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosMateriaSeleccionada();
        }

        private void cmbPresidenteMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (cmbPresidenteMesa.SelectedValue != null && int.TryParse(cmbPresidenteMesa.SelectedValue.ToString(), out int personalId))
                //CargarVocales(personalId);

            ValidarCampos();
        }

        private void CargarDatosMateriaSeleccionada()
        {
            if (this.Accion != TipoAccion.Agregar || cmbMateria.SelectedValue == null) return;

            CargarProfesorTitular();
            CargarVocales(0);
            ValidarCampos();
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterias();
        }
    }
}
