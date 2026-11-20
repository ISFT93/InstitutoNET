using ISFDyT93.Entidades.Core;

namespace ISFDyT93.Entidades.Modelos
{
    public class TipoExamenModelo : ModeloBase
    {
        public int TipoExamenId { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionPlanilla { get; set; }
        public string TipoDato { get; set; }
        public bool Requerido { get; set; }
        public bool Activo { get; set; }
    }
}
