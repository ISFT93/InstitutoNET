using ISFDyT93.Datos.Core;

namespace ISFDyT93.Datos.Modelos
{
    public class CargosModeloDTO : ModeloBase
    {
        public int CursoMateriaId { get; set; }
        public string NombreCompleto { get; set; }
        public string Cargo { get; set; }
        public bool Activo { get; set; }
    }
}
