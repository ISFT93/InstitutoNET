using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ISFDyT93.Datos.Core
{
    public class Conexion:IConexion
    {
        //Primero se declara el objeto
        public SqlConnection Conector;

        //Luego se instancia en el constructor
        public Conexion()
        {
            // Leer la cadena de conexión desde App.config (proyecto ISFDyT93.Vista)
            var connSetting = ConfigurationManager.ConnectionStrings["InstiDB"];
            if (connSetting == null || string.IsNullOrWhiteSpace(connSetting.ConnectionString))
            {
                throw new System.InvalidOperationException("No se encontró la cadena de conexión 'InstiDB' en App.config.");
            }

            string strConexion = connSetting.ConnectionString;
            this.Conector = new SqlConnection(strConexion);
        }

        //Metodo para obtener muchos registros
        public DataTable ObtenerRegistros(string query)
        {
            var Comando = new SqlCommand(query, this.Conector);

            DataTable result = new DataTable();

            this.Conector.Open();

            result.Load(Comando.ExecuteReader());

            this.Conector.Close();

            return result;
        }

        //Metodo para obtener un solo registro
        public DataRow ObtenerRegistro(string query)
        {
            var Tabla = this.ObtenerRegistros(query);

            DataRow result = null;

            //Solo devuelvela primer fila
            if (Tabla.Rows.Count > 0)
            {
                result = Tabla.Rows[0];
            }

            return result;
        }

        //Metodo para ejecutar altas, bajas y modificaciones
        public int EjecutarAccion(string query)
        {
            var Comando = new SqlCommand(query, this.Conector);

            this.Conector.Open();

             int result = Comando.ExecuteNonQuery();

            this.Conector.Close();

            return result;

           
        }

        public DataTable EjecutarStore(string nombreSP, SqlParameter[] parametros = null)
        {
            var Comando = new SqlCommand(nombreSP, this.Conector);
            Comando.CommandType = CommandType.StoredProcedure;

            if (parametros != null)
            {
                Comando.Parameters.AddRange(parametros);
            }

            DataTable result = new DataTable();

            Conector.Open();

            result.Load(Comando.ExecuteReader());

            Conector.Close();

            return result;          
        }
        
         public int EjecutarStoreNumber(string nombre, SqlParameter[] parametros)
        {           
            var Comando = new SqlCommand(nombre, this.Conector);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddRange(parametros);
            Conector.Open();
            int result = 0;
            try
            {
                result = Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Conector.Close();
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    result = 0;
                    Comando.Parameters.Clear();
                    Conector.Close();
                }
            }
            return result;
        }
    }
}