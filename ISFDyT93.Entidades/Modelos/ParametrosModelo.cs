using ISFDyT93.Entidades.Core.Attributes;
using System;
using ISFDyT93.Entidades.Core;

namespace ISFDyT93.Entidades.Modelos
{
    public class ParametrosModelo : ModeloBase
    {
        public int ParametroId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public Int16 TipoId { get; set; }
        public bool Activo { get; set; }

    }
}
