using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Daos
{
    public class TurnosDao : DaoBase, ITurnos
    {
        public DataTable ObtenerTurnosCursada()
        {
            string query = "SELECT * FROM TurnosCursada";
            return this.Conexion.ObtenerRegistros(query);
        }
    }
}
