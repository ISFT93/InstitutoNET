using ISFDyT93.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class SoloLetrasEspacios : Validacion
    {
        const string LETRAS = "abcdefghijklmnñopqrstuvwxyzáéíóú ,";

        public SoloLetrasEspacios(string mensaje = "Solo ingrese letras y espacios") : base(mensaje)
        {
            this.Metodo += InnerValidar;
        }

        public bool InnerValidar(object value, ModeloBase modelo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in value.ToString())
            {
                if (!LETRAS.Contains(c.ToString().ToLower()))
                {
                    validado = false;
                }
            }

            return validado;
        }
    }
}
