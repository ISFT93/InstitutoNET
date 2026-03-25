using ISFDyT93.Datos;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;
using System.Data;

namespace ISFDyT93.Negocio.Logica
{
    public class CursosLogica : LogicaBase
    {
        CursosDao cursosDao;
        CiclosLectivosDao ciclosLectivosDao;

        public CursosLogica()
        {
            this.cursosDao = new CursosDao();
            this.ciclosLectivosDao = new CiclosLectivosDao();
        }

        public DataTable ConsultarCursos(int anioCarreraId)
        {
            return cursosDao.ConsultarCursos(anioCarreraId);
        }
        
        public DataTable ConsultarCursosPrimerAnio(int alumnoId)
        {
            return cursosDao.ConsultarCursosPrimerAnio(alumnoId);
        }

        public DataTable AgregarCurso(int anioCarreraId, int cantidadCursos)
        {
            string abecedario = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            string nombreCurso = abecedario[cantidadCursos].ToString();         

            return cursosDao.AgregarCurso(anioCarreraId, nombreCurso);
        }

        public int ModificarCurso(int cursoId, string nombreCurso)
        {
            return cursosDao.ModificarCurso(cursoId, nombreCurso);
        }

        public int EliminarCurso(int cursoId)
        {
            return cursosDao.EliminarCurso(cursoId);
        }

        public DataTable CursosInactivos(int anioCarreraId)
        {
            return cursosDao.CursosInactivos(anioCarreraId);
        }

        public int DarAltaCurso(int cursoId)
        {
            return cursosDao.DarAltaCurso(cursoId);
        }

        public DataTable ObtenerCursoMateria(int cursadaId)
        {
            return cursosDao.ObtenerDatosAlumnoCursoMateria(cursadaId);
        }

        public CursosModelo ObtenerCurso(int cursoId)
        {
            return cursosDao.ObtenerCurso(cursoId);
        }
    }
}
