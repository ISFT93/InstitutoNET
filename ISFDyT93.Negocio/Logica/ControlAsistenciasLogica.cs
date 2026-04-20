using System.Data;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class ControlAsistenciasLogica : LogicaBase
    {
        ControlAsistenciasDao controlAsistenciasDao;

        public ControlAsistenciasLogica()
        {
            this.controlAsistenciasDao = new ControlAsistenciasDao();
        }

        public DataTable CargarAsistenciasAlumnosReporte(AsistenciasModelo modelo)
        {
            DataTable dt = new DataTable();
            dt = this.controlAsistenciasDao.CargarAsistenciasAlumnosReporte(modelo);
            return dt;
        }

        public DataTable CargarAsistenciasAlumnos()
        {
            DataTable dt = new DataTable();
            dt = this.controlAsistenciasDao.CargarAsistenciasAlumnos();
            return dt;
        }

        public DataTable CargarAsistenciasAnteriores(AsistenciasModelo modelo)
        {
            DataTable dt = new DataTable();
            dt = this.controlAsistenciasDao.CargarAsistenciasAnteriores(modelo);
            return dt;
        }

        public DataRow CargarProfesor()
        {
            return this.controlAsistenciasDao.CargarProfesor();
        }

        public void ActualizoUltimaFechaAsistencia(AsistenciasModelo Modelo)
        {
            controlAsistenciasDao.ActualizoUltimaFechaAsistencia(Modelo);
        }

        public int AgregarAsistencia(AsistenciasModelo Modelo)
        {
            return controlAsistenciasDao.AgregarAsistencia(Modelo);
        }

        public int ActualizarCursada(AsistenciasModelo Modelo)
        {
            return controlAsistenciasDao.ActualizarCursada(Modelo);
        }

        public DataRow CalculaTotalAlumnos()
        {
            return controlAsistenciasDao.CalculaTotalAlumnos();
        }
        public DataRow CalculaModulosAlumnos(AsistenciasModelo Modelo)
        {
            return controlAsistenciasDao.CalculaModulosAlumnos(Modelo);
        }

        public int ActualizarGrilla(AsistenciasModelo Modelo)
        {
            return controlAsistenciasDao.ActualizarGrilla(Modelo);
        }

        public DataRow CalcularPorcentajeAsistenciaAlumnos(AsistenciasModelo Modelo)
        {
            return controlAsistenciasDao.CalcularPorcentajeAsistenciaAlumnos(Modelo);
        }

        public DataTable HistorialAsistenciasAlumnos(AsistenciasModelo Modelo)
        {
            return this.controlAsistenciasDao.HistorialAsistenciasAlumnos(Modelo);
        }
    }
}

