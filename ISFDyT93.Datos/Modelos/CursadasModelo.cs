using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Modelos
{
	public class CursadasModelo : ModeloBase
	{
		[Clave]
		public int CursadaId { get; set; }
		public int CursoMateriaId { get; set; }
		public int AnioLectivo { get; set; }
		public int Anio { get; set; }
		public int CantidadAlumnos { get; set; }
		public int CantidadAlumnosRecursantes { get; set; }
		public int CantidadAlumnosDesertores { get; set; }
		public int HoraCatedra { get; set; }
		public DateTime FechaAsistencia { get; set; }
		public int PorcentajeAsistencia { get; set; }

		[Ignorar]
		public int CursoId { get; set; }
		[Ignorar]
		public string Materia { get; set; }
		[Ignorar]
		public int ModulosMateria { get; set; }
	}
}
