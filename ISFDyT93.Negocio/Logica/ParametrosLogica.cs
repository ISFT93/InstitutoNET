using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Datos.Daos;

namespace ISFDyT93.Negocio.Logica
{
    public class ParametrosLogica
    {
        ParametrosDao parametros = new ParametrosDao();
        public IList<ParametrosModelo> ObtenerParametros()
        {
            return parametros.ObtenerParametros();
        }
        public ParametrosModelo ObtenerParametro(string Nombre)
        {
           return parametros.ObtenerParametro(Nombre);
        }
        public int ActualizarParametros(IList<ParametrosModelo> parametrosModelo)
        {
           return parametros.ActualizarParametros(parametrosModelo);
        }
    }
}
