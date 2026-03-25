using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class MayorQue : Validacion
    {
        public string Campo { get; set; }

        public MayorQue(string campo, [CallerMemberName] string propertyName = null) : base()
        {
            this.Metodo += InnerValidar;
            this.Campo = campo;

            this.Mensaje = $"{propertyName} debe ser mayor que { campo }";
        }

        public bool InnerValidar(object value, ModeloBase modelo)
        {
            bool valido = true;
            Type tipo = modelo.GetType();

            var propiedad = tipo.GetProperty(this.Campo);

            if(propiedad != null)
            {
                var valueB = propiedad.GetValue(modelo);

                if(value != null && valueB != null)
                {
                    valido = Comparar(value, valueB);
                }
            }

            return valido;
        }

        private bool Comparar(object valorA, object valorB)
        {
            if(valorA.GetType() != valorB.GetType())
            {
                return false;
            }

            if(IsNumber(valorA) && IsNumber(valorB))
            {
                Decimal.TryParse(valorA.ToString(), out decimal dValorA);
                Decimal.TryParse(valorB.ToString(), out decimal dValorB);

                return dValorA > dValorB;
            }
            else if(valorA is DateTime dtValorA && valorB is DateTime dtValorB)
            {
                return dtValorA > dtValorB;
            }

            return true;
        }

        private bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
}
