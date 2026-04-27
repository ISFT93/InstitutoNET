using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Modelos;
using System;
using System.Data;

namespace ISFDyT93.Datos.Daos
{
    public class CarrerasDao : DaoBase
    {
        public DataTable ObtenerCarreras(bool Activo = true)
        {
            //Query para seleccionar todos resgistros de Carreras
            string query = "SELECT C.CarreraId, C.Nombre, C.DescripcionCorta AS [Descripción], C.NumeroExpediente AS [Numero de Expediente], C.AnioInicio as [Año de Inicio], IIF(C.AnioFin > 0, Convert(nvarchar(4), C.AnioFin) , '') as [Año de Fin], C.CantidadHoras as [Carga Horaria Completa], C.CarreraEstadoId, CE.Descripcion AS Estado FROM Carreras C" +
              " INNER JOIN CarreraEstados CE on C.CarreraEstadoId = CE.CarreraEstadoId WHERE C.CarreraEstadoId = 1";
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable CarrerasInactivas(bool Activo = false)
        {
            //Query para seleccionar todos resgistros de Carreras
            string query = "SELECT C.CarreraId, C.Nombre, C.DescripcionCorta AS [Descripción], C.NumeroExpediente AS [Numero de Expediente], C.CarreraEstadoId , CE.Descripcion AS Estado FROM Carreras C INNER JOIN CarreraEstados CE on C.CarreraEstadoId = CE.CarreraEstadoId AND C.CarreraEstadoId = " + (Activo ? "1" : "2");
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable CarrerasBorrador(bool Activo = false)
        {
            //Query para seleccionar todos resgistros de Carreras
            string query = "SELECT C.CarreraId, C.Nombre, C.DescripcionCorta AS [Descripción], C.NumeroExpediente AS [Numero de Expediente], C.CarreraEstadoId , C.CantidadHoras as [Carga Horaria Completa], CE.Descripcion AS Estado FROM Carreras C INNER JOIN CarreraEstados CE on C.CarreraEstadoId = CE.CarreraEstadoId AND C.CarreraEstadoId = " + (Activo ? "1" : "3");
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable CarrerasActivas(bool Activo = true)
        {
            //Query para seleccionar todos resgistros de Carrera
            string query = "SELECT C.CarreraId, C.Nombre, C.DescripcionCorta AS [Descripción], C.NumeroExpediente AS [Numero de Expediente], C.CarreraEstadoId , CE.Descripcion AS Estado FROM Carreras C INNER JOIN CarreraEstados CE on C.CarreraEstadoId = CE.CarreraEstadoId AND C.CarreraEstadoId = " + (Activo ? "1" : "1");// FROM Carreras WHERE CarreraEstadoId = " + (Activo ? "1" : "1");
     
            return this.Conexion.ObtenerRegistros(query);
        }
        public CarrerasModelo ObtenerCarrera(int id)
        { /* Si activo es true escribe 1 si no 0 */
            string query = "SELECT * FROM Carreras WHERE CarreraId = " + id;

            return this.MapToModel<CarrerasModelo>(this.Conexion.ObtenerRegistro(query));
        }

        public DataRow CarreraExiste(string Nombre)
        {
            string query = "SELECT TOP 1 CarreraId FROM Carreras WHERE Nombre = '" + Nombre+"'";
            return this.Conexion.ObtenerRegistro(query);
        }

        public int TraeIdDeCarrera(string nombre)
        {
            string query = "SELECT CarreraId FROM Carreras WHERE Nombre = '" + nombre + "'";
            var carrera = this.Conexion.ObtenerRegistro(query);

                if (carrera != null)
                {
                    return Convert.ToInt32(carrera["CarreraId"]);
                }

                return 0;
          
        }

        public int ObtenerUltimoCarreraId()
        { /* Si activo es true escribe 1 si no 0 */
            string query = "SELECT TOP 1 CarreraId FROM Carreras ORDER BY CarreraId DESC";

            var row = this.Conexion.ObtenerRegistro(query);

            if (row != null)
            {
                return Convert.ToInt32(row["CarreraId"]);
            }
            return 0;
        }

        //METODO para agregar carreras a la base de datos
        public int AgregarCarreras(CarrerasModelo modelo)
        {
            string query = this.CreateInsertQuery<CarrerasModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }

        //METODO para modificar carreras de la base 
        public int ModificarCarrera(CarrerasModelo modelo)
        {
            string query = this.CreateUpdateQuery<CarrerasModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }

        public int ModificarCarreraEstado(CarrerasModelo modelo)
        {
            string query = "UPDATE Carreras SET CarreraEstadoId=" + modelo.CarreraEstadoId + " WHERE CarreraId= " + modelo.CarreraId;
            return this.Conexion.EjecutarAccion(query);
        }

        public void EliminarCarrera(int CarreraId)
        {
            // string query = "UPDATE Carreras SET Activo = " + 0 + "WHERE CarreraId = " + CarreraId + "";
            string query = "DELETE Carreras WHERE CarreraId =" + CarreraId;
            this.Conexion.EjecutarAccion(query);
        }

        public void AltaCarreraActivo(int CarreraId)
        {
            string query = "UPDATE Carreras SET CarreraEstadoId = 1 WHERE CarreraId = " + CarreraId + "";
            this.Conexion.EjecutarAccion(query);
        }

        public void ActualizarCargaHoraria(int CarreraId, int cantidadHoras)
        {
            string query = "UPDATE Carreras SET CantidadHoras = " + cantidadHoras + " WHERE CarreraId = " + CarreraId + "";
            this.Conexion.EjecutarAccion(query);
        }
    }
}
