using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;
using ISFDyT93.Datos.Core.Attributes.Validaciones;
using ISFDyT93.Datos.Enums;
using System;

namespace ISFDyT93.Datos.Modelos
{
    public class ServiciosModelo : ModeloBase
    {
        [Clave]
        public int ServicioId { get; set; }
        [Obligatorio]
        public int PersonalId { get; set; }
        [Obligatorio]
        public int SituacionRevistaId { get; set; }
        [Obligatorio]
        public int CargoId { get; set; }
        [Obligatorio(condicion: "EsDocente")]
        public int? CursoMateriaId { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? CantidadModulos { get; set; }
        public string Causa { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string Personal { get; set; }
        public bool Activo { get; set; }
        public int LibroActaId { get; set; }
        [Obligatorio(condicion: "EsJefeCatedra")]
        public int? CarreraId { get; set; }

        [Obligatorio]
        [SoloNumeros(minimo: 1, maximo: 20)]
        public int Modulo { get; set; }

        public bool EsDocente() => this.CargoId == (int)Cargo.Profesor || this.CargoId == (int)Cargo.Ayudante;
        public bool NoEsDocente() => this.CargoId != (int)Cargo.Profesor && this.CargoId != (int)Cargo.Ayudante;
        public bool EsJefeCatedra() => this.CargoId == (int)Cargo.JefeCatedra;
    }
}
