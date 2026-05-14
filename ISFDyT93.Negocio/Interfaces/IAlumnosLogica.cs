using ISFDyT93.Entidades.Enums;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IAlumnosLogica
    {
        int AgregarAlumno(AlumnosModelo modelo);
        int UltimoRegistroAlumno(AlumnosModelo modelo);
        int AgregarAlumnoTablaExcel(AlumnosModelo modelo);
        int AgregarAlumnoCargaMasiva(AlumnosModelo modelo);
        int AgregarAlumnoCarrera(AlumnosCarrerasModelo modelo);
        int AgregarAlumnoCarreraExcel(AlumnosCarrerasModelo modelo);
        int ModificarAlumnoCarrera(AlumnosCarrerasModelo modelo);
        DataTable ObtenerAlumnosPrueba();
        int ModificarAlumnoTablaExcel(AlumnosModelo modelo);
        int ModificarAlumno(AlumnosModelo modelo);
        AlumnosModelo ObtenerAlumno(int AlumnoId);
        AlumnosCarrerasModelo TraerAlumnoCarrera(int AlumnoId);
        int TraerCarreraIdActiva(int AlumnoId);
        void EliminarAlumno(int AlumnoId);
        void BajaAlumnoCarrera(int AlumnoId);
        bool AlumnoExiste(string DNI);
        int ConsultarAlumnoCiclo(int AlumnoId);
        void DarAltaAlumnos(int alumnoId);
        DataTable ObtenerTodosAlumnos(TipoFiltroAlumno tipo, string filtro, string activo = null);
        string[] ObtenerPaisNacimientoAlumnos();
        string[] ObtenerLocalidadAlumnos();
        string[] ObtenerDistritoAlumnos();
        string[] ObtenerProvinciaAlumnos();
    }
}
