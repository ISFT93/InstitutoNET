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
            // Ya no llamamos a ConfigurarMenuContextual() para evitar que pise los estados
            dgvTurnos.ContextMenuStrip = menu;
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

 
            if (dgvTurnos.Columns.Contains("ModuloId"))
            {
                dgvTurnos.Columns["ModuloId"].Visible = false;
            }
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

            // Aseguramos que las opciones fijas de agregar siempre se muestren
            opcionAgregar.Visible = true;
            opcionAgregarHorario.Visible = true;

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

            // Si está activo (true), mostramos "Deshabilitar" y ocultamos "Habilitar"
            // Si está inactivo (false), mostramos "Habilitar" y ocultamos "Deshabilitar"
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

            string turnoSeleccionado = dgvTurnos.CurrentRow.Cells["Turno"].Value.ToString();

         
            bool actualizado = horariosLogica.ActualizarEstadoPorTurno(turnoSeleccionado, nuevoEstado);

            if (actualizado)
            {
                string mensaje = nuevoEstado
                    ? $"Se habilitaron todos los módulos del turno '{turnoSeleccionado}'."
                    : $"Se deshabilitaron todos los módulos del turno '{turnoSeleccionado}'.";

                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDGV();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar el estado del turno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picMover_Click(object sender, EventArgs e)
        {
            
        }
    }
}