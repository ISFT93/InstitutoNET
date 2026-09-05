using System.Data;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Forms.Parametros;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscTiposLicencias : UserControl
    {
        private readonly LicenciaServicioLogica licenciaLogica = new LicenciaServicioLogica();

        public uscTiposLicencias()
        {
            DoubleBuffered = true;
            InitializeComponent();
            ConfigurarMenuContextual();
        }

        private void uscTiposLicencias_Load(object sender, System.EventArgs e)
        {
            BackColor = ThemeColor.GetColor();
            CargarDGV();
        }

        private void CargarDGV()
        {
            DataTable dt = licenciaLogica.ObtenerLicenciasTipo();
            dgvLicencias.DataSource = dt;
        }

        private void ConfigurarMenuContextual()
        {
            dgvLicencias.ContextMenuStrip = menu;
            menu.Opening += (s, e) =>
            {
                bool activa = FilaSeleccionadaEstaActiva();
                bool hayFilaSeleccionada = dgvLicencias.CurrentRow != null;

                opcionAgregar.Visible = true;
                opcionModificar.Visible = hayFilaSeleccionada;
                opcionDeshabilitar.Visible = hayFilaSeleccionada && activa;
                opcionHabilitar.Visible = hayFilaSeleccionada && !activa && dgvLicencias.Columns.Contains("Activo");
            };
            opcionAgregar.Click += opcionAgregar_Click;
            opcionModificar.Click += opcionModificar_Click;
            opcionHabilitar.Click += opcionHabilitar_Click;
            opcionDeshabilitar.Click += opcionDeshabilitar_Click;
        }

        private void dgvLicencias_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DataGridView.HitTestInfo info = dgvLicencias.HitTest(e.X, e.Y);

            if (info.RowIndex < 0)
            {
                dgvLicencias.ClearSelection();
                dgvLicencias.CurrentCell = null;
                return;
            }

            dgvLicencias.ClearSelection();
            dgvLicencias.Rows[info.RowIndex].Selected = true;
            dgvLicencias.CurrentCell = dgvLicencias.Rows[info.RowIndex].Cells[info.ColumnIndex >= 0 ? info.ColumnIndex : 0];
        }

        private bool FilaSeleccionadaEstaActiva()
        {
            if (dgvLicencias.CurrentRow == null || !dgvLicencias.Columns.Contains("Activo"))
                return false;

            object valor = dgvLicencias.CurrentRow.Cells["Activo"].Value;
            return valor != null && valor != System.DBNull.Value && System.Convert.ToBoolean(valor);
        }

        private void opcionDeshabilitar_Click(object sender, System.EventArgs e)
        {
            if (dgvLicencias.CurrentRow == null)
                return;

            string tipoLicenciaId = dgvLicencias.CurrentRow.Cells["TipoLicenciaId"].Value.ToString();
            string descripcion = dgvLicencias.CurrentRow.Cells["Descripcion"].Value.ToString();

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea deshabilitar la licencia {descripcion}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            if (licenciaLogica.DeshabilitarTipoLicencia(tipoLicenciaId) > 0)
            {
                FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha deshabilitado la licencia {descripcion}");
                CargarDGV();
            }
            else
            {
                FormNotificacion.Mensaje(TipoNotificacion.Error, "No se pudo deshabilitar la licencia");
            }
        }

        private void opcionHabilitar_Click(object sender, System.EventArgs e)
        {
            if (dgvLicencias.CurrentRow == null)
                return;

            string tipoLicenciaId = dgvLicencias.CurrentRow.Cells["TipoLicenciaId"].Value.ToString();
            string descripcion = dgvLicencias.CurrentRow.Cells["Descripcion"].Value.ToString();

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea habilitar la licencia {descripcion}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            if (licenciaLogica.HabilitarTipoLicencia(tipoLicenciaId) > 0)
            {
                FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha habilitado la licencia {descripcion}");
                CargarDGV();
            }
            else
            {
                FormNotificacion.Mensaje(TipoNotificacion.Error, "No se pudo habilitar la licencia");
            }
        }

        private void opcionAgregar_Click(object sender, System.EventArgs e)
        {
            using (FormAgregarTipoLicencia frmAgregarTipoLicencia = new FormAgregarTipoLicencia())
            {
                frmAgregarTipoLicencia.StartPosition = FormStartPosition.CenterParent;
                if (frmAgregarTipoLicencia.ShowDialog() == DialogResult.OK)
                    CargarDGV();
            }
        }

        private void opcionModificar_Click(object sender, System.EventArgs e)
        {
            if (dgvLicencias.CurrentRow == null)
                return;

            string tipoLicenciaId = dgvLicencias.CurrentRow.Cells["TipoLicenciaId"].Value.ToString();
            string descripcion = dgvLicencias.CurrentRow.Cells["Descripcion"].Value.ToString();
            object diasValor = dgvLicencias.CurrentRow.Cells["Dias"].Value;
            object fechaFinValor = dgvLicencias.CurrentRow.Cells["FechaFinObligatoria"].Value;
            int? dias = diasValor == null || diasValor == System.DBNull.Value ? (int?)null : System.Convert.ToInt32(diasValor);
            bool fechaFinObligatoria = fechaFinValor != null && fechaFinValor != System.DBNull.Value && System.Convert.ToBoolean(fechaFinValor);

            using (FormAgregarTipoLicencia frmAgregarTipoLicencia = new FormAgregarTipoLicencia())
            {
                frmAgregarTipoLicencia.CargarDatos(tipoLicenciaId, descripcion, dias, fechaFinObligatoria);
                frmAgregarTipoLicencia.StartPosition = FormStartPosition.CenterParent;
                if (frmAgregarTipoLicencia.ShowDialog() == DialogResult.OK)
                    CargarDGV();
            }
        }

        private void picMover_Click(object sender, System.EventArgs e)
        {
            FormNotificacion.Mensaje(TipoNotificacion.Message, "Licencias Disponibles\nPermite gestionar los tipos de licencias disponibles");
        }
    }
}
