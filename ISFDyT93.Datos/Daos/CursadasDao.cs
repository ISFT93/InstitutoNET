using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISFDyT93.Datos.Daos
{
    public class CursadasDao : DaoBase , ICursadasDao
    {
        public DataRow ObtenerDatosCursadaByCursadaAlumnoCarreraId(int CursadaAlumnoCarreraId)
        {
            string query = $"SELECT CursadaId FROM CursadaAlumnoCarreras WHERE CursadaAlumnoCarreraId = {CursadaAlumnoCarreraId}";

            return this.Conexion.ObtenerRegistro(query);
        }

        public CursadasModelo ObtenerCursada(int CursadaId)
        {
            string query = "SELECT c.*, cm.CursoId, m.Nombre as Materia, m.Modulos as ModulosMateria FROM Cursadas c " +
                        "INNER JOIN CursoMaterias cm ON c.CursoMateriaId = cm.CursoMateriaId " +
                        "INNER JOIN Materias m ON cm.MateriaId = m.MateriaId " +
                        $"WHERE CursadaId = {CursadaId}";

            return this.MapToModel<CursadasModelo>(this.Conexion.ObtenerRegistro(query));
        }

        public int? ObtenerCursadaIdPorFiltros(int cursoId, int materiaId, int anioLectivo)
        {
            string query = "SELECT TOP 1 c.CursadaId FROM Cursadas c " +
                        "INNER JOIN CursoMaterias cm ON c.CursoMateriaId = cm.CursoMateriaId " +
                        $"WHERE cm.CursoId = {cursoId} " +
                        $"AND cm.MateriaId = {materiaId} " +
                        $"AND c.AnioLectivo = {anioLectivo}";

            DataRow dr = this.Conexion.ObtenerRegistro(query);
            if (dr == null || dr["CursadaId"] == DBNull.Value)
                return null;

            return Convert.ToInt32(dr["CursadaId"]);
        }
        // Método para inscribir al alumno en una MATERIA ESPECÍFICA (CursoMateriaId)
        // Cecilia
        public int CargarAlumnoEnMateriaEspecifica(int cicloLectivo, int carreraId, int cursoMateriaId, string dni)
        {
            // Obtengo el AlumnoId por DNI
            string queryAlumno = $"SELECT AlumnoId FROM Alumnos WHERE NumeroDocumento = '{dni.Trim()}'";
            DataRow drAlumno = this.Conexion.ObtenerRegistro(queryAlumno);

            if (drAlumno == null || drAlumno["AlumnoId"] == DBNull.Value)
            {
                return -1; // Alumno no existe
            }

            int alumnoId = Convert.ToInt32(drAlumno["AlumnoId"]);

            // Gestionar AlumnosCarreras
            string queryAlumnoCarrera = $@"SELECT AlumnoCarreraId 
                                   FROM AlumnosCarreras 
                                   WHERE AlumnoId = {alumnoId} AND CarreraId = {carreraId}";

            DataRow drAlumnoCarrera = this.Conexion.ObtenerRegistro(queryAlumnoCarrera);
            int alumnoCarreraId;

            if (drAlumnoCarrera == null || drAlumnoCarrera["AlumnoCarreraId"] == DBNull.Value)
            {
                string queryCrearAlumnoCarrera = $@"
                INSERT INTO AlumnosCarreras (CarreraId, AlumnoId, FechaAlta, Activo, CicloLectivoId, inicializado)
                VALUES ({carreraId}, {alumnoId}, GETDATE(), 1, {cicloLectivo}, 1);
                SELECT SCOPE_IDENTITY() AS AlumnoCarreraId;";

                DataRow drNuevo = this.Conexion.ObtenerRegistro(queryCrearAlumnoCarrera);
                if (drNuevo == null || drNuevo["AlumnoCarreraId"] == DBNull.Value)
                    return -1;

                alumnoCarreraId = Convert.ToInt32(drNuevo["AlumnoCarreraId"]);
            }
            else
            {
                alumnoCarreraId = Convert.ToInt32(drAlumnoCarrera["AlumnoCarreraId"]);

                string queryUpdateAlumnoCarrera = $@"
                UPDATE AlumnosCarreras 
                SET CicloLectivoId = {cicloLectivo}, inicializado = 1 
                WHERE AlumnoCarreraId = {alumnoCarreraId};
                SELECT 1 AS Ok;";

                this.Conexion.ObtenerRegistro(queryUpdateAlumnoCarrera);
            }

            // VALIDACIÓN ANTI-CRUCE: Verificar si el alumno ya está inscripto en esa misma Materia en OTRA comisión/curso
            string queryValidarOtraComision = $@"
            SELECT TOP 1 cur.NombreCurso
            FROM CursadaAlumnoCarreras cac
            INNER JOIN Cursadas c ON cac.CursadaId = c.CursadaId
            INNER JOIN CursoMaterias cm ON c.CursoMateriaId = cm.CursoMateriaId
            INNER JOIN Cursos cur ON cm.CursoId = cur.CursoId
            WHERE cac.AlumnoCarreraId = {alumnoCarreraId}
              AND c.AnioLectivo = {cicloLectivo}
              AND cm.MateriaId = (SELECT MateriaId FROM CursoMaterias WHERE CursoMateriaId = {cursoMateriaId})
              AND cm.CursoId <> (SELECT CursoId FROM CursoMaterias WHERE CursoMateriaId = {cursoMateriaId})";

            DataRow drConflicto = this.Conexion.ObtenerRegistro(queryValidarOtraComision);
            if (drConflicto != null)
            {
                return -3; // El alumno pertenece a otra comisión y se rechaza la inserción para no mezclar los datos
            }

            // Asegurar que exista la Cursada para esta materia y año lectivo
            string queryCrearCursadaFaltante = $@"
            IF {cursoMateriaId} > 0 AND NOT EXISTS (SELECT 1 FROM Cursadas WHERE CursoMateriaId = {cursoMateriaId} AND AnioLectivo = {cicloLectivo})
            BEGIN
                INSERT INTO Cursadas (CursoMateriaId, AnioLectivo, HoraCatedra, PorcentajeAsistencia)
                VALUES ({cursoMateriaId}, {cicloLectivo}, 4, 100);
            END";

            this.Conexion.EjecutarAccion(queryCrearCursadaFaltante);

            // Obtener CursadaId
            string queryGetCursadaId = $"SELECT CursadaId FROM Cursadas WHERE CursoMateriaId = {cursoMateriaId} AND AnioLectivo = {cicloLectivo}";
            DataRow drCursada = this.Conexion.ObtenerRegistro(queryGetCursadaId);

            if (drCursada == null || drCursada["CursadaId"] == DBNull.Value)
                return -1;

            int cursadaId = Convert.ToInt32(drCursada["CursadaId"]);

            // Inscribir al alumno en la cursada
            string queryInsertInscripcion = $@"
            IF NOT EXISTS (
                SELECT 1 FROM CursadaAlumnoCarreras 
                WHERE CursadaId = {cursadaId} AND AlumnoCarreraId = {alumnoCarreraId}
            )
            BEGIN
                INSERT INTO CursadaAlumnoCarreras (CursadaId, AlumnoCarreraId, AnioCicloLectivo, HorasCursadas, PorcentajeAsistencia, Estado)
                VALUES ({cursadaId}, {alumnoCarreraId}, {cicloLectivo}, 0, 100, 'R');
                SELECT 1 AS Ok;
            END
            ELSE
            BEGIN
                SELECT -2 AS Ok; -- Ya estaba inscripto
            END";

            DataRow drResultado = this.Conexion.ObtenerRegistro(queryInsertInscripcion);

            if (drResultado != null && drResultado["Ok"] != DBNull.Value)
            {
                return Convert.ToInt32(drResultado["Ok"]);
            }

            return -2;
        }


        public int CargarAlumnoEnCursoMasivo(int cicloLectivo, int carreraId, int cursoId, string dni)
        {
            // Obtener el AlumnoId por DNI de forma limpia
            string queryAlumno = $"SELECT AlumnoId FROM Alumnos WHERE NumeroDocumento = '{dni.Trim()}'";

            DataRow drAlumno = this.Conexion.ObtenerRegistro(queryAlumno);

            if (drAlumno == null || drAlumno["AlumnoId"] == DBNull.Value)
                return -1; // Alumno no existe

            int alumnoId = Convert.ToInt32(drAlumno["AlumnoId"]);

            // Gestionar AlumnosCarreras
            string queryAlumnoCarrera = $"SELECT AlumnoCarreraId FROM AlumnosCarreras WHERE AlumnoId = {alumnoId} AND CarreraId = {carreraId}";
            DataRow drAlumnoCarrera = this.Conexion.ObtenerRegistro(queryAlumnoCarrera);
            int alumnoCarreraId;

            if (drAlumnoCarrera == null || drAlumnoCarrera["AlumnoCarreraId"] == DBNull.Value)
            {
                string queryCrear = $"INSERT INTO AlumnosCarreras (CarreraId, AlumnoId, FechaAlta, Activo, CicloLectivoId, inicializado) VALUES ({carreraId}, {alumnoId}, GETDATE(), 1, {cicloLectivo}, 1); SELECT SCOPE_IDENTITY() AS AlumnoCarreraId;";
                DataRow drNuevo = this.Conexion.ObtenerRegistro(queryCrear);
                if (drNuevo == null || drNuevo["AlumnoCarreraId"] == DBNull.Value) return -1;
                alumnoCarreraId = Convert.ToInt32(drNuevo["AlumnoCarreraId"]);
            }
            else
            {
                alumnoCarreraId = Convert.ToInt32(drAlumnoCarrera["AlumnoCarreraId"]);
            }

            // Obtener las materias del curso
            string queryMaterias = $"SELECT CursoMateriaId FROM CursoMaterias WHERE CursoId = {cursoId}";
            DataTable dtMaterias = this.Conexion.ObtenerRegistros(queryMaterias);

            if (dtMaterias == null || dtMaterias.Rows.Count == 0)
                return -1;

            int inscripcionesExitosas = 0;

            foreach (DataRow rowMateria in dtMaterias.Rows)
            {
                int cursoMateriaId = Convert.ToInt32(rowMateria["CursoMateriaId"]);

                // Verificar si ya existe la Cursada para este año, si no, crearla con una consulta simple
                string queryCheckCursada = $"SELECT CursadaId FROM Cursadas WHERE CursoMateriaId = {cursoMateriaId} AND AnioLectivo = {cicloLectivo}";
                DataRow drCursada = this.Conexion.ObtenerRegistro(queryCheckCursada);
                int cursadaId = 0;

                if (drCursada == null || drCursada["CursadaId"] == DBNull.Value)
                {
                    string queryInsCursada = $"INSERT INTO Cursadas (CursoMateriaId, AnioLectivo, HoraCatedra, PorcentajeAsistencia) VALUES ({cursoMateriaId}, {cicloLectivo}, 4, 100); SELECT SCOPE_IDENTITY() AS CursadaId;";
                    DataRow drNuevaCursada = this.Conexion.ObtenerRegistro(queryInsCursada);
                    if (drNuevaCursada != null && drNuevaCursada["CursadaId"] != DBNull.Value)
                    {
                        cursadaId = Convert.ToInt32(drNuevaCursada["CursadaId"]);
                    }
                }
                else
                {
                    cursadaId = Convert.ToInt32(drCursada["CursadaId"]);
                }

                if (cursadaId > 0)
                {
                    // Verificar si ya está inscripto antes de insertar
                    string queryCheckInsc = $"SELECT 1 FROM CursadaAlumnoCarreras WHERE CursadaId = {cursadaId} AND AlumnoCarreraId = {alumnoCarreraId}";
                    DataRow drInsc = this.Conexion.ObtenerRegistro(queryCheckInsc);

                    if (drInsc == null)
                    {
                        string queryInsert = $"INSERT INTO CursadaAlumnoCarreras (CursadaId, AlumnoCarreraId, HorasCursadas, PorcentajeAsistencia, Estado) VALUES ({cursadaId}, {alumnoCarreraId}, 0, 100, 'R')";
                        this.Conexion.EjecutarAccion(queryInsert);
                    }
                    inscripcionesExitosas++;
                }
            }

            return inscripcionesExitosas > 0 ? 1 : -2;
        }

        public int ObtenerCursoMateriaId(int cursoId, int materiaId)
        {
            string query = $"SELECT CursoMateriaId FROM CursoMaterias WHERE CursoId = {cursoId} AND MateriaId = {materiaId}";
            DataRow dr = this.Conexion.ObtenerRegistro(query);
            if (dr != null && dr["CursoMateriaId"] != DBNull.Value)
            {
                return Convert.ToInt32(dr["CursoMateriaId"]);
            }
            return 0;
        }
    }
}

