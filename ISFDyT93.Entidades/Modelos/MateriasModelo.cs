using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Core.Attributes;
using ISFDyT93.Entidades.Core.Attributes.Validaciones;

namespace ISFDyT93.Entidades.Modelos
{
    public class MateriasModelo : ModeloBase
    {
        //Propiedades Propias de Materias

        [Clave]
        public int MateriaId { get; set; }
        [Obligatorio]
        [SoloLetrasEspacios]
        public string Nombre { get; set; }
        public int AnioCarreraId { get; set; }
        public int EspacioId { get; set; }
        [Obligatorio]
        [SoloNumeros(minimo: 0, maximo: 3000)]
        public int CargaHoraria { get; set; }
        [Obligatorio]
        [SoloNumeros(minimo: 0, maximo: 99)]
        public int Modulos { get; set; }
        public bool Activo { get; set; }


        // Propiedades Extras
        [Ignorar]
        public int CarreraId { get; set; }

        [Ignorar]
        public int AnioCarrera { get; set; }
    }
}
