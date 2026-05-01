using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface ICargosLogica
    {
        (DataTable, DataTable, IList<CargosModelo>) ObtenerCargos();
        int ActualizarCargos(IList<CargosModelo> ltsCargos);
    }
}
