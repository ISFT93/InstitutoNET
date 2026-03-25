using ISFDyT93.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class Email : Validacion
    {
        const string EMAIL = "abcdefghijklmnñopqrstuvwxyzáéíóú0123456789@_.";

        public Email(string mensaje = "El campo  tiene un formato email incorrecto") : base(mensaje)
        {
            Metodo += InnerValidar;
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
                if (!EMAIL.Contains(c.ToString().ToLower()))
                {
                    validado = false;
                }
            }
            return validado;
        }
    }
}
