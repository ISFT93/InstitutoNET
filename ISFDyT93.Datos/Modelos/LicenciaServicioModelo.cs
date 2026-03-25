using ISFDyT93.Datos.Core;
using System;

namespace ISFDyT93.Datos.Modelos
{
    public class LicenciaServicioModelo : ModeloBase
    {
        //Servicios
        public int servicioId { get; set; }
        //Licencias
        public int licenciaId {get; set;}
        public DateTime fechaAlta {get {return Convert.ToDateTime(fechaAltaSTR); } set { this.fechaAltaSTR = value.ToString("yyyy-MM-dd"); } }
        public DateTime fechaBaja { get{ return Convert.ToDateTime(fechaBajaSTR); } set { this.fechaBajaSTR = value.ToString("yyyy-MM-dd"); } }
        public string fechaAltaSTR { get; set; }
        public string fechaBajaSTR { get; set; }
        public string certificado { get; set; }
        public string comentarios { get; set; }
        public int activo { get; set; }

        //Personal
        public int personalId { get; set; }
        //LicenciaTipo
        public int licenciaTipoId { get; set; }

    }
}
