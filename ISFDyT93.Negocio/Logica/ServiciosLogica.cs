using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;
using System;
using System.Data;


namespace ISFDyT93.Negocio.Logica
{
    public class ServiciosLogica : LogicaBase
    {
        ServiciosDao serviciosDao;

        public ServiciosLogica()
        {
            this.serviciosDao = new ServiciosDao();
        }

        public DataTable ObtenerCargos(int PersonalId)
        {
            return this.serviciosDao.ObtenerCargos(PersonalId);
        }

        public LibroActasModelo ObtenerUltimoLibro(int tipoLibroId)
        {
            var libro = this.serviciosDao.ObtenerUltimoLibro(tipoLibroId);
            int libroNumero = -1;

            if(libro != null)
            {   
                if(libro.FolioNumero == libro.FolioMaximo)
                {
                    libroNumero = libro.LibroNumero;
                }
                else
                {
                    libro.FolioNumero++;
                }
            }
            else
            {
                libroNumero = 0;
            }

            if(libroNumero != -1)
            {
                libroNumero++;

                libro = new LibroActasModelo
                {
                    FolioMaximo = 200,
                    LibroNumero = libroNumero,
                    FolioNumero = 1,
                    FechaAlta = DateTime.Now,
                    Activo = true,
                    TipoLibroId = tipoLibroId
                };
            }

            return libro;
        }

        public DataTable ObtenerServiciosPersonal(int PersonalId, int Activo)
        {
            return this.serviciosDao.ObtenerServicioPersonal(PersonalId, Activo);
        }

        public DataTable ObtenerSituacionRevista()
        { 
            return this.serviciosDao.ObtenerSituacionRevista();
        }
         
        public DataTable ObtenerCargosAsignados(int CargoId, int personalId)
        {
            return this.serviciosDao.ObtenerCargosAsignados(CargoId, personalId);
        }

        public DataTable ObtenerMateriasLibres(int tipoAsignacionId, int CursoId, int situacionRevistaId)
        {
            return this.serviciosDao.ObtenerMateriasLibres(tipoAsignacionId, CursoId, situacionRevistaId);
        }

        public bool AgregarServicio(ServiciosModelo servicio, PersonalModelo personal, LibroActasModelo libroActa)
        {
            if (libroActa.LibroActaId > 0)
                this.serviciosDao.ActualizarLibroActa(libroActa);
            else
                libroActa = this.serviciosDao.AgregarLibroActa(libroActa);

            servicio.LibroActaId = libroActa.LibroActaId;
            servicio.PersonalId = personal.PersonalId;
            servicio.Activo = true;
            servicio.FechaAlta = DateTime.Now;

            var result = this.serviciosDao.AgregarServicio(servicio);

            if(result > 0)
            {
                if (servicio.CargoId == (int)Cargo.JefeCatedra)
                {
                    var nombrePersonal = $"{personal.Nombre} {personal.Apellido}";
                    this.serviciosDao.ActualizarJefeCatedra(servicio.CarreraId.Value, nombrePersonal);
                }

                this.serviciosDao.ActualizarPersonalEstado((int)PersonalEstado.Activa, servicio.PersonalId);
            }

            return result > 0;
        }

        public void DesactivarServicio(int servicioId, int cantidadServicios)
        {
            var servicio = this.serviciosDao.ObtenerServicio(servicioId);

            servicio.FechaBaja = DateTime.Now;
            servicio.Activo = false;

            var result = this.serviciosDao.ActualizarServicio(servicio);

            if(result > 0)
            {
                if(servicio.CargoId == (int)Cargo.JefeCatedra)
                {
                    this.serviciosDao.ActualizarJefeCatedra(servicio.CarreraId.Value, null);
                }

                if(cantidadServicios == 1)
                {
                    this.serviciosDao.ActualizarPersonalEstado((int)PersonalEstado.Inactiva, servicio.PersonalId);
                }
            }
        }

        public DataTable ObtenerCarreras(int tipoAsignacionId, int situacionRevistaId)
        { 
            return this.serviciosDao.ObtenerCarreras(tipoAsignacionId, situacionRevistaId);
        }
        public DataTable ObtenerCarrerasSinJefeCatedra(int PersonalId)
        {
            return this.serviciosDao.ObtenerCarrerasSinJefeCatedra(PersonalId);
        }

        public DataTable ObtenerAnioCarreras(int CarreraId)
        { 
            return this.serviciosDao.ObtenerAnioCarreras(CarreraId);
        }
        public DataTable ObtenerCursos(int AnioCarreraId)
        { 
            return this.serviciosDao.ObtenerCursos(AnioCarreraId);
        }
        public int ObtenerModuloMateria(int CursoMateriaId)
        {
            DataRow row = serviciosDao.ObtenerModuloMateria(CursoMateriaId);
            string result = row["Modulos"].ToString();
            if (result != null && result != "")
                    return Convert.ToInt32(result);
            
            return -1;
        }
    }
}
