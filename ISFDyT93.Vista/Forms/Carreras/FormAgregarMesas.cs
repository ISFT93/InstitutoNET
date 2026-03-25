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

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormAgregarMesas : FormBase
    {
        #region Publics
        public int CarreraId { get; set; }
        public string NombreCarrera { get; set; }
        public int MesaFinalId { get; set; }
        public DateTime Fecha { get; set; }
        public string Turno { get; set; }
        public TipoAccion Accion { get; set; }
        #endregion

        #region Privates
        private MateriasLogica materiasLogica;
        private MesasFinalesLogica mesasFinalesLogica;
        private DateTime fecha;
        #endregion

        public FormAgregarMesas()
        {
            InitializeComponent();
            materiasLogica = new MateriasLogica();
            mesasFinalesLogica = new MesasFinalesLogica(); 
        }

        private void FormAgregarMesas_Load(object sender, EventArgs e)
        {
            Contenedor.SetTitulo("Agregar Mesa").SetVolver(() =>
            {
                Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                {
                    form.CarreraId = this.CarreraId;
                    form.NombreCarrera = this.NombreCarrera;
                });
            });

            if (this.Accion == TipoAccion.Modificar)
            {
                cmbMateria.Enabled = false;
                btnAgregar.Text = "Modificar";
                cmbMateria.DataSource = mesasFinalesLogica.ObtenerMateriaFinal(this.MesaFinalId);
                cmbMateria.DisplayMember = "Nombre";
                cmbMateria.ValueMember = "MateriaId";
                dtpFechaMesa.Value = this.Fecha;
                CargarProfesorTitular();
                CargarVocales(Convert.ToInt32(cmbPresidenteMesa.SelectedValue));
            }
        }

        private void cmbMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarProfesorTitular();
            CargarVocales(Convert.ToInt32(cmbPresidenteMesa.SelectedValue));
            ValidarCampos();
        }

        private void CargarMateriasPorTurno()
        {
            cmbMateria.DataSource = mesasFinalesLogica.ObtenerMateriasPorTurno(this.CarreraId, cmbTurno.Text);
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
                int res = mesasFinalesLogica.ModificarMesa(fecha, cmbTurno.Text, Convert.ToInt32(cmbPresidenteMesa.SelectedValue), Convert.ToInt32(cmbVocalMesa.SelectedValue), this.MesaFinalId);
                if (res > 0)
                {
                    Notificar(TipoNotificacion.Success, "Mesa modificada correctamente");
                    Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                    {
                        form.CarreraId = this.CarreraId;
                        form.NombreCarrera = this.NombreCarrera;
                    });
                }
                else
                    Notificar(TipoNotificacion.Error, "Ocurrió un error");
            }
            else
            {
                int res = mesasFinalesLogica.AgregarMesa(this.CarreraId, fecha, cmbTurno.Text, Convert.ToInt32(cmbPresidenteMesa.SelectedValue), Convert.ToInt32(cmbVocalMesa.SelectedValue), Convert.ToInt32(cmbMateria.SelectedValue));
                if (res > 0)
                {
                    Notificar(TipoNotificacion.Success, "Mesa agregada correctamente");
                    Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                    {
                        form.CarreraId = this.CarreraId;
                        form.NombreCarrera = this.NombreCarrera;
                    });
                }
            }

        }

        private void cmbTurno_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.Accion != TipoAccion.Modificar)
                CargarMateriasPorTurno();
            ValidarCampos();
        }
        private void ValidarCampos()
        {
            if ((cmbTurno.Text != "")&&(cmbMateria.Text != "")&&(cmbPresidenteMesa.Text != "")&&(cmbVocalMesa.Text != ""))
                btnAgregar.Enabled = true;
        }

        private void cmbPresidenteMesa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void cmbVocalMesa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ValidarCampos();
        }
    }
}
