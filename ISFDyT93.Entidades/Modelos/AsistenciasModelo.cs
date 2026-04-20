using System;
using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Core.Attributes;

namespace ISFDyT93.Entidades.Modelos
{
    public class AsistenciasModelo : ModeloBase
    {
        public int CursadaAlumnoCarreraId { get; set; }
        public int AlumnoCarreraId { get; set; }
        public int AnioCicloLectivo { get; set; }
        public int MateriaId { get; set; }
        public int CursoMateriaId { get; set; }
        public int AlumnoId { get; set; }
        public int HorasCursadas { get; set; }
        public double PorcentajeAsistencia { get; set; }
        public int Modulos { get; set; }
        public int PersonalId { get; set; }
        public char Asistencia { get; set; }
        public int CursadaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int CargaHoraria { get; set; }
        public DateTime UltimoPresentismo { get; set; }
        public DateTime FechaAsistencia { set { this.FechaAsistenciaStr = value.ToString("yyyy-MM-dd"); } }
        public string FechaAsistenciaStr { get; set; }
        public int HoraCatedra { get; set; }
        public float PorcentajeAsistenciaC { get; set; }
    }
}
