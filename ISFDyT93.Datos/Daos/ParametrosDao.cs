using System;
using System.Data;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Datos.Enums;
using System.Data.SqlClient;
using ISFDyT93.Datos.Core;
using System.Collections.Generic;

namespace ISFDyT93.Datos.Daos
{
    public class ParametrosDao : DaoBase
    {
        public IList<ParametrosModelo> ObtenerParametros(bool actualizar = false)
        {
            if (Cache.Parametros == null || actualizar)
            {
                string query = "SELECT * FROM Parametros";

                Cache.Parametros = this.MapToModel<ParametrosModelo>(this.Conexion.ObtenerRegistros(query));
            }
            return Cache.Parametros;
        }
        public ParametrosModelo ObtenerParametro(string Nombre)
        {
            foreach(ParametrosModelo parametro in ObtenerParametros())
                if(parametro.Nombre == Nombre && parametro.Activo == true)
                    return parametro;
            return null;
        }
        public int ActualizarParametros(IList<ParametrosModelo> parametrosModelo)
        {
            int Nro = 0;
            foreach (var parametro in parametrosModelo)
            {
                string query = $"UPDATE Parametros SET Valor= '{parametro.Valor}', Activo= '{parametro.Activo}' WHERE ParametroId= {parametro.ParametroId}";
                Nro += Conexion.EjecutarAccion(query);
            }
            if (Nro > 0) _ = ObtenerParametros(true);
            return Nro;
        }
    }
}
