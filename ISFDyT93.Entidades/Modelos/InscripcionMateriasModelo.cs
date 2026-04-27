using ISFDyT93.Entidades.Core;

namespace ISFDyT93.Entidades.Modelos
{
    public class InscripcionMateriasModelo : ModeloBase
    {
        public int cursadaAlumnoId { get; set; }
        public string estado { get; set; }
        public string cursada { get; set; }
    }
}
