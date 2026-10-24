using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Parametros;
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
        private bool huboCambios = false; 

        public FormAgregarHorario()
        {
            InitializeComponent();
        }

        private void FormAgregarHorario_Load(object sender, EventArgs e)
        {
            CargarComboTurnos();

            txtDe1.KeyPress += SoloNumeros_KeyPress;
            txtD2.KeyPress += SoloNumeros_KeyPress;
            txtA1.KeyPress += SoloNumeros_KeyPress;
            txtA2.KeyPress += SoloNumeros_KeyPress;

        
            txtDe1.MaxLength = 2;
            txtD2.MaxLength = 2;
            txtA1.MaxLength = 2;
            txtA2.MaxLength = 2;


            txtDe1.TextChanged += TxtHorario_TextChanged;
            txtD2.TextChanged += TxtHorario_TextChanged;
            txtA1.TextChanged += TxtHorario_TextChanged;
            txtA2.TextChanged += TxtHorario_TextChanged;
        }

        private void CargarComboTurnos()
        {
            cmbTurnosDisponibles.ValueMember = "Turno";
            cmbTurnosDisponibles.DisplayMember = "Turno";
            cmbTurnosDisponibles.DataSource = horariosLogica.ObtenerTurnosUnicos();
            cmbTurnosDisponibles.SelectedIndex = -1;
        }

        private void TxtHorario_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txt && txt.Text.Length == 2)
            {

                if (txt == txtA2)
                {
                    btnAñadir.Focus();
                }
                else
                {

                    this.SelectNextControl(txt, true, true, true, true);
                }
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (cmbTurnosDisponibles.SelectedValue == null)
            {
                Notificar(TipoNotificacion.Warning, "Debe seleccionar un turno.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDe1.Text) || string.IsNullOrWhiteSpace(txtD2.Text) ||
                string.IsNullOrWhiteSpace(txtA1.Text) || string.IsNullOrWhiteSpace(txtA2.Text))
            {
                Notificar(TipoNotificacion.Warning, "Complete todos los campos de horario.");
                return;
            }

            string turnoSeleccionado = cmbTurnosDisponibles.SelectedValue.ToString();

            string horaInicio = $"{txtDe1.Text.Trim().PadLeft(2, '0')}:{txtD2.Text.Trim().PadLeft(2, '0')}";
            string horaFin = $"{txtA1.Text.Trim().PadLeft(2, '0')}:{txtA2.Text.Trim().PadLeft(2, '0')}";
            string descripcionHorario = $"{horaInicio} - {horaFin}";

            bool insertado = horariosLogica.InsertarModulo(turnoSeleccionado, descripcionHorario);

            if (insertado)
            {
                Notificar(TipoNotificacion.Success, "Horario agregado correctamente.");

                huboCambios = true;

                
                txtDe1.Clear();
                txtD2.Clear();
                txtA1.Clear();
                txtA2.Clear();


                txtDe1.Focus();
            }
            else
            {
                Notificar(TipoNotificacion.Error, "Ocurrió un error al guardar el horario.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarFormulario();
        }

        private void FormAgregarHorario_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarFormulario();
        }

        private void CerrarFormulario()
        {
            this.DialogResult = huboCambios ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }
    }
}