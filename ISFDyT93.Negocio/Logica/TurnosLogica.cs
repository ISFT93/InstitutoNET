using ISFDyT93.Datos;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Negocio.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISFDyT93.Negocio.Interfaces;

namespace ISFDyT93.Negocio.Logica
{
    public class TurnosLogica : LogicaBase, ITurnosLogica
    {
        private TurnosDao turnosDao = new TurnosDao();

        public DataTable ObtenerTurnosCursada()
        {
            return turnosDao.ObtenerTurnosCursada();
        }
    }
}
