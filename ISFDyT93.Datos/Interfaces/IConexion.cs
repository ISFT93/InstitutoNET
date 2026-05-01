using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IConexion
    {
        DataTable ObtenerRegistros(string query);
        DataRow ObtenerRegistro(string query);
        int EjecutarAccion(string query);
        DataTable EjecutarStore(string nombreSP, SqlParameter[] parametros = null);
        int EjecutarStoreNumber(string nombre, SqlParameter[] parametros);
    }
}
