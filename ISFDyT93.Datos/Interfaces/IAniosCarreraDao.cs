using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IAniosCarreraDao
    {
        DataTable ObtenerAniosCarrera(int carreraId);
        int AgregarAnio(int anioCarrera, int carreraId);
        int EliminarAnios(int anioCarreraId);
        int ActualizarCargaHoria(int anioCarreraId);
        DataTable ObtenerAnios(int alumnoId);
        int ObtenerCargaHoraria(int CarreraId);
        DataRow ObtenerCarrera(int AnioCarreraId);
        AniosCarrerasModelo ObtenerAnioCarrera(int anioCarreraId);
        int ObtenerAnio(int anioCarreraId);
    }
}
