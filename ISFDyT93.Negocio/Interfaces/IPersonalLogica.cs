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
    public interface IPersonalLogica
    {
        DataTable ObtenerListaPersonal(TipoFiltroProfesor tipo, string filtro, int estado);
        IList<CargosModeloDTO> ObtenerPersonalConCargos(List<int> cursoMateriaIds);
        void AsignarProfesorMateria(int MateriaId, int CursoId, int ProfesorId, string Fecha);
        void AgregarPersonal(PersonalModelo modelo);
        int ModificarPersonal(PersonalModelo modelo);
        PersonalModelo ObtenerPersonal(int personalId);
        void EliminarPersonal(int personalId);
        void EliminarProfesorMateria(int ProfesorMateriaId);
        void VerLegajo(int profesorId);
        DataTable ObtenerProfesorMaterias(int ProfesorId);
        bool PersonalExiste(string DNI);
        int AgregarDocumentacion(string Analitico, string Proyecto, int ProfesorMateriaId, int CiclosLectivoId);
        int ModificarDocumentacion(string Analitico, string Proyecto, int ProfesorMateriaId, int CiclosLectivoId);
        DataRow ObtenerDocumentacion(int ProfesorMateriaId, int CicloLectivoId);
        DataTable ObtenerPath(int ProfesorMateriaId, int CicloLectivoId);
        void DarAltaProfesores(int ProfesorId);
        DataTable ObtenerSituacionRevista();
        bool PoseeMaterias(int ProfesorId, int MateriaId);
        DataTable ObtenerNacionalidades();
    }
}
