using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ISFDyT93.Datos.Modelos;
using System.Data.SqlClient;
using ISFDyT93.Datos.Core;

using System.Windows.Forms;


namespace ISFDyT93.Datos.Daos
{
    public class CiclosLectivosDao : DaoBase
    {
        public DataTable ObtenerCicloLectivo(bool actualizar = false) 
        {
            if (Cache.CicloLectivo == null || actualizar)
            {
                string query = "SELECT * FROM CicloLectivo ORDER BY AnioLectivo desc";
                Cache.CicloLectivo = this.Conexion.ObtenerRegistros(query);
            }
            return Cache.CicloLectivo;
        }
        
        public DataTable CargarInscripcionAlumnoSP(int CicloLectivo)
        {
            var parCicloLectivoId = new SqlParameter("AnioLectivoId", SqlDbType.Int);
            parCicloLectivoId.Value = CicloLectivo.ToString();
            var parametros = new SqlParameter[1] { parCicloLectivoId };
            return this.Conexion.EjecutarStore("SP_InscripcionAlumnos", parametros);

        }

        public int IngresoCursadaPrimeroSP(int CicloLectivo)
        {
            var parCicloLectivoId1 = new SqlParameter("AnioLectivoId", SqlDbType.Int);
            parCicloLectivoId1.Value = CicloLectivo.ToString();
            var parametros1 = new SqlParameter[1] { parCicloLectivoId1 };
            return this.Conexion.EjecutarStoreNumber("SP_IngresoCursadaPrimero", parametros1); 

        }
        
        public int AgregarCicloLectivo(CicloLectivoModelo Modelo)
        {
            string query = this.CreateInsertQuery<CicloLectivoModelo>(Modelo);

            int result = this.Conexion.EjecutarAccion(query);

            _ = ObtenerCicloLectivo(true);

            return result > 0 ? Modelo.AnioLectivo : 0; 
        }

        public int CargarCursadasSP(int anioLectivo)
        {
            var parAnioLectivoId = new SqlParameter("AnioLectivoId", SqlDbType.Int);
            parAnioLectivoId.Value = anioLectivo;

            var parametros = new SqlParameter[1] { parAnioLectivoId};
            var result = this.Conexion.EjecutarStoreNumber("SP_CargaCursadas", parametros);
            
            return result;
        }
        
        public int AgregarFechaFinalesMarzo(CicloLectivoModelo modelo)
        {
            string query = $"update CicloLectivo set FechaMarzoInicio = '{modelo.FechaMarzoInicio:yyyy-MM-dd}', FechaMarzoFinal = '{modelo.FechaMarzoFinal:yyyy-MM-dd}' where anioLectivo = {modelo.AnioLectivo}";
            return this.Conexion.EjecutarAccion(query);
        }
        public int AgregarFechaFinalesJulio(CicloLectivoModelo modelo)
        {
            string query = $"update CicloLectivo set FechaJunioInicio = '{modelo.FechaJunioInicio:yyyy-MM-dd}', FechaJunioFinal = '{modelo.FechaJunioFinal:yyyy-MM-dd}' where AnioLectivo = {modelo.AnioLectivo}";
            return this.Conexion.EjecutarAccion(query);
        }
        public int AgregarFechaFinalesDiciembre(CicloLectivoModelo modelo)
        {
            string query = $"update CicloLectivo set FechaDiciembreInicio = '{modelo.FechaDiciembreInicio:yyyy-MM-dd}', FechaDiciembreFinal = '{modelo.FechaDiciembreFinal:yyyy-MM-dd}' where anioLectivo = {modelo.AnioLectivo}";
            return this.Conexion.EjecutarAccion(query);
        }

        public int ObtenerAlumnoDePrimero(int CicloLectivo)
        {
            string query = "SELECT COUNT(*) from AlumnosCarreras where CicloLectivoId =" + CicloLectivo + " and Inicializado = 0";
           var  ret=  this.Conexion.EjecutarAccion(query);
            return ret;

        }       

        
    }
}
