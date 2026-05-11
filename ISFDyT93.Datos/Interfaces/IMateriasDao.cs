using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IMateriasDao
    {
        DataTable ObtenerMaterias(int anioCarreraId, bool activo = true);
        DataTable CargarMaterias(int anioCarreraId, bool activo = true);
        int ObtenerUltimaMateriaId();
        int EliminarMateria(int idMateria);
        DataRow MateriaAsignada(int id);
        int AgregarMaterias(MateriasModelo modelo);
        int ModificarMateria(MateriasModelo modelo);
        DataTable ObtenerEspacios();
        MateriasModelo ObtenerMateria(int materiaId);
        DataTable ObtenerAsignarMateria(int alumnoId, int anioCarreraId);
        DataTable ObtenerMateriasAsignar(int alumnoId, int anioCarreraId);
        DataTable ObtenerMateriasAsignar(int alumnoId);
        int EliminarMateriaAsignada(MateriasModelo modelo);
        int AsignarMateria(MateriasModelo modelo);
        int EliminarMateriaAsignar(int alumnoCicloLectivoMateriaId);
        DataRow ObtenerCarreraDeAnio(int AnioCarerraId);
        DataTable ObtenerNombresMaterias();
        DataTable MateriasId(int carreraId);
        DataTable ObtenerMateriasByCursoAndAnioLectivo(int AnioLectivo, int CursoId);
    }
}
