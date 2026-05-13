using ISFDyT93.Datos.Daos;
using ISFDyT93.Entidades.Enums;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ISFDyT93.Negocio.Logica
{
    public class AlumnosLogica : LogicaBase
    {

        AlumnosDao alumnosDao;
        MailService mailService;
        public AlumnosLogica()
        {
            alumnosDao = new AlumnosDao();
            mailService = new MailService();
        }

        public int AgregarAlumno(AlumnosModelo modelo)
        {
            string replacePoint = modelo.Promedio.ToString();
            replacePoint.Replace(".", ",");

            if (this.alumnosDao.AgregarAlumno(modelo) > 0)
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

        public DataTable ObtenerAlumnosPorEstadoDocumentacion(int estado,int idCarrera)
        {
            // Llama al DAO para traer los alumnos filtrados
            return this.alumnosDao.ObtenerAlumnosPorEstadoDocumentacion(estado,idCarrera);
        }

        public int ActualizarEstadoInicializado(int alumnoId, int nuevoEstado)
        {
            // Llama al DAO para actualizar el campo Inicializado (0, 1 o 2)
            return this.alumnosDao.ActualizarEstadoInicializado(alumnoId, nuevoEstado);
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
            return localidad.Rows.Cast<DataRow>().Select(r => r.Field<String>("Localidad")).ToArray();
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
        public bool EnviarMailDocumentos(string destino,
        string asunto,
        string mensaje,
        bool esHtml = true,
        List<string> adjuntos = null,
        List<string> copia = null,
        List<string> copiaOculta = null)
        {
            return this.mailService.SendMail(destino,
        asunto,
        mensaje,
        esHtml = true,
        adjuntos = null,
        copia = null,
        copiaOculta = null);
        }
    }
}
