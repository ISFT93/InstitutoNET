using System;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class CarrerasLogica : LogicaBase
    {
        CarrerasDao carrerasDao;
        AniosCarreraDao aniosCarreraDao;
        CorrelativasDao correlativasDao;
        MateriasDao materiasDao;

        public CarrerasLogica()
        {
            this.carrerasDao = new CarrerasDao();
            this.aniosCarreraDao = new AniosCarreraDao();
            this.correlativasDao = new CorrelativasDao();
            this.materiasDao = new MateriasDao();
        }
        public DataTable ObtenerCarreras()
        {
            return this.carrerasDao.ObtenerCarreras(true);
        }
        public DataTable CarrerasInactivas()
        {
            return this.carrerasDao.CarrerasInactivas(false);
        }
        public DataTable CarrerasBorrador()
        {
            return this.carrerasDao.CarrerasBorrador(false);
        }
        public DataTable CarrerasActivas()
        {
            return this.carrerasDao.CarrerasActivas(true);
        }
        public bool CarrerasExiste(string Nombre)
        { 
            var resultado = this.carrerasDao.CarreraExiste(Nombre);

            return resultado != null;
        }
        public CarrerasModelo ObtenerCarrera(int id)
        {
            return this.carrerasDao.ObtenerCarrera(id);
        }
        public int TraeIdDeCarrera(string nombre)
        {
            return this.carrerasDao.TraeIdDeCarrera(nombre);
        }

        public bool GuardarCarrera(CarrerasModelo modelo, TipoAccion accion)
        {
            bool resultado = false;

            try
            {
                string time = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                string archiPlanEstudio = modelo.PlanEstudio;
                string archiResolucion = modelo.Resolucion;
                string archiCorrelatividades = modelo.Correlatividades;
                string archiImagen = modelo.ImagenDescriptiva;

                if(accion == TipoAccion.Agregar)
                {
                    modelo.Activo = true;
                    modelo.CarreraEstadoId = 3;

                    if (!string.IsNullOrEmpty(modelo.PlanEstudio))
                    {
                        modelo.PlanEstudio = @"\PDF\PlanEstudio_" + time + ".pdf";
                    }

                    if (!string.IsNullOrEmpty(modelo.Resolucion))
                    {
                        modelo.Resolucion = @"\PDF\Resolucion" + time + ".pdf";
                    }

                    if (!string.IsNullOrEmpty(modelo.Correlatividades))
                    {
                        modelo.Correlatividades = @"\PDF\Correlatividades" + time + ".pdf";
                    }

                    if (!string.IsNullOrEmpty(modelo.ImagenDescriptiva))
                    {
                        string extension = modelo.ImagenDescriptiva.Substring(modelo.ImagenDescriptiva.LastIndexOf("."));
                        modelo.ImagenDescriptiva = @"\Imagen\Imagen" + time + extension;
                    }

                    if (this.carrerasDao.AgregarCarreras(modelo) > 0)
                    {
                        if (!string.IsNullOrEmpty(archiPlanEstudio))
                            GuardarArchivo(archiPlanEstudio, modelo.PlanEstudio, @"\PDF");

                        if (!string.IsNullOrEmpty(archiResolucion))
                            GuardarArchivo(archiResolucion, modelo.Resolucion, @"\PDF");

                        if (!string.IsNullOrEmpty(archiCorrelatividades))
                            GuardarArchivo(archiCorrelatividades, modelo.Correlatividades, @"\PDF");

                        if (!string.IsNullOrEmpty(archiImagen))
                            GuardarArchivo(archiImagen, modelo.ImagenDescriptiva, @"\Imagen");

                        
                        int carreraId = carrerasDao.ObtenerUltimoCarreraId();

                        for (int anio = 1; anio <= modelo.Duracion; anio++)
                        {
                            aniosCarreraDao.AgregarAnio(anio, carreraId);
                        }

                        resultado = true;
                    }
                } 
                else if( accion == TipoAccion.Modificar)
                {
                    if (!string.IsNullOrEmpty(modelo.PlanEstudio) && !modelo.PlanEstudio.StartsWith(@"\PDF"))
                    {
                        modelo.PlanEstudio = @"\PDF\PlanEstudio_" + time + ".pdf";
                    }

                    if (!string.IsNullOrEmpty(modelo.Resolucion) && !modelo.Resolucion.StartsWith(@"\PDF"))
                    {
                        modelo.Resolucion = @"\PDF\Resolucion_" + time + ".pdf";
                    }

                    if (!string.IsNullOrEmpty(modelo.Correlatividades) && !modelo.Correlatividades.StartsWith(@"\PDF"))
                    {
                        modelo.Correlatividades = @"\PDF\Correlatividades_" + time + ".pdf";
                    }

                    if (!string.IsNullOrEmpty(modelo.ImagenDescriptiva) && !modelo.ImagenDescriptiva.StartsWith(@"\Imagen"))
                    {
                        string extension = modelo.ImagenDescriptiva.Substring(modelo.ImagenDescriptiva.LastIndexOf("."));

                        modelo.ImagenDescriptiva = @"\Imagen\Imagen_" + time + extension;
                    }

                    if (this.carrerasDao.ModificarCarrera(modelo) > 0)
                    {
                        if (!modelo.PoseeMaterias)
                        {
                            aniosCarreraDao.EliminarAnios(modelo.CarreraId);

                            for (int anio = 1; anio <= modelo.Duracion; anio++)
                            {
                                aniosCarreraDao.AgregarAnio(anio, modelo.CarreraId);
                            }
                        }

                        resultado = true;
                    }
                }

                if(resultado)
                {
                    if (!string.IsNullOrEmpty(archiPlanEstudio) && !archiPlanEstudio.StartsWith(@"\PDF"))
                        GuardarArchivo(archiPlanEstudio, modelo.PlanEstudio, @"\PDF");

                    if (!string.IsNullOrEmpty(archiResolucion) && !archiResolucion.StartsWith(@"\PDF"))
                        GuardarArchivo(archiResolucion, modelo.Resolucion, @"\PDF");

                    if (!string.IsNullOrEmpty(archiCorrelatividades) && !archiCorrelatividades.StartsWith(@"\PDF"))
                        GuardarArchivo(archiCorrelatividades, modelo.Correlatividades, @"\PDF");

                    if (!string.IsNullOrEmpty(archiImagen) && !archiImagen.StartsWith(@"\Imagen"))
                        GuardarArchivo(archiImagen, modelo.ImagenDescriptiva, @"\Imagen");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }

        private void GuardarArchivo(string archivoViejo, string archivoNuevo, string Carpeta)
        {
            var path = Application.StartupPath;

            if(!System.IO.Directory.Exists(Carpeta))
            {
                System.IO.Directory.CreateDirectory(Carpeta);
            }

            // Para modificar elimino el anterior archivo
            if (System.IO.File.Exists(path + archivoNuevo))
            {
                System.IO.File.Delete(path + archivoNuevo);
            }

            // Muevo el archivo a una ubicación interna del programa
            System.IO.File.Copy(archivoViejo, path + archivoNuevo);
        }

        public void EliminarCarrera(int CarreraId)
        {
            var CorrelativasId = correlativasDao.Correlativaid(CarreraId);
            var materiasId = materiasDao.MateriasId(CarreraId);
            var AniosCarreraId = aniosCarreraDao.ObtenerAniosCarrera(CarreraId);

            if (CorrelativasId.Rows.Count > 0)
            {
                for (int i = 0; i < CorrelativasId.Rows.Count; i++)
                {
                    correlativasDao.EliminarCorrelativa(Convert.ToInt32(CorrelativasId.Rows[i]["CorrelativaId"]));
                }
            }

            if (materiasId.Rows.Count > 0)
            {
                for (int i = 0; i < materiasId.Rows.Count; i++)
                {
                    materiasDao.EliminarMateria(Convert.ToInt32(materiasId.Rows[i]["MateriaId"]));
                }
            }
            if (AniosCarreraId.Rows.Count > 0)
            {
                for (int i = 0; i < AniosCarreraId.Rows.Count; i++)
                {
                    aniosCarreraDao.EliminarAnios(Convert.ToInt32(AniosCarreraId.Rows[i]["AnioCarreraId"]));

                }
            }

            this.carrerasDao.EliminarCarrera(CarreraId);
        }

        public void AltaCarreraActivo(int Carreraid)
        {
            this.carrerasDao.AltaCarreraActivo(Carreraid);
        }
    }
}
