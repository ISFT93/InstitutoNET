using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IEspacioFormacion : IDaoBase
    {
        DataTable ObtenerEspacios();
        DataTable ObtenerEspaciosActivos();
        int HabilitarEspacio(int espacioId);
        int DeshabilitarEspacio(int espacioId);
        int AgregarEspacio(EspacioModelo modelo);
        int ModificarEspacio(EspacioModelo modelo);
    }
}
