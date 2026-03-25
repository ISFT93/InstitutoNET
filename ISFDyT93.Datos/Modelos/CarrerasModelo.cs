using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;
using ISFDyT93.Datos.Core.Attributes.Validaciones;
using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Datos.Modelos
{
    public class CarrerasModelo : ModeloBase
    {
        [Clave]
        public int CarreraId { get; set; }
        [Obligatorio]
        [SoloLetrasEspacios]
        public string Nombre { get; set; }
        [Obligatorio]
        [SoloLetrasNumerosEspacios]
        public string Titulo { get; set; }
        [Obligatorio]
        [SoloLetrasEspacios]
        public string DescripcionCorta { get; set; }
        [SoloLetrasEspacios]
        public string JefeCatedra { get; set; }
        [Obligatorio]
        [SoloNumeros]
        [Longitud(longitud: 4)]
        public int AnioInicio { get; set; }

        [SoloNumeros]
        [Longitud(longitud: 4)]
        public int AnioFin { get; set; }
        public bool Activo { get; set; }
        
        public string PlanEstudio { get; set; }
        public string Resolucion { get; set; }
        public string Correlatividades { get; set; }
        public string ImagenDescriptiva { get; set; }
        
        [Expediente] // 5801-3.279.866/03
        public string NumeroExpediente { get; set; }
        
        [Obligatorio]
        [SoloNumeros(minimo: 0, maximo: 3000)]
        public int CantidadHoras { get; set; }

        [Obligatorio]
        [SoloNumeros(minimo: 0, maximo: 99)]
        public int Duracion { get; set; }
       
        public int CarreraEstadoId { get; set; }

        [Ignorar]
        public bool PoseeMaterias { get; set; }
    }
}
