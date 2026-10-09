using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ISFDyT93.Datos.Daos
{
    public class EspaciosDao : DaoBase, IEspaciosDao
    {
        //public (DataTable TipoAsignacion, DataTable TipoAplicacion, IList<EspaciosModelo> Espacios) ObtenerEspacios()
        //{
        //    string query = "SELECT * FROM Espacios";
        //    IList<EspaciosModelo> ltsModelos = this.MapToModel<EspaciosModelo>(
        //        this.Conexion.ObtenerRegistros(query)
        //    );
        //    query = "SELECT TipoAsignacionId, Descripcion  FROM TipoAsignacion";
        //    DataTable tipoAsignacion = this.Conexion.ObtenerRegistros(query);
        //    query = "SELECT TipoAplicacionId, Descripcion FROM TipoAplicacion";
        //    DataTable tipoAplicacion = this.Conexion.ObtenerRegistros(query);
        //    return (tipoAsignacion, tipoAplicacion, ltsModelos);
        //}
        public IList<EspaciosModelo> ObtenerEspacios()
        {
            string query = "SELECT * FROM Espacios";

            return this.MapToModel<EspaciosModelo>(
                this.Conexion.ObtenerRegistros(query)
            );
        }
        public int ActualizarEspacios(IList<EspaciosModelo> ltsEspacios)
        {
            int registros = 0;

            foreach (EspaciosModelo espacioModelo in ltsEspacios)
            {
                string query = CreateUpdateQuery(espacioModelo);

                registros += this.Conexion.EjecutarAccion(query);
            }

            return registros;
        }

        public bool EspaciosActivos()
        {
            string query = "SELECT * FROM Espacios WHERE Activo = 1";

            DataTable registros = this.Conexion.ObtenerRegistros(query);

            return registros.Rows.Count > 0;
        }

        public bool EspaciosInactivos()
        {
            string query = "SELECT * FROM Espacios WHERE Activo = 0";

            DataTable registros = this.Conexion.ObtenerRegistros(query);

            return registros.Rows.Count > 0;
        }

        public void DeshabilitarEspacio(int EspacioId)
        {
            string query =
                $"UPDATE Espacios SET Activo = 0 WHERE EspacioId = {EspacioId}";

            this.Conexion.EjecutarAccion(query);
        }

        public void HabilitarEspacio(int EspacioId)
        {
            string query =
                $"UPDATE Espacios SET Activo = 1 WHERE EspacioId = {EspacioId}";

            this.Conexion.EjecutarAccion(query);
        }

        public DataTable EspaciosHabilitados()
        {
            string query =
                "SELECT EspacioId, Descripcion FROM Espacios WHERE Activo = 1";

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable EspaciosDeshabilitados()
        {
            string query =
                "SELECT EspacioId, Descripcion FROM Espacios WHERE Activo = 0";

            return this.Conexion.ObtenerRegistros(query);
        }

        public void AgregarEspacio(string Descripcion)
        {
            try
            {
                string query =
                    $"INSERT INTO Espacios (Descripcion, Activo) " +
                    $"VALUES ('{Descripcion.Replace("'", "''")}', 1)";
                this.Conexion.EjecutarAccion(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al intentar agregar el espacio:\n{ex}"
                );
            }
        }
    }
}
