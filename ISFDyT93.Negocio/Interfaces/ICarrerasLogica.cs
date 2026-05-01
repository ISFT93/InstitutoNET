using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface ICarrerasLogica
    {
        DataTable ObtenerCarreras();
        DataTable CarrerasInactivas();
        DataTable CarrerasBorrador();
        DataTable CarrerasActivas();
        bool CarrerasExiste(string Nombre);
        CarrerasModelo ObtenerCarrera(int id);
        int TraeIdDeCarrera(string nombre);
        bool GuardarCarrera(CarrerasModelo modelo, TipoAccion accion);
        void EliminarCarrera(int CarreraId);
        void AltaCarreraActivo(int Carreraid);
    }
}
