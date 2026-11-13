using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Data;
using System.Windows.Forms;
using ISFDyT93.Negocio;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormEsquemasEstado : Form
    {
        private bool Accion;
        private string Titulo;

        EsquemaEvaluacionLogica logica =
            new EsquemaEvaluacionLogica();

        public FormEsquemasEstado(bool habilitar)
        {
            InitializeComponent();

            Accion = habilitar;
            CambiarTitulos(habilitar);
        }

        private void AsignarTitulos()
        {
            lblEsquemas.Text = $"{Titulo} Esquema";
            btnCambiar.Text = Titulo;
            this.Text = $"{Titulo} Esquema";
        }

        private void CambiarTitulos(bool habilitar)
        {
            if (habilitar == true)
                Titulo = "Habilitar";
            else
                Titulo = "Deshabilitar";
        }

        private void FormEsquemasEstado_Load(
            object sender, EventArgs e)
        {
            AsignarTitulos();
            CargarComboBox(Accion);
        }

        private void btnCancelar_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCambiar_Click(
            object sender, EventArgs e)
        {
            if (cbxEsquemas.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un esquema.");
                return;
            }

            int CodEsq =
                Convert.ToInt32(cbxEsquemas.SelectedValue);

            string Esquema = cbxEsquemas.Text;

            if (Accion == true)
            {
                DialogResult confirm = MessageBox.Show(
                    $"¿Está seguro que desea habilitar el esquema {Esquema}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                    return;

                logica.HabilitarEsquema(CodEsq);

                FormNotificacion.Mensaje(
                    TipoNotificacion.Success,
                    $"Se ha habilitado el esquema {Esquema}"
                );
            }
            else
            {
                DialogResult confirm = MessageBox.Show(
                    $"¿Está seguro que desea deshabilitar el esquema {Esquema}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                    return;

                logica.DeshabilitarEsquema(CodEsq);

                FormNotificacion.Mensaje(
                    TipoNotificacion.Success,
                    $"Se ha deshabilitado el esquema {Esquema}"
                );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CargarComboBox(bool habilitar)
        {
            DataTable esquemas;

            if (habilitar == true)
                esquemas = logica.EsquemasDeshabilitados();
            else
                esquemas = logica.EsquemasHabilitados();

            // Mostrar datos para distinguir esquemas repetidos.
            esquemas.Columns.Add(
                "DescripcionCompleta", typeof(string));

            foreach (DataRow fila in esquemas.Rows)
            {
                fila["DescripcionCompleta"] =
                    fila["CodEsq"] + " - " +
                    fila["esquema"] + " - " +
                    fila["ex_descripc"] + " - " +
                    fila["ex_descripcion_planilla"];
            }

            cbxEsquemas.DisplayMember = "DescripcionCompleta";
            cbxEsquemas.ValueMember = "CodEsq";
            cbxEsquemas.DataSource = esquemas;

            btnCambiar.Enabled = esquemas.Rows.Count > 0;
        }
    }
}
