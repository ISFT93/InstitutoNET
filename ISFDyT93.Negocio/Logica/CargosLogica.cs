using ISFDyT93.Datos.Daos;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISFDyT93.Negocio.Interfaces;

namespace ISFDyT93.Negocio.Logica
{
    public class CargosLogica : ICargosLogica
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
