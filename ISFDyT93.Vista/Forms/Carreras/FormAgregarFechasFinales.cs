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
        }

        private void FormAgregarMesas_Load(object sender, EventArgs e)
        {
            if (this.Accion == TipoAccion.Agregar)
            {
                CargarMaterias();
                CargarTurnoMateria(false);
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
        }

        private void CargarProfesorTitular()
        {
            cmbPresidenteMesa.DataSource = mesasFinalesLogica.ObtenerProfesorTitular(Convert.ToInt32(cmbMateria.SelectedValue));
            cmbPresidenteMesa.ValueMember = "PersonalId";
            cmbPresidenteMesa.DisplayMember = "Nombre";
        }
        private void CargarVocales(int PersonalId)
        {
            cmbVocalMesa.DataSource = mesasFinalesLogica.ObtenerVocales(this.CarreraId, PersonalId);
            cmbVocalMesa.ValueMember = "PersonalId";
            cmbVocalMesa.DisplayMember = "Nombre";
        }

        private void dtpFechaMesa_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaMesa.CustomFormat = "dd/MM/yyyy";
            int res = DateTime.Compare(dtpFechaMesa.Value.Date, DateTime.Now);
            if (res > 0)
            {
                fecha = dtpFechaMesa.Value.Date;
                ValidarCampos();
            }
                
            else
            {
                MessageBox.Show("Seleccione una fecha posterior al día de hoy.", "Fecha errónea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if ((cmbTurno.Text != "")&&(cmbMateria.Text != "")&&(cmbPresidenteMesa.Text != "")&&(cmbVocalMesa.Text != ""))
                btnAgregar.Enabled = true;
        }

        private void CargarTurnoMateria(bool especial)
        {
            switch (this.Accion)
            {
                case TipoAccion.Agregar:
                    {
                        cmbTurno.DataSource = mesasFinalesLogica.ObtenerTurnos(especial);
                        cmbTurno.DisplayMember = "Descripcion";
                        cmbTurno.ValueMember = "TurnoId";
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
            ValidarCampos();
        }

        private void cmbVocalMesa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void cmbMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.Accion == TipoAccion.Agregar)
            {
                CargarProfesorTitular();
                CargarVocales(Convert.ToInt32(cmbPresidenteMesa.SelectedValue));
                ValidarCampos();
            }
        }
    }
}
