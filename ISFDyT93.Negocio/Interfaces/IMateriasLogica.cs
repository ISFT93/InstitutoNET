using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IMateriasLogica
    {
        DataRow ObtenerCarreraDeAnio(int AnioCarerraId);
        DataTable ObtenerMaterias(int AnioCarreraId);
        DataTable CargarMaterias(int AnioCarreraId);
        int ObtenerUltimaMateriaId();
        int EliminarMateria(int materiaId, int anioCarreraId);
        int MateriaAsignada(int id);
        int AgregarMaterias(MateriasModelo modelo);
        DataTable ObtnenerEspacios();
        MateriasModelo ObtenerMateria(int MateriaId);
        int ModificarMateria(MateriasModelo modelo);
        DataTable ObtenerAsignarMateria(int AlumnoId, int AnioCarreraId);
        DataTable ObtenerMateriasAsignar(int AlumnoId, int AnioCarreraId);
        DataTable ObtenerMateriasAsignar(int AlumnoId);
        int EliminarMateriaAsignada(MateriasModelo modelo);
        int AsignarMateria(MateriasModelo modelo);
        int EliminarMateriaAsignar(int AlumnoCicloLectivoMateriaId);
        DataTable ObtenerNombresMaterias();
        DataTable MateriasId(int CarreraId);
        DataTable ObtenerMateriasByCursoAndAnioLectivo(int AnioLectivo, int CursoId);
    }
}
