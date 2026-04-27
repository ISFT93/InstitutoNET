using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ISFDyT93.Datos.Core;

namespace ISFDyT93.Datos.Daos
{
    public class InscripcionAlumnoDao : DaoBase
    {
        public DataTable ObtenerMateriasVigentes(int alumnoId, string anio)
        {
            string filtroAnio = "";
            if (anio != "") filtroAnio = $"AND Anio= '{anio}'";
            string query = "SELECT CicloLectivoId AS [Ciclo Lectivo], Materia, Anio AS Año, Carrera, MateriaId, CursoId FROM MateriasCarrerasVigentes " +
                "WHERE MateriaId NOT IN (SELECT MateriaId FROM AlumnoMateriaCursoAnioCarrera " +
                "WHERE Estado != 'DE' " +
                $"AND AlumnoId= {alumnoId}) {filtroAnio} " +
                $"AND CarreraId IN (SELECT CarreraId FROM AlumnosCarreras WHERE AlumnoId= {alumnoId})";
            
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
            string query = "SELECT TOP 1 FechaInscripcionInicio, FechaInscripcionFinal FROM CicloLectivo ORDER BY FechaInscripcionInicio";
            return this.Conexion.ObtenerRegistro(query);
        }

        public int actualizarEstadoCursada(Modelos.InscripcionMateriasModelo Modelo)
        {
            string query = "UPDATE CursadaAlumnoCarreras SET Estado = '" + Modelo.estado + "', Cursada = '" + Modelo.cursada + "' WHERE CursadaAlumnoCarreraId =" + Modelo.cursadaAlumnoId;
            return Conexion.EjecutarAccion(query);
        }
    }
}
