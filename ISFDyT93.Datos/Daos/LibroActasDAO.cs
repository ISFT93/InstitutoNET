using ISFDyT93.Datos.Core;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Daos
{
    public class LibroActasDao : DaoBase
    {
        public IList<LibroActasModelo> ObtenerLibroActas()
        {
            string query = @"SELECT 
        LibroActas.LibroActaId,           
        TipoLibros.Descripcion AS Descripcion, 
        LibroActas.LibroNumero,               
        Carreras.Nombre AS Carrera,           
        LibroActas.FolioNumero,
        LibroActas.FolioMaximo,
        LibroActas.FechaAlta,
        LibroActas.FechaBaja,
        LibroActas.Activo
    FROM LibroActas
    INNER JOIN TipoLibros 
        ON LibroActas.TipoLibroId = TipoLibros.TipoLibroId
    LEFT JOIN Carreras 
        ON LibroActas.CarreraID = Carreras.CarreraId
ORDER BY LibroActas.Activo DESC -- El DESC pone los '1' (Activos) arriba";

            return this.MapToModel<LibroActasModelo>(
                this.Conexion.ObtenerRegistros(query)
            );
        }
        public void DesactivarLibro(int libroActaId)
        {
           
            string query = string.Format(@"UPDATE LibroActas 
                                   SET Activo = 0, 
                                       FechaBaja = CAST(GETDATE() AS DATE) 
                                   WHERE LibroActaId = {0}", libroActaId);

            this.Conexion.EjecutarAccion(query);
        }

        public IList<LibroActasModelo> ObtenerTiposLibroDisponibles(int carreraId)
        {
            IList<LibroActasModelo> lista = new List<LibroActasModelo>();

            string query = $@"
        SELECT 
            T.TipoLibroId,
            T.Descripcion
        FROM TipoLibros T
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM LibroActas L
            WHERE L.TipoLibroId = T.TipoLibroId
            AND L.CarreraID = {carreraId}
            AND L.Activo = 1
        )";

            var tabla = this.Conexion.ObtenerRegistros(query);

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new LibroActasModelo
                {
                    TipoLibroId = Convert.ToInt32(row["TipoLibroId"]),
                    Descripcion = row["Descripcion"].ToString()
                });
            }

            return lista;
        }

        public IList<LibroActasModelo> ObtenerCarrerasDisponibles()
        {
            IList<LibroActasModelo> lista = new List<LibroActasModelo>();

            string query = @"
        SELECT DISTINCT
            C.CarreraId,
            C.Nombre
        FROM Carreras C
        WHERE EXISTS
        (
            SELECT 1
            FROM TipoLibros T
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM LibroActas L
                WHERE L.CarreraID = C.CarreraId
                AND L.TipoLibroId = T.TipoLibroId
                AND L.Activo = 1
            )
        )";

            var tabla = this.Conexion.ObtenerRegistros(query);

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new LibroActasModelo
                {
                    CarreraId = Convert.ToInt32(row["CarreraId"]),
                    Carrera = row["Nombre"].ToString()
                });
            }

            return lista;
        }

        public void CrearLibroActa(int tipoLibroId, int carreraId, int folioMaximo)
        {
            string queryNumero = $@"
        SELECT ISNULL(MAX(LibroNumero), 0) + 1 AS NuevoNumero
        FROM LibroActas
        WHERE TipoLibroId = {tipoLibroId}
        AND CarreraID = {carreraId}";

            var tablaNumero = this.Conexion.ObtenerRegistros(queryNumero);

            int nuevoNumero = Convert.ToInt32(tablaNumero.Rows[0]["NuevoNumero"]);

            string queryInsert = $@"
        INSERT INTO LibroActas
        (
            TipoLibroId,
            LibroNumero,
            FolioNumero,
            FolioMaximo,
            FechaAlta,
            FechaBaja,
            Activo,
            CarreraID
        )
        VALUES
        (
            {tipoLibroId},
            {nuevoNumero},
            0,
            {folioMaximo},
            CAST(GETDATE() AS DATE),
            NULL,
            1,
            {carreraId}
        )";

            this.Conexion.ObtenerRegistros(queryInsert);
        }

    }
}
