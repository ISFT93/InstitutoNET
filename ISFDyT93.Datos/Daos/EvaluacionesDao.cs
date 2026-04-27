using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Datos.Daos
{
    public class EvaluacionesDao : DaoBase
    {
        public DataTable ObtenerAlumnos(int ServicioId)
        {
            string query = "select cac.CursadaAlumnoCarreraId, CONCAT(UPPER(a.Apellido),', ',a.Nombre) AS Alumnos, cac.Estado as Condicion, cu.CursadaId from Servicios se inner join CursoMaterias cm on se.CursoMateriaId=cm.CursoMateriaId " +
                "inner join Materias ma on ma.MateriaId = cm.MateriaId inner join " +
                "Cursadas cu on cu.CursoMateriaId = cm.CursoMateriaId inner join " +
                "CursadaAlumnoCarreras cac on cac.CursadaId = cu.CursadaId inner join " +
                "AlumnosCarreras ac on cac.AlumnoCarreraId = ac.AlumnoCarreraId inner join " +
                "Alumnos a on a.AlumnoId = ac.AlumnoId " +
                $"WHERE se.ServicioId={ServicioId}";

            return this.Conexion.ObtenerRegistros(query);
        }

        public int AsignarFechaExamen(int CursadaId, DateTime fecha, int Evaluados )
        {
            var parCursadaId = new SqlParameter("CursadaId", SqlDbType.Int);
            parCursadaId.Value = CursadaId;

            var parFecha = new SqlParameter("Fecha", SqlDbType.Date);
            parFecha.Value = fecha;

            var parEvaluados = new SqlParameter("Evaluados", SqlDbType.Int);
            parEvaluados.Value = Evaluados;

           var parametros = new SqlParameter[3] { parCursadaId,parFecha,parEvaluados };



            return this.Conexion.EjecutarStoreNumber("SP_CursadaExamen", parametros);
             
        }

        public DataRow ObtenerUltimoExamenId()
        {
            string query = "SELECT CursadaExamenId from CursadaExamen WHERE TipoExamenId=(SELECT MAX(TipoExamenId) FROM CursadaExamen)";
            return this.Conexion.ObtenerRegistro(query);
        }

        public void AsignarNotas(int nota,int CursadaExamenId, int CursadaAlumnoCarreraId)
        {
            string query = $"INSERT INTO CursadaNotas(CursadaExamenId,CursadaAlumnoCarreraId,nota) VALUES({CursadaExamenId},{CursadaAlumnoCarreraId},{nota})";
        }
        public void ModificarNota(int nota, int CursadaExamenId, int CursadaAlumnoCarreraId)
        {
            string query = $"UPDATE CursadaNotas";
        }
    }
}
