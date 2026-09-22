using System;
using System.Data;
using System.Data.SqlClient;
using ISFDyT93.Datos.Core;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Datos.Interfaces;
using System.Windows.Forms;

namespace ISFDyT93.Datos.Daos
{
    public class EspacioDao : DaoBase, IEspacioFormacion
    {
        public DataTable ObtenerEspacios()
        {
            string query = "SELECT EspacioId, Descripcion, Acumulador, SumaHoras, CalculaPorcentaje, Activo FROM dbo.Espacios ORDER BY EspacioId";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerEspaciosActivos()
        {
            string query = "SELECT EspacioId, Descripcion, Acumulador, SumaHoras, CalculaPorcentaje, Activo FROM dbo.Espacios WHERE Activo = 1 ORDER BY Descripcion";
            return this.Conexion.ObtenerRegistros(query);
        }

        public int HabilitarEspacio(int espacioId)
        {
            using (var comando = new SqlCommand("UPDATE dbo.Espacios SET Activo = 1 WHERE EspacioId = @EspacioId", this.Conexion.Conector))
            {
                comando.Parameters.AddWithValue("@EspacioId", espacioId);
                try
                {
                    this.Conexion.Conector.Open();
                    return comando.ExecuteNonQuery();
                }
                finally
                {
                    this.Conexion.Conector.Close();
                }
            }
        }

        public int DeshabilitarEspacio(int espacioId)
        {
            using (var comando = new SqlCommand("UPDATE dbo.Espacios SET Activo = 0 WHERE EspacioId = @EspacioId", this.Conexion.Conector))
            {
                comando.Parameters.AddWithValue("@EspacioId", espacioId);
                try
                {
                    this.Conexion.Conector.Open();
                    return comando.ExecuteNonQuery();
                }
                finally
                {
                    this.Conexion.Conector.Close();
                }
            }
        }

        public int AgregarEspacio(EspacioModelo modelo)
        {
            string query = @"INSERT INTO dbo.Espacios (Descripcion, Acumulador, SumaHoras, CalculaPorcentaje, Activo) 
                             VALUES (@Descripcion, @Acumulador, @SumaHoras, @CalculaPorcentaje, 1)";

            using (var comando = new SqlCommand(query, this.Conexion.Conector))
            {
                comando.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                comando.Parameters.AddWithValue("@Acumulador", string.IsNullOrEmpty(modelo.Acumulador) ? (object)DBNull.Value : modelo.Acumulador);
                comando.Parameters.AddWithValue("@SumaHoras", modelo.SumaHoras);
                comando.Parameters.AddWithValue("@CalculaPorcentaje", modelo.CalculaPorcentaje);

                try
                {
                    this.Conexion.Conector.Open();
                    return comando.ExecuteNonQuery();
                }
                finally
                {
                    this.Conexion.Conector.Close();
                }
            }
        }

        public int ModificarEspacio(EspacioModelo modelo)
        {
            string query = @"UPDATE dbo.Espacios 
                             SET Descripcion = @Descripcion, 
                                 Acumulador = @Acumulador, 
                                 SumaHoras = @SumaHoras, 
                                 CalculaPorcentaje = @CalculaPorcentaje 
                             WHERE EspacioId = @EspacioId";

            using (var comando = new SqlCommand(query, this.Conexion.Conector))
            {
                comando.Parameters.AddWithValue("@EspacioId", modelo.EspacioId);
                comando.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                comando.Parameters.AddWithValue("@Acumulador", string.IsNullOrEmpty(modelo.Acumulador) ? (object)DBNull.Value : modelo.Acumulador);
                comando.Parameters.AddWithValue("@SumaHoras", modelo.SumaHoras);
                comando.Parameters.AddWithValue("@CalculaPorcentaje", modelo.CalculaPorcentaje);

                try
                {
                    this.Conexion.Conector.Open();
                    return comando.ExecuteNonQuery();
                }
                finally
                {
                    this.Conexion.Conector.Close();
                }
            }
        }
    }

}
