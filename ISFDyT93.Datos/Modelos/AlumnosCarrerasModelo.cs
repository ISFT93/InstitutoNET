using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;
using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Core.Attributes;
using System;

namespace ISFDyT93.Datos.Modelos
{
    public class AlumnosCarrerasModelo : ModeloBase
    {
        [Clave]
        public int AlumnoCarreraId { get; set; }
        public int CarreraId { get; set; }
        public int AlumnoId { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }
    }
}
