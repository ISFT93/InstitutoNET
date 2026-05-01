using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IAniosCarreraLogica
    {
        DataTable ObtenerAniosCarrera(int id);
        DataTable ObtenerAnios(int AlumnoId);
        int ActualizarCargaHoraria(int AnioCarreraId);
        int ObtenerCargaHoraria(int CarreraId);
        AniosCarrerasModelo ObtenerAnioCarrera(int anioCarreraId);
        CarrerasModelo ObtenerCarrera(int AnioCarreraId);
        int ObtenerAnio(int anioCarreraId);
        int EliminarAnios(int AnioCarreraId);
    }
}
