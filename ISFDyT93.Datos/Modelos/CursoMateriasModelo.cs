using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;
using ISFDyT93.Datos.Core.Attributes.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Modelos
{
    public class CursoMateriasModelo : ModeloBase
    {
        [Clave]
        public string CursoMateriaId { get; set; }
        public string MateriaId { get; set; }
        public string CursoId { get; set; }
        public string FechaAlta { get; set; }
        public string FechaBaja { get; set; }
        public string Activo { get; set; }
    }
}
