using ISFDyT93.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IUnico
    {
        bool InnerValidar(object value, ModeloBase modelo);
    }
}
