using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ISFDyT93.Datos.Daos
{
    public class CarrerasDao : DaoBase , ICarrerasDao
    {
        public DataTable ObtenerTodasLasCarreras(bool Activo = true)
        {
            //Todas las carreras(Activas,Inactivas,Borrador).
            string query = "SELECT C.CarrerasCodigoBloque AS [Código], C.CarreraId, C.Nombre, C.DescripcionCorta AS [Descripción], " +
                "C.NumeroExpediente AS [Numero de Expediente], C.AnioInicio as [Año de Inicio], IIF(C.AnioFin > 0, " +
                "Convert(nvarchar(4), C.AnioFin) , '') as [Año de Fin], C.CantidadHoras as [Carga Horaria Completa], " +
                "C.CarreraEstadoId, CE.Descripcion AS Estado FROM Carreras C" +
              " INNER JOIN Estados CE on C.CarreraEstadoId = CE.EstadoId";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerCarreras(bool Activo = true)
        {
            //Query para seleccionar todos resgistros de Carreras
            string query = "SELECT C.CarrerasCodigoBloque AS [Código], C.CarreraId, C.Nombre, C.DescripcionCorta AS [Descripción], C.NumeroExpediente AS [Numero de Expediente], C.AnioInicio as [Año de Inicio], IIF(C.AnioFin > 0, Convert(nvarchar(4), C.AnioFin) , '') as [Año de Fin], C.CantidadHoras as [Carga Horaria Completa], C.CarreraEstadoId, CE.Descripcion AS Estado FROM Carreras C" +
              " INNER JOIN Estados CE on C.CarreraEstadoId = CE.EstadoId WHERE C.CarreraEstadoId = 1" +
              " ORDER BY C.Nombre ASC;";

            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ObtenerCarrerasConPrimeroActivo(bool Activo = true)
        {
            //Query para seleccionar todos resgistros de Carreras
            string query = @"SELECT
                                C.CarrerasCodigoBloque AS [Código],
                                C.CarreraId,
                                C.Nombre,
                                C.DescripcionCorta AS [Descripción],
                                C.NumeroExpediente AS [Numero de Expediente],
                                C.AnioInicio AS [Año de Inicio],
                                IIF(C.AnioFin > 0, CONVERT(NVARCHAR(4), C.AnioFin), '') AS [Año de Fin],
                                C.CantidadHoras AS [Carga Horaria Completa],
                                C.CarreraEstadoId,
                                CE.Descripcion AS Estado
                            FROM Carreras C
                            INNER JOIN Estados CE
                                ON C.CarreraEstadoId = CE.EstadoId
                            WHERE
                                C.CarreraEstadoId = 1
                                AND EXISTS (
                                    SELECT 1
                                    FROM AniosCarreras AC
                                    INNER JOIN Cursos CU
                                        ON CU.AnioCarreraId = AC.AnioCarreraId
                                    WHERE
                                        AC.CarreraId = C.CarreraId
                                        AND AC.AnioCarrera = 1
                                        AND CU.Activo = 1
                                )
                            ORDER BY C.Nombre ASC;";

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable CarrerasInactivas(bool Activo = false)
        {
            //Obtiene info de Carreras en estado Inactivas
            string query = "SELECT CarrerasCodigoBloque AS [Código], C.CarreraId, " +
                "C.Nombre, C.DescripcionCorta AS [Descripción], " +
                "C.NumeroExpediente AS [Numero de Expediente], " +
                "C.CarreraEstadoId , CE.Descripcion AS Estado " +
                "FROM Carreras C INNER JOIN Estados CE on C.CarreraEstadoId = CE.EstadoId AND C.CarreraEstadoId = " + (Activo ? "1" : "2");
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable CarrerasBorrador(bool Activo = false)
        {
            //Obtiene info de Carreras en estado Borrador
            string query = "SELECT C.CarrerasCodigoBloque AS [Código], C.CarreraId, " +
                "C.Nombre, C.DescripcionCorta AS [Descripción], C.NumeroExpediente AS [Numero de Expediente], " +
                "C.CarreraEstadoId , C.CantidadHoras as [Carga Horaria Completa], " +
                "CE.Descripcion AS Estado " +
                "FROM Carreras C INNER JOIN Estados CE on C.CarreraEstadoId = CE.EstadoId AND C.CarreraEstadoId = " + (Activo ? "1" : "3");
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable CarrerasActivas(bool Activo = true)
        {
            //Obtiene info de Carreras en estado Activas
            string query = "SELECT C.CarrerasCodigoBloque AS [Código], C.CarreraId, C.Nombre, " +
                "C.DescripcionCorta AS [Descripción], C.NumeroExpediente AS [Numero de Expediente], " +
                "C.CarreraEstadoId , CE.Descripcion AS Estado " +
                "FROM Carreras C INNER JOIN Estados CE on C.CarreraEstadoId = CE.EstadoId AND C.CarreraEstadoId = " + (Activo ? "1" : "1");// FROM Carreras WHERE CarreraEstadoId = " + (Activo ? "1" : "1");

            return this.Conexion.ObtenerRegistros(query);
        }
        public int TraeIdDeCarrera(string nombre)
        {
            string query = "SELECT CarreraId FROM Carreras WHERE Nombre = '" + nombre + "'";
            var carrera = this.Conexion.ObtenerRegistro(query);

            if (carrera != null)
            {
                return Convert.ToInt32(carrera["CarreraId"]);
            }

            return 0;

        }
        public CarrerasModelo ObtenerCarrera(int id)
        { /* Si activo es true escribe 1 si no 0 */
            string query = "SELECT * FROM Carreras WHERE CarreraId = " + id;

            return this.MapToModel<CarrerasModelo>(this.Conexion.ObtenerRegistro(query));
        }

        public DataRow CarreraExiste(string Nombre)
        {
            string query = "SELECT TOP 1 CarreraId FROM Carreras WHERE Nombre = '" + Nombre + "'";
            return this.Conexion.ObtenerRegistro(query);
        }

        public int CarreraTienePrimerAnio(int id)
        {
            string query = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM AniosCarreras WHERE CarreraId = "+id+ " AND AnioCarrera = 1) THEN 1 ELSE 0 END AS TienePrimerAnio";
            var row = this.Conexion.ObtenerRegistro(query);
            int existe = Convert.ToInt32(row["TienePrimerAnio"]);
            return existe;
        }

        public int ObtenerUltimoCarreraId()
        { /* Si activo es true escribe 1 si no 0 */
            string query = "SELECT TOP 1 CarreraId FROM Carreras ORDER BY CarreraId DESC";

            var row = this.Conexion.ObtenerRegistro(query);

            if (row != null)
            {
                return Convert.ToInt32(row["CarreraId"]);
            }
            return 0;
        }

        //METODO para agregar carreras a la base de datos
        public int AgregarCarreras(CarrerasModelo modelo)
        {
            string query = this.CreateInsertQuery<CarrerasModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }

        //METODO para modificar carreras de la base 
        public int ModificarCarrera(CarrerasModelo modelo)
        {
            string query = this.CreateUpdateQuery<CarrerasModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }

        public int ModificarCarreraEstado(CarrerasModelo modelo)
        {
            string query = "UPDATE Carreras SET CarreraEstadoId=" + modelo.CarreraEstadoId + " WHERE CarreraId= " + modelo.CarreraId;
            return this.Conexion.EjecutarAccion(query);
        }

        public void EliminarCarrera(int CarreraId)
        {
            // string query = "UPDATE Carreras SET Activo = " + 0 + "WHERE CarreraId = " + CarreraId + "";
            string query = "DELETE Carreras WHERE CarreraId =" + CarreraId;
            this.Conexion.EjecutarAccion(query);
        }

        public void AltaCarreraActivo(int CarreraId)
        {
            string query = "UPDATE Carreras SET CarreraEstadoId = 1 WHERE CarreraId = " + CarreraId + "";
            this.Conexion.EjecutarAccion(query);
        }

        public void ActualizarCargaHoraria(int CarreraId, int cantidadHoras)
        {
            string query = "UPDATE Carreras SET CantidadHoras = " + cantidadHoras + " WHERE CarreraId = " + CarreraId + "";
            this.Conexion.EjecutarAccion(query);
        }

        //Crea codigo de bloque para Carreras
        public int GeneraCarrerasCodigoBloque()
        {
            string query = "SELECT ISNULL((SELECT TOP 1 CarrerasCodigoBloque FROM Carreras ORDER BY CarrerasCodigoBloque DESC), 0) AS CarrerasCodigoBloque";
            var row = this.Conexion.ObtenerRegistro(query);
            int codigo = Convert.ToInt32(row["CarrerasCodigoBloque"]);
            codigo++;
            return codigo;
        }

        public int CantidadCorrelativasCarrera(int CarreraId)
        {
            string query = "SELECT CantidadCorrelativas FROM Carreras WHERE CarreraId = " + CarreraId + "";
            var row = this.Conexion.ObtenerRegistro(query);
            int cantCorrelativas = Convert.ToInt32(row["CantidadCorrelativas"]);

            return cantCorrelativas;
        }

    }
}
