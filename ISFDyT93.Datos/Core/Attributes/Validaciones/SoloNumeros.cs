using ISFDyT93.Datos.Modelos;

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
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            bool validado = true;
            foreach (char c in value.ToString())
            {
                if (!NUMEROS.Contains(c.ToString()))
                {
                    validado = false;
                }
            }

            long salida;

            if(!long.TryParse(value.ToString(), out salida))
            {
                validado = false;
            }

            if (validado)
            {
                if (this.Minimo != null && this.Minimo > salida)
                {
                    validado = false;
                }

                if(this.Maximo != null && this.Maximo < salida)
                {
                    validado = false;
                }
            }

            return validado;

        }
    }
}
