using ISFDyT93.Datos.Core;
using ISFDyT93.Entidades.Core.Attributes.Validaciones;
using ISFDyT93.Entidades.Enums;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISFDyT93.Datos.Daos
{
    public class LibroActasDao
    {
        public DataTable ObtenerLibros()
        {
            /* string query = "SELECT la.TipoLibroId, la.CarreraID, tl.Descripcion, la.LibroNumero, c.DescripcionCorta," +
                            " la.FolioNumero, la.FolioMaximo, la.FechaAlta, la.FechaBaja, la.Activo FROM TipoLibros tl " +
                            "LEFT JOIN LibroActas la ON tl.TipoLibroId = la.TipoLibroId " +
                            "LEFT JOIN Carreras c ON c.CarreraId = la.CarreraID ORDER BY Activo DESC, LibroNumero DESC"; */
            string query = "SELECT la.TipoLibroId, la.CarreraID, tl.Descripcion, la.LibroNumero, c.DescripcionCorta, " +
                       "la.FolioNumero, la.FolioMaximo, la.FechaAlta, la.FechaBaja, la.Activo " +
                       "FROM TipoLibros tl " +
                       "INNER JOIN LibroActas la ON tl.TipoLibroId = la.TipoLibroId " +
                       "LEFT JOIN Carreras c ON c.CarreraId = la.CarreraID " +
                       "ORDER BY la.Activo DESC, la.LibroNumero DESC; ";
            Conexion conexion = new Conexion();
            DataTable libros = conexion.ObtenerRegistros(query);

            return libros;
        }

        public bool RelacionNuevaPosible()
        {
            string query = "SELECT t.TipoLibroID FROM TipoLibros t WHERE t.Descripcion <> 'Libro de Toma de Posición' AND EXISTS " +
                "(SELECT 1 FROM Carreras c WHERE NOT EXISTS (SELECT 1 FROM LibroActas l WHERE l.TipoLibroID = t.TipoLibroID AND l.CarreraID = c.CarreraID))";

            Conexion conexion = new Conexion();
            DataTable registros = conexion.ObtenerRegistros(query);

            if (registros.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool ActualizacionPosible()
        {
            string query = "SELECT l.TipoLibroID, l.CarreraID, l.LibroNumero, l.Activo FROM LibroActas l " +
                        "INNER JOIN (SELECT TipoLibroID,CASE WHEN CarreraID IS NULL THEN -1 ELSE CarreraID END AS CarreraAgrupada, " +
                        "MAX(LibroNumero) AS UltimoLibroNumero FROM LibroActas GROUP BY TipoLibroID, CASE WHEN CarreraID IS NULL THEN -1 ELSE CarreraID END) " +
                        "ultimos ON l.TipoLibroID = ultimos.TipoLibroID AND CASE WHEN l.CarreraID IS NULL THEN -1 ELSE l.CarreraID END = ultimos.CarreraAgrupada " +
                        "AND l.LibroNumero = ultimos.UltimoLibroNumero WHERE l.Activo = 0;";
            Conexion conexion = new Conexion();
            DataTable registros = conexion.ObtenerRegistros(query);

            if (registros.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public int? ObtenerTomaPosicion()
        {
            string query = "SELECT tl.TipoLibroId FROM TipoLibros tl WHERE Descripcion = 'Libro de Toma de Posición'";
            Conexion conexion = new Conexion();
            DataRow row = conexion.ObtenerRegistro(query);

            if (row != null && row["TipoLibroId"] != DBNull.Value)
                return Convert.ToInt32(row["TipoLibroId"]);
            else
                return null;
        }
        public void LibrosSinActualizar(ComboBox cmb)
        {
            string query = "SELECT DISTINCT t.TipoLibroID, t.Descripcion FROM TipoLibros t " +
                        "INNER JOIN LibroActas l ON t.TipoLibroID = l.TipoLibroID INNER JOIN " +
                        "(SELECT TipoLibroID, CarreraID, MAX(LibroNumero) AS UltimoLibroNumero FROM LibroActas " +
                        "GROUP BY TipoLibroID, CarreraID) ultimos ON l.TipoLibroID = ultimos.TipoLibroID AND " +
                        "l.CarreraID = ultimos.CarreraID AND l.LibroNumero = ultimos.UltimoLibroNumero WHERE l.Activo = 0 " +
                        "UNION " +
                        "SELECT DISTINCT t.TipoLibroID, t.Descripcion FROM TipoLibros t " +
                        "INNER JOIN LibroActas l ON t.TipoLibroId = l.TipoLibroId INNER JOIN " +
                        "(SELECT TipoLibroID, MAX(LibroNumero) AS UltimoLibroNumero FROM LibroActas " +
                        "GROUP BY TipoLibroId) ultimos ON l.TipoLibroId = ultimos.TipoLibroId AND " +
                        "l.CarreraID IS NULL AND l.LibroNumero = ultimos.UltimoLibroNumero WHERE l.Activo = 0";

            Conexion conexion = new Conexion();
            DataTable librosSinActualizar = conexion.ObtenerRegistros(query);

            cmb.DataSource = librosSinActualizar;
            cmb.ValueMember = "TipoLibroID";
            cmb.DisplayMember = "Descripcion";
        }
        public void CarrerasSinActualizar(ComboBox cmb, int TipoLibroId)
        {
            string query = $"SELECT c.CarreraID, c.DescripcionCorta FROM Carreras c INNER JOIN LibroActas l ON " +
                         "c.CarreraID = l.CarreraID INNER JOIN (SELECT TipoLibroID, CarreraID, MAX(LibroNumero) AS UltimoLibroNumero " +
                        $"FROM LibroActas WHERE TipoLibroID = {TipoLibroId} GROUP BY TipoLibroID, CarreraID) ultimos ON " +
                        "l.TipoLibroID = ultimos.TipoLibroID AND l.CarreraID = ultimos.CarreraID AND l.LibroNumero = ultimos.UltimoLibroNumero WHERE l.Activo = 0";
            Conexion conexion = new Conexion();
            DataTable carreras = conexion.ObtenerRegistros(query);

            cmb.DataSource = carreras;
            cmb.ValueMember = "CarreraID";
            cmb.DisplayMember = "DescripcionCorta";
        }
        public void LibrosSinRelacionar(ComboBox cmb, int? excepcion)
        {
            if (excepcion == null)
                excepcion = 0;

            string query = "SELECT t.TipoLibroID, t.Descripcion FROM TipoLibros t WHERE EXISTS " +
                           "(SELECT 1 FROM Carreras c WHERE NOT EXISTS(SELECT 1 FROM LibroActas l WHERE " +
                           $"l.TipoLibroID = t.TipoLibroID AND l.CarreraID = c.CarreraID)) AND t.TipoLibroID NOT IN({excepcion}) " +
                           "UNION " +
                           $"SELECT t.TipoLibroID, t.Descripcion FROM TipoLibros t WHERE t.TipoLibroId = {excepcion} AND NOT EXISTS " +
                           $"(SELECT 1 FROM LibroActas la WHERE la.TipoLibroId = {excepcion})";
            Conexion conexion = new Conexion();
            DataTable librosSinRelacionar = conexion.ObtenerRegistros(query);

            cmb.DataSource= librosSinRelacionar;
            cmb.ValueMember = "TipoLibroID";
            cmb.DisplayMember = "Descripcion";
        }
        public void CarrerasSinRelacionar(ComboBox cmb, int TipoLibroId)
        {
            string query = $"SELECT c.CarreraID, c.DescripcionCorta FROM Carreras c WHERE NOT EXISTS (SELECT 1 FROM LibroActas l WHERE l.CarreraID = c.CarreraID AND l.TipoLibroID = {TipoLibroId})";
            Conexion conexion = new Conexion();
            DataTable carrerasSinRelacionar = conexion.ObtenerRegistros(query);

            cmb.DataSource = carrerasSinRelacionar;
            cmb.ValueMember = "CarreraID";
            cmb.DisplayMember = "DescripcionCorta";
        }
        public void SumarNumeroLibro(int TipoLibroId, int? CarreraId, int FoliosMaximos, DateTime FechaAlta)
        {
            Conexion conexion = new Conexion();

            string ultimoNumero = $"SELECT ISNULL(MAX(LibroNumero), 0) + 1 AS NumeroLibro FROM LibroActas WHERE TipoLibroID = {TipoLibroId}";
            DataRow registro = conexion.ObtenerRegistro(ultimoNumero);
            int nuevoNumeroLibro = Convert.ToInt32(registro["NumeroLibro"]);

            try
            {
                SqlParameter[] parametros = new SqlParameter[]
                {
                new SqlParameter("@TipoLibroID", TipoLibroId),
                new SqlParameter("@LibroNumero", nuevoNumeroLibro),
                new SqlParameter("@CarreraID", CarreraId.HasValue ? CarreraId.Value : (object)DBNull.Value),
                new SqlParameter("@FolioMaximo", FoliosMaximos),
                new SqlParameter("@FechaAlta", FechaAlta)
                };

                conexion.EjecutarStore("AgregarNumeroLibro", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al momento de sumar el numero del libro: \n{ex}");
            }
        }
    }
}
