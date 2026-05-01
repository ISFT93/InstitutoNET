using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface ICargosDao
    {
        (DataTable TipoAsignacion, DataTable TipoAplicacion, IList<CargosModelo> Cargos) ObtenerCargos();
        int ActualizarCargos(IList<CargosModelo> ltsCargos);
    }
}
