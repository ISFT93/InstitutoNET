using System;
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
    public partial class uscTablaEspacios : UserControl
    {
        private readonly EspacioFormacionLogica espacioLogica = new EspacioFormacionLogica();

        public uscTablaEspacios()
        {
            DoubleBuffered = true;
            InitializeComponent();
            ConfigurarMenuContextual();
        }

        private void uscTablaEspacios_Load(object sender, EventArgs e)
        {
            BackColor = ThemeColor.GetColor();
            CargarDGV();
        }

        public void CargarDGV()
        {
            DataTable dt = espacioLogica.ObtenerEspacios();
            dgvEspacios.DataSource = dt;
        }

        private void ConfigurarMenuContextual()
        {
            dgvEspacios.ContextMenuStrip = menu;
            menu.Opening += (s, e) =>
            {
                bool activa = FilaSeleccionadaEstaActiva();
                bool hayFilaSeleccionada = dgvEspacios.CurrentRow != null;

                opcionAgregar.Visible = true;
                opcionModificar.Visible = hayFilaSeleccionada;
                opcionDeshabilitar.Visible = hayFilaSeleccionada && activa;
                opcionHabilitar.Visible = hayFilaSeleccionada && !activa && dgvEspacios.Columns.Contains("Activo");
            };

            opcionAgregar.Click += opcionAgregar_Click;
            opcionModificar.Click += opcionModificar_Click;
            opcionHabilitar.Click += opcionHabilitar_Click;
            opcionDeshabilitar.Click += opcionDeshabilitar_Click;
        }

        private void dgvEspacios_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DataGridView.HitTestInfo info = dgvEspacios.HitTest(e.X, e.Y);

            if (info.RowIndex < 0)
            {
                dgvEspacios.ClearSelection();
                dgvEspacios.CurrentCell = null;
                return;
            }

            dgvEspacios.ClearSelection();
            dgvEspacios.Rows[info.RowIndex].Selected = true;
            dgvEspacios.CurrentCell = dgvEspacios.Rows[info.RowIndex].Cells[info.ColumnIndex >= 0 ? info.ColumnIndex : 0];
        }

        private bool FilaSeleccionadaEstaActiva()
        {
            if (dgvEspacios.CurrentRow == null || !dgvEspacios.Columns.Contains("Activo"))
                return false;

            object valor = dgvEspacios.CurrentRow.Cells["Activo"].Value;
            return valor != null && valor != DBNull.Value && Convert.ToBoolean(valor);
        }

        private void opcionDeshabilitar_Click(object sender, EventArgs e)
        {
            if (dgvEspacios.CurrentRow == null)
                return;

            int espacioId = Convert.ToInt32(dgvEspacios.CurrentRow.Cells["EspacioId"].Value);
            string descripcion = dgvEspacios.CurrentRow.Cells["Descripcion"].Value.ToString();

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea deshabilitar el espacio '{descripcion}'?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            if (espacioLogica.DeshabilitarEspacio(espacioId) > 0)
            {
                FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha deshabilitado '{descripcion}'");
                CargarDGV();
            }
            else
            {
                FormNotificacion.Mensaje(TipoNotificacion.Error, "No se pudo deshabilitar el espacio");
            }
        }

        private void opcionHabilitar_Click(object sender, EventArgs e)
        {
            if (dgvEspacios.CurrentRow == null)
                return;

            int espacioId = Convert.ToInt32(dgvEspacios.CurrentRow.Cells["EspacioId"].Value);
            string descripcion = dgvEspacios.CurrentRow.Cells["Descripcion"].Value.ToString();

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea habilitar el espacio '{descripcion}'?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            if (espacioLogica.HabilitarEspacio(espacioId) > 0)
            {
                FormNotificacion.Mensaje(TipoNotificacion.Success, $"Se ha habilitado '{descripcion}'");
                CargarDGV();
            }
            else
            {
                FormNotificacion.Mensaje(TipoNotificacion.Error, "No se pudo habilitar el espacio");
            }
        }

        private void opcionAgregar_Click(object sender, EventArgs e)
        {
            using (FormAgregarEspacio frm = new FormAgregarEspacio())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                    CargarDGV();
            }
        }

        private void opcionModificar_Click(object sender, EventArgs e)
        {
            if (dgvEspacios.CurrentRow == null)
                return;

            var modelo = new EspacioModelo
            {
                EspacioId = Convert.ToInt32(dgvEspacios.CurrentRow.Cells["EspacioId"].Value),
                Descripcion = dgvEspacios.CurrentRow.Cells["Descripcion"].Value.ToString(),
                Acumulador = dgvEspacios.CurrentRow.Cells["Acumulador"].Value?.ToString(),
                SumaHoras = Convert.ToBoolean(dgvEspacios.CurrentRow.Cells["SumaHoras"].Value),
                CalculaPorcentaje = Convert.ToBoolean(dgvEspacios.CurrentRow.Cells["CalculaPorcentaje"].Value)
            };

            using (FormAgregarEspacio frm = new FormAgregarEspacio())
            {
                frm.CargarDatos(modelo);
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                    CargarDGV();
            }
        }
    }
}