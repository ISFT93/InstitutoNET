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

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscTiposHorarios : UserControl
    {
        private HorariosLogica horariosLogica = new HorariosLogica();
        public uscTiposHorarios()
        {
            InitializeComponent();
            ConfigurarMenuContextual();
        }

        private void uscTiposHorarios_Load(object sender, EventArgs e)
        {
            BackColor = ThemeColor.GetColor();
            CargarDGV();
        }
        private void CargarDGV()
        {

            DataTable dtTurnos = horariosLogica.ObtenerTurnosConDetalleOrdenados();

            dgvTurnos.DataSource = dtTurnos;

            if (dgvTurnos.Columns.Contains("horario"))
            {
                dgvTurnos.Columns["horario"].HeaderText = "Horario";
            }
        }

        private void ConfigurarMenuContextual()
        {
            dgvTurnos.ContextMenuStrip = menu;
            menu.Opening += (s, e) =>
            {

                bool hayFilaSeleccionada = dgvTurnos.CurrentRow != null;

                opcionAgregar.Visible = true;
                opcionAgregarHorario.Visible = true;
                opcionHabilitar.Visible = true;
                opcionAgregarHorario.Visible = true;

            };

        }

        private void dgvTurnos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DataGridView.HitTestInfo info = dgvTurnos.HitTest(e.X, e.Y);

            if (info.RowIndex < 0)
            {
                dgvTurnos.ClearSelection();
                dgvTurnos.CurrentCell = null;
                return;
            }

            dgvTurnos.ClearSelection();
            dgvTurnos.Rows[info.RowIndex].Selected = true;
            dgvTurnos.CurrentCell = dgvTurnos.Rows[info.RowIndex].Cells[info.ColumnIndex >= 0 ? info.ColumnIndex : 0];
        }

        private void opcionModificar_Click(object sender, EventArgs e)
        {
            using (var form = new FormAgregarHorario())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarDGV();
                }
            }
        }

        private void opcionAgregar_Click(object sender, EventArgs e)
        {

            using (var form = new formAgregarTurno())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarDGV();
                }
            }
        }

        private void menu_Opening(object sender, CancelEventArgs e)
        {
  
            if (dgvTurnos.CurrentRow == null || dgvTurnos.CurrentRow.Index < 0)
            {
                e.Cancel = true; 
                return;
            }

            var valorActivo = dgvTurnos.CurrentRow.Cells["Activo"].Value;
            bool activo = false;

            if (valorActivo != null && valorActivo != DBNull.Value)
            {
                if (valorActivo is bool b)
                {
                    activo = b;
                }
                else if (int.TryParse(valorActivo.ToString(), out int i))
                {
                    activo = (i == 1);
                }
                else if (bool.TryParse(valorActivo.ToString(), out bool parsedBool))
                {
                    activo = parsedBool;
                }
            }

            opcionHabilitar.Visible = !activo;
            opcionDeshabilitar.Visible = activo;
        }

        private void opcionHabilitar_Click(object sender, EventArgs e)
        {
            CambiarEstadoModulo(true);
        }


        private void opcionDeshabilitar_Click(object sender, EventArgs e)
        {
            CambiarEstadoModulo(false);
        }
        private void CambiarEstadoModulo(bool nuevoEstado)
        {
            if (dgvTurnos.CurrentRow == null) return;

            // Obtenemos el ModuloId de la fila seleccionada
            int moduloId = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["ModuloId"].Value);

            // Ejecutamos el cambio en la base de datos a través de la lógica
            bool actualizado = horariosLogica.ActualizarEstadoModulo(moduloId, nuevoEstado);

            if (actualizado)
            {
                string mensaje = nuevoEstado ? "Módulo habilitado correctamente." : "Módulo deshabilitado correctamente.";

                // Reemplazamos Notificar por MessageBox.Show
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargamos la grilla para reflejar el cambio al instante
                CargarDGV();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar el estado del módulo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
