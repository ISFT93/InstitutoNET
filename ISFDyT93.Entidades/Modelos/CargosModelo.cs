using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Entidades.Modelos
{
    public class CargosModelo : ModeloBase
    {
        [Clave]
        public int CargoId { get; set; }
        public string Descripcion { get; set; }
        public int TipoAsignacionId { get; set; }
        public int TipoAplicacionId { get; set; }
        public bool Activo { get; set; }
    }
}
