using ISFDyT93.Entidades.Core;

namespace ISFDyT93.Entidades.Modelos
{
    public class EsquemaEvaluacionModelo : ModeloBase
    {
        public int CodEsq { get; set; }
        public int Indice { get; set; }
        public string Esquema { get; set; }
        public int TipoExamenId { get; set; }
        public bool Activo { get; set; }
        public bool NuevoEsquema { get; set; }
    }
}
