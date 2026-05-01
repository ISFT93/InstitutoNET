using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface ICursosDao
    {
        DataTable ConsultarCursos(int AnioCarreraId);

        DataTable ConsultarCursosPrimerAnio(int AlumnoId);

        DataTable AgregarCurso(int AnioCarreraId, string NombreCurso);

        int ModificarCurso(int CursoId, string NombreCurso);

        int EliminarCurso(int CursoId);

        DataTable CursosInactivos(int AnioCarreraId);

        int DarAltaCurso(int CursoId);

        DataTable ObtenerDatosAlumnoCursoMateria(int cursadaId);

        CursosModelo ObtenerCurso(int cursoId);
    }
}
