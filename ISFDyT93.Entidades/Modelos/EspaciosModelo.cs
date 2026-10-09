using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Core.Attributes;

namespace ISFDyT93.Entidades.Modelos
{
    public class EspaciosModelo : ModeloBase
    {
        [Clave]
        public int EspacioId { get; set; }

        public string Descripcion { get; set; }

        public string Acumulador { get; set; }

        public int SumaHoras { get; set; }

        public decimal CalculaPorcentaje { get; set; }

        public bool Activo { get; set; }
    }
}
