using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
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
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in value.ToString())
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
