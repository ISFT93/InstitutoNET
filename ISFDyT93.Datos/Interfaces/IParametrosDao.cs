using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IParametrosDao
    {
        IList<ParametrosModelo> ObtenerParametros(bool actualizar = false);
        ParametrosModelo ObtenerParametro(string Nombre);
        int ActualizarParametros(IList<ParametrosModelo> parametrosModelo);
    }
}
