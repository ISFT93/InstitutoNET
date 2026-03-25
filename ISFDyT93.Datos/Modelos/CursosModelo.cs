using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Modelos
{
    public class CursosModelo : ModeloBase
    {
        [Clave]
		public int CursoId { get; set; }
		public string NombreCurso { get; set; }
		public int CicloLectivoId { get; set; }
		public int AnioCarreraId { get; set; }
		public bool Activo { get; set; }
		public bool AdmiteCurso { get; set; }

        [Ignorar]
		public int AnioCarrera { get; set; }
	}
}
