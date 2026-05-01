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
    public interface IPersonalDao
    {
        DataTable ObtenerListaPersonal(int estado);
        DataTable ObtenerListaPersonal(TipoFiltroProfesor tipo, string filtro, int estado);
        DataTable ArmarLegajo(int profesorId);
        IList<CargosModeloDTO> ObtenerPersonalConCargos(List<int> cursoMateriaIds);
        int AgregarPersonal(PersonalModelo modelo);
        int ModificarPersonal(PersonalModelo modelo);
        void EliminarPersonal(int personalId);
        PersonalModelo ObtenerPersonal(int personalId);
        void EliminarProfesor(int ProfesorId);
        void EliminarProfesorMateria(int ProfesorMateriaId);
        void AsignarProfesorMateria(int MateriaId, int CursoId, int ProfesorId, string Fecha);
        DataTable ObtenerProfesorMaterias(int PersonalId);
        DataRow PersonalExiste(string DNI);
        int AgregarDocumentacion(string Analitico, string Proyecto, int ProfesorMateriaId, int CiclosLectivoId);
        int ModificarDocumentacion(string Analitico, string Proyecto, int ProfesorMateriaId, int CiclosLectivoId);
        DataRow ObtenerDocumentacion(int ProfesorMateriaId, int CicloLectivoId);
        DataTable ObtenerPath(int ProfesorMateriaId, int CicloLectivoId);
        void DarAltaProfesores(int ProfesorId);
        DataTable ObtenerPersonalInactivos();
        DataTable ObtenerTodoPersonal(TipoFiltroProfesor tipo, string filtro);
        DataRow ObtenerCantidadMaterias(int ProfesorId, int MateriaId);
        DataTable ObtenerSituacionRevista();
        DataTable ObtenerNacionalidades();
    }
}
