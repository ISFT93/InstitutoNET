using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISFDyT93.Datos.Daos;
using System.Data;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class CicloLectivosLogica : LogicaBase
    {
        CiclosLectivosDao ciclolectivoDao;
        public CicloLectivosLogica()
        {
            this.ciclolectivoDao = new CiclosLectivosDao();
        }
        public int AgregarCicloLectivo(CicloLectivoModelo Modelo)
        {
            var anioLectivo = this.ciclolectivoDao.AgregarCicloLectivo(Modelo);

            if(anioLectivo > 0)
            {
                this.ciclolectivoDao.CargarCursadasSP(anioLectivo);
            }

            return anioLectivo;
        }

        public int CargarCursadas(int anioLectivoId)
        {
            return this.ciclolectivoDao.CargarCursadasSP(anioLectivoId);
        }

        public DataTable ConsultarUnCicloLectivo(int anio)
        {
            DataRow[] dr = this.ciclolectivoDao.ObtenerCicloLectivo().Select($"AnioLectivo= {anio}");
            return dr.CopyToDataTable();
        }

        public int AgregarFechaFinalesMarzo(CicloLectivoModelo modelo)
        {
            return this.ciclolectivoDao.AgregarFechaFinalesMarzo(modelo);
        }

        public int AgregarFechaFinalesJulio(CicloLectivoModelo modelo)
        {
            return this.ciclolectivoDao.AgregarFechaFinalesJulio(modelo);
        }
        public int AgregarFechaFinalesDiciembre(CicloLectivoModelo modelo)
        {
            return this.ciclolectivoDao.AgregarFechaFinalesDiciembre(modelo);
        }

       
        public int IngresoCursadaPrimeroSP(int CicloLectivo)
        {
            return this.ciclolectivoDao.IngresoCursadaPrimeroSP(CicloLectivo);
        }

        
        public DataTable ObtenerCargaGrillaCicloLectivo()
        {
            return this.ciclolectivoDao.ObtenerCicloLectivo();
        }

        public int ObtenerAlumnoDePrimero(int aniolectivo)
        {
            return this.ciclolectivoDao.ObtenerAlumnoDePrimero(aniolectivo);
        }
        
        public int ObtenerMaximoAnioCicloLectivo()
        {
            int maxAnioLectivo = 0;
            var dt = this.ciclolectivoDao.ObtenerCicloLectivo();
            if(dt.Rows.Count > 0)             
                maxAnioLectivo = (int)dt.Compute("Max(AnioLectivo)", "");          
           
            return maxAnioLectivo;
        }

        public bool ExisteUnCicloCreado()
        {
            int[] ciclosActivos = ObtenerAniosCiclosLectivosActivos();
            if (ciclosActivos.Length > 0)
                return (ObtenerMaximoAnioCicloLectivo() > ciclosActivos[0]);
            return false;
        }

        public DataTable CargarInscripcionAlumnoSP(int CicloLectivo)
        {
         return this.ciclolectivoDao.CargarInscripcionAlumnoSP(CicloLectivo);
            
        }
        
        public int[] ObtenerAniosCiclosLectivos()
        {            
            var ciclosLectivos = this.ciclolectivoDao.ObtenerCicloLectivo();
            return ciclosLectivos.Rows.Cast<DataRow>().Select(r => r.Field<int>("AnioLectivo")).ToArray();
        }

        public int[] ObtenerAniosCiclosLectivosActivos()
        {
            DataRow[] dr = this.ciclolectivoDao.ObtenerCicloLectivo().Select("Activo=True");
            return dr.Cast<DataRow>().Select(r => r.Field<int>("AnioLectivo")).ToArray();
        }

        public int ObtenerCicloLectivoActual()
        {
            DataRow[] dr = this.ciclolectivoDao.ObtenerCicloLectivo().Select("Activo=True");           
            if (dr.Length > 0) return Convert.ToInt32(dr.Cast<DataRow>().Select(r => r.Field<int>("AnioLectivo")).ToArray()[0]);
            return 0;
        }
    }
    
}
