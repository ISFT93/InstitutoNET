using ISFDyT93.Datos.Core;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.UserControls;
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
    public partial class FormCargosEstado : Form
    {
        private bool Accion;
        private string Titulo;
        public FormCargosEstado(bool habilitar)
        {
            InitializeComponent();
            Accion = habilitar;
            CambiarTitulos(habilitar);
        }
        CargosLogica logica = new CargosLogica();
        private void AsignarTitulos()
        {
            lblCargos.Text = $"{Titulo} Cargo";
            btnCambiar.Text = $"{Titulo}";
        }
        private void CambiarTitulos(bool habilitar)
        {
            if (habilitar == true)
                Titulo = "Habilitar";
            else
                Titulo = "Deshabilitar";
        }

        private void FormCargosEstado_Load(object sender, EventArgs e)
        {
            AsignarTitulos();
            CargarComboBox(Accion);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            int CargoID = Convert.ToInt32(cbxCargos.SelectedValue);
            string Cargo = Convert.ToString(cbxCargos.Text);

            if (Accion == true)
            {
                DialogResult confirm = MessageBox.Show($"¿Está seguro que desea habilitar el cargo {Cargo}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;
                else
                {
                    logica.HabilitarCargo(CargoID);
                    FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha Habilitado el cargo {Cargo}");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                DialogResult confirm = MessageBox.Show($"¿Está seguro que desea deshabilitar el cargo {Cargo}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;
                else
                {
                    logica.DeshabilitarCargo(CargoID);
                    FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha Deshabilitado el cargo {Cargo}");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private void CargarComboBox(bool habilitar)
        {
            if (habilitar == true)
            {
                DataTable cargos = logica.CargosDeshabilitados();
                cbxCargos.DataSource = cargos;
                cbxCargos.DisplayMember = "Descripcion";
                cbxCargos.ValueMember = "CargoId";
            }
            else
            {
                DataTable cargos = logica.CargosHabilitados();
                cbxCargos.DataSource = cargos;
                cbxCargos.DisplayMember = "Descripcion";
                cbxCargos.ValueMember = "CargoId";
            }
        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
