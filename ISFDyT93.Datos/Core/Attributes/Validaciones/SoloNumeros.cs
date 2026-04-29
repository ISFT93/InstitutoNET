using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Datos.Modelos;
using System.Linq;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class SoloNumeros : Validacion
    {
        const string NUMEROS = "0123456789";

        private int? Minimo { get; set; }
        private int? Maximo { get; set; }

        public SoloNumeros() : base(null)
        {
            Inicializar();
        }

        public SoloNumeros(int minimo)
        {
            this.Minimo = minimo;
            this.Mensaje = "Solo se admiten números mayores o iguales a " + minimo;
            Inicializar();
        }

        public SoloNumeros(int minimo, int maximo)
        {
            this.Minimo = minimo;
            this.Maximo = maximo;
            this.Mensaje = $"Solo se admiten números entre {minimo} y {maximo}";
            Inicializar();
        }

        private void Inicializar()
        {
            this.Metodo += InnerValidar;
        }

        public bool InnerValidar(object value, ModeloBase modelo)
        {
            if (value == null)
                return true;

            string texto = value.ToString();
            
            string limpio = new string(texto.Where(char.IsDigit).ToArray());

            if (!long.TryParse(value.ToString(), out salida))
            {
                validado = false;
            }

            if (validado)
            {
                if (this.Minimo != null && this.Minimo > salida)
                {
                    validado = false;
                }

                if (this.Maximo != null && this.Maximo < salida)
                {
                    validado = false;
                }
            }

            if (this.Maximo != null && salida > this.Maximo)
                return false;

            return true;
        }
    }
}
