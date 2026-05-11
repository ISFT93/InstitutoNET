using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IParametrosLogica
    {
        IList<ParametrosModelo> ObtenerParametros();
        ParametrosModelo ObtenerParametro(string Nombre);
        int ActualizarParametros(IList<ParametrosModelo> parametrosModelo);
    }
}
