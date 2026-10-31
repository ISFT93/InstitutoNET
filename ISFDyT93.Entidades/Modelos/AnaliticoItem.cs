using System;

namespace ISFDyT93.Entidades.Modelos
{
    public class AnaliticoItem
    {
        public int AnaliticoId { get; set; }
        public int CursadaAlumnoCarreraId { get; set; }
        public int AlumnoCarreraId { get; set; }
        public string CodigoBloqueMateria { get; set; }
        public int AnioCicloLectivo { get; set; }
        public string AnioCarrera { get; set; }
        public int Orden { get; set; }
        public string Materia { get; set; }
        public int? AnioCursada { get; set; }
        public decimal? Nota { get; set; }
        public string NotaLetras { get; set; }
        public string Condicion { get; set; }
        public int? Libro { get; set; }
        public int? Folio { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
