using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Logica
{
    public class CargosLogica
    {
        CargosDao cargosDao = new CargosDao();
        public (DataTable, DataTable, IList<CargosModelo>) ObtenerCargos()
        {
            return cargosDao.ObtenerCargos();
        }
        public int ActualizarCargos(IList<CargosModelo> ltsCargos)
        {
            return cargosDao.ActualizarCargos(ltsCargos);
        }
    }
}
