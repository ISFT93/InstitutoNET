using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface ICarrerasDao
    {
        DataTable ObtenerCarreras(bool Activo = true);
        DataTable CarrerasInactivas(bool Activo = false);
        DataTable CarrerasBorrador(bool Activo = false);
        DataTable CarrerasActivas(bool Activo = true);
        CarrerasModelo ObtenerCarrera(int id);
        DataRow CarreraExiste(string Nombre);
        int TraeIdDeCarrera(string nombre);
        int ObtenerUltimoCarreraId();
        int AgregarCarreras(CarrerasModelo modelo);
        int ModificarCarrera(CarrerasModelo modelo);
        int ModificarCarreraEstado(CarrerasModelo modelo);
        void EliminarCarrera(int CarreraId);
        void AltaCarreraActivo(int CarreraId);
        void ActualizarCargaHoraria(int CarreraId, int cantidadHoras);
    }
}
