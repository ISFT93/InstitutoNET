using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISFDyT93.Negocio.Interfaces;

namespace ISFDyT93.Negocio.Core
{
    public class LogicaBase : ILogicaBase
    {
        public DataTable ObtenerSiNo()
        {
            var tabla = new DataTable();
            tabla.Columns.Add("Codigo");
            tabla.Columns.Add("Descripcion");

            tabla.Rows.Add(1, "Si");
            tabla.Rows.Add(0, "No");

            return tabla;
        }
    }
}
