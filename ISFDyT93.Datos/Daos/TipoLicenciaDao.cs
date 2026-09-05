using System;
using System.Collections.Generic;
using System.Data;
using ISFDyT93.Datos.Core;
using ISFDyT93.Entidades.Modelos;

namespace ISFDyT93.Datos.Daos
{
    public class TipoLicenciaDao : DaoBase
    {
        public IList<TipoLicenciaModelo> ObtenerTipoLicencias()
        {
            List<TipoLicenciaModelo> lista = new List<TipoLicenciaModelo>();
            string query = "SELECT TipoLicenciaId, Descripcion, Dias, FechaFinObligatoria, Activo FROM TipoLicencias";

            DataTable dt = this.Conexion.ObtenerRegistros(query);

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new TipoLicenciaModelo
                {
                    TipoLicenciaId = row["TipoLicenciaId"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Dias = row["Dias"] != DBNull.Value ? Convert.ToInt32(row["Dias"]) : (int?)null,
                    FechaFinObligatoria = Convert.ToBoolean(row["FechaFinObligatoria"]),
                    Activo = Convert.ToBoolean(row["Activo"])
                });
            }

            return lista;
        }

        public int GuardarTipoLicencia(TipoLicenciaModelo modelo)
        {
            string diasVal = modelo.Dias.HasValue ? modelo.Dias.Value.ToString() : "NULL";
            int fechaFinVal = modelo.FechaFinObligatoria ? 1 : 0;
            int activoVal = modelo.Activo ? 1 : 0;

            string query = $@"INSERT INTO TipoLicencias (TipoLicenciaId, Descripcion, Dias, FechaFinObligatoria, Activo) 
                            VALUES ('{modelo.TipoLicenciaId}', '{modelo.Descripcion}', {diasVal}, {fechaFinVal}, {activoVal})";

            return this.Conexion.EjecutarAccion(query);
        }

        public int ActualizarTipoLicencias(IList<TipoLicenciaModelo> lista)
        {
            int filasAfectadas = 0;

            foreach (var modelo in lista)
            {
                string diasVal = modelo.Dias.HasValue ? modelo.Dias.Value.ToString() : "NULL";
                int fechaFinVal = modelo.FechaFinObligatoria ? 1 : 0;
                int activoVal = modelo.Activo ? 1 : 0;

                string query = $@"UPDATE TipoLicencias 
                                SET Descripcion = '{modelo.Descripcion}', 
                                    Dias = {diasVal}, 
                                    FechaFinObligatoria = {fechaFinVal}, 
                                    Activo = {activoVal} 
                                WHERE TipoLicenciaId = '{modelo.TipoLicenciaId}'";

                filasAfectadas += this.Conexion.EjecutarAccion(query);
            }

            return filasAfectadas;
        }

        public bool ExisteEstadoLicencia(bool activo)
        {
            int val = activo ? 1 : 0;
            string query = $"SELECT * FROM TipoLicencias WHERE Activo = {val}";
            DataTable dt = this.Conexion.ObtenerRegistros(query);
            return dt != null && dt.Rows.Count > 0;
        }
    }
}