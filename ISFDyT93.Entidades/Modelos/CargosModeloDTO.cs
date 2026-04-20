using ISFDyT93.Entidades.Core;

namespace ISFDyT93.Entidades.Modelos
{
    public class CargosModeloDTO : ModeloBase
    {
        public int CursoMateriaId { get; set; }
        public string NombreCompleto { get; set; }
        public string Cargo { get; set; }
        public bool Activo { get; set; }
    }
}
