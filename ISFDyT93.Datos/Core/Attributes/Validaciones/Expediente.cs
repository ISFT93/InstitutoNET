using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class Expediente : Validacion
    {
        public Expediente() : base("El Expediente tiene un formato incorrecto")
        {
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

            var stringValue = value.ToString();

            // 5801-3.279.866/03
            int index = stringValue.IndexOf("-");

            // Verifica que haya guión
            if (index < 0)
                return false;

            string bloque1 = stringValue.Substring(0, index);
            int intbloque1 = 0;

            // Verifica que haya un número antes del guión
            if (!int.TryParse(bloque1, out intbloque1))
            {
                return false;
            }

            // Obtengo el resto del string
            stringValue = stringValue.Substring(index + 1);

            // Obtengo el indice de la barra
            index = stringValue.IndexOf("/");
            if (index < 0)
                return false;

            // Obtengo el valor entre el guión y la barra
            string bloque2 = stringValue.Substring(0, index);


            // Verifico que se respete cada 3 números le sigue un punto
            int cant = 0;
            for (int i = bloque2.Length - 1; i > 0; i--)
            {
                char letra = bloque2[i];

                if (cant == 3 && letra != '.')
                {
                    return false;
                }
                else if (cant == 3 && letra == '.')
                {
                    cant = 0;
                }
                else
                {
                    cant++;
                }
            }

            // Le quito los puntos al bloque 2
            bloque2 = bloque2.Replace(".", "");
            long intbloque2 = 0;

            // Verifica que haya un número en el bloque 2
            if (!long.TryParse(bloque2, out intbloque2))
            {
                return false;
            }

            // Obtengo el bloque 3 despues de guión
            string bloque3 = stringValue.Substring(index + 1);
            int intbloque3 = 0;

            // Verifica que haya un número en el bloque 3
            if (!int.TryParse(bloque3, out intbloque3))
            {
                return false;
            }


            return true;
        }
    }
}
