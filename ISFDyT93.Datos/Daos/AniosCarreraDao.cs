using System;
using System.Data;
using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Datos.Daos
{
    public class AniosCarreraDao : DaoBase
    {
        public DataTable ObtenerAniosCarrera(int carreraId)
        {
            string query = "SELECT AnioCarreraId,AnioCarrera AS [Año],CantidadMaterias AS [Cantidad de Materias],CargaHorariaCompleta AS [Carga Horaria Completa] FROM AniosCarreras WHERE CarreraId = " + carreraId;

            return this.Conexion.ObtenerRegistros(query);
        }
        public int AgregarAnio(int anioCarrera, int carreraId)
        {
            string query = "INSERT INTO AniosCarreras (AnioCarrera, CarreraId) VALUES(" + anioCarrera + "," + carreraId + ")";
                
            return this.Conexion.EjecutarAccion(query);
        }

        public int EliminarAnios(int anioCarreraId)
        {
            string query = "DELETE AniosCarreras WHERE AnioCarreraId = " + anioCarreraId;

            return this.Conexion.EjecutarAccion(query);
        }

        public int ActualizarCargaHoria(int anioCarreraId)
        {
            string query = "UPDATE AniosCarreras SET CantidadMaterias = (SELECT COUNT(MateriaId) FROM Materias WHERE AnioCarreraId =" + anioCarreraId+")," +
            "CargaHorariaCompleta = (SELECT SUM(CargaHoraria) FROM Materias WHERE AnioCarreraId = " + anioCarreraId + ") WHERE AnioCarreraId = " + anioCarreraId;
            
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
            string query = "SELECT SUM(CargaHorariaCompleta) as CargaHoraria FROM AniosCarreras WHERE CarreraId = "+ CarreraId;
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

        public DataRow ObtenerCarrera(int AnioCarreraId)
        {
            string query = "SELECT CarreraId from AniosCarreras where AnioCarreraId=" + AnioCarreraId;
            return this.Conexion.ObtenerRegistro(query);
        }

        public AniosCarrerasModelo ObtenerAnioCarrera(int anioCarreraId)
        {
            string query = $"SELECT A.*, C.DescripcionCorta AS NombreCarrera, C.CarreraEstadoId FROM AniosCarreras A INNER JOIN Carreras C ON A.CarreraId = C.CarreraId where AnioCarreraId = { anioCarreraId }";
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
