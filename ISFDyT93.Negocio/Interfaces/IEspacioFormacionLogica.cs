using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IEspacioFormacionLogica
    {
        DataTable ObtenerEspacios();
        DataTable ObtenerEspaciosActivos();
        int HabilitarEspacio(int espacioId);
        int DeshabilitarEspacio(int espacioId);
        int AgregarEspacio(Entidades.Modelos.EspacioModelo modelo);
        int ModificarEspacio(Entidades.Modelos.EspacioModelo modelo);
    }
}
