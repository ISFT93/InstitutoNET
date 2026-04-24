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

            // 3. Si está vacío, lo consideramos válido (como hacías antes)
            if (string.IsNullOrEmpty(limpio))
                return true;
            
            if (!long.TryParse(limpio, out long salida))
                return false;
            
            if (this.Minimo != null && salida < this.Minimo)
                return false;

            if (this.Maximo != null && salida > this.Maximo)
                return false;

            return true;
        }
    }
}
