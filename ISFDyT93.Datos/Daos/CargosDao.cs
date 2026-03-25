using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Daos
{
    public class CargosDao : DaoBase
    {
        public (DataTable TipoAsignacion, DataTable TipoAplicacion, IList<CargosModelo> Cargos) ObtenerCargos()
        {

            string query = "SELECT * FROM Cargos";

            IList<CargosModelo> ltsModelos = this.MapToModel<CargosModelo>(this.Conexion.ObtenerRegistros(query));

            query = "SELECT TipoAsignacionId, Descripcion  FROM TipoAsignacion";
            DataTable tipoAsignacion = this.Conexion.ObtenerRegistros(query);

            query = "SELECT TipoAplicacionId, Descripcion FROM TipoAplicacion";
            DataTable tipoAplicacion = this.Conexion.ObtenerRegistros(query);

            return (tipoAsignacion, tipoAplicacion, ltsModelos);
        }

        public int ActualizarCargos(IList<CargosModelo> ltsCargos)
        {
            int registros = 0;

            foreach (CargosModelo cargosModelo in ltsCargos)
            {
                string query = CreateUpdateQuery(cargosModelo);
                registros += this.Conexion.EjecutarAccion(query);
            }
            return registros;
        }
    }
}
