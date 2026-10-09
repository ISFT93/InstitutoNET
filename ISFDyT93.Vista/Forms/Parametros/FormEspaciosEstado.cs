using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Data;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormEspaciosEstado : Form
    {
        private bool Accion;
        private string Titulo;

        public FormEspaciosEstado(bool habilitar)
        {
            InitializeComponent();

            Accion = habilitar;
            CambiarTitulos(habilitar);
        }

        EspaciosLogica logica = new EspaciosLogica();

        private void AsignarTitulos()
        {
            lblEspacios.Text = $"{Titulo} Espacio";
            btnCambiar.Text = $"{Titulo}";
        }

        private void CambiarTitulos(bool habilitar)
        {
            if (habilitar == true)
                Titulo = "Habilitar";
            else
                Titulo = "Deshabilitar";
        }

        private void FormEspaciosEstado_Load(object sender, EventArgs e)
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
            int EspacioID = Convert.ToInt32(cbxEspacios.SelectedValue);
            string Espacio = Convert.ToString(cbxEspacios.Text);

            if (Accion == true)
            {
                DialogResult confirm = MessageBox.Show(
                    $"¿Está seguro que desea habilitar el espacio {Espacio}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                    return;

                logica.HabilitarEspacio(EspacioID);

                FormNotificacion.Mensaje(
                    TipoNotificacion.Success,
                    $"Se ha habilitado el espacio {Espacio}"
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DialogResult confirm = MessageBox.Show(
                    $"¿Está seguro que desea deshabilitar el espacio {Espacio}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                    return;

                logica.DeshabilitarEspacio(EspacioID);

                FormNotificacion.Mensaje(
                    TipoNotificacion.Success,
                    $"Se ha deshabilitado el espacio {Espacio}"
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CargarComboBox(bool habilitar)
        {
            if (habilitar == true)
            {
                DataTable espacios = logica.EspaciosDeshabilitados();

                cbxEspacios.DataSource = espacios;
                cbxEspacios.DisplayMember = "Descripcion";
                cbxEspacios.ValueMember = "EspacioId";
            }
            else
            {
                DataTable espacios = logica.EspaciosHabilitados();

                cbxEspacios.DataSource = espacios;
                cbxEspacios.DisplayMember = "Descripcion";
                cbxEspacios.ValueMember = "EspacioId";
            }
        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}