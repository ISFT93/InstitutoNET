using System.Data;
using System.Data.SqlClient;
using ISFDyT93.Datos.Core;
using ISFDyT93.Entidades.Modelos;

namespace ISFDyT93.Datos.Daos
{
    public class ControlAsistenciasDao : DaoBase
    {
        public DataTable CargarAsistenciasAlumnos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Al.AlumnoId, AC.AlumnoCarreraId, Ca.CursadaId, Ca.CursadaAlumnoCarreraId, Al.Apellido, Ca.HorasCursadas AS Modulos, Ca.UltimoPresentismo, Ca.PorcentajeAsistencia, A.Asistencia FROM AlumnosCarreras AC INNER JOIN Alumnos Al on Al.AlumnoId = AC.AlumnoId inner join CursadaAlumnoCarreras Ca ON AC.AlumnoCarreraId = Ca.AlumnoCarreraId left JOIN  Asistencias A ON ( Ca.CursadaAlumnoCarreraId = A.CursadaAlumnoCarreraId and CA.UltimoPresentismo = A. Fecha)  WHERE Ca.CursadaId = 1 ";
            dt = this.Conexion.ObtenerRegistros(query);
            return dt;
        }

        public DataTable CargarAsistenciasAlumnosReporte(AsistenciasModelo modelo)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Al.AlumnoId, AC.AlumnoCarreraId, Ca.CursadaId, Ca.CursadaAlumnoCarreraId, Concat(Al.Apellido, ', ', Al.Nombre) AS 'Alumnos', Ca.HorasCursadas AS [Módulos], Ca.UltimoPresentismo AS 'Ultimo_Presentismo', Ca.PorcentajeAsistencia AS 'Porcentaje_de_Asistencia', A.Asistencia FROM AlumnosCarreras AC INNER JOIN Alumnos Al on Al.AlumnoId = AC.AlumnoId inner join CursadaAlumnoCarreras Ca ON AC.AlumnoCarreraId = Ca.AlumnoCarreraId left JOIN  Asistencias A ON ( Ca.CursadaAlumnoCarreraId = A.CursadaAlumnoCarreraId and ' " + modelo.FechaAsistenciaStr + "'= A. Fecha)  WHERE Ca.CursadaId = 1 ";
            dt = this.Conexion.ObtenerRegistros(query);
            return dt;
        }

        public DataTable CargarAsistenciasAnteriores(AsistenciasModelo Modelo)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Al.AlumnoId, AC.AlumnoCarreraId, Ca.CursadaId, Ca.CursadaAlumnoCarreraId, Al.Apellido, Ca.HorasCursadas AS Modulos, Ca.UltimoPresentismo, Ca.PorcentajeAsistencia, A.Asistencia FROM AlumnosCarreras AC INNER JOIN Alumnos Al on Al.AlumnoId = AC.AlumnoId inner join CursadaAlumnoCarreras Ca ON AC.AlumnoCarreraId = Ca.AlumnoCarreraId left JOIN  Asistencias A ON (Ca.CursadaAlumnoCarreraId = A.CursadaAlumnoCarreraId AND A.Fecha = '" + Modelo.FechaAsistenciaStr + "') WHERE Ca.CursadaId = 1";
            dt = this.Conexion.ObtenerRegistros(query);
            return dt;
        }

        public DataRow CargarProfesor()
        {
            string query = $"SELECT Nombre, Apellido FROM Personal WHERE PersonalId = 2";
            return this.Conexion.ObtenerRegistro(query);
        }

        public void ActualizoUltimaFechaAsistencia(AsistenciasModelo Modelo)
        {
            string FechaA = Modelo.UltimoPresentismo.ToString("yyyy-MM-dd");
            string query = "update CursadaAlumnoCarreras set UltimoPresentismo = '" + FechaA + "', HorasCursadas = '" + Modelo.HorasCursadas + "', PorcentajeAsistencia = '" + Modelo.PorcentajeAsistencia + "'  where CursadaAlumnoCarreraId = '" + Modelo.CursadaAlumnoCarreraId + "'";
            this.Conexion.EjecutarAccion(query);
        }

        public int AgregarAsistencia(AsistenciasModelo Modelo)
        {
            string FechaA = Modelo.UltimoPresentismo.ToString("yyyy-MM-dd");
            string query = $"INSERT INTO Asistencias VALUES ('{FechaA}', '{Modelo.Asistencia}', {Modelo.CursadaAlumnoCarreraId})";
            return this.Conexion.EjecutarAccion(query);
        }

        public int ActualizarCursada(AsistenciasModelo Modelo)
        {
            string FechaA = Modelo.FechaAsistenciaStr;
            string query = $"UPDATE Cursadas SET HoraCatedra = '{Modelo.HorasCursadas}', FechaAsistencia = '{FechaA}', PorcentajeAsistencia = '{Modelo.PorcentajeAsistencia}' WHERE CursadaId = {Modelo.CursadaId}";
            return this.Conexion.EjecutarAccion(query);
        }

        public DataRow CalculaTotalAlumnos()
        {
            DataRow dr;
            string query = "select count(CursadaAlumnoCarreraId) from CursadaAlumnoCarreras where CursadaId = 1";
            dr = this.Conexion.ObtenerRegistro(query);
            return dr;
        }
        public DataRow CalculaModulosAlumnos(AsistenciasModelo Modelo)
        {
            DataRow dr;
            string query = "select HorasCursadas AS Modulos from CursadaAlumnoCarreras where CursadaAlumnoCarreraId = '" + Modelo.CursadaAlumnoCarreraId + "'";
            dr = this.Conexion.ObtenerRegistro(query);
            return dr;
        }
        public DataRow CalcularPorcentajeAsistenciaAlumnos(AsistenciasModelo Modelo)
        {
            DataRow dr;
            string query = "select PorcentajeAsistencia from CursadaAlumnoCarreras where AlumnoCarreraId = '" + Modelo.AlumnoCarreraId + "'";
            dr = this.Conexion.ObtenerRegistro(query);
            return dr;
        }

        public DataTable GuardarAsistenciasAlumnos(AsistenciasModelo Modelo)
        {
            DataTable dt = new DataTable();
            string query = "update CursadaAlumnoCarreras set AlumnoCarreraId=" + Modelo.AlumnoCarreraId + "'";
            dt = this.Conexion.ObtenerRegistros(query);
            return dt;
        }
        public int ActualizarGrilla(AsistenciasModelo Modelo)
        {
            int res = 0;
            var parHorascursadasCa = new SqlParameter("HorascursadasCa", SqlDbType.Int);
            parHorascursadasCa.Value = Modelo.HorasCursadas;
            var parPorcentajeAsistenciaCa = new SqlParameter("PorcentajeAsistenciaCa", SqlDbType.Int);
            parPorcentajeAsistenciaCa.Value = Modelo.PorcentajeAsistencia;
            var parUltimoPresentismoCa = new SqlParameter("UltimoPresentismoCa", SqlDbType.Date);
            parUltimoPresentismoCa.Value = Modelo.UltimoPresentismo;
            var parFechaAsistencia = new SqlParameter("FechaAsistencia", SqlDbType.Date);
            parFechaAsistencia.Value = Modelo.FechaAsistenciaStr;
            var parPorcentajeAsistenciaC = new SqlParameter("PorcentajeAsistenciaC", SqlDbType.Float);
            parPorcentajeAsistenciaC.Value = Modelo.PorcentajeAsistenciaC;
            var parCursadaId = new SqlParameter("CursadaId", SqlDbType.Int);
            parCursadaId.Value = Modelo.CursadaId;
            var parAlumnoCarreraId = new SqlParameter("AlumnoCarreraId", SqlDbType.Int);
            parAlumnoCarreraId.Value = Modelo.AlumnoCarreraId;
            var parHoraCatedraC = new SqlParameter("HoraCatedraC", SqlDbType.Int);
            parHoraCatedraC.Value = Modelo.HoraCatedra;
            var parAsistencia = new SqlParameter("Asistencia", SqlDbType.Char);
            parAsistencia.Value = Modelo.Asistencia;
            var parCursadaAlumnoCarreraId = new SqlParameter("CursadaAlumnoCarreraId", SqlDbType.Int);
            parCursadaAlumnoCarreraId.Value = Modelo.Asistencia;
            var parametros = new SqlParameter[10] { parHorascursadasCa, parPorcentajeAsistenciaCa, parUltimoPresentismoCa, parFechaAsistencia, parHoraCatedraC, parPorcentajeAsistenciaC, parCursadaId, parAlumnoCarreraId, parAsistencia, parCursadaAlumnoCarreraId };
            res = this.Conexion.EjecutarStoreNumber("SP_ActualizarPorcentajeAsistencia", parametros);
            return res;
        }

        public DataTable HistorialAsistenciasAlumnos(AsistenciasModelo Modelo)
        {
            string query = "select Fecha AS [Fechas], iif(Asistencia = 'P', 'Presente', 'Ausente') AS [Asistencia] from Asistencias where CursadaAlumnoCarreraId = " + Modelo.CursadaAlumnoCarreraId;
            return this.Conexion.ObtenerRegistros(query);
        }
    }
}
