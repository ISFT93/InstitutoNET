using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Modelos;
using System.Data;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Negocio.Core;
using System;
using System.Linq;

namespace ISFDyT93.Negocio.Logica
{
    public class AlumnosLogica : LogicaBase
    {

        AlumnosDao alumnosDao;
        public AlumnosLogica()
        {
            alumnosDao = new AlumnosDao();
        }

        public int AgregarAlumno(AlumnosModelo modelo)
        {
            string replacePoint = modelo.Promedio.ToString();
            replacePoint.Replace(".", ",");
            
            if(this.alumnosDao.AgregarAlumno(modelo) > 0)
            {
                return this.alumnosDao.UltimoId();
            }

            return 0;
        }
        public int UltimoRegistroAlumno(AlumnosModelo modelo)
        {           
                return this.alumnosDao.UltimoId();
                      
        }
        public int AgregarAlumnoTablaExcel(AlumnosModelo modelo)
        {
            if (this.alumnosDao.AgregarAlumnoTablaExcel(modelo) > 0)
            {
                return this.alumnosDao.UltimoId();
            }

            return 0;
        }
        public int AgregarAlumnoCargaMasiva(AlumnosModelo modelo)
        {
            if (this.alumnosDao.AgregarAlumnoCargaMasiva(modelo) > 0)
            {
                return this.alumnosDao.UltimoId();
            }

            return 0;
        }
        public int AgregarAlumnoCarrera(AlumnosCarrerasModelo modelo)
        {
            return this.alumnosDao.AgregarAlumnoCarrera(modelo);
        }
        public int AgregarAlumnoCarreraExcel(AlumnosCarrerasModelo modelo)
        {
            return this.alumnosDao.AgregarAlumnoCarreraExcel(modelo);
        }
        public int ModificarAlumnoCarrera(AlumnosCarrerasModelo modelo)
        {
            return this.alumnosDao.ModificarAlumnoCarrera(modelo);
        }

        
        public DataTable ObtenerAlumnosPrueba()
        {
            return this.alumnosDao.ObtenerAlumnosPrueba();
        }

        public int ModificarAlumnoTablaExcel(AlumnosModelo modelo)
        {
            return this.alumnosDao.ModificarAlumnoTablaExcel(modelo);
        }
        public int ModificarAlumno(AlumnosModelo modelo)
        {
            return this.alumnosDao.ModificarAlumno(modelo);
        }

        public AlumnosModelo ObtenerAlumno(int AlumnoId)
        {
            return this.alumnosDao.ObtenerAlumno(AlumnoId);
        }

        public AlumnosCarrerasModelo TraerAlumnoCarrera(int AlumnoId)
        {
            return this.alumnosDao.TraerAlumnoCarrera(AlumnoId);
        }

        public int TraerCarreraIdActiva(int AlumnoId)
         {
            //AlumnosCarreraModelo result = new AlumnosCarreraModelo();

            //return result;
            return this.alumnosDao.TraerCarreraIdActiva(AlumnoId);
        }

        public void EliminarAlumno(int AlumnoId)
        {
            this.alumnosDao.EliminarAlumno(AlumnoId);
        }
        public void BajaAlumnoCarrera(int AlumnoId)
        {
            this.alumnosDao.BajaAlumnoCarrera(AlumnoId);
        }
       
        public bool AlumnoExiste(string DNI)
        {
            var resultado = this.alumnosDao.AlumnoExiste(DNI);

            return resultado != null;
        }
       
        public int ConsultarAlumnoCiclo(int AlumnoId)
        {
            return this.alumnosDao.ConsultarAlumnoCiclo(AlumnoId);
        }
        public void DarAltaAlumnos(int alumnoId)
        {
            this.alumnosDao.DarAltaAlumnos(alumnoId);
        }
        
        public DataTable ObtenerTodosAlumnos(TipoFiltroAlumno tipo, string filtro, string activo = null)
        {
            return this.alumnosDao.ObtenerTodosAlumnos(tipo, filtro, activo);
        }
        public string[] ObtenerPaisNacimientoAlumnos()
        {
            var paisNacimiento = alumnosDao.ObtenerPaisNacimientoAlumnos();
            return paisNacimiento.Rows.Cast<DataRow>().Select(r => r.Field<String>("PaisNacimiento")).ToArray();           
        }
        public string[] ObtenerLocalidadAlumnos()
        {
            var localidad = alumnosDao.ObtenerLocalidadAlumnos();
            return  localidad.Rows.Cast<DataRow>().Select(r => r.Field<String>("Localidad")).ToArray();            
        }
        public string[] ObtenerDistritoAlumnos()
        {
            var distrito = alumnosDao.ObtenerDistritoAlumnos();
            return distrito.Rows.Cast<DataRow>().Select(r => r.Field<String>("Distrito")).ToArray();
        }
        public string[] ObtenerProvinciaAlumnos()
        {
            var provincia = alumnosDao.ObtenerProvinciaAlumnos();
            return provincia.Rows.Cast<DataRow>().Select(r => r.Field<String>("Provincia")).ToArray();
        }

    }
}
