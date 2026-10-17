using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ISFDyT93.Datos.Core;

namespace ISFDyT93.Datos.Daos
{
    public class ClasificacionCarrerasDao
    {
        // 1. Lee de la tabla de configuración persistente de la grilla
        public DataTable ObtenerClasificacion()
        {
            // Solo lee de la tabla de guardado/trabajo, nunca trae la tabla maestra entera de golpe
            string query = "SELECT descripcion AS Descripcion, descripcionCorta AS DescripcionCorta, horas AS Horas, activo AS Activo FROM clasificacion_carreras ORDER BY id;";
            Conexion conexion = new Conexion();
            return conexion.ObtenerRegistros(query);

        }

        public int ObtenerHorasPorVariable(string descripcionCorta)
        {
            int horas = 0;
            try
            {
                Conexion conexion = new Conexion();
                string query = @"
            SELECT TOP 1 
                CASE 
                    WHEN v.descripción = 'Anual' THEN 32
                    WHEN v.descripción = 'Cuatrimestral' THEN 16
                    ELSE 0
                END AS Horas
            FROM [variable] v
            INNER JOIN familia f ON v.Grupo_fami = f.Grupo_fami
            WHERE v.descripción = @descCorta;";

                if (conexion.Conector.State != ConnectionState.Open)
                    conexion.Conector.Open();

                using (SqlCommand cmd = new SqlCommand(query, conexion.Conector))
                {
                    cmd.Parameters.AddWithValue("@descCorta", descripcionCorta);
                    var resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        horas = Convert.ToInt32(resultado);
                    }
                }

                if (conexion.Conector.State == ConnectionState.Open)
                    conexion.Conector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular horas: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return horas;
        }

        // 2. Consulta real a la tabla familia
        public DataTable ObtenerFamilias()
        {
            string query = "SELECT Grupo_fami AS id, descripción AS descripcion FROM familia;";
            Conexion conexion = new Conexion();
            return conexion.ObtenerRegistros(query);
        }

        // 3. Consulta real a la tabla variable (sin inventar columnas que no están)
        public DataTable ObtenerVariables()
        {
            string query = "SELECT id_variable AS id, descripción AS descripcion FROM [variable];";
            Conexion conexion = new Conexion();
            return conexion.ObtenerRegistros(query);
        }

        // 4. Guardado masivo sincronizado
        public void GuardarClasificacionCompleta(DataTable dtGrilla)
        {
            Conexion conexion = new Conexion();
            SqlTransaction tran = null;
            try
            {
                if (conexion.Conector.State != ConnectionState.Open)
                    conexion.Conector.Open();

                tran = conexion.Conector.BeginTransaction();

                using (SqlCommand cmdLimpiar = new SqlCommand("DELETE FROM clasificacion_carreras;", conexion.Conector, tran))
                {
                    cmdLimpiar.ExecuteNonQuery();
                }

                if (dtGrilla != null)
                {
                    foreach (DataRow row in dtGrilla.Rows)
                    {
                        if (row.RowState == DataRowState.Deleted) continue;

                        string descripcion = row["Descripcion"]?.ToString() ?? "";
                        string descripcionCorta = row["DescripcionCorta"]?.ToString() ?? "";
                        int horas = row["Horas"] != DBNull.Value && !string.IsNullOrEmpty(row["Horas"].ToString()) ? Convert.ToInt32(row["Horas"]) : 0;
                        bool activo = Convert.ToBoolean(row["Activo"]);

                        const string queryInsert = "INSERT INTO clasificacion_carreras (descripcion, descripcionCorta, horas, activo) VALUES (@desc, @descCorta, @horas, @activo)";

                        using (SqlCommand cmd = new SqlCommand(queryInsert, conexion.Conector, tran))
                        {
                            cmd.Parameters.AddWithValue("@desc", string.IsNullOrEmpty(descripcion) ? (object)DBNull.Value : descripcion);
                            cmd.Parameters.AddWithValue("@descCorta", string.IsNullOrEmpty(descripcionCorta) ? (object)DBNull.Value : descripcionCorta);
                            cmd.Parameters.AddWithValue("@horas", horas);
                            cmd.Parameters.AddWithValue("@activo", activo);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                throw new Exception("Error al guardar en base de datos: " + ex.Message);
            }
            finally
            {
                if (conexion.Conector.State == ConnectionState.Open)
                    conexion.Conector.Close();
            }
        }

        public bool VerificarRelacionFamiliaVariable(string familia, string variable)
        {
            bool pertenece = false;
            try
            {
                Conexion conexion = new Conexion();
                string query = @"
            SELECT COUNT(1) 
            FROM [variable] v
            INNER JOIN familia f ON v.Grupo_fami = f.Grupo_fami
            WHERE f.descripción = @familia AND v.descripción = @variable;";

                if (conexion.Conector.State != ConnectionState.Open)
                    conexion.Conector.Open();

                using (SqlCommand cmd = new SqlCommand(query, conexion.Conector))
                {
                    cmd.Parameters.AddWithValue("@familia", familia);
                    cmd.Parameters.AddWithValue("@variable", variable);

                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                    pertenece = (resultado > 0);
                }

                if (conexion.Conector.State == ConnectionState.Open)
                    conexion.Conector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en base de datos al validar relación: " + ex.Message);
            }
            return pertenece;
        }

        public void AgregarRegistro(string descripcion, string descripcionCorta, bool activo)
        {
            int horasCalculadas = 0;
            if (!string.IsNullOrEmpty(descripcionCorta))
            {
                if (descripcionCorta.Equals("Anual", StringComparison.OrdinalIgnoreCase))
                {
                    horasCalculadas = 32;
                }
                else if (descripcionCorta.Equals("Cuatrimestral", StringComparison.OrdinalIgnoreCase))
                {
                    horasCalculadas = 16;
                }
                else
                {
                    horasCalculadas = 0;
                }
            }

            try
            {
                Conexion conexion = new Conexion();
                string query = "INSERT INTO clasificacion_carreras (descripcion, descripcionCorta, horas, activo) VALUES (@desc, @descCorta, @horas, @activo)";

                if (conexion.Conector.State != ConnectionState.Open)
                    conexion.Conector.Open();

                using (SqlCommand cmd = new SqlCommand(query, conexion.Conector))
                {
                    cmd.Parameters.AddWithValue("@desc", string.IsNullOrEmpty(descripcion) ? (object)DBNull.Value : descripcion);
                    cmd.Parameters.AddWithValue("@descCorta", string.IsNullOrEmpty(descripcionCorta) ? (object)DBNull.Value : descripcionCorta);
                    cmd.Parameters.AddWithValue("@horas", horasCalculadas);
                    cmd.Parameters.AddWithValue("@activo", activo);
                    cmd.ExecuteNonQuery();
                }

                if (conexion.Conector.State == ConnectionState.Open)
                    conexion.Conector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- MÉTODOS NUEVOS PARA VALIDAR DUPLICADOS AL ESCRIBIR A MANO ---

        public bool ExisteVariable(string nombreVariable)
        {
            bool existe = false;
            try
            {
                Conexion conexion = new Conexion();
                string query = "SELECT COUNT(1) FROM [variable] WHERE descripción = @variable;";

                if (conexion.Conector.State != ConnectionState.Open)
                    conexion.Conector.Open();

                using (SqlCommand cmd = new SqlCommand(query, conexion.Conector))
                {
                    cmd.Parameters.AddWithValue("@variable", nombreVariable);
                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                    existe = (resultado > 0);
                }

                if (conexion.Conector.State == ConnectionState.Open)
                    conexion.Conector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar existencia de variable: " + ex.Message);
            }
            return existe;
        }

        //public bool ExisteFamilia(string nombreFamilia)
        //{
        //    bool existe = false;
        //    try
        //    {
        //        Conexion conexion = new Conexion();
        //        string query = "SELECT COUNT(1) FROM familia WHERE descripción = @familia;";

        //        if (conexion.Conector.State != ConnectionState.Open)
        //            conexion.Conector.Open();

        //        using (SqlCommand cmd = new SqlCommand(query, conexion.Conector))
        //        {
        //            cmd.Parameters.AddWithValue("@familia", nombreFamilia);
        //            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
        //            existe = (resultado > 0);
        //        }

        //        if (conexion.Conector.State == ConnectionState.Open)
        //            conexion.Conector.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al verificar existencia de familia: " + ex.Message);
        //    }
        //    return existe;
        //}
    }
}