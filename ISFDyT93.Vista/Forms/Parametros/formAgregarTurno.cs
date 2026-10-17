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
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Interfaces;
using ISFDyT93.Negocio.Logica;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class formAgregarTurno : FormBase
    {
        private HorariosLogica horariosLogica = new HorariosLogica();
        public formAgregarTurno()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            string nuevoTurno = txtNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(nuevoTurno))
            {
                Notificar(TipoNotificacion.Warning, "El nombre del turno no puede estar vacío.");
                return;
            }

            bool insertado = horariosLogica.InsertarTurno(nuevoTurno);

            if (insertado)
            {
                Notificar(TipoNotificacion.Success, "Turno agregado correctamente.");
                this.DialogResult = DialogResult.OK;
                CargarComboTurnosCreados();
                this.Close();

            }
            else
            {
                Notificar(TipoNotificacion.Error, "Ocurrió un error al guardar el turno.");
            }
        }

        private void formAgregarTurno_Load(object sender, EventArgs e)
        {
            CargarComboTurnosCreados();
        }

        private void CargarComboTurnosCreados()
        {
          
            cmbTurnosDisponibles.ValueMember = "Turno";
            cmbTurnosDisponibles.DisplayMember = "Turno";
            cmbTurnosDisponibles.DataSource = horariosLogica.ObtenerTurnosUnicos();
            cmbTurnosDisponibles.SelectedIndex = -1;
        }


    }
}
