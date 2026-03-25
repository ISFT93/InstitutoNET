using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;
using ISFDyT93.Datos.Core.Attributes.Validaciones;
using System;

namespace ISFDyT93.Datos.Modelos
{
    public class PersonalModelo : ModeloBase
    {
        [Clave]
        public int PersonalId { get; set; }
        [Obligatorio("El número de documento es obligatorio")]
        [SoloNumeros]
        [Unico(condicion: "EsNuevo", mensaje: "Ya existe personal con ese número de documento")]
        public string NumeroDocumento { get; set; }
        [Obligatorio("El nombre es obligatorio")]
        [SoloLetrasEspacios]
        public string Nombre { get; set; }
        [Obligatorio("El apellido es obligatorio")]
        [SoloLetrasEspacios]
        public string Apellido { get; set; }
        [Obligatorio("La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }
        [Obligatorio]
        public char Sexo { get; set; }
        [SoloLetrasNumerosEspacios]
        public string Direccion { get; set; }
        [SoloNumeros]
        public string Piso { get; set; }
        [SoloLetras]
        public string Departamento { get; set; }
        [SoloLetrasEspacios]
        public string Localidad { get; set; }
        [SoloNumeros]
        public string Celular { get; set; }
        [AlmenosUno("Celular:Email")]
        [SoloNumeros]
        public string Telefono { get; set; }
        [SoloLetrasEspacios]
        public string Nacionalidad { get; set; }
        [Email]
        public string Email { get; set; }
        public string EstadoCivil { get; set; }
        public string Foto { get; set; }
        [Obligatorio]
        [SoloLetrasEspacios]
        public string Titulo { get; set; }
        [Obligatorio]
        public string TramoPedagogico { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int PersonalEstadoId { get; set; }

        //Propiedades extras

        public bool EsNuevo() => PersonalId == 0;
    }
}
