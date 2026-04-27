using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;

namespace ISFDyT93.Datos.Modelos
{
    public class AniosCarrerasModelo : ModeloBase
    {
        // Propiedades Propias de AniosCarreras

        [Clave]
        public int AnioCarreraId { get; set; }
        public int AnioCarrera { get; set; }
        public int CantidadMaterias { get; set; }
        public int CargaHorariaCompleta { get; set; }
        public int CarreraId { get; set; }

        // Propuedades Extras

        [Ignorar]
        public string NombreCarrera { get; set; }
        [Ignorar]
        public int CarreraEstadoId { get; set; }
    }
}
