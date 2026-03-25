using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Daos
{
    public class CursosDao : DaoBase
    {
        public DataTable ConsultarCursos(int AnioCarreraId)
        {
            string query = "SELECT * FROM Cursos WHERE AnioCarreraId =" + AnioCarreraId + " AND Activo=" + 1;

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ConsultarCursosPrimerAnio(int AlumnoId)
        {
            string query = "SELECT Cursos.* FROM AlumnosCarreras AlumCar" +
                    " INNER JOIN AniosCarreras AC ON AlumCar.CarreraId = AC.CarreraId" +
                    " INNER JOIN Cursos ON AC.AnioCarreraId = Cursos.AnioCarreraId " +
                    " WHERE AlumCar.AlumnoId = " + AlumnoId + " AND AlumCar.Activo = 1 AND AC.AnioCarrera = 1";

            return this.Conexion.ObtenerRegistros(query);
        }
        /*
        public int AgregarCurso(int AnioCarreraId,int CicloLectivo, string NombreCurso)
        {
            string query = "INSERT INTO Cursos(AnioCarreraId,CicloLectivoId,NombreCurso,Activo, AdmiteCurso) VALUES(" + AnioCarreraId +","+CicloLectivo+",'"+ NombreCurso + "',"+ 1 +","+1+")";

            return this.Conexion.EjecutarAccion(query);
        }*/

        public DataTable AgregarCurso(int AnioCarreraId, string NombreCurso)
        {
            var parNombreCurso = new SqlParameter("NombreCurso", SqlDbType.VarChar, 50);
            parNombreCurso.Value = NombreCurso;

            var parAnioCarreraId = new SqlParameter("AnioCarreraId", SqlDbType.Int);
            parAnioCarreraId.Value = AnioCarreraId;

            var parametros = new SqlParameter[2] { parNombreCurso, parAnioCarreraId };

            return this.Conexion.EjecutarStore("sp_insertCursosMaterias", parametros);
        }

        public int ModificarCurso(int CursoId, string NombreCurso)
        {
            string query = "UPDATE Cursos SET NombreCurso='" + NombreCurso +"' WHERE CursoId=" + CursoId;

            return this.Conexion.EjecutarAccion(query);
        }
        public int EliminarCurso(int CursoId)
        {
            string query = "UPDATE Cursos SET  Activo=" + 0 + "WHERE CursoId=" + CursoId;
            string query2 = "UPDATE CursoMaterias SET Activo=0, FechaBaja=GETDATE() WHERE CursoId=" + CursoId;
            
            this.Conexion.EjecutarAccion(query2);
            return this.Conexion.EjecutarAccion(query);
        }
     
        public DataTable CursosInactivos(int AnioCarreraId)
        {
            string query = "SELECT * FROM Cursos WHERE AnioCarreraId =" + AnioCarreraId + " AND Activo=" + 0;

            return this.Conexion.ObtenerRegistros(query);
        }
        public int DarAltaCurso(int CursoId)
        {
            string query = "UPDATE Cursos SET Activo=" + 1 + "WHERE CursoId=" + CursoId;

            return this.Conexion.EjecutarAccion(query);
        }

        public DataTable ObtenerDatosAlumnoCursoMateria(int cursadaId)
        {
            string query = "SELECT A.Nombre as 'Nombre' , A.Apellido as 'Apellido' , AC.Activo as 'Estado',"
            + "CAC.UltimoPresentismo as 'Ultimo presentismo', CAC.PorcentajeAsistencia as 'Porcentaje de asistencia', CAC.CursadaAlumnoCarreraId, CU.CursoId "
            + "FROM(Alumnos A INNER JOIN AlumnosCarreras AC ON A.AlumnoId = AC.AlumnoId)"
            + " INNER JOIN Carreras Carr ON AC.CarreraId = Carr.CarreraId"
            + " INNER JOIN AniosCarreras ACA ON Carr.CarreraId = ACA.CarreraId"
            + " INNER JOIN Cursos CU ON ACA.AnioCarreraId = CU.AnioCarreraId"
            + " INNER JOIN CursoMaterias CM ON CU.CursoId = cm.CursoId"
            + " INNER JOIN Cursadas CUR ON CM.CursoMateriaId = CUR.CursoMateriaId"
            + " INNER JOIN CursadaAlumnoCarreras CAC ON CUR.CursadaId = CAC.CursadaId"
            +$" WHERE CUR.CursadaId = {cursadaId}";

            return this.Conexion.ObtenerRegistros(query);
        } 

        public CursosModelo ObtenerCurso(int cursoId)
        {
            string query = $"SELECT AnioCarrera, NombreCurso, c.AnioCarreraId "
                + $"FROM Cursos c INNER JOIN AniosCarreras ac ON ac.AnioCarreraId = c.AnioCarreraId "
                + $"WHERE CursoId={cursoId}";

            return this.MapToModel<CursosModelo>(this.Conexion.ObtenerRegistro(query));
        }
    }
}
