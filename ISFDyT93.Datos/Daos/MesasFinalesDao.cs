using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ISFDyT93.Datos.Core;
using System.Reflection;
using System.Data.SqlClient;
using System.Globalization;
using System.Security;
using ISFDyT93.Datos.Interfaces;

namespace ISFDyT93.Datos.Daos
{
    public class MesasFinalesDao : DaoBase , IMesasFinalesDao
    {

        public DataTable ObtenerProfesorTitular(int MateriaId)
        {
            var query = $"select Pe.PersonalId, concat (Pe.Nombre, ' ', Pe.Apellido) as Nombre from Personal Pe " +
                $"inner join Servicios Se on Pe.PersonalId = Se.PersonalId " +
                $"inner join CursoMaterias Cu on Se.CursoMateriaId = Cu.CursoMateriaId " +
                $"inner join Materias Ma on Cu.MateriaId = Ma.MateriaId " +
                $"where Ma.MateriaId = {MateriaId} and Se.Activo = 1";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerVocales(int CarreraId, int PersonalId)
        {
            var query = $"select Pe.PersonalId, concat (Pe.Nombre, ' ', Pe.Apellido) as Nombre from Personal Pe " +
                $"inner join Servicios Se on Pe.PersonalId = Se.PersonalId " +
                $"left join CursoMaterias CM on Se.CursoMateriaId = CM.CursoMateriaId " +
                $"left join Materias Ma on CM.MateriaId = Ma.MateriaId " +
                $"left join AniosCarreras AC on Ma.AnioCarreraId = AC.AnioCarreraId " +
                $"where (Se.CarreraId = {CarreraId} or AC.CarreraId = {CarreraId}) and Se.Activo = 1 " +
                $"and Se.PersonalId <> {PersonalId} " +
                $"group by Pe.PersonalId, Pe.Nombre, Pe.Apellido " +
                $"order by Pe.Apellido, Pe.Nombre";
            return this.Conexion.ObtenerRegistros(query);
        }

        public int AgregarMesa(int CarreraId, DateTime fecha, int Turno, int Llamado, int MateriaId, int PresidenteId, int AnioLectivo, int? VocalId = null)
        {
            string vocalSql = VocalId.HasValue
        ? VocalId.Value.ToString()
        : "NULL";
            var query = $@" INSERT INTO MesasFinales ( CarreraId, TurnoId,LlamadoId, MateriaId, PresidenteId, CicloLectivoId, FinalEstadoId ) VALUES ( {CarreraId}, {Turno}, {Llamado}, {MateriaId}, {PresidenteId}, {AnioLectivo}, 1)";
            return this.Conexion.EjecutarAccion(query);
        }

        public DataTable ObtenerMesas(int CarreraId)
        {
            var query = "select Fi.MesaFinalId, Fi.Fecha, Ll.Descripcion as 'Llamado', Tu.Descripcion as 'Turno', Ma.Nombre as 'Materia', concat(Pe.Nombre, ' ', Pe.Apellido) as 'Titular', concat(Voc.Nombre, ' ', Voc.Apellido) as Vocal, Est.Descripcion as 'Estado'" +
                        " m MesasFinales Fi inner join Materias Ma on Fi.MateriaId = Ma.MateriaId inner join Turnos Tu on Fi.TurnoId = Tu.TurnoId" +
                        " inner join Llamados Ll on Fi.LlamadoId = Ll.LlamadoId inner join Estados Est on Fi.FinalEstadoId = Est.EstadoId left" +
                        $"join Personal Pe on Fi.PresidenteId = Pe.PersonalId left join Personal Voc on Fi.VocalId = Voc.PersonalId where Fi.CarreraId = {CarreraId}";
            return this.Conexion.ObtenerRegistros(query);
        }

        public int ModificarMesas(DateTime fecha, int turno, int presidenteId, int vocalId, int mesaFinalId)
        {
            var query = $"update MesasFinales set Fecha = '{fecha:yyyy-MM-dd}', TurnoId = '{turno}',PresidenteId ={presidenteId}, VocalId = {vocalId}, FinalEstadoId = 1 where MesaFinalId = {mesaFinalId}";
            return this.Conexion.EjecutarAccion(query);
        }

        public int EliminarMesas(int mesaFinalId)
        {
            var query = $"delete from MesasFinales where MesaFinalId = {mesaFinalId}";
            return this.Conexion.EjecutarAccion(query);
        }

        public DataTable ObtenerMateriaFinal(int mesaFinalId)
        {
            var query = "select Ma.MateriaId, Ma.Nombre from Materias Ma " +
                "inner join MesasFinales Fi on Ma.MateriaId = Fi.MateriaId " +
                $"where Fi.MesaFinalId = {mesaFinalId}";  
            return this.Conexion.ObtenerRegistros(query);
        }

        public int CargarMesasFinales(int cicloLectivoId, int turnoId)
        {
            var parcicloLectivoId = new SqlParameter ("anioLectivo", SqlDbType.Int);
            parcicloLectivoId.Value = cicloLectivoId;
            var parturnoId = new SqlParameter("turnoId", SqlDbType.Int);
            parturnoId.Value = turnoId;
            var parameters = new SqlParameter[2] { parcicloLectivoId, parturnoId };
            var res = this.Conexion.EjecutarStoreNumber("SP_CrearMesasFinales", parameters);
            return res;
        }

        public DataTable ObtenerTurnoMesa(int mesaFinalId)
        {
            var query = $"select Tu.TurnoId, Tu.Descripcion from Turnos Tu inner join MesasFinales MF " +
                $"on Tu.TurnoId = MF.TurnoId where MF.MesaFinalId = {mesaFinalId}";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerTurnos()
        {
            var query = "select * from Turnos";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerAniosLectivos()
        {
            var query = "select AnioLectivo as CicloLectivoId from CicloLectivo order by AnioLectivo desc";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerMesasFiltro(int carreraId, int anioLectivoId, int turnoId, int llamadoId, int anioCarreraId = 0, int cursoId = 0, int materiaId = 0, int profesorId = 0)
        {
            var query = "select distinct Fi.MesaFinalId, Ma.Nombre as 'Materia', Ll.Descripcion as 'Llamado', Tu.Descripcion as 'Turno', Fi.Fecha, concat(Pe.Nombre, ' ', Pe.Apellido) as 'Titular', concat(Voc.Nombre, ' ', Voc.Apellido) as Vocal, Est.Descripcion as 'Estado', Fi.VocalId, Fi.CarreraId, Fi.CicloLectivoId,Fi.FinalEstadoId" +
                " from MesasFinales Fi inner join Materias Ma on Fi.MateriaId = Ma.MateriaId" +
                " inner join Turnos Tu on Fi.TurnoId = Tu.TurnoId" +
                " inner join Llamados Ll on Fi.LlamadoId = Ll.LlamadoId" +
                " inner join Estados Est on Fi.FinalEstadoId = Est.EstadoId" +
                " left join Personal Pe on Fi.PresidenteId = Pe.PersonalId" +
                " left join Personal Voc on Fi.VocalId = Voc.PersonalId" +
                " left join CursoMaterias cm on Ma.MateriaId = cm.MateriaId" +
                " where 1 = 1";

            if (carreraId > 0)
                query += $" and Fi.CarreraId = {carreraId}";
            if (anioLectivoId > 0)
                query += $" and Fi.CicloLectivoId = {anioLectivoId}";
            if (turnoId > 0)
                query += $" and Fi.TurnoId = {turnoId}";
            if (llamadoId > 0)
                query += $" and Fi.LlamadoId = {llamadoId}";
            if (anioCarreraId > 0)
                query += $" and Ma.AnioCarreraId = {anioCarreraId}";
            if (cursoId > 0)
                query += $" and cm.CursoId = {cursoId}";
            if (materiaId > 0)
                query += $" and Fi.MateriaId = {materiaId}";
            if (profesorId > 0)
                query += $" and Fi.PresidenteId = {profesorId}";

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerMesasReporte(int carreraId, int anioLectivoId, int turnoId, int llamadoId)
        {
            var query = "select Fi.MesaFinalId, Ma.Nombre as 'Materia', Ll.Descripcion as 'Llamado', Tu.Descripcion as 'Turno', Fi.Fecha, concat (Pe.Nombre, ' ', Pe.Apellido) as 'Titular', concat (Voc.Nombre, ' ', Voc.Apellido) as Vocal, Est.Descripcion as 'Estado' " +
                "from MesasFinales Fi inner join Materias Ma on Fi.MateriaId = Ma.MateriaId " +
                "inner join Turnos Tu on Fi.TurnoId = Tu.TurnoId " +
                "inner join Llamados Ll on Fi.LlamadoId = Ll.LlamadoId " +
                "inner join Estados Est on Fi.FinalEstadoId = Est.EstadoId " +
                "left join Personal Pe on Fi.PresidenteId = Pe.PersonalId " +
                $"left join Personal Voc on Fi.VocalId = Voc.PersonalId where Fi.CarreraId = {carreraId} and Fi.CicloLectivoId = {anioLectivoId} and Fi.TurnoId = {turnoId} and Fi.LlamadoId = {llamadoId} and Fi.FinalEstadoId = 1";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerMesaReporte(int mesaFinalId)
        {
            string query = $" SELECT Fi.MesaFinalId, Ca.Nombre AS Carrera, Ma.Nombre AS Materia, " +
                       "AC.AnioCarrera, CAST(NULL AS varchar(10)) AS Curso, "+
                       "Fi.CicloLectivoId, Ll.Descripcion AS Llamado, Tu.Descripcion AS Turno, "+
                       "Fi.Fecha, LTRIM(RTRIM(CONCAT(Pe.Nombre, ' ', Pe.Apellido))) AS Titular, "+
                       "LTRIM(RTRIM(CONCAT(Voc.Nombre, ' ', Voc.Apellido))) AS Vocal, "+
                       "Fi.FinalEstadoId, Est.Descripcion AS Estado, "+
                       "LA.LibroNumero AS LibroActa, Fi.NroFolio AS FolioActa "+
                "FROM MesasFinales Fi "+
                "LEFT JOIN Materias Ma ON Fi.MateriaId = Ma.MateriaId "+
                "LEFT JOIN AniosCarreras AC ON Ma.AnioCarreraId = AC.AnioCarreraId "+
                "LEFT JOIN Carreras Ca ON Fi.CarreraId = Ca.CarreraId "+
                "LEFT JOIN Turnos Tu ON Fi.TurnoId = Tu.TurnoId "+
                "LEFT JOIN Llamados Ll ON Fi.LlamadoId = Ll.LlamadoId " +
                "LEFT JOIN Estados Est ON Fi.FinalEstadoId = Est.EstadoId " +
                "LEFT JOIN Personal Pe ON Fi.PresidenteId = Pe.PersonalId " +
                "LEFT JOIN Personal Voc ON Fi.VocalId = Voc.PersonalId " +
                "LEFT JOIN LibroActas LA ON Fi.LibroActaId = LA.LibroActaId " +
                $"WHERE Fi.MesaFinalId = { mesaFinalId }";

            return this.Conexion.ObtenerRegistros(query);
        }


        public DataTable ObtenerAlumnosMesaReporte(int mesaFinalId)
        {
            if (mesaFinalId <= 0)
                throw new ArgumentOutOfRangeException(nameof(mesaFinalId));

            string query = "SELECT a.AlumnoId, CAST(NULL AS NVARCHAR(50)) AS Libro, CAST(NULL AS NVARCHAR(50)) AS Folio, "+
                            "a.NumeroDocumento, a.Apellido, a.Nombre, " +
                            "ma.Nota, ma.NotaDefinitiva, ma.NotaLetra, ma.Estado " +
                            "FROM dbo.MesaAlumno AS ma " +
                            "INNER JOIN dbo.MesasFinales AS mf "+
                            "ON ma.MesaFinalId = mf.MesaFinalId "+
                            "INNER JOIN dbo.CursadaAlumnoCarreras AS cac "+
                            "ON ma.CursadaAlumnoCarreraId = cac.CursadaAlumnoCarreraId "+
                            "INNER JOIN dbo.AlumnosCarreras AS ac "+
                            "ON cac.AlumnoCarreraId = ac.AlumnoCarreraId "+
                            "INNER JOIN dbo.Alumnos AS a "+
                            "ON ac.AlumnoId = a.AlumnoId "+
                            $"WHERE ma.MesaFinalId = { mesaFinalId } "+
                            "ORDER BY a.Apellido, a.Nombre ";

            DataTable alumnos = this.Conexion.ObtenerRegistros(query);
            alumnos.Columns.Add("NotaPrimerNumero", typeof(string));
            alumnos.Columns.Add("NotaPrimerLetra", typeof(string));
            alumnos.Columns.Add("NotaFinalNumero", typeof(string));
            alumnos.Columns.Add("NotaFinalLetra", typeof(string));
            alumnos.Columns.Add("TotalAprobado", typeof(int));
            alumnos.Columns.Add("TotalAplazado", typeof(int));
            alumnos.Columns.Add("TotalAusente", typeof(int));

            foreach (DataRow alumno in alumnos.Rows)
            {
                string letraRegistrada = Convert.ToString(alumno["NotaLetra"]).Trim();
                bool estadoAusente = string.Equals(Convert.ToString(alumno["Estado"]).Trim(), "Ausente", StringComparison.OrdinalIgnoreCase);
                bool ausente = estadoAusente
                    || string.Equals(letraRegistrada, "Ausente", StringComparison.OrdinalIgnoreCase);
                decimal? definitiva = alumno.IsNull("NotaDefinitiva") ? (decimal?)null : Convert.ToDecimal(alumno["NotaDefinitiva"]);
                alumno["TotalAprobado"] = !estadoAusente && definitiva >= 4 ? 1 : 0;
                alumno["TotalAplazado"] = !estadoAusente && definitiva <= 3 ? 1 : 0;
                alumno["TotalAusente"] = estadoAusente ? 1 : 0;
                if (ausente)
                {
                    foreach (string columna in new[] { "NotaPrimerNumero", "NotaPrimerLetra", "NotaFinalNumero", "NotaFinalLetra" })
                        alumno[columna] = "Ausente";
                    continue;
                }

                decimal? primera = alumno.IsNull("Nota") ? (decimal?)null : Convert.ToDecimal(alumno["Nota"]);
                alumno["NotaPrimerNumero"] = FormatearNota(primera);
                alumno["NotaPrimerLetra"] = primera.HasValue
                    ? (string.IsNullOrEmpty(letraRegistrada) ? NotaEnLetras(primera.Value) : letraRegistrada)
                    : string.Empty;
                alumno["NotaFinalNumero"] = FormatearNota(definitiva);
                alumno["NotaFinalLetra"] = definitiva.HasValue
                    ? (definitiva == primera && !string.IsNullOrEmpty(letraRegistrada)
                        ? letraRegistrada : NotaEnLetras(definitiva.Value))
                    : string.Empty;
            }

            return alumnos;
        }

        private static string FormatearNota(decimal? nota)
        {
            return nota.HasValue ? nota.Value.ToString("0.##", CultureInfo.GetCultureInfo("es-AR")) : string.Empty;
        }

        private static string NotaEnLetras(decimal nota)
        {
            string[] nombres = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Diez" };
            int parteEntera = (int)decimal.Truncate(nota);
            if (parteEntera < 0 || parteEntera >= nombres.Length) return string.Empty;
            string resultado = nombres[parteEntera];
            string[] partes = nota.ToString("0.##", CultureInfo.InvariantCulture).Split('.');
            if (partes.Length == 1) return resultado;
            string[] digitos = { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            return resultado + " coma " + string.Join(" ", partes[1].Select(c => digitos[c - '0']));
        }

        public DataTable ExistenFechasFinales(int anioLectivo)
        {
            var paranioLectivo = new SqlParameter("anioLectivo", SqlDbType.Int);
            paranioLectivo.Value = anioLectivo;
            var parametros = new SqlParameter[1] { paranioLectivo };
            return this.Conexion.EjecutarStore("SP_ExistenFechasFinales", parametros);
        }

        public DataTable ObtenerLlamados()
        {
            var query = "select * from Llamados";
            return this.Conexion.ObtenerRegistros(query);
        }
    }
}
