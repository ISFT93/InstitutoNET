using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormLicenciaEstado : Form
    {
        private bool Accion;
        private string Titulo;
        private TipoLicenciaLogica logica = new TipoLicenciaLogica();

        public FormLicenciaEstado(bool habilitar)
        {
            InitializeComponent();
            Accion = habilitar;
            CambiarTitulos(habilitar);
        }

        private void AsignarTitulos()
        {
            lblLicencias.Text = $"{Titulo} Licencia";
            btnCambiar.Text = $"{Titulo}";
        }

        private void CambiarTitulos(bool habilitar)
        {
            if (habilitar)
                Titulo = "Habilitar";
            else
                Titulo = "Deshabilitar";
        }

        private void FormLicenciaEstado_Load(object sender, EventArgs e)
        {
            AsignarTitulos();
            CargarComboBox(Accion);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (cbxLicencias.SelectedItem == null)
                return;

            // Se obtiene el objeto completo de la selección para no perder Descripcion ni Dias
            TipoLicenciaModelo licenciaSeleccionada = (TipoLicenciaModelo)cbxLicencias.SelectedItem;
            string LicenciaID = licenciaSeleccionada.TipoLicenciaId;

            string accionTexto = Accion ? "habilitar" : "deshabilitar";

            DialogResult confirm = MessageBox.Show($"¿Está seguro que desea {accionTexto} la licencia {LicenciaID}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            // Modificamos únicamente el estado sobre la entidad completa
            licenciaSeleccionada.Activo = Accion;

            if (logica.ActualizarLicencias(new List<TipoLicenciaModelo> { licenciaSeleccionada }) > 0)
            {
                string estadoTxt = Accion ? "Habilitado" : "Deshabilitado";
                FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha {estadoTxt} la licencia {LicenciaID}");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                FormNotificacion.Mensaje(TipoNotificacion.Error, "Error al actualizar la base de datos");
            }
        }

        private void CargarComboBox(bool habilitar)
        {
            IList<TipoLicenciaModelo> licencias = logica.ObtenerLicencias();

            if (habilitar)
            {
                var deshabilitadas = licencias.Where(x => !x.Activo).ToList();
                cbxLicencias.DataSource = deshabilitadas;
            }
            else
            {
                var habilitadas = licencias.Where(x => x.Activo).ToList();
                cbxLicencias.DataSource = habilitadas;
            }

            cbxLicencias.DisplayMember = "TipoLicenciaId";
            cbxLicencias.ValueMember = "TipoLicenciaId";
        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e) { }
    }
}