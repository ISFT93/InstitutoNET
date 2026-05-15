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
            string query = "SELECT la.TipoLibroId, la.CarreraID, tl.Descripcion, la.LibroNumero, c.DescripcionCorta, la.FolioNumero, la.FolioMaximo, la.FechaAlta, la.FechaBaja, la.Activo FROM TipoLibros tl INNER JOIN LibroActas la ON tl.TipoLibroId = la.TipoLibroId INNER JOIN Carreras c ON c.CarreraId = la.CarreraID ORDER BY Activo DESC, LibroNumero DESC";
            Conexion conexion = new Conexion();
            DataTable dt = conexion.ObtenerRegistros(query);

            dgv.DataSource = dt;
            dgv.Columns["TipoLibroId"].Visible = false;
            dgv.Columns["CarreraID"].Visible = false;
        }

        private void AbrirNuevoLibro(bool nuevaRelacion)
        {
            using (FormCargarNumLibro frm = new FormCargarNumLibro(nuevaRelacion))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarDGV(dgvLibros);
                }
            }
        }
        private bool RelacionNuevaPosible()
        {
            string query = "\r\nSELECT t.TipoLibroID FROM TipoLibros t WHERE EXISTS (SELECT 1 FROM Carreras c WHERE NOT EXISTS (SELECT 1 FROM LibroActas l WHERE l.TipoLibroID = t.TipoLibroID AND l.CarreraID = c.CarreraID))";
            Conexion conexion = new Conexion();
            DataTable registros = conexion.ObtenerRegistros(query);

            if (registros.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private bool ActualizacionPosible()
        {
            string query = "SELECT l.TipoLibroID, l.CarreraID, l.LibroNumero, l.Activo FROM LibroActas l INNER JOIN (SELECT TipoLibroID, CarreraID, MAX(LibroNumero) AS UltimoLibroNumero FROM LibroActas GROUP BY TipoLibroID, CarreraID) ultimos ON l.TipoLibroID = ultimos.TipoLibroID AND l.CarreraID = ultimos.CarreraID AND l.LibroNumero = ultimos.UltimoLibroNumero WHERE Activo = 0";
            Conexion conexion = new Conexion();
            DataTable registros = conexion.ObtenerRegistros(query);

            if (registros.Rows.Count > 0)
                return true;
            else
                return false;

        }
        private void MenuContextual()
        {
            dgvLibros.ContextMenuStrip = menu;

            if (ActualizacionPosible() == true)
                opcionActualizarLibro.Visible = true;
            else
                opcionActualizarLibro.Visible = false;

            if (RelacionNuevaPosible() == true)
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
