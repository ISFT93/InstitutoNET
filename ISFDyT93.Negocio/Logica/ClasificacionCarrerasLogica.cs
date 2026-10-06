using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Daos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ISFDyT93.Negocio.Logica
{
    public class ClasificacionCarrerasLogica
    {
        private ClasificacionCarrerasDao dao = new ClasificacionCarrerasDao();

        public DataTable ObtenerClasificacion()
        {
            return dao.ObtenerClasificacion();
        }

        public DataTable ObtenerFamilias()
        {
            return dao.ObtenerFamilias();
        }

        public bool PerteneceVariableAFamilia(string familia, string variable)
        {
            try
            {
                ClasificacionCarrerasDao dao = new ClasificacionCarrerasDao();
                return dao.VerificarRelacionFamiliaVariable(familia, variable);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la relación entre familia y variable: " + ex.Message);
            }
        }

        public DataTable ObtenerVariables()
        {
            return dao.ObtenerVariables();
        }

        // ==========================================
        // NUEVO MÉTODO DE INSERCIÓN INDIVIDUAL
        // ==========================================
        public void GuardarRegistroClasificacion(string descripcion, string descripcionCorta, object horas, bool activo)
        {
            try
            {
                Conexion conexion = new Conexion();

                string query = @"
                    INSERT INTO clasificacion_carreras (descripcion, descripcionCorta, horas, activo)
                    VALUES (@descripcion, @descripcionCorta, @horas, @activo);";

                if (conexion.Conector.State != ConnectionState.Open)
                    conexion.Conector.Open();

                using (SqlCommand cmd = new SqlCommand(query, conexion.Conector))
                {
                    cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(descripcion) ? (object)DBNull.Value : descripcion);
                    cmd.Parameters.AddWithValue("@descripcionCorta", string.IsNullOrEmpty(descripcionCorta) ? (object)DBNull.Value : descripcionCorta);
                    cmd.Parameters.AddWithValue("@horas", horas ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", activo);

                    cmd.ExecuteNonQuery();
                }

                if (conexion.Conector.State == ConnectionState.Open)
                    conexion.Conector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el registro en la base de datos: " + ex.Message);
            }
        }

        public void AgregarRegistroPorVariable(int idVariable, bool activo)
        {
            try
            {
                Conexion conexion = new Conexion();

                string query = @"
            INSERT INTO clasificacion_carreras (descripcion, descripcionCorta, horas, activo)
            SELECT 
                f.descripción AS Descripcion,
                v.descripción AS DescripcionCorta,
                CASE 
                    WHEN v.descripción = 'Anual' THEN 32
                    WHEN v.descripción = 'Cuatrimestral' THEN 16
                    ELSE 0
                END AS Horas,
                @activo AS Activo
            FROM [variable] v
            INNER JOIN familia f ON v.Grupo_fami = f.Grupo_fami
            WHERE v.id_variable = @idVariable;";

                if (conexion.Conector.State != ConnectionState.Open)
                    conexion.Conector.Open();

                using (SqlCommand cmd = new SqlCommand(query, conexion.Conector))
                {
                    cmd.Parameters.AddWithValue("@idVariable", idVariable);
                    cmd.Parameters.AddWithValue("@activo", activo);
                    cmd.ExecuteNonQuery();
                }

                if (conexion.Conector.State == ConnectionState.Open)
                    conexion.Conector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar registro: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GuardarClasificacionCompleta(DataTable dtGrilla)
        {
            dao.GuardarClasificacionCompleta(dtGrilla);
        }
    }
}