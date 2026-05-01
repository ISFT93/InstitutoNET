using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IServiciosDao
    {
        DataTable ObtenerCargos(int personalId);
        LibroActasModelo ObtenerUltimoLibro(int tipoLibroId);
        DataTable ObtenerServicioPersonal(int personalId, int activo);
        ServiciosModelo ObtenerServicio(int servicioId);
        DataTable ObtenerCargosAsignados(int cargoId, int personalId);
        DataTable ObtenerMateriasLibres(int tipoAsignacionId, int cursoId, int situacionRevistaId);
        void ActualizarPersonalEstado(int personalEstadoId, int personalId);
        int AgregarServicio(ServiciosModelo modelo);
        int ActualizarServicio(ServiciosModelo modelo);
        DataTable ObtenerSituacionRevista();
        DataTable ObtenerCarreras(int tipoAsignacionId, int situacionRevistaId);
        DataTable ObtenerCarrerasSinJefeCatedra(int PersonalId);
        DataTable ObtenerAnioCarreras(int carreraId);
        DataTable ObtenerCursos(int anioCarreraId);
        LibroActasModelo AgregarLibroActa(LibroActasModelo libro);
        void ActualizarLibroActa(LibroActasModelo libro);
        void ActualizarJefeCatedra(int carreraId, string nombreProfesor);
        DataRow ObtenerModuloMateria(int CursoMateriaId);
    }
}
