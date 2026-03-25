using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Datos.Modelos;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace ISFDyT93.Datos.Daos
{
    public class PersonalDao : DaoBase
    {
        public DataTable ObtenerListaPersonal(int estado)
        {
            string query = "SELECT PersonalId, NumeroDocumento AS [Documento], Nombre, Apellido, FechaAlta, FechaBaja, pe.Descripcion AS Estado, p.PersonalEstadoId FROM Personal p " +
                "INNER JOIN PersonalEstados pe on pe.PersonalEstadoId = p.PersonalEstadoId";

            if (estado != 0)
            {
                query += $" WHERE p.PersonalEstadoId = {estado}";
            }

            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ObtenerListaPersonal(TipoFiltroProfesor tipo, string filtro, int estado)
        {
            string query = "SELECT PersonalId, NumeroDocumento AS [Documento], Nombre, Apellido, FechaAlta, FechaBaja, pe.Descripcion AS Estado, p.PersonalEstadoId FROM Personal p " +
                "INNER JOIN PersonalEstados pe on pe.PersonalEstadoId = p.PersonalEstadoId";

            string where = "";

            switch (tipo)
            {
                case TipoFiltroProfesor.Todos:
                    where = $" WHERE Nombre LIKE '%{filtro}%' OR NumeroDocumento LIKE '%{filtro}%' OR Apellido LIKE '%{filtro}%'";
                    break;
                case TipoFiltroProfesor.NumeroDocumento:
                    where = $" WHERE NumeroDocumento LIKE '%{filtro}%'";
                    break;
                case TipoFiltroProfesor.Nombre:
                    where = $" WHERE Nombre LIKE '%{filtro}%'";
                    break;
                case TipoFiltroProfesor.Apellido:
                    where = $" WHERE Apellido LIKE '%{filtro}%'";
                    break;
            }

            if (estado != 0)
            {
                if (where.Length > 0)
                    where += " AND";
                else
                    where += " WHERE";

                where += $" p.PersonalEstadoId = {estado}";
            }

            query += where;

            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ArmarLegajo(int profesorId)
        {
            string query = "SELECT * FROM Personal WHERE PersonalId = " + profesorId + "";

            return this.Conexion.ObtenerRegistros(query);
        }
        public IList<CargosModeloDTO> ObtenerPersonalConCargos(List<int> cursoMateriaIds) 
        {
            string ids = string.Join(",", cursoMateriaIds);
            
            string query = $"Select * FROM ViewCargosServiciosCursoMateria WHERE CursoMateriaId IN ({ids}) AND Activo = 'True'";
            return MapToModel<CargosModeloDTO>(Conexion.ObtenerRegistros(query));
        }

        public int AgregarPersonal(PersonalModelo modelo)
        {
            string query = this.CreateInsertQuery<PersonalModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);

        }
        public int ModificarPersonal(PersonalModelo modelo)
        {
            string query = this.CreateUpdateQuery<PersonalModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }
        public void EliminarPersonal(int personalId)
        {
            string query = "DELETE FROM Personal WHERE PersonalId = " + personalId;
            this.Conexion.EjecutarAccion(query);
        }
        public PersonalModelo ObtenerPersonal(int personalId)
        {
            string query = "SELECT * FROM Personal WHERE PersonalId = " + personalId;

            return this.MapToModel<PersonalModelo>(this.Conexion.ObtenerRegistro(query));
        }

        public void EliminarProfesor(int ProfesorId)
        {
            string query = "UPDATE Profesores SET Activo = " + 0 + "WHERE ProfesorId = " + ProfesorId + "";
            this.Conexion.EjecutarAccion(query);
        }

        public void EliminarProfesorMateria(int ProfesorMateriaId)
        {
            string query = "DELETE ProfesoresMaterias WHERE ProfesorMateriaId = " + ProfesorMateriaId + "";
            this.Conexion.EjecutarAccion(query);
        }
        public void AsignarProfesorMateria(int MateriaId, int CursoId, int ProfesorId, string Fecha)
        {
            string query = "INSERT INTO ProfesoresMaterias (ProfesorId, MateriaId, CursoId, Fecha) VALUES ( " + ProfesorId + "," + MateriaId + "," + CursoId + ",'"+ Fecha +"' )";
          
             this.Conexion.EjecutarAccion(query);
        }
        public DataTable ObtenerProfesorMaterias(int PersonalId)
        {
            string query = "SELECT PM.ProfesorMateriaId, M.Nombre AS Materia, AC.AnioCarrera AS Año, AC.AnioCarreraId, C.NombreCurso AS Curso, CA.Nombre AS Carrera, M.CargaHoraria FROM Materias as M "+
                " INNER JOIN ProfesoresMaterias as PM ON M.MateriaId = PM.MateriaId INNER JOIN Cursos as C ON PM.CursoId = C.CursoId "+ 
                " INNER JOIN AniosCarreras as AC ON C.AnioCarreraId = AC.AnioCarreraId "+
                " INNER JOIN Carreras as CA ON AC.CarreraId = CA.CarreraId WHERE PM.PersonalId = " + PersonalId + " ORDER BY AC.AnioCarrera ASC";


            return this.Conexion.ObtenerRegistros(query);
        }
        public DataRow PersonalExiste(string DNI)
        {
            string query = "SELECT TOP 1 PersonalId FROM Personal WHERE NumeroDocumento = " + DNI;
            return this.Conexion.ObtenerRegistro(query);
        }

        public int AgregarDocumentacion(string Analitico, string Proyecto, int ProfesorMateriaId, int CiclosLectivoId)
        {
            string query = "INSERT INTO ProfesorMateriaCicloLectivo (Analitico, Proyecto, ProfesorMateriaId, CicloLectivoId) VALUES ( '" + Analitico + "','" + Proyecto + "'," + ProfesorMateriaId + "," + CiclosLectivoId + " )";

            return this.Conexion.EjecutarAccion(query);
        }
        public int ModificarDocumentacion(string Analitico, string Proyecto, int ProfesorMateriaId, int CiclosLectivoId)
        {
            string query = "UPDATE  ProfesorMateriaCicloLectivo SET Analitico = '" + Analitico + "', Proyecto = '" + Proyecto + "' WHERE ProfesorMateriaId = " + ProfesorMateriaId + " AND CicloLectivoId = " + CiclosLectivoId +"";

            return this.Conexion.EjecutarAccion(query);
        }
        public DataRow ObtenerDocumentacion(int ProfesorMateriaId, int CicloLectivoId)
        {
            string query = "SELECT TOP 1 * FROM ProfesorMateriaCicloLectivo WHERE ProfesorMateriaId = " + ProfesorMateriaId + " AND CicloLectivoId = " + CicloLectivoId;

            return this.Conexion.ObtenerRegistro(query);
        }

        public DataTable ObtenerPath(int ProfesorMateriaId, int CicloLectivoId)
        {
            string query = "SELECT Analitico, Proyecto FROM ProfesorMateriaCicloLectivo WHERE ProfesorMateriaId = " + ProfesorMateriaId + " AND CicloLectivoId = " + CicloLectivoId;
            return this.Conexion.ObtenerRegistros(query);
        }
        public void DarAltaProfesores(int ProfesorId)
        {
            string query = "UPDATE Profesores SET Activo = " + 1 + "WHERE ProfesorId = " + ProfesorId + "";
            this.Conexion.EjecutarAccion(query);
        }
        public DataTable ObtenerPersonalInactivos()
        {
            string query = "SELECT ProfesorId, NumeroDocumento AS [Documento], Nombre, Apellido, Activo FROM Profesores WHERE Activo = " + 0;

            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ObtenerTodoPersonal(TipoFiltroProfesor tipo, string filtro)
        {
            string query = "SELECT PersonalId, NumeroDocumento AS [Documento], Nombre, Apellido, Activo FROM Personal WHERE ";

            switch (tipo)
            {
                case TipoFiltroProfesor.Todos:
                    query += "Profesores.Apellido LIKE '%" + filtro + "%'" + " OR " +
                        "Profesores.Nombre LIKE '%" + filtro + "%'" + " OR " +
                        "Profesores.NumeroDocumento LIKE '%" + filtro + "%'";
                    break;
                case TipoFiltroProfesor.NumeroDocumento:
                    query += "Profesores.NumeroDocumento LIKE '%" + filtro + "%'";
                    break;
                case TipoFiltroProfesor.Nombre:
                    query += "Profesores.Nombre LIKE '%" + filtro + "%'";
                    break;
                case TipoFiltroProfesor.Apellido:
                    query += "Profesores.Apellido LIKE '%" + filtro + "%'";
                    break;
            }

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataRow ObtenerCantidadMaterias(int ProfesorId, int MateriaId)
        {
            string query = $"SELECT COUNT(MateriaId) AS Cantidad FROM ProfesoresMaterias where ProfesorId = {ProfesorId} AND MateriaId = {MateriaId} AND Activo = 1";

            return this.Conexion.ObtenerRegistro(query);
        }
        public DataTable ObtenerSituacionRevista()
        {
            string query = "SELECT SituacionRevistaId, Descripcion from SituacionRevistas";
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ObtenerNacionalidades()
        {
            string query = "SELECT DISTINCT Nacionalidad FROM Personal";
            return this.Conexion.ObtenerRegistros(query);
        }
         
         
    }
}
