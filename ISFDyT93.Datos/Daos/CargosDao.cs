using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISFDyT93.Datos.Daos
{
    public class CargosDao : DaoBase , ICargosDao
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
        public bool CargosActivos()
        {
            string query = "SELECT * FROM Cargos WHERE Activo = 1";
            Conexion conexion = new Conexion();
            DataTable registros = conexion.ObtenerRegistros(query);

            if (registros.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool CargosInactivos()
        {
            string query = "SELECT * FROM Cargos WHERE Activo = 0";
            Conexion conexion = new Conexion();
            DataTable registros = conexion.ObtenerRegistros(query);

            if (registros.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void DeshabilitarCargo(int CargoId)
        {
            string query = $"UPDATE Cargos SET Activo = 0 WHERE CargoId = {CargoId}";
            this.Conexion.EjecutarAccion(query);
        }
        public void HabilitarCargo(int CargoId)
        {
            string query = $"UPDATE Cargos SET Activo = 1 WHERE CargoId = {CargoId}";
            this.Conexion.EjecutarAccion(query);
        }
        public DataTable CargosHabilitados()
        {
            string query = "SELECT CargoId, Descripcion FROM Cargos WHERE Activo = 1";
            DataTable cargos = this.Conexion.ObtenerRegistros(query);
            return cargos;
        }
        public DataTable CargosDeshabilitados()
        {
            string query = "SELECT CargoId, Descripcion FROM Cargos WHERE Activo = 0";
            DataTable cargos = this.Conexion.ObtenerRegistros(query);
            return cargos;
        }
        public void CargarTipoAsignacion(ComboBox cmb)
        {
            string query = "SELECT TipoAsignacionId, Descripcion FROM TipoAsignacion";
            DataTable tipoAsignacion = this.Conexion.ObtenerRegistros(query);

            cmb.DataSource = tipoAsignacion;
            cmb.DisplayMember = "Descripcion";
            cmb.ValueMember = "TipoAsignacionId";
        }
        public void CargarTipoAplicacion(ComboBox cmb)
        {
            string query = "SELECT TipoAplicacionId, Descripcion FROM TipoAplicacion";
            DataTable tipoAplicacion = this.Conexion.ObtenerRegistros(query);

            cmb.DataSource = tipoAplicacion;
            cmb.DisplayMember = "Descripcion";
            cmb.ValueMember = "TipoAplicacionId";
        }
        public void AgregarCargo(string Nombre, int CargaHoraria, int TipoAplicacionId, int TipoAsignacionId)
        {
            try 
            {
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Descripcion", Nombre),
                    new SqlParameter("@CargaHoraria", CargaHoraria),
                    new SqlParameter("@TipoAplicacionId", TipoAplicacionId),
                    new SqlParameter("@TipoAsignacionId", TipoAsignacionId)
                };
                //usa el metodo de la clase conexion para ejecutar el store
                this.Conexion.EjecutarStore("InsertarCargo", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error en al intentar agregar los cargos: \n{ex}");
            }
        }
    }
}
