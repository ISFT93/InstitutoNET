using ISFDyT93.Entidades.Core;

namespace ISFDyT93.Entidades.Modelos
{
    public class CorrelatividadModel : ModeloBase
    {
        public int CorrelatividadId { get; set; }
        public int MateriaCorrelativaId { get; set; }
        public int MateriaId { get; set; }

    }
}
