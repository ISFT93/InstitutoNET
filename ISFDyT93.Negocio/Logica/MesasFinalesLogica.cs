using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;
using Microsoft.Win32;

namespace ISFDyT93.Negocio.Logica
{
    public class MesasFinalesLogica : LogicaBase
    {
        #region Privates
        private MesasFinalesDao mesasFinalesDao;
        private ServiciosDao serviciosDao;
        private ServiciosLogica serviciosLogica;
        private LibroActasModelo Actas { get; set; }
        #endregion
        public MesasFinalesLogica()
        {
            this.mesasFinalesDao = new MesasFinalesDao();
            this.serviciosDao = new ServiciosDao();
            this.serviciosLogica = new ServiciosLogica();
        }


        public DataTable ObtenerProfesorTitular(int materiaId)
        {
            return this.mesasFinalesDao.ObtenerProfesorTitular(materiaId);
        }

        public DataTable ObtenerVocales(int carreraId, int personalId)
        {
            return this.mesasFinalesDao.ObtenerVocales(carreraId, personalId);
        }

        public int AgregarMesa(int carreraId, DateTime fecha, int turno, int llamado, int materiaId, int presidenteId, int vocalId, int anioLectivo)
        {
            //Actas = serviciosLogica.ObtenerUltimoLibro((int)TipoLibro.LibroActaExamenes);
            //if (Actas.LibroActaId > 0)
            //    this.serviciosDao.ActualizarLibroActa(Actas);
            //else
            //    Actas = this.serviciosDao.AgregarLibroActa(Actas);
            //int libroId = Actas.LibroActaId;
            //int libroNumero = Actas.LibroNumero;
            //int folioNumero = Actas.FolioNumero;
            return this.mesasFinalesDao.AgregarMesa(carreraId, fecha, turno, llamado, materiaId, presidenteId, vocalId, anioLectivo);
        }

        public int ModificarMesa (DateTime fecha, int turno, int presidenteId, int vocalId, int mesaFinalId)
        {
            return this.mesasFinalesDao.ModificarMesas(fecha, turno, presidenteId, vocalId, mesaFinalId);
        }

        public int EliminarMesa (int mesaFinalId)
        {
            return this.mesasFinalesDao.EliminarMesas(mesaFinalId);
        }

        public DataTable ObtenerMateriaFinal (int mesaFinalId)
        {
            return this.mesasFinalesDao.ObtenerMateriaFinal(mesaFinalId);
        }
        public DataTable ObtenerMesas(int carreraId)
        {
            return this.mesasFinalesDao.ObtenerMesas(carreraId);
        }

        public DataTable ObtenerMesasFiltro(int carreraId, int anioLectivoId, int turnoId, int llamadoId)
        {
            return this.mesasFinalesDao.ObtenerMesasFiltro(carreraId, anioLectivoId, turnoId, llamadoId);
        }

        public DataTable ObtenerMesasReporte(int carreraId, int anioLectivoId, int turnoId, int llamadoId)
        {
            return this.mesasFinalesDao.ObtenerMesasReporte(carreraId, anioLectivoId, turnoId , llamadoId);
        }

        public int CargarMesasFinales(int cicloLectivoId, int turnoId)
        {
            return this.mesasFinalesDao.CargarMesasFinales(cicloLectivoId, turnoId);
        }

        public DataTable ObtenerTurnoMesa(int mesaFinalId)
        {
            return this.mesasFinalesDao.ObtenerTurnoMesa(mesaFinalId);
        }

        public DataTable ObtenerTurnos(bool todos)
        {
            if (!todos)
            {
                DataRow[] dr = this.mesasFinalesDao.ObtenerTurnos().Select("TurnoId = 4");
                return dr.CopyToDataTable();
            }

            else
                return this.mesasFinalesDao.ObtenerTurnos();

        }

        public DataTable ObtenerAniosLectivos()
        {
            return this.mesasFinalesDao.ObtenerAniosLectivos();
        }

        public DataTable ExistenMesasFinales(int anioLectivo)
        {
            return this.mesasFinalesDao.ExistenFechasFinales(anioLectivo);
        }

        public DataTable ObtenerLlamados(bool fechaUnica)
        {
            DataRow[] dr;
            if (fechaUnica)
                dr = this.mesasFinalesDao.ObtenerLlamados().Select("LlamadoId = 3");
            
            else
                dr = this.mesasFinalesDao.ObtenerLlamados().Select("LlamadoId <> 3");

            return dr.CopyToDataTable();
        }
    }
}
