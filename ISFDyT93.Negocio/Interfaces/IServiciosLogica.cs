using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IServiciosLogica
    {
        DataTable ObtenerCargos(int PersonalId);
        LibroActasModelo ObtenerUltimoLibro(int tipoLibroId);
        DataTable ObtenerServiciosPersonal(int PersonalId, int Activo);
        DataTable ObtenerSituacionRevista();
        DataTable ObtenerCargosAsignados(int CargoId, int personalId);
        DataTable ObtenerMateriasLibres(int tipoAsignacionId, int CursoId, int situacionRevistaId);
        bool AgregarServicio(ServiciosModelo servicio, PersonalModelo personal, LibroActasModelo libroActa);
        void DesactivarServicio(int servicioId, int cantidadServicios);
        DataTable ObtenerCarreras(int tipoAsignacionId, int situacionRevistaId);
        DataTable ObtenerCarrerasSinJefeCatedra(int PersonalId);
        DataTable ObtenerAnioCarreras(int CarreraId);
        DataTable ObtenerCursos(int AnioCarreraId);
        int ObtenerModuloMateria(int CursoMateriaId);

    }
}
