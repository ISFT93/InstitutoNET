using System.Collections.Generic;
using ISFDyT93.Datos.Core.Attributes;

namespace ISFDyT93.Datos.Core
{
    public class ModeloBase
    {
        public ModeloBase()
        {
            this.Errores = new List<Error>();
        }

        [Ignorar]
        public bool Nuevo { get; set; }
        public bool Creando() => this.Nuevo;
        public bool Modificando() => !this.Nuevo;

        [Ignorar]
        public IList<Error> Errores { get; set; }


    }
}