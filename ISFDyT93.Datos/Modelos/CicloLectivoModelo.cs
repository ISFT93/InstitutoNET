using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;
using ISFDyT93.Datos.Core.Attributes.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Modelos
{

    public class CicloLectivoModelo : ModeloBase
    {
        [Clave(autoIncremental: false)]
        [Obligatorio]
        [SoloNumeros]
        public int AnioLectivo { get; set; }
        [Obligatorio]
        [SoloNumeros(minimo: 1)]
        public int CantidadSemana { get; set; }
        [Obligatorio]
        public DateTime? FechaInicio { get; set; }
        [Obligatorio]
        public DateTime? FechaInscripcionInicio { get; set; }
        [Obligatorio(condicion: "checkFechaInscripcionInicio")]
        [MayorQue("FechaInscripcionInicio")]
        public DateTime? FechaInscripcionFinal { get; set; }
        [Obligatorio("Modificando")]
        public DateTime? FechaMarzoInicio { get; set; }
        [Obligatorio(condicion: "checkFechaMarzoInicio")]
        [MayorQue("FechaMarzoInicio")]
        public DateTime? FechaMarzoFinal { get; set; }
        [Obligatorio("Modificando")]
        public DateTime? FechaJunioInicio { get; set; }
        [Obligatorio(condicion: "checkFechaJunioInicio")]
        [MayorQue("FechaJunioInicio")]
        public DateTime? FechaJunioFinal { get; set; }
        [Obligatorio("Modificando")]
        public DateTime? FechaDiciembreInicio { get; set; }
        [Obligatorio(condicion: "checkFechaDiciembreInicio")]
        [MayorQue("FechaDiciembreInicio")]
        public DateTime? FechaDiciembreFinal { get; set; }
        [Obligatorio("Modificando")]
        public DateTime? FechaEspecialInicio { get; set; }
        [Obligatorio(condicion: "checkFechaEspecialInicio")]
        [MayorQue("FechaEspecialInicio")]
        public DateTime? FechaEspecialFinal { get; set; }
        [Obligatorio(condicion: "checkFechaInicio")]
        [MayorQue("FechaInicio")]
        public DateTime? FechaCierre { get; set; }
        [Ignorar]
        public bool Activo { get; set; }

        public bool checkFechaInicio() => this.Modificando() && this.FechaInicio != null;
        public bool checkFechaInscripcionInicio() => this.FechaInscripcionInicio != null;
        public bool checkFechaMarzoInicio() => this.Modificando() && this.FechaMarzoInicio != null;
        public bool checkFechaJunioInicio() => this.Modificando() && this.FechaJunioInicio != null;
        public bool checkFechaDiciembreInicio() => this.Modificando() && this.FechaDiciembreInicio != null;
        public bool checkFechaEspecialInicio() => this.Modificando() && this.FechaEspecialInicio != null;
    }
}
