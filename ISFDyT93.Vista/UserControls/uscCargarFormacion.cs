using System.Data;
using System.Windows.Forms;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Forms.Parametros;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscCargarFormacion : UserControl
    {
        private readonly EspacioFormacionLogica espacioFormacion = new EspacioFormacionLogica();

        public uscCargarFormacion()
        {
            DoubleBuffered = true;
            InitializeComponent();
            ConfigurarMenuContextual();
        }

        private void uscCargarFormacion_Load(object sender, System.EventArgs e)
        {
            BackColor = ThemeColor.GetColor();
            CargarDGV();
        }

        private void CargarDGV()
        {
            DataTable dt = espacioFormacion.ObtenerEspacios();
            dgvFormacion.DataSource = dt;
            dgvFormacion.Columns["CalculaPorcentaje"].Visible = false;
            dgvFormacion.Columns["SumaHoras"].Visible = false;
            dgvFormacion.Columns["EspacioID"].Visible = false;
            dgvFormacion.Columns["Acumulador"].Visible = false;
        }

        private void ConfigurarMenuContextual()
        {
            dgvFormacion.ContextMenuStrip = menu;
            menu.Opening += (s, e) =>
            {
                bool activa = FilaSeleccionadaEstaActiva();
                bool hayFilaSeleccionada = dgvFormacion.CurrentRow != null;

                opcionAgregar.Visible = true;
                opcionModificar.Visible = hayFilaSeleccionada;
                opcionDeshabilitar.Visible = hayFilaSeleccionada && activa;
                opcionHabilitar.Visible = hayFilaSeleccionada && !activa && dgvFormacion.Columns.Contains("Activo");
            };
            opcionAgregar.Click += opcionAgregar_Click;
            opcionModificar.Click += opcionModificar_Click;
            opcionHabilitar.Click += opcionHabilitar_Click;
            opcionDeshabilitar.Click += opcionDeshabilitar_Click;
        }

        private void dgvFormacion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DataGridView.HitTestInfo info = dgvFormacion.HitTest(e.X, e.Y);

            if (info.RowIndex < 0)
            {
                dgvFormacion.ClearSelection();
                dgvFormacion.CurrentCell = null;
                return;
            }

            dgvFormacion.ClearSelection();
            dgvFormacion.Rows[info.RowIndex].Selected = true;
            dgvFormacion.CurrentCell = dgvFormacion.Rows[info.RowIndex].Cells[info.ColumnIndex >= 0 ? info.ColumnIndex : 0];
        }

        private bool FilaSeleccionadaEstaActiva()
        {
            if (dgvFormacion.CurrentRow == null || !dgvFormacion.Columns.Contains("Activo"))
                return false;

            object valor = dgvFormacion.CurrentRow.Cells["Activo"].Value;
            return valor != null && valor != System.DBNull.Value && System.Convert.ToBoolean(valor);
        }

        private void opcionDeshabilitar_Click(object sender, System.EventArgs e)
        {
            if (dgvFormacion.CurrentRow == null)
                return;

            int espacioID = (int)dgvFormacion.CurrentRow.Cells["EspacioID"].Value;
            string descripcion = dgvFormacion.CurrentRow.Cells["Descripcion"].Value.ToString(); 
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea deshabilitar la licencia {descripcion}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            if (espacioFormacion.DeshabilitarEspacio(espacioID) > 0)
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
            if (dgvFormacion.CurrentRow == null)
                return;

            int espacioID = (int)dgvFormacion.CurrentRow.Cells["EspacioID"].Value;
            string descripcion = dgvFormacion.CurrentRow.Cells["Descripcion"].Value.ToString(); 
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea habilitar la licencia {descripcion}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            if (espacioFormacion.HabilitarEspacio(espacioID) > 0)
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
            using (FormAgregarEspacio frmAgregarEspacio = new FormAgregarEspacio())
            {
                frmAgregarEspacio.StartPosition = FormStartPosition.CenterParent;
                if (frmAgregarEspacio.ShowDialog() == DialogResult.OK)
                    CargarDGV();
            }
        }

        private void opcionModificar_Click(object sender, System.EventArgs e)
        {
            if (dgvFormacion.CurrentRow == null)
                return;
            
        EspacioModelo modelo = new EspacioModelo
            {
            EspacioId = (int)dgvFormacion.CurrentRow.Cells["EspacioId"].Value,
            Descripcion = dgvFormacion.CurrentRow.Cells["Descripcion"].Value.ToString(),
            SumaHoras = dgvFormacion.CurrentRow.Cells["SumaHoras"].Value != null && dgvFormacion.CurrentRow.Cells["SumaHoras"].Value != System.DBNull.Value && System.Convert.ToBoolean(dgvFormacion.CurrentRow.Cells["SumaHoras"].Value),
        };
            
            using (FormAgregarEspacio frmAgregarEspacio = new FormAgregarEspacio())
            {
                frmAgregarEspacio.CargarDatos(modelo);
                frmAgregarEspacio.StartPosition = FormStartPosition.CenterParent;
                if (frmAgregarEspacio.ShowDialog() == DialogResult.OK)
                    CargarDGV();
            }
        }

        private void picMover_Click(object sender, System.EventArgs e)
        {
            FormNotificacion.Mensaje(TipoNotificacion.Message, "Licencias Disponibles\nPermite gestionar los tipos de licencias disponibles");
        }
    }
}
