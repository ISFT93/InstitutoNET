using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    public static class LimpiarTexto
    {
        //Elimina saltos de linea invisibles cuando se valida el texto,
        //y espacios al principio y final del texto.
        public static string QuitarSaltosDeLineaYEspacios(string texto)
        {
            return texto
                .Replace("\r", "")
                .Replace("\n", "")
                .Trim();
        }

    }
}
