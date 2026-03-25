using ISFDyT93.Datos.Core;
using System.Data;
using System.Data.SqlClient;

namespace ISFDyT93.Datos.Core
{
    public class Conexion
    {
        //Primero se declara el objeto
        public SqlConnection Conector;

        //Luego se instancia en el constructor
        public Conexion()
        {
            //Servidor SQL Server - Base de Datos
            string strConexion = Settings.STRCONNECTION;
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
        
        /*
         * En la forma que estaba antes, si se ejecutaba un SP que tuviera un throw o un raiserror se cortaba la ejecución
         * del programa para mostrar el error.
         * El try/catch colocado es para poder traer excepciones generadas en la ejecución del SP y poder generar un errorMessage
         * en el form correspondiente.
        */

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