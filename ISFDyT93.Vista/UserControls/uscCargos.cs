using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Forms.Personal;
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
    public partial class uscCargos : UserControl
    {
        public uscCargos()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            CrearMenuContextual();
            AsignarMenuAControles(this);
        }
        CargosLogica cargosLogica = new CargosLogica();
        uscPersonalGrid usc;
        (DataTable TipoAsignacion, DataTable TipoAplicacion, IList<CargosModelo> Cargos) cargos;

        private void uscCargos_Load(object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);
            this.BackColor = ThemeColor.GetColor();
            CargarGrilla();
        }

        #region MenuContextual
        private ContextMenuStrip menu;
        private void CrearMenuContextual() //////
        {
            menu = new ContextMenuStrip();

            ToolStripMenuItem opcion = new ToolStripMenuItem("Agregar Cargo");
            opcion.Click += (s, e) =>
            {
                using (FormAgregarCargos frmAgregarCargos = new FormAgregarCargos())
                {
                    frmAgregarCargos.StartPosition = FormStartPosition.CenterParent;
                    if (frmAgregarCargos.ShowDialog() == DialogResult.OK) //agreguen este if
                    {
                        RecargarTabla();
                    }
                }
            };
            menu.Items.Add(opcion);
        }
        private void RecargarTabla()
        {
            pnlContenedor.Controls.Clear();
            CargarGrilla();
        }
        private void AsignarMenuAControles(Control control)
        {
            control.ContextMenuStrip = menu;

            foreach (Control hijo in control.Controls)
            {
                AsignarMenuAControles(hijo);
            }
        }
        #endregion
        private void CargarGrilla()
        {
            uscPersonalGrid.AnchoCelda = 150;
            usc = new uscPersonalGrid(new string[] { "Descripcion", "Carga Horaria", "Asignacion", "Cantidad", "Activo" });
            pnlContenedor.Controls.Add(usc);
            cargos = cargosLogica.ObtenerCargos();

            foreach (CargosModelo cargo in cargos.Cargos)
            {
                usc.AgregarCelda(cargo.Descripcion, cargo.CargoId);
                usc.AgregarCelda(cargo.CargaHoraria.ToString(), cargo.CargoId);
                usc.AgregarCelda(cargos.TipoAsignacion, cargo.TipoAsignacionId.ToString());
                usc.AgregarCelda(cargos.TipoAplicacion, cargo.TipoAplicacionId.ToString());
                usc.AgregarCelda(cargo.Activo);
            }

            Dimensionar();
        }
        private void Dimensionar()
        {
            this.Width = usc.Width + 50;
            this.Height = usc.Height + 45;
            usc.Dock = DockStyle.Fill;
        }
        private void picMover_Click(object sender, EventArgs e)
        {
            FormNotificacion.Mensaje(TipoNotificacion.Message, "Cargos Disponibles\nPermite gestionar todos los cargos disponibles");
        }
        private void picAgregar_Click(object sender, EventArgs e)
        {
            usc.Dock = DockStyle.None;
            usc.AgregarCelda("Nombre", true);
            usc.AgregarCelda(cargos.TipoAsignacion);
            usc.AgregarCelda(cargos.TipoAplicacion);
            usc.AgregarCelda(true);
            Dimensionar();
        }
        public void Guardar()
        {
            IList<CargosModelo> actualizarCargos = new List<CargosModelo>();

            foreach (var row in usc.Rows)
            {
                if (row[1].Value == null || string.IsNullOrWhiteSpace(row[1].Value.ToString()))
                {
                    MessageBox.Show("Debe ingresar un valor numérico en la carga horaria");
                    return;
                }
                int cargaHoraria;
                if (!int.TryParse(row[1].Value.ToString(), out cargaHoraria))
                {
                    MessageBox.Show("La carga horaria debe ser un número válido");
                    return;
                }

                if (cargaHoraria > 20)
                {
                    MessageBox.Show("El valor máximo permitido de carga horaria es de 20");
                    return;
                }

                actualizarCargos.Add(new CargosModelo()
                {
                    CargoId = row[0].Id,
                    Descripcion = row[0].Value,
                    TipoAsignacionId = Convert.ToInt32(row[2].Value),
                    TipoAplicacionId = Convert.ToInt32(row[3].Value),
                    Activo = Convert.ToBoolean(row[4].Value),
                    CargaHoraria = cargaHoraria
                });
            }

            if (cargosLogica.ActualizarCargos(actualizarCargos) > 0)
                FormNotificacion.Mensaje(TipoNotificacion.Success, "Cargos actualizados");
            else
                FormNotificacion.Mensaje(TipoNotificacion.Error, "Error al actualizar");
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
