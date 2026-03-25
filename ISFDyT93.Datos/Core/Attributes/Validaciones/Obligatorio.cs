using System;
using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class Obligatorio : Validacion
    {
        private string Condicion { get; set; }

        public Obligatorio(string mensaje = "Este campo es obligatorio") : base(mensaje)
        {
            this.Metodo += InnerValidar;
        }

        public Obligatorio(string condicion, string mensaje = "Este campo es obligatorio") : base(mensaje)
        {
            this.Metodo += InnerValidar;
            this.Condicion = condicion;
        }

        public bool InnerValidar(object value, ModeloBase modelo)
        {
            Type tipo = modelo.GetType();

            if(!string.IsNullOrEmpty(this.Condicion))
            {
                var metodo = tipo.GetMethod(Condicion);

                bool result = (bool)metodo.Invoke(modelo, null);

                if (result == false)
                {
                    return true;
                }
            }

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
