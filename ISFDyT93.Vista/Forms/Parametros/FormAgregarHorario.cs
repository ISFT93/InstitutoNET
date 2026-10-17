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

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormAgregarHorario : FormBase
    {
        private HorariosLogica horariosLogica = new HorariosLogica();
        public FormAgregarHorario()
        {
            InitializeComponent();
        }

        private void FormAgregarHorario_Load(object sender, EventArgs e)
        {
            CargarComboTurnos();
        }
        private void CargarComboTurnos()
        {
            cmbTurnosDisponibles.ValueMember = "Turno";
            cmbTurnosDisponibles.DisplayMember = "Turno";
            cmbTurnosDisponibles.DataSource = horariosLogica.ObtenerTurnosUnicos();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            // 1. Validar que se haya seleccionado un turno
            if (cmbTurnosDisponibles.SelectedValue == null)
            {
                Notificar(TipoNotificacion.Warning, "Debe seleccionar un turno.");
                return;
            }

            // 2. Validar que los campos de hora no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDe1.Text) || string.IsNullOrWhiteSpace(txtD2.Text) ||
                string.IsNullOrWhiteSpace(txtA1.Text) || string.IsNullOrWhiteSpace(txtA2.Text))
            {
                Notificar(TipoNotificacion.Warning, "Complete todos los campos de horario.");
                return;
            }

            string turnoSeleccionado = cmbTurnosDisponibles.SelectedValue.ToString();

            // 3. Formatear la descripción del horario (Ej: "13:00 - 14:00")
            string horaInicio = $"{txtDe1.Text.Trim().PadLeft(2, '0')}:{txtD2.Text.Trim().PadLeft(2, '0')}";
            string horaFin = $"{txtA1.Text.Trim().PadLeft(2, '0')}:{txtA2.Text.Trim().PadLeft(2, '0')}";
            string descripcionHorario = $"{horaInicio} - {horaFin}";

            // 4. Insertar en la base de datos a través de la lógica
            bool insertado = horariosLogica.InsertarModulo(turnoSeleccionado, descripcionHorario);

            if (insertado)
            {
                Notificar(TipoNotificacion.Success, "Horario agregado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Notificar(TipoNotificacion.Error, "Ocurrió un error al guardar el horario.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
