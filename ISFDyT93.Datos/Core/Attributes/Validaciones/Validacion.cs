using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class Validacion : System.Attribute
    {
        public string Mensaje { get; set; }

        public delegate bool InvocarHandler(object valor, ModeloBase modelo);

        public InvocarHandler Metodo { get; set; }

        public Validacion(string mensaje = null)
        {
            this.Mensaje = mensaje;
        }

        public virtual bool Validar(object valor, ModeloBase modelo) {
            return Metodo(valor, modelo);
        }
    }
}
