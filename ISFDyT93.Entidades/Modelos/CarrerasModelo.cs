using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Core.Attributes;
using ISFDyT93.Entidades.Core.Attributes.Validaciones;
using ISFDyT93.Entidades.Modelos;

namespace ISFDyT93.Entidades.Modelos
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

        public string NumeroResolucion { get; set; }

        [Obligatorio]
        [SoloNumeros(minimo: 0, maximo: 3000)]
        public int CantidadHoras { get; set; }

        [Obligatorio]
        [SoloNumeros(minimo: 0, maximo: 99)]
        public int Duracion { get; set; }

        public int CarreraEstadoId { get; set; }

        [Ignorar]
        public bool PoseeMaterias { get; set; }

        public string CarrerasCodigoBloque { get; set; }

        [Obligatorio]
        [SoloNumeros(minimo: 0, maximo: 99)]
        public int CantidadCorrelativas { get; set; }

        // Propiedades institucionales adaptadas a los nombres de los controles
        public string SectorActividad { get; set; }
        public string FamiliaProfesional { get; set; }
        public string Variante { get; set; }
        public string Modalidad { get; set; }
        public string RegimenDefecto { get; set; }

        public int RegimenId { get; set; } // 1: Anual, 2: Cuatrimestral, 3: Otros
    }
}