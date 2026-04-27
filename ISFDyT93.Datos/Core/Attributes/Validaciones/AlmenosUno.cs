using ISFDyT93.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class AlmenosUno : Validacion
    {
        public string Campos { get; set; }

        public AlmenosUno(string campos, [CallerMemberName] string propertyName = null) : base()
        {
            this.Metodo += InnerValidar;
            this.Campos = campos;

            var _campos = this.Campos.Split(':');

            this.Mensaje = "Al menos debe ingresar un " + propertyName;

            foreach (var campo in _campos)
            {
                this.Mensaje += ", " + campo;
            }
        }

        public bool InnerValidar(object value, ModeloBase modelo)
        {
            Type tipo = modelo.GetType();

            bool validado = TieneValor(value);

            var campos = this.Campos.Split(':');

            foreach(var campo in campos)
            {
                var propiedad = tipo.GetProperty(campo);

                if(propiedad != null)
                {
                    var valor = propiedad.GetValue(modelo);

                    if(!validado)
                    {
                        validado = TieneValor(valor);
                    }
                }
            }

            return validado;
        }

        private bool TieneValor(object value)
        {
            if (value == null)
                return false;

            if (value.GetType() == typeof(char) && ((char)value) == (char)1)
            {
                return false;
            }

            if (value.GetType() == typeof(DateTime) && ((DateTime)value) == DateTime.MinValue)
            {
                return false;
            }

            return !string.IsNullOrEmpty(value.ToString()) && value.ToString().Trim() != "";
        }
    }
}
