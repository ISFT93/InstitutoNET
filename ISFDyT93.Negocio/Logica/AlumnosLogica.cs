using ISFDyT93.Datos.Daos;
using ISFDyT93.Entidades.Modelos;
using System.Collections.Generic;
using System.Data;
using ISFDyT93.Entidades.Enums;
using ISFDyT93.Negocio.Core;
using System;
using System.Linq;
using ISFDyT93.Negocio.Interfaces;
using System.Windows.Forms;

namespace ISFDyT93.Negocio.Logica
{
    public class AlumnosLogica : LogicaBase , IAlumnosLogica
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

        public DataRow ObtenerLibroYFolioAlumno(int AlumnoId)
        {
            return this.alumnosDao.ObtenerLibroYFolioAlumno(AlumnoId);
        }

        public DataRow ObtenerDatosAnaliticoAlumno(int AlumnoId)
        {
            return this.alumnosDao.ObtenerDatosAnaliticoAlumno(AlumnoId);
        }

        public List<AnaliticoItem> ObtenerAnaliticoAlumno(int AlumnoCarreraId)
        {
            DataTable tabla = this.alumnosDao.ObtenerAnaliticoAlumno(AlumnoCarreraId);
            var items = new List<AnaliticoItem>();

            foreach (DataRow fila in tabla.Rows)
            {
                items.Add(new AnaliticoItem
                {
                    AnaliticoId = fila["AnaliticoId"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(fila["AnaliticoId"]),
                    CursadaAlumnoCarreraId = fila["CursadaAlumnoCarreraId"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(fila["CursadaAlumnoCarreraId"]),
                    AlumnoCarreraId = fila["AlumnoCarreraId"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(fila["AlumnoCarreraId"]),
                    CodigoBloqueMateria = fila["CodigoBloqueMateria"] == DBNull.Value
                        ? null
                        : fila["CodigoBloqueMateria"].ToString(),
                    AnioCicloLectivo = fila["AnioCicloLectivo"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(fila["AnioCicloLectivo"]),
                    AnioCarrera = ObtenerNombreAnioCarrera(fila["AnioCarrera"]),
                    Orden = fila["Orden"] == DBNull.Value ? 0 : Convert.ToInt32(fila["Orden"]),
                    Materia = fila["Materia"] == DBNull.Value ? "" : fila["Materia"].ToString(),
                    AnioCursada = fila["AnioCursada"] == DBNull.Value
                        ? (int?)null
                        : Convert.ToInt32(fila["AnioCursada"]),
                    Nota = fila["Nota"] == DBNull.Value
                        ? (decimal?)null
                        : Convert.ToDecimal(fila["Nota"]),
                    NotaLetras = fila["NotaLetras"] == DBNull.Value
                        ? null
                        : fila["NotaLetras"].ToString(),
                    Condicion = fila["Condicion"] == DBNull.Value
                        ? null
                        : fila["Condicion"].ToString(),
                    Libro = fila["Libro"] == DBNull.Value
                        ? (int?)null
                        : Convert.ToInt32(fila["Libro"]),
                    Folio = fila["Folio"] == DBNull.Value
                        ? (int?)null
                        : Convert.ToInt32(fila["Folio"]),
                    Fecha = fila["Fecha"] == DBNull.Value
                        ? (DateTime?)null
                        : Convert.ToDateTime(fila["Fecha"])
                });
            }

            return items;
        }

        public int GuardarNotaEquivalencia(AnaliticoItem item)
        {
            return this.alumnosDao.GuardarNotaEquivalencia(item);
        }

        private string ObtenerNombreAnioCarrera(object valor)
        {
            if (valor == DBNull.Value)
                return "SIN AÑO";

            int anio = Convert.ToInt32(valor);

            switch (anio)
            {
                case 1: return "PRIMER AÑO";
                case 2: return "SEGUNDO AÑO";
                case 3: return "TERCER AÑO";
                case 4: return "CUARTO AÑO";
                case 5: return "QUINTO AÑO";
                default: return $"{anio}° AÑO";
            }
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
        public int ActualizarEstadoInicializado(int alumnoId, int nuevoEstado)
        {
            return this.alumnosDao.ActualizarEstadoInicializado(alumnoId, nuevoEstado);
        }
        public DataTable ObtenerAlumnosPorEstadoDocumentacion(int estado,int carrera, string filtro)
        {
            return this.alumnosDao.ObtenerAlumnosPorEstadoDocumentacion(estado,carrera,filtro);
        }
        public bool EnviarMailDocumentos(string email, string asunto, string mensaje)
        {
            MailService mailService = new MailService();
            return mailService.SendMail(email, asunto, mensaje);
        }
        public DataTable ObtenerTodosAlumnos(TipoFiltroAlumno tipo, string filtro, string activo = null)
        {
            return this.alumnosDao.ObtenerTodosAlumnos(tipo, filtro, activo);
        }
        public DataTable ObtenerTodosAlumnos(TipoFiltroAlumno tipo, string filtro, bool? activo, int? CarreraId, int? AnioLectivoId)
        {
            return this.alumnosDao.ObtenerTodosAlumnos(tipo, filtro, activo, CarreraId, AnioLectivoId);
        }
        public void ObtenerCarreraCorta(ComboBox cmb)
        {
            this.alumnosDao.ObtenerCarreraCorta(cmb);
        }
        public void ObtenerCicloLectivo(ComboBox cmb)
        {
            this.alumnosDao.ObtenerCicloLectivo(cmb);
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

    }
}
