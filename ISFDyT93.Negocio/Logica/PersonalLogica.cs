using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Datos.Modelos;
using iTextSharp.text.pdf;
using ISFDyT93.Negocio.Core;
using System.Collections.Generic;

namespace ISFDyT93.Negocio.Logica
{
    public class PersonalLogica : LogicaBase
    {
        PersonalDao personalDao;

        public PersonalLogica()
        {
            this.personalDao = new PersonalDao();
        }
         
        public DataTable ObtenerListaPersonal(TipoFiltroProfesor tipo,  string filtro, int estado )
        {
            if (string.IsNullOrEmpty(filtro))
            {
                return this.personalDao.ObtenerListaPersonal(estado);
            }
            else
            {
                return this.personalDao.ObtenerListaPersonal(tipo, filtro, estado);
            }
        }

        public IList<CargosModeloDTO> ObtenerPersonalConCargos(List<int> cursoMateriaIds)
        {
            return personalDao.ObtenerPersonalConCargos(cursoMateriaIds);
        }
        private void GuardarArchivo(string archivoViejo, string archivoNuevo, string Carpeta)
        {
            var path = Application.StartupPath;

            if (!System.IO.Directory.Exists(Carpeta))
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

        public void AsignarProfesorMateria( int MateriaId, int CursoId, int ProfesorId, string Fecha)
        {
            this.personalDao.AsignarProfesorMateria( MateriaId, CursoId, ProfesorId, Fecha);
        }

        public void AgregarPersonal(PersonalModelo modelo)
        {
            string time = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;

            string archiImagen = modelo.Foto;

            if (!string.IsNullOrEmpty(modelo.Foto))
            {
                string extension = modelo.Foto.Substring(modelo.Foto.LastIndexOf("."));

                modelo.Foto = @"\Imagen\Imagen" + time + extension;
            }

            modelo.FechaAlta = DateTime.Now;
            modelo.PersonalEstadoId = 3;

            if (this.personalDao.AgregarPersonal(modelo) > 0)
            {
                if (!string.IsNullOrEmpty(archiImagen))
                    GuardarArchivo(archiImagen, modelo.Foto, @"\Imagen");
            }
        }

        public int ModificarPersonal(PersonalModelo modelo)
        {
            string time = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
           
            string archiImagen = modelo.Foto;

            if (!string.IsNullOrEmpty(modelo.Foto) && !modelo.Foto.StartsWith(@"\Imagen"))
            {
                string extension = modelo.Foto.Substring(modelo.Foto.LastIndexOf("."));
                modelo.Foto = @"\Imagen\Imagen_" + time + extension;
            }

            if (this.personalDao.ModificarPersonal(modelo) > 0)
            {              
                if (!string.IsNullOrEmpty(archiImagen) && !archiImagen.StartsWith(@"\Imagen"))
                    GuardarArchivo(archiImagen, modelo.Foto, @"\Imagen");
            }

            return 0;
        }

        public PersonalModelo ObtenerPersonal(int personalId)
        {
            return this.personalDao.ObtenerPersonal(personalId);
        }

        public void EliminarPersonal(int personalId)
        {
            this.personalDao.EliminarPersonal(personalId);
        }

        public void EliminarProfesorMateria(int ProfesorMateriaId)
        {
            this.personalDao.EliminarProfesorMateria(ProfesorMateriaId);
        }

        public void VerLegajo(int profesorId)
        {
            DataTable DTprofesores = new DataTable();

            using (FileStream resultado = new FileStream("PDF/Profesor.pdf", FileMode.Create))
            {
                PdfReader pdfReader = new PdfReader("Legajo.pdf");
                PdfStamper pdfStamper = new PdfStamper(pdfReader, resultado);
                pdfStamper.FormFlattening = true;

                AcroFields campos = pdfStamper.AcroFields;

                DTprofesores = personalDao.ArmarLegajo(profesorId);

                foreach (DataRow fila in DTprofesores.Rows)
                {
                    campos.SetField("Nombre", fila["Nombre"].ToString());
                    campos.SetField("Apellido", fila["Apellido"].ToString());
                    campos.SetField("Documento", fila["NumeroDocumento"].ToString());
                    campos.SetField("FechaNacimiento", fila["FechaNacimiento"].ToString());
                    campos.SetField("Nacionalidad", fila["Nacionalidad"].ToString());
                    campos.SetField("EstadoCivil", fila["EstadoCivil"].ToString());
                    campos.SetField("Sexo", fila["Sexo"].ToString());
                    campos.SetField("Titulo", fila["Titulo"].ToString());
                    campos.SetField("Direccion", fila["Direccion"].ToString());
                    campos.SetField("Piso", fila["Piso"].ToString());
                    campos.SetField("Departamento", fila["Departamento"].ToString());
                    campos.SetField("Localidad", fila["Localidad"].ToString());
                    campos.SetField("Telefono", fila["Telefono"].ToString());
                    campos.SetField("Celular", fila["Celular"].ToString());
                    campos.SetField("Email", fila["Email"].ToString());

                    if((fila["Foto"] != DBNull.Value) && (!string.IsNullOrEmpty(fila["Foto"].ToString())))
                    {
                        try
                        {
                            var push = campos.GetNewPushbuttonFromField("Foto");

                            var imagen = iTextSharp.text.Image.GetInstance(Application.StartupPath + fila["Foto"].ToString());

                            push.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                            push.ProportionalIcon = true;
                            push.Image = imagen;

                            campos.ReplacePushbuttonField("Foto", push.Field);
                        }
                        catch
                        {
                            
                        }
                    }
                }


                pdfStamper.Close();
                pdfReader.Close();
            }

            Process.Start(@"PDF\Profesor.pdf");
        }

        public DataTable ObtenerProfesorMaterias(int ProfesorId)
        {
          return this.personalDao.ObtenerProfesorMaterias(ProfesorId);
        }

        public bool PersonalExiste(string DNI)
        {
            var resultado = this.personalDao.PersonalExiste(DNI);

            return resultado != null;
        }

        public int AgregarDocumentacion(string Analitico, string Proyecto, int ProfesorMateriaId, int CiclosLectivoId)
        {
            int id = 1;
            try
            {
                string time = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                string archiAnalitico = Analitico;
                string archiProyecto = Proyecto;

                if (!string.IsNullOrEmpty(Analitico))
                {
                    Analitico = @"\PDF\Analitico_" + time + ".pdf";
                }
                if (!string.IsNullOrEmpty(Proyecto))
                {
                    Proyecto = @"\PDF\Proyecto_" + time + ".pdf";
                }

                if (this.personalDao.AgregarDocumentacion(Analitico, Proyecto, ProfesorMateriaId,CiclosLectivoId) > 0)
                {

                    if (!string.IsNullOrEmpty(archiAnalitico))
                        GuardarArchivo(archiAnalitico, Analitico, @"\PDF");

                    if (!string.IsNullOrEmpty(archiProyecto))
                        GuardarArchivo(archiProyecto, Proyecto, @"\PDF");
                
                }

            }
            catch 
            {

            }
            return id;
        }

        public int ModificarDocumentacion(string Analitico, string Proyecto, int ProfesorMateriaId, int CiclosLectivoId)
        {
            int id = 1;
            try
            {
                string time = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                string archiAnalitico = Analitico;
                string archiProyecto = Proyecto;

                if (!string.IsNullOrEmpty(Analitico))
                {
                    Analitico = @"\PDF\Analitico_" + time + ".pdf";
                }
                if (!string.IsNullOrEmpty(Proyecto))
                {
                    Proyecto = @"\PDF\Proyecto_" + time + ".pdf";
                }

                if (this.personalDao.ModificarDocumentacion(Analitico, Proyecto, ProfesorMateriaId, CiclosLectivoId) > 0)
                {

                    if (!string.IsNullOrEmpty(archiAnalitico))
                        GuardarArchivo(archiAnalitico, Analitico, @"\PDF");

                    if (!string.IsNullOrEmpty(archiProyecto))
                        GuardarArchivo(archiProyecto, Proyecto, @"\PDF");

                }

            }
            catch
            {

            }
            return id;
        }

        public DataRow ObtenerDocumentacion( int ProfesorMateriaId, int CicloLectivoId )
        {
            return this.personalDao.ObtenerDocumentacion(ProfesorMateriaId, CicloLectivoId);
        }

        public DataTable ObtenerPath(int ProfesorMateriaId, int CicloLectivoId)
        {
            return this.personalDao.ObtenerPath(ProfesorMateriaId, CicloLectivoId);
        }
        
        public void DarAltaProfesores(int ProfesorId)
        {
            this.personalDao.DarAltaProfesores(ProfesorId);
        }

        public DataTable ObtenerSituacionRevista()
        {
            return this.personalDao.ObtenerSituacionRevista();
        }

        public bool PoseeMaterias(int ProfesorId, int MateriaId)
        {
            var fila = this.personalDao.ObtenerCantidadMaterias(ProfesorId, MateriaId);
            var cant = Convert.ToInt32(fila["Cantidad"]);
            return cant > 0;
        }

        public DataTable ObtenerNacionalidades()
        {
            return this.personalDao.ObtenerNacionalidades();
        }
    }
}
