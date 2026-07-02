using ISFDyT93.Datos.Daos;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISFDyT93.Negocio.Interfaces;
using System.Windows.Forms;

namespace ISFDyT93.Negocio.Logica
{
    public class CargosLogica : ICargosLogica
    {
        CargosDao cargosDao = new CargosDao();
        public (DataTable, DataTable, IList<CargosModelo>) ObtenerCargos()
        {
            return cargosDao.ObtenerCargos();
        }
        public int ActualizarCargos(IList<CargosModelo> ltsCargos)
        {
            return cargosDao.ActualizarCargos(ltsCargos);
        }
        public bool CargosActivos() => cargosDao.CargosActivos();
        public bool CargosInactivos() => cargosDao.CargosInactivos();
        public void HabilitarCargo(int CargoID)
        {
            cargosDao.HabilitarCargo(CargoID);
        }
        public void DeshabilitarCargo(int CargoID)
        {
            cargosDao.DeshabilitarCargo(CargoID);
        }
        public DataTable CargosHabilitados()
        {
            return cargosDao.CargosHabilitados();
        }
        public DataTable CargosDeshabilitados()
        {
            return cargosDao.CargosDeshabilitados();
        }
        public void CargarTipoAsignacion(ComboBox cmb)
        {
            cargosDao.CargarTipoAsignacion(cmb);
        }
        public void CargarTipoAplicacion(ComboBox cmb)
        {
            cargosDao.CargarTipoAplicacion(cmb);
        }
        public void AgregarCargo(string Nombre, int CargaHoraria, int TipoAplicacionId, int TipoAsignacionId)
        {
            cargosDao.AgregarCargo(Nombre, CargaHoraria, TipoAplicacionId, TipoAsignacionId);
        }
    }
}
