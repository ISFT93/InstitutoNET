using ISFDyT93.Entidades.Modelos;
using System.Collections.Generic;
using System.Data;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IEspaciosDao
    {
        //(DataTable TipoAsignacion, DataTable TipoAplicacion, IList<EspaciosModelo> Espacios) ObtenerEspacios();
        IList<EspaciosModelo> ObtenerEspacios();
        int ActualizarEspacios(IList<EspaciosModelo> ltsEspacios);

        bool EspaciosActivos();

        bool EspaciosInactivos();

        void HabilitarEspacio(int EspacioId);

        void DeshabilitarEspacio(int EspacioId);

        void AgregarEspacio(string Descripcion);
    }
}