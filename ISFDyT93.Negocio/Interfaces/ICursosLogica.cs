using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface ICursosLogica
    {
        DataTable ConsultarCursos(int anioCarreraId);
        bool ConsultarCursosInactivo(int AnioCarreraId);
        DataTable ConsultarCursosPrimerAnio(int alumnoId);
        DataTable AgregarCurso(int anioCarreraId, int cantidadCursos);
        int ModificarCurso(int cursoId, string nombreCurso);
        int EliminarCurso(int cursoId);
        DataTable CursosInactivos(int anioCarreraId);
        int DarAltaCurso(int cursoId);
        DataTable ObtenerCursoMateria(int cursadaId);
        CursosModelo ObtenerCurso(int cursoId);
    }
}
