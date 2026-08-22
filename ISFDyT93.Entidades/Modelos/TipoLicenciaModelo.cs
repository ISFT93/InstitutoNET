using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Entidades.Modelos
{
    public class TipoLicenciaModelo
    {
        public string TipoLicenciaId { get; set; }
        public string Descripcion { get; set; }
        public int? Dias { get; set; }
        public bool FechaFinObligatoria { get; set; }
        public bool Activo { get; set; }
    }
}
