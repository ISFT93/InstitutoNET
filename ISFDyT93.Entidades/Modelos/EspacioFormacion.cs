using ISFDyT93.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Entidades.Modelos
{
    public class EspacioModelo : ModeloBase
    {
        public int EspacioId { get; set; }
        public string Descripcion { get; set; }
        public string Acumulador { get; set; }
        public bool SumaHoras { get; set; }
        public bool CalculaPorcentaje { get; set; }
        public bool Activo { get; set; }
    }
}
