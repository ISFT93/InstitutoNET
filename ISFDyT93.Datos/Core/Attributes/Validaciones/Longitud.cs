using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class Longitud : Validacion
    {
        private int Long { get; set; }
        private int Minimo { get; set; }
        private int Maximo { get; set; }

        public Longitud(int longitud = -1, int minimo = -1, int maximo = -1) : base(null)
        {
            Inicializar();

            this.Long = longitud;
            this.Minimo = minimo;
            this.Maximo = maximo;

            if(this.Long >= 0)
            {
                this.Mensaje = $"El campo debe tener { this.Long } caracteres";
            } else {

                if(Minimo >= 0 && Maximo >= 0)
                {
                    this.Mensaje = $"El campo debe tener entre ${ this.Minimo } y ${ this.Maximo } caracteres";
                } 
                else
                {
                    if (this.Minimo >= 0)
                    {
                        this.Mensaje = $"El campo debe tener un mínimo de ${ this.Minimo } caracteres";
                    }
                    else if(this.Maximo >= 0)
                    {
                        this.Mensaje = $"El campo debe tener un máximo de ${ this.Maximo } caracteres";
                    }
                }
            }
        }

        private void Inicializar()
        {
            this.Metodo += InnerValidar;
        }

        public bool InnerValidar(object value, ModeloBase modelo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            var stringValue = value.ToString();

            if (this.Long >= 0)
            {
                return this.Long >= stringValue.Length;
            }
            else
            {
                if (Minimo >= 0 && Maximo >= 0)
                {
                    return this.Minimo >= stringValue.Length && this.Maximo <= stringValue.Length;
                }
                else
                {
                    if (Minimo >= 0)
                    {
                        return this.Minimo >= stringValue.Length;
                    }
                    else if (Minimo >= 0)
                    {
                        return this.Maximo <= stringValue.Length;
                    }
                }
            }

            return false;
        }
    }
}
