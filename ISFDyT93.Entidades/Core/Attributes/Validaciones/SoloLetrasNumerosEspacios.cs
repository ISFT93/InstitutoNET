using ISFDyT93.Entidades.Modelos;

namespace ISFDyT93.Entidades.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class SoloLetrasNumerosEspacios : Validacion
    {
        const string NUMEROSLETRAS = "abcdefghijklmnñopqrstuvwxyzáéíóú0123456789 ";

        public SoloLetrasNumerosEspacios(string mensaje = "Solo ingrese letras, números y espacios") : base(mensaje)
        {
            this.Metodo += InnerValidar;
        }

        public bool InnerValidar(object value, ModeloBase modelo)
        {
            var stringValue = value?.ToString();

            if (string.IsNullOrEmpty(stringValue))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in stringValue)
            {
                if (!NUMEROSLETRAS.Contains(c.ToString().ToLower()))
                {
                    validado = false;
                }
            }

            return validado;
        }
    }
}
