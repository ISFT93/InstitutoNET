using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Core.Attributes;
using System;

namespace ISFDyT93.Entidades.Modelos
{
    public class LibroActasModelo : ModeloBase
    {
        [Clave]
        public int LibroActaId { get; set; }
        public int LibroNumero { get; set; }
        public int FolioNumero { get; set; }
        public int FolioMaximo { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }
        public int TipoLibroId { get; set; }
    }
}
