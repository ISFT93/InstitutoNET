using System;
using System.Collections.Generic;
using System.Data;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class MateriasLogica : LogicaBase
    {
        AniosCarreraDao aniosCarreraDao;
        MateriasDao materiasDao;
        public MateriasLogica()
        {
            this.aniosCarreraDao = new AniosCarreraDao();
            this.materiasDao = new MateriasDao();
        }

        public DataRow ObtenerCarreraDeAnio(int AnioCarerraId)
        {
            return this.materiasDao.ObtenerCarreraDeAnio(AnioCarerraId);
        }
        public DataTable ObtenerMaterias(int AnioCarreraId)
        {
            return this.materiasDao.ObtenerMaterias(AnioCarreraId, true);
        }
        public DataTable CargarMaterias(int AnioCarreraId)
        {
            return this.materiasDao.CargarMaterias(AnioCarreraId, true);
        }

        public int ObtenerUltimaMateriaId()
        {          
           return this.materiasDao.ObtenerUltimaMateriaId();           
        }
        public int EliminarMateria(int materiaId, int anioCarreraId)
        {
            var resultado = this.materiasDao.EliminarMateria(materiaId);

            if(resultado >= 0)
            {
                this.aniosCarreraDao.ActualizarCargaHoria(anioCarreraId);
            }

            return resultado;
        }

        public int MateriaAsignada(int id)
        {
            var row = this.materiasDao.MateriaAsignada(id);

            if (row != null)
                return Convert.ToInt32(row["Cantidad"]);

            return 0;
        }
        public int AgregarMaterias(MateriasModelo modelo)
        {
            int estado = this.materiasDao.AgregarMaterias(modelo);

            if(estado > 0)
            {
                this.aniosCarreraDao.ActualizarCargaHoria(modelo.AnioCarreraId);
            }

            return estado;
        }

        public DataTable ObtnenerEspacios()
        {
            return materiasDao.ObtenerEspacios();
        }
        public MateriasModelo ObtenerMateria(int MateriaId)
        {
            return this.materiasDao.ObtenerMateria(MateriaId);
        }

        public int ModificarMateria(MateriasModelo modelo)
        {
            int estado = this.materiasDao.ModificarMateria(modelo);

            if (estado > 0)
            {
                this.aniosCarreraDao.ActualizarCargaHoria(modelo.AnioCarreraId);
            }

            return estado;
        }
        public DataTable ObtenerAsignarMateria(int AlumnoId, int AnioCarreraId)
        {
            return this.materiasDao.ObtenerAsignarMateria(AlumnoId, AnioCarreraId);
        }

        public DataTable ObtenerMateriasAsignar(int AlumnoId, int AnioCarreraId)
        {
            return this.materiasDao.ObtenerMateriasAsignar(AlumnoId, AnioCarreraId);
        }

        public DataTable ObtenerMateriasAsignar(int AlumnoId)
        {
            return this.materiasDao.ObtenerMateriasAsignar(AlumnoId);
        }
        public int EliminarMateriaAsignada(MateriasModelo modelo)
        {
            return this.materiasDao.EliminarMateriaAsignada(modelo);
        }
        public int AsignarMateria(MateriasModelo modelo)
        {
            return this.materiasDao.AsignarMateria(modelo);
        }
        public int EliminarMateriaAsignar(int AlumnoCicloLectivoMateriaId)
        {
            return this.materiasDao.EliminarMateriaAsignar(AlumnoCicloLectivoMateriaId);
        }
       
        public DataTable ObtenerNombresMaterias()
        {
            return this.materiasDao.ObtenerNombresMaterias();
        }

        public DataTable MateriasId(int CarreraId)
        {
            return this.materiasDao.MateriasId(CarreraId);
        }

        public DataTable ObtenerMateriasByCursoAndAnioLectivo(int AnioLectivo,int CursoId)
        {
            return this.materiasDao.ObtenerMateriasByCursoAndAnioLectivo(AnioLectivo, CursoId);
        }
    }

}