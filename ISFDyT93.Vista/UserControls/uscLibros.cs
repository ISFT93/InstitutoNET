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
using ISFDyT93.Datos.Core;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscLibros : UserControl
    {
        public uscLibros()
        {
            DoubleBuffered = true;
            InitializeComponent();

            MenuContextual();
        }
        LibroActasLogica libroActasLogica = new LibroActasLogica();
        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void uscLibros_Load(object sender, EventArgs e)
        {
            this.BackColor = ThemeColor.GetColor();
            CargarDGV(dgvLibros);
        }

        private void CargarDGV(DataGridView dgv)
        {
            DataTable dt = libroActasLogica.ObtenerLibros();

            dgv.DataSource = dt;

            dgv.Columns["TipoLibroId"].Visible = false;
            dgv.Columns["CarreraID"].Visible = false;

            // Evita registrar el evento varias veces
            dgv.CellPainting -= Dgv_CellPainting;
            dgv.CellPainting += Dgv_CellPainting;
        }
        private void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Evitar encabezados
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Solo columna FolioNumero
            if (dgv.Columns[e.ColumnIndex].Name == "FolioNumero")
            {
                object valorFolio = dgv.Rows[e.RowIndex]
                                       .Cells["FolioNumero"]
                                       .Value;

                object valorTipoLibro = dgv.Rows[e.RowIndex]
                                           .Cells["TipoLibroId"]
                                           .Value;

                if (valorFolio != null &&
                    valorFolio != DBNull.Value &&
                    valorTipoLibro != null &&
                    valorTipoLibro != DBNull.Value &&
                    int.TryParse(valorFolio.ToString(), out int folio) &&
                    int.TryParse(valorTipoLibro.ToString(), out int tipoLibroId))
                {
                    // Solamente Libro de Actas (TipoLibroId = 2)
                    // y folio mayor a 170
                    if (tipoLibroId == 2 && folio > 170)
                    {
                        // Dibujar normalmente la celda
                        e.Paint(
                            e.CellBounds,
                            DataGridViewPaintParts.All
                        );

                        // Dibujar borde rojo
                        using (Pen lapiz = new Pen(Color.Red, 2))
                        {
                            Rectangle rectangulo = new Rectangle(
                                e.CellBounds.X + 1,
                                e.CellBounds.Y + 1,
                                e.CellBounds.Width - 3,
                                e.CellBounds.Height - 3
                            );

                            e.Graphics.DrawRectangle(
                                lapiz,
                                rectangulo
                            );
                        }

                        e.Handled = true;
                    }
                }
            }
        }
        private void AbrirNuevoLibro(bool nuevaRelacion)
        {
            using (FormCargarNumLibro frm = new FormCargarNumLibro(nuevaRelacion))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarDGV(dgvLibros);
                    if (libroActasLogica.ActualizacionPosible() == true)
                        opcionActualizarLibro.Visible = true;
                    else
                        opcionActualizarLibro.Visible = false;

                    if (libroActasLogica.RelacionNuevaPosible() == true)
                        opcionAgregarNuevoLibro.Visible = true;
                    else
                        opcionAgregarNuevoLibro.Visible = false;
                }
            }
        }
        
        private void MenuContextual()
        {
            dgvLibros.ContextMenuStrip = menu;

            if (libroActasLogica.ActualizacionPosible() == true)
                opcionActualizarLibro.Visible = true;
            else
                opcionActualizarLibro.Visible = false;

            if (libroActasLogica.RelacionNuevaPosible() == true)
                opcionAgregarNuevoLibro.Visible = true;
            else
                opcionAgregarNuevoLibro.Visible = false;

            opcionActualizarLibro.Click += (s, e) => { AbrirNuevoLibro(false); };
            opcionAgregarNuevoLibro.Click += (s, e) => { AbrirNuevoLibro(true); };
        }

        private void picMover_Click(object sender, EventArgs e)
        {
            FormNotificacion.Mensaje(TipoNotificacion.Message, "Libros de actas\nPermite gestionar los libros de actas y sus carreras");
        }
    }
}
