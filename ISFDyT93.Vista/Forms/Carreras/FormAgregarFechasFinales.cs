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
        public int ProfesorId { get; set; }
        public int VocalId { get; set; }
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
            dtpFechaMesa.MinDate = DateTime.Today.AddDays(1);
            dtpFechaMesa.Value = DateTime.Today.AddDays(1);
            CargarAniosLectivos();
            CargarCarreras();
            ConfigurarDatePicker(dtpFechaMesa);
            ValidarCampos();
            if (this.Accion == TipoAccion.Agregar)
            {
                CargarMaterias();
                //OcultarVocalYFecha();
                CargarTurnoMateria(true);
                cmbMateria.Enabled = true;
                title = "Agregar fecha especial";
            }

            if (this.Accion == TipoAccion.Modificar)
            {
                cmbCarrera.SelectedValue = this.CarreraId;
                CargarTurnoMateria(false);
                CargarProfesorTitular();
                CargarVocales(ProfesorId);
                title = "Asignar fecha y vocal";
                btnAgregar.Text = "Modificar";
                cmbCarrera.Enabled = false;
                cmbMateria.Enabled = false;
            }

            Contenedor.SetTitulo(title).SetVolver(() =>
            {
                Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                {
                    //form.CarreraId = this.CarreraId;
                    form.NombreCarrera = this.NombreCarrera;
                    form.AnioLectivoId = this.AnioLectivoId;
                    form.TurnoId = this.TurnoId;
                    form.LlamadoId = this.LlamadoId;
                    if (this.LlamadoId == 3)
                        form.FechaUnica = true;
                });
            });
        }
        private void CargarAniosLectivos()
        {
            DataTable dt = mesasFinalesLogica.ObtenerAniosLectivos();
            // Ciclo lectivo
            AnioLectivoId = Convert.ToInt32(dt.Rows[0]["CicloLectivoId"]);
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

            if (cmbMateria.SelectedValue == null ||
        !int.TryParse(cmbMateria.SelectedValue.ToString(), out int materiaId))
                return;

            DataTable dt = mesasFinalesLogica.ObtenerProfesorTitular(materiaId);

            if (dt != null && dt.Rows.Count > 0)
            {
                int personalId = Convert.ToInt32(dt.Rows[0]["PersonalId"]);

                ProfesorId = personalId;
            }
            else
            {
                ProfesorId = 0;
            }
            cmbPresidenteMesa.DataSource = dt;

            cmbPresidenteMesa.ValueMember = "PersonalId";
            cmbPresidenteMesa.DisplayMember = "Nombre";

            if (ProfesorId == 0)
            {
                Notificar(TipoNotificacion.Error, "La materia no tiene un profesor asignado.\n Asigne un profesor para poder guardar los cambios");
                btnAgregar.Enabled = false;
                return;
            } 
            cmbPresidenteMesa.SelectedValue = 1;
            //ValidarCampos();
        }
        private void CargarVocales(int PersonalId)
        {
            cmbVocalMesa.DataSource = mesasFinalesLogica.ObtenerVocales(this.CarreraId, PersonalId);
            cmbVocalMesa.ValueMember = "PersonalId";
            cmbVocalMesa.DisplayMember = "Nombre";
            cmbVocalMesa.SelectedValue = VocalId;
            cmbVocalMesa.Enabled = cmbVocalMesa.Items.Count > 0;
            //ValidarCampos();
        }

        private void dtpFechaMesa_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaMesa.CustomFormat = "dd/MM/yyyy";
        }
        private void ConfigurarDatePicker(DateTimePicker datePicker)
        {
            DateTime hoy = DateTime.Today;

            // Rango permitido
            datePicker.MinDate = hoy;
            datePicker.MaxDate = hoy.AddYears(1);

            // Fecha inicial
            datePicker.Value = hoy;

            // Formato
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy";

            // Estilo
            datePicker.Font = new Font("Segoe UI", 10F);
            datePicker.CalendarFont = new Font("Segoe UI", 10F);

            datePicker.CalendarMonthBackground = Color.White;
            datePicker.CalendarForeColor = Color.Black;
            datePicker.CalendarTitleBackColor = Color.FromArgb(36, 35, 58);
            datePicker.CalendarTitleForeColor = Color.White;
            datePicker.CalendarTrailingForeColor = Color.Gray;

            // Mostrar calendario desplegable
            datePicker.ShowUpDown = false;
        }

        private void OcultarVocalYFecha()
        {
            // VOCAL
            int filaVocal = tableLayoutPanel1.GetRow(lblVocal);

            lblVocal.Visible = false;
            cmbVocalMesa.Visible = false;

            tableLayoutPanel1.RowStyles[filaVocal].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[filaVocal].Height = 0;


            // FECHA
            int filaFecha = tableLayoutPanel1.GetRow(lblFecha);

            lblFecha.Visible = false;
            dtpFechaMesa.Visible = false;

            tableLayoutPanel1.RowStyles[filaFecha].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[filaFecha].Height = 0;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            fecha = dtpFechaMesa.Value.Date;
            if (this.Accion == TipoAccion.Modificar)
            {
                if (Convert.ToInt32(cmbVocalMesa.SelectedValue) == 0)
                {
                    Notificar(TipoNotificacion.Warning, "Seleccione un vocal!");
                    return;
                }
                int res = mesasFinalesLogica.ModificarMesa(fecha, Convert.ToInt32(cmbTurno.SelectedValue), ProfesorId, Convert.ToInt32(cmbVocalMesa.SelectedValue), this.MesaFinalId);
                if (res > 0)
                {
                    Notificar(TipoNotificacion.Success, "Mesa modificada correctamente");
                    Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                    {
                        //form.CarreraId = this.CarreraId;
                        form.NombreCarrera = this.NombreCarrera;
                        //form.AnioLectivoId = this.AnioLectivoId;
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
                if (ProfesorId == 0)
                {
                    Notificar(TipoNotificacion.Warning, "La materia no tiene un profesor asignado");
                    return;
                }
                int res = mesasFinalesLogica.AgregarMesa(Convert.ToInt32(cmbCarrera.SelectedValue), fecha, 4, 3, Convert.ToInt32(cmbMateria.SelectedValue), ProfesorId, AnioLectivoId, null);
                if (res > 0)
                {
                    Notificar(TipoNotificacion.Success, "Mesa agregada correctamente");
                    Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                    {
                        form.CarreraId = this.CarreraId;
                        form.NombreCarrera = this.NombreCarrera;
                        //form.AnioLectivoId = this.AnioLectivoId;
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
            bool carreraValida = TieneValorValido(cmbCarrera);

            bool turnoValido = TieneValorValido(cmbTurno);

            bool materiaValida =
                cmbMateria.Enabled &&
                TieneValorValido(cmbMateria);

            btnAgregar.Enabled =
                carreraValida &&
                turnoValido &&
                materiaValida;
        }
        private bool TieneValorValido(ComboBox combo)
        {
            return combo.SelectedValue != null &&
                   int.TryParse(combo.SelectedValue.ToString(), out int id) &&
                   id > 0;
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

        private void CargarDatosMateriaSeleccionada()
        {
            if (this.Accion != TipoAccion.Agregar || cmbMateria.SelectedValue == null) return;

            CargarProfesorTitular();
            CargarVocales(0);
            //ValidarCampos();
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterias();
        }

    }
}
