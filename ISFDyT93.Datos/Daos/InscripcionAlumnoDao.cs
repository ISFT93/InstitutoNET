using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ISFDyT93.Datos.Core;
using ISFDyT93.Entidades;
using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Datos.Interfaces;

namespace ISFDyT93.Datos.Daos
{
    public class InscripcionAlumnoDao : DaoBase , IInscripcionAlumnoDao
    {
        public DataTable ObtenerMateriasVigentes(int alumnoId, string anio)
        {
            string filtroAnio = "";
            if (anio != "") filtroAnio = $"AND CAST(AN.AnioCarrera AS varchar(10)) + CU.NombreCurso = '{anio}'";
            string query = $@"
                SELECT
                    CL.AnioLectivo AS [Ciclo Lectivo],
                    M.Nombre AS Materia,
                    CAST(AN.AnioCarrera AS varchar(10)) + CU.NombreCurso AS Año,
                    CA.DescripcionCorta AS Carrera,
                    M.MateriaId,
                    CU.CursoId,
                    CAC.Estado,
                    CAC.Cursada,
                    CAC.CursadaAlumnoCarreraId,
                    AC.AlumnoCarreraId
                FROM Cursadas C
                INNER JOIN CicloLectivo CL ON CL.AnioLectivo = C.AnioLectivo
                INNER JOIN CursoMaterias CM ON CM.CursoMateriaId = C.CursoMateriaId
                INNER JOIN Cursos CU ON CU.CursoId = CM.CursoId
                INNER JOIN AniosCarreras AN ON AN.AnioCarreraId = CU.AnioCarreraId
                INNER JOIN Carreras CA ON CA.CarreraId = AN.CarreraId
                INNER JOIN Materias M ON M.MateriaId = CM.MateriaId
                INNER JOIN AlumnosCarreras AC ON AC.CarreraId = CA.CarreraId AND AC.AlumnoId = {alumnoId}
                LEFT JOIN CursadaAlumnoCarreras CAC ON CAC.CursadaId = C.CursadaId AND CAC.AlumnoCarreraId = AC.AlumnoCarreraId
                WHERE M.Activo = 'True'
                    AND CA.CarreraEstadoId = 1
                    AND CL.Activo = 'True'
                    {filtroAnio}";

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerAniosVigentes(int alumnoId)
        {
            string query = "SELECT CAST(Anio AS VARCHAR) AS Anio FROM MateriasCarrerasVigentes " +
                "WHERE MateriaId NOT IN (SELECT MateriaId FROM AlumnoMateriaCursoAnioCarrera " +
                "WHERE Estado != 'DE' " +
                $"AND AlumnoId= {alumnoId}) " +
                $"AND CarreraId IN (SELECT CarreraId FROM AlumnosCarreras WHERE AlumnoId= {alumnoId}) " +
                $"GROUP BY Anio";

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataRow obtenerFechaIncripcion()
        {
            string query = "SELECT TOP 1 FechaInscripcionInicio, FechaInscripcionFinal FROM CicloLectivo ORDER BY FechaInscripcionInicio DESC";
            return this.Conexion.ObtenerRegistro(query);
        }

        public int actualizarEstadoCursada(InscripcionMateriasModelo Modelo)
        {
            string query = "UPDATE CursadaAlumnoCarreras SET Estado = '" + Modelo.estado + "', Cursada = '" + Modelo.cursada + "' WHERE CursadaAlumnoCarreraId =" + Modelo.cursadaAlumnoId;
            return Conexion.EjecutarAccion(query);
        }
    }
}
