using ISFDyT93.Datos.Core.Attributes;
using System;
using ISFDyT93.Datos.Core;

namespace ISFDyT93.Datos.Modelos
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
