using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Datos.Daos
{
    public class MateriasDao : DaoBase
    {
        public DataTable ObtenerMaterias(int anioCarreraId, bool activo = true)
        {
            string query = "SELECT Mat.MateriaId, Mat.Nombre, Mat.AnioCarreraId, Mat.CargaHoraria AS [Carga Horaria], Esp.Descripcion AS [Descripción], Mat.EspacioId,  COUNT(Cor.MateriaId) As Correlativas " +    
                "FROM Materias as Mat " +
                "INNER JOIN Espacios as Esp ON Esp.EspacioId = Mat.EspacioId " +
                "LEFT JOIN Correlativas as Cor ON Cor.MateriaId = Mat.MateriaId " +
                $"WHERE AnioCarreraId = { anioCarreraId } AND Activo = { (activo ? "1" : "0") } " +
                "GROUP BY Mat.MateriaId, Mat.Nombre, Mat.AnioCarreraId, Mat.CargaHoraria, Esp.Descripcion, Mat.EspacioId " +
                "ORDER BY Mat.EspacioId";

            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable CargarMaterias(int anioCarreraId, bool activo = true)
        {
            string query = $"SELECT MateriaId, Nombre " +
                $"FROM Materias " +
                $"WHERE AnioCarreraId = { anioCarreraId } AND Activo = { (activo ? "1" : "0") } ";

            return this.Conexion.ObtenerRegistros(query);
        }
        public int ObtenerUltimaMateriaId()
        { /* Si activo es true escribe 1 si no 0 */
            string query = "SELECT TOP 1 MateriaId " +
                "FROM Materias " +
                "ORDER BY MateriaId DESC";

            var row = this.Conexion.ObtenerRegistro(query);

            if (row != null)
            {
                return Convert.ToInt32(row["MateriaId"]);
            }
            return 0;
        }

        public int EliminarMateria(int idMateria)
        {
            string query = $"DELETE Materias WHERE MateriaId = { idMateria }";
          return  this.Conexion.EjecutarAccion(query);
        }

        public DataRow MateriaAsignada(int id)
        {
           string query = "SELECT COUNT(Materias.MateriaId) AS Cantidad " +
                "FROM Materias " +
                "INNER JOIN AniosCarreras ON Materias.AnioCarreraId = AniosCarreras.AnioCarreraId " +
                $"WHERE AniosCarreras.CarreraId = { id }";
            return this.Conexion.ObtenerRegistro(query);
        }
        
        public int AgregarMaterias(MateriasModelo modelo)
        {
            string query = this.CreateInsertQuery<MateriasModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }

        public int ModificarMateria(MateriasModelo modelo)
        {
            string query = this.CreateUpdateQuery<MateriasModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }

        public DataTable ObtenerEspacios()
        {
            string query = "SELECT * FROM Espacios";

            return this.Conexion.ObtenerRegistros(query);
        }

        public MateriasModelo ObtenerMateria(int materiaId)
        {  /*   Si activo es true escribe 1 si no 0 */
            string query = "SELECT M.*, AC.CarreraId, AC.AnioCarrera "+
                "FROM Materias M "+
                "INNER JOIN AniosCarreras AC ON M.AnioCarreraId = AC.AnioCarreraId " +
                $"WHERE MateriaId = { materiaId }";

            return this.MapToModel<MateriasModelo>(this.Conexion.ObtenerRegistro(query));//
        }

        public DataTable ObtenerAsignarMateria(int alumnoId, int anioCarreraId)
        {
            string query = " SELECT M.MateriaId, M.Nombre " +
                "FROM Materias M INNER JOIN AniosCarreras AC ON M.AnioCarreraId = AC.AnioCarreraId " +
                "INNER JOIN Carreras C ON AC.CarreraId = C.CarreraId  INNER JOIN AlumnosCarreras ALC ON C.CarreraId = ALC.CarreraId " +
                $"WHERE ALC.Activo = 1 AND ALC.AlumnoId = { alumnoId } AND AC.AnioCarreraId = { anioCarreraId }";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerMateriasAsignar(int alumnoId, int anioCarreraId)
        {
            var parMateria = new SqlParameter("AlumnoID", SqlDbType.Int);
            parMateria.Value = alumnoId;

            var parCarreras = new SqlParameter("AnioCarreraID", SqlDbType.Int);
            parCarreras.Value = anioCarreraId;

            var parMensaje = new SqlParameter("Msj", SqlDbType.VarChar, 50);
            parMensaje.Direction = ParameterDirection.Output;

            var parametros = new SqlParameter[3] { parMateria, parCarreras, parMensaje };

            return this.Conexion.EjecutarStore("SP_ListaMateriasAlumno", parametros);
        }

        public DataTable ObtenerMateriasAsignar(int alumnoId)//agregar concat
        {
            string query = "SELECT M.MateriaId, M.Nombre, ACLM.AlumnoCicloLectivoMateriaId " +
                "FROM Materias M " +
                "INNER JOIN AlumnoCicloLectivoMaterias ACLM ON M.MateriaId = ACLM.MateriaId " +
                $"WHERE ACLM.AlumnoId = { alumnoId }";

            return this.Conexion.ObtenerRegistros(query);
        }

        public int EliminarMateriaAsignada(MateriasModelo modelo)
        {
            /*
            string query = "DELETE AlumnoCicloLectivoMaterias WHERE AlumnoId =" + modelo.AlumnoId + " AND CursoId =" + modelo.CursoId + " AND CicloLectivoId =" + modelo.CicloLectivoId;
            */
            return this.Conexion.EjecutarAccion("");
        }
        public int AsignarMateria(MateriasModelo modelo)
        {
            //string query = "INSERT INTO AlumnoCicloLectivoMaterias (MateriaId, CursoId, AlumnoId, CicloLectivoId) VALUES (" + modelo.MateriaId + "," + modelo.CursoId + "," + modelo.AlumnoId + "," + modelo.CicloLectivoId + ")";

            return this.Conexion.EjecutarAccion("");
        }
        
        public int EliminarMateriaAsignar(int alumnoCicloLectivoMateriaId)
        {
            string query = $"DELETE AlumnoCicloLectivoMaterias WHERE AlumnoCicloLectivoMateriaId = { alumnoCicloLectivoMateriaId }";

            return this.Conexion.EjecutarAccion(query);
        }

        public DataRow ObtenerCarreraDeAnio(int AnioCarerraId)
        {
            string query = $"SELECT c.* FROM " +
                $"AniosCarreras AS Ac " +
                $"INNER JOIN Carreras AS C ON Ac.CarreraId = C.CarreraId " +
                $"WHERE Ac.AnioCarreraID = {AnioCarerraId}";

            return this.Conexion.ObtenerRegistro(query);
        }

        public DataTable ObtenerNombresMaterias()
        {
            string query = "SELECT DISTINCT Nombre from Materias";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable MateriasId(int carreraId)
        {
           string query = "SELECT ma.MateriaId, ma.Nombre " +
                "FROM materias ma " +
                "INNER JOIN AniosCarreras ac ON ma.AnioCarreraId = ac.AnioCarreraId " +
                "INNER JOIN Carreras ca on ac.CarreraId = ca.CarreraId " +
                $"WHERE ca.CarreraId = { carreraId }";

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerMateriasByCursoAndAnioLectivo(int AnioLectivo, int CursoId)
        {
            string query = "SELECT c.AnioLectivo as 'Ciclo lectivo', m.Nombre as 'Materia' , c.CantidadAlumnos as 'Cantidad de alumnos', c.CursadaId " +
                "FROM (Materias m INNER JOIN CursoMaterias cm ON m.MateriaId = cm.MateriaId)" +
                "INNER JOIN Cursadas c ON cm.CursoMateriaId = c.CursoMateriaId " +
                $"WHERE c.AnioLectivo = {AnioLectivo} and cm.CursoId = {CursoId}";

            return this.Conexion.ObtenerRegistros(query);
        }
    }
}
