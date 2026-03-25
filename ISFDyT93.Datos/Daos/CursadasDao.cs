using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Daos
{
    public class CursadasDao : DaoBase
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
    }
}
