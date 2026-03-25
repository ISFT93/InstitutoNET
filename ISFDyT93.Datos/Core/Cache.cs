using System.Data;
using ISFDyT93.Datos.Modelos;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ISFDyT93.Datos
{
    public sealed class Cache
    {
        internal static DataTable CicloLectivo { get; set; }
        internal static IList<ParametrosModelo> Parametros { get; set; }
        public static Form FormPrincipal {get; set;}
        public static Form FormNotificacion { get; set; }
    }
}
