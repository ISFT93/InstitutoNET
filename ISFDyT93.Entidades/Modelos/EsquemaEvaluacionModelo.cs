using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Entidades.Modelos
{
    public class EsquemaEvaluacionModelo : ModeloBase
    {
        public int CodEsq { get; set; }

        public int indice { get; set; }

        public string esquema { get; set; }

        public string ex_descripc { get; set; }

        public string ex_descripcion_planilla { get; set; }

        public string ex_tipo_dat { get; set; }

        public bool ex_requeric { get; set; }

        public bool Activo { get; set; }
    }
}
