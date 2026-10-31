using ISFDyT93.Entidades.Enums;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IAlumnosDao
    {
        int AgregarAlumnoTablaExcel(AlumnosModelo modelo);
        int ModificarAlumnoTablaExcel(AlumnosModelo modelo);
        int AgregarAlumno(AlumnosModelo modelo);
        int AgregarAlumnoCargaMasiva(AlumnosModelo modelo);
        int ModificarAlumno(AlumnosModelo modelo);
        int AgregarAlumnoCarrera(AlumnosCarrerasModelo modelo);
        int AgregarAlumnoCarreraExcel(AlumnosCarrerasModelo modelo);
        int ModificarAlumnoCarrera(AlumnosCarrerasModelo modelo);
        DataTable ObtenerAlumnosPrueba();
        AlumnosModelo ObtenerAlumno(int AlumnoId);
        AlumnosModelo ObtenerAlumnoCarrera(int AlumnoId);
        AlumnosCarrerasModelo TraerAlumnoCarrera(int AlumnoId);
        DataRow ObtenerLibroYFolioAlumno(int AlumnoId);
        DataRow ObtenerDatosAnaliticoAlumno(int AlumnoId);
        DataTable ObtenerAnaliticoAlumno(int AlumnoCarreraId);
        int GuardarNotaEquivalencia(AnaliticoItem item);
        void EliminarAlumno(int AlumnoId);
        void BajaAlumnoCarrera(int AlumnoId);
        int TraerCarreraIdActiva(int AlumnoId);
        int UltimoId();
        DataRow AlumnoExiste(string DNI);
        int ConsultarAlumnoCiclo(int AlumnoId);
        void DarAltaAlumnos(int alumnoId);
        DataTable ObtenerTodosAlumnos(TipoFiltroAlumno tipo, string filtro, string activo);
        DataTable ObtenerTodosAlumnos(TipoFiltroAlumno tipo, string filtro, bool? activo, int? carreraId, int? anioLectivoId);
        int CargarCursadasAlumnoSP(AlumnosCarrerasModelo Modelo);
        DataTable ObtenerPaisNacimientoAlumnos();
        DataTable ObtenerLocalidadAlumnos();
        DataTable ObtenerDistritoAlumnos();
        DataTable ObtenerProvinciaAlumnos();
    }
}
