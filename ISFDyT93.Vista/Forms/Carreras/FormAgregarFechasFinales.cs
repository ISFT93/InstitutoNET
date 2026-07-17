using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Datos.Daos;

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
        private MesasFinalesLogica mesasFinalesLogica;
        private DateTime fecha;
        private string title;
        #endregion

        public FormAgregarFechasFinales()
        {
            InitializeComponent();
            materiasLogica = new MateriasLogica();
            mesasFinalesLogica = new MesasFinalesLogica(); 
            cmbMateria.SelectedIndexChanged += cmbMateria_SelectedIndexChanged;
            cmbPresidenteMesa.SelectedIndexChanged += cmbPresidenteMesa_SelectedIndexChanged;
        }

        private void FormAgregarMesas_Load(object sender, EventArgs e)
        {
            dtpFechaMesa.MinDate = DateTime.Today.AddDays(1);
            dtpFechaMesa.Value = DateTime.Today.AddDays(1);

            if (this.Accion == TipoAccion.Agregar)
            {
                CargarMaterias();
                CargarTurnoMateria(true);
                cmbMateria.Enabled = true;
                title = "Agregar fecha especial";
            }

            if (this.Accion == TipoAccion.Modificar)
            {
                CargarTurnoMateria(false);
                CargarProfesorTitular();
                CargarVocales(Convert.ToInt32(cmbPresidenteMesa.SelectedValue));
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

        private void CargarMaterias()
        {
            cmbMateria.DataSource = materiasLogica.MateriasId(this.CarreraId);
            cmbMateria.ValueMember = "MateriaId";
            cmbMateria.DisplayMember = "Nombre";
            cmbMateria.SelectedIndex = -1;
            cmbMateria.Enabled = cmbMateria.Items.Count > 0;
            ValidarCampos();
        }

        private void CargarProfesorTitular()
        {
            if (cmbMateria.SelectedValue == null || !int.TryParse(cmbMateria.SelectedValue.ToString(), out int materiaId)) return;

            cmbPresidenteMesa.DataSource = mesasFinalesLogica.ObtenerProfesorTitular(materiaId);
            cmbPresidenteMesa.ValueMember = "PersonalId";
            cmbPresidenteMesa.DisplayMember = "Nombre";
            cmbPresidenteMesa.SelectedIndex = -1;
            cmbPresidenteMesa.Enabled = cmbPresidenteMesa.Items.Count > 0;
            ValidarCampos();
        }
        private void CargarVocales(int PersonalId)
        {
            cmbVocalMesa.DataSource = mesasFinalesLogica.ObtenerVocales(this.CarreraId, PersonalId);
            cmbVocalMesa.ValueMember = "PersonalId";
            cmbVocalMesa.DisplayMember = "Nombre";
            cmbVocalMesa.SelectedIndex = -1;
            cmbVocalMesa.Enabled = cmbVocalMesa.Items.Count > 0;
            ValidarCampos();
        }

        private void dtpFechaMesa_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaMesa.CustomFormat = "dd/MM/yyyy";
            ValidarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (this.Accion == TipoAccion.Modificar)
            {
                int res = mesasFinalesLogica.ModificarMesa(fecha, Convert.ToInt32(cmbTurno.SelectedValue), Convert.ToInt32(cmbPresidenteMesa.SelectedValue), Convert.ToInt32(cmbVocalMesa.SelectedValue), this.MesaFinalId);
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
                int res = mesasFinalesLogica.AgregarMesa(this.CarreraId, fecha, 4, 3, Convert.ToInt32(cmbMateria.SelectedValue), Convert.ToInt32(cmbPresidenteMesa.SelectedValue), Convert.ToInt32(cmbVocalMesa.SelectedValue), this.AnioLectivoId);
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
            bool fechaValida = dtpFechaMesa.Value.Date > DateTime.Today;
            bool turnoValido = this.Accion == TipoAccion.Agregar || cmbTurno.SelectedValue != null;
            bool camposValidos = turnoValido && cmbMateria.SelectedValue != null &&
                cmbPresidenteMesa.SelectedValue != null &&
                cmbVocalMesa.SelectedValue != null;

            btnAgregar.Enabled = fechaValida && camposValidos;

            if (fechaValida)
                fecha = dtpFechaMesa.Value.Date;
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
            if (cmbPresidenteMesa.SelectedValue != null && int.TryParse(cmbPresidenteMesa.SelectedValue.ToString(), out int personalId))
                CargarVocales(personalId);

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
            if (cmbPresidenteMesa.SelectedValue != null && int.TryParse(cmbPresidenteMesa.SelectedValue.ToString(), out int personalId))
                CargarVocales(personalId);

            ValidarCampos();
        }

        private void CargarDatosMateriaSeleccionada()
        {
            if (this.Accion != TipoAccion.Agregar || cmbMateria.SelectedValue == null) return;

            CargarProfesorTitular();
            CargarVocales(0);
            ValidarCampos();
        }
    }
}
