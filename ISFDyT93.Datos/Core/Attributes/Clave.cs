using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Core.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class Clave : System.Attribute
    {
        public bool AutoIncremental { get; set; }

        public Clave(bool autoIncremental = true)
        {
            this.AutoIncremental = autoIncremental;
        }
    }
}
