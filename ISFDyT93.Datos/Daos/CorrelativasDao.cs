using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Datos.Core;

namespace ISFDyT93.Datos.Daos
{
    public class CorrelativasDao : DaoBase
    {
        public int CorrelativaExisteCarrera(int CarreraId)
        {
            string query = "select correlativaId from correlativas inner join Materias "+
               " on Correlativas.MateriaId = Materias.MateriaId inner join "+
               " AniosCarreras on Materias.AnioCarreraId = AniosCarreras.AnioCarreraId inner join Carreras"+
               " on Carreras.CarreraId = AniosCarreras.CarreraId where carreras.CarreraId = "+CarreraId;

            var cantidad = this.Conexion.ObtenerRegistro(query);
            if (cantidad == null)
            {
                return 0;
            }

            return 1;
        }

        public DataTable ObtenerCorrelatividades(int IdMateria, int IdCarrera)
        {
            var parMateria = new SqlParameter("MateriaID", SqlDbType.Int);
            parMateria.Value = IdMateria;

            var parCarreras = new SqlParameter("CarreraID", SqlDbType.Int);
            parCarreras.Value = IdCarrera;

            var parMensaje = new SqlParameter("Msj", SqlDbType.VarChar, 50);
            parMensaje.Direction = ParameterDirection.Output;

            var parametros = new SqlParameter[3] { parMateria, parCarreras, parMensaje };

            return this.Conexion.EjecutarStore("SP_ListaMaterias", parametros);
        }

        public DataTable ObtenerMateriasCorrelativas(int MateriaId)
        {
            var query = "SELECT C.CorrelativaId, CONCAT(AC.AnioCarrera, '° año - ', M.Nombre) AS Materia, M.MateriaId FROM Correlativas C " +
                    "INNER JOIN Materias M ON C.MateriaCorrelativaId = M.MateriaId " +
                    "INNER JOIN AniosCarreras AC ON M.AnioCarreraId = AC.AnioCarreraId " +
                    "WHERE C.MateriaId = " + MateriaId;

            return this.Conexion.ObtenerRegistros(query);//CONCATENAR EL ANIO
        }


        public int AgregarCorrelativa( int IdMateria, int IdCorrelativa )
        {
            var query = "INSERT INTO Correlativas ( MateriaId, MateriaCorrelativaId ) VALUES ( " + IdMateria + ", " + IdCorrelativa + " ) ";

            return this.Conexion.EjecutarAccion(query);
        }

        public int GuardarCorrelatividades(IList<CorrelatividadModel> correlativas)
        {
            string query = "INSERT INTO Correlativas ( MateriaId, MateriaCorrelativaId) VALUES ";

            for (int i = 0; i < correlativas.Count; i++)
            {
                var modelo = correlativas[i];
                query += string.Format("( {0}, {1} )", modelo.MateriaId, modelo.CorrelatividadId);
                query += i < correlativas.Count - 1 ? "," : ";";//
            }

            return this.Conexion.EjecutarAccion(query);
        }

        public int EliminarCorrelativa(int CorrelativaId)
        {
            var query = "DELETE Correlativas WHERE CorrelativaId =" + CorrelativaId;

            return this.Conexion.EjecutarAccion(query);
        }

        public int EliminarCorrelativas(int IdMateria)
        {
            var query = "DELETE Correlativas WHERE MateriaId =" + IdMateria;

            return this.Conexion.EjecutarAccion(query);
        }

        public DataTable Correlativaid(int CarreraId)
        {
            var query = "SELECT CorrelativaId from Correlativas co inner join materias ma on " +
             "ma.MateriaId = co.MateriaId inner join AniosCarreras ac on ma.AnioCarreraId = ac.AnioCarreraId " +
             "inner join Carreras ca on ac.CarreraId = ca.CarreraId " +
             "where ca.CarreraId = " + CarreraId;

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerCorrelativasAnio(int AnioCarreraId)
        {
            var query = $"select M.Nombre as 'Para cursar', MC.Nombre as 'Necesita' " +
                $"from dbo.Materias M " +
                $"inner join dbo.Correlativas C on C.MateriaId = M.MateriaId " +
                $"inner join dbo.Materias MC on MC.MateriaId = C.MateriaCorrelativaId " +
                $"where M.AnioCarreraId = {AnioCarreraId} order by M.Nombre asc";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerCorrelativasCarrera(int CarreraId)
        {
            var query = $"select M.Nombre as 'Para cursar', MC.Nombre as 'Necesita' from dbo.Materias M " +
                $"inner join dbo.Correlativas C on C.MateriaId = M.MateriaId " +
                $"inner join dbo.Materias MC on MC.MateriaId = C.MateriaCorrelativaId " +
                $"inner join AniosCarreras AC on M.AnioCarreraId = AC.AnioCarreraId " +
                $"where AC.CarreraId = {CarreraId} " +
                $"order by AC.AnioCarreraId asc, M.Nombre asc";
            return this.Conexion.ObtenerRegistros(query);
        }
    }
}
