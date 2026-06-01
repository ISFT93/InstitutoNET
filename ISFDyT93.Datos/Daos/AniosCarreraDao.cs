using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace ISFDyT93.Datos.Daos
{
    public class AniosCarreraDao : DaoBase , IAniosCarreraDao
    {
        public DataTable ObtenerAniosCarrera(int carreraId)
        {
            string query = "SELECT AniosCarrerasCodigoBloque AS [Código], " +
                "AnioCarreraId, " +
                "CantidadMaterias AS [Cantidad de Materias]," +
                "CargaHorariaCompleta AS [Carga Horaria Completa] " +
                "FROM AniosCarreras WHERE CarreraId = " + carreraId;

            return this.Conexion.ObtenerRegistros(query);
        }
        public int AgregarAnio(int anioCarrera, int carreraId, string aniosCarrerasCodigoBloque)
        {
            string query = "INSERT INTO AniosCarreras (AnioCarrera, CarreraId, AniosCarrerasCodigoBloque) VALUES(" + anioCarrera + "," + carreraId + ",'" + aniosCarrerasCodigoBloque + "')";

            return this.Conexion.EjecutarAccion(query);
        }

        public int EliminarAnios(int anioCarreraId)
        {
            string query = "DELETE AniosCarreras WHERE AnioCarreraId = " + anioCarreraId;

            return this.Conexion.EjecutarAccion(query);
        }

        public int EliminarAniosDeUnaCarrera(int carreraId)
        {
            string query =
                "BEGIN TRY" +
                " BEGIN TRAN;" +
                "  DELETE c FROM Correlativas AS c INNER JOIN Materias m ON c.MateriaId = m.MateriaId WHERE m.CarreraId = " + carreraId + ";" +
                "  DELETE FROM Materias WHERE CarreraId = " + carreraId + ";" +
                "  DELETE FROM AniosCarreras WHERE CarreraId = " + carreraId + ";" +
                " COMMIT;" +
                "END TRY" +
                "  BEGIN CATCH" +
                "  ROLLBACK;" +
                "END CATCH;";

            return this.Conexion.EjecutarAccion(query);
        }


        public int ActualizarCargaHoria(int anioCarreraId)
        {
            //Se ingresa 0 en lugar de NULL en la CargaHoraria
            string query = "UPDATE AniosCarreras SET CantidadMaterias = (SELECT COUNT(MateriaId) FROM Materias WHERE AnioCarreraId = " + anioCarreraId + ")," +
               "CargaHorariaCompleta = (SELECT ISNULL(SUM(CargaHoraria),0) FROM Materias WHERE AnioCarreraId = " + anioCarreraId + ") " +
               "WHERE AnioCarreraId = " + anioCarreraId;

            return this.Conexion.EjecutarAccion(query);
        }

        public DataTable ObtenerAnios(int alumnoId)
        {
            string query = "SELECT AC.AnioCarreraId, AC.AnioCarrera FROM AniosCarreras AC " +
              "INNER JOIN Carreras C ON AC.CarreraId = C.CarreraId " +
              "INNER JOIN AlumnosCarreras ALC ON C.CarreraId = ALC.CarreraId WHERE ALC.AlumnoId =" + alumnoId + " AND ALC.Activo = 1";

            return this.Conexion.ObtenerRegistros(query);
        }

        public int ObtenerCargaHoraria(int CarreraId)
        {
            string query = "SELECT SUM(CargaHorariaCompleta) as CargaHoraria FROM AniosCarreras WHERE CarreraId = " + CarreraId;
            var row = this.Conexion.ObtenerRegistro(query);
            try
            {
                if (row != null)
                {
                    return Convert.ToInt32(row["CargaHoraria"]);
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public int ObtenerIdCarrera(int AnioCarreraId)
        {
            string query = "SELECT CarreraId from AniosCarreras where AnioCarreraId=" + AnioCarreraId;
            var row = this.Conexion.ObtenerRegistro(query);
            return Convert.ToInt32(row["CarreraId"]);

        }

        public DataRow ObtenerCarrera(int AnioCarreraId)
        {
            string query = "SELECT CarreraId from AniosCarreras where AnioCarreraId=" + AnioCarreraId;
            return this.Conexion.ObtenerRegistro(query);
        }

        public AniosCarrerasModelo ObtenerAnioCarrera(int anioCarreraId)
        {
            string query = $"SELECT A.*, C.DescripcionCorta AS NombreCarrera, C.CarreraEstadoId FROM AniosCarreras A INNER JOIN Carreras C ON A.CarreraId = C.CarreraId where AnioCarreraId = {anioCarreraId}";
            return this.MapToModel<AniosCarrerasModelo>(this.Conexion.ObtenerRegistro(query));
        }

        public int ObtenerAnio(int anioCarreraId)
        {
            string query = "SELECT AnioCarrera FROM AniosCarreras WHERE AnioCarreraId = " + anioCarreraId;
            var row = this.Conexion.ObtenerRegistro(query);
            if (row != null)
            {
                return Convert.ToInt32(row["AnioCarrera"]);
            }
            return 0;
        }




    }
}
