using ISFDyT93.Datos.Core;

namespace ISFDyT93.Datos.Modelos
{
    public class CorrelatividadModel : ModeloBase
    {
        public int CorrelatividadId { get; set; }
        public int MateriaCorrelativaId { get; set; }
        public int MateriaId { get; set; }

    }
}
