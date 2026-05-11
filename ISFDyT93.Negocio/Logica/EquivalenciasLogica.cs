using ISFDyT93.Negocio.Core;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Datos.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ISFDyT93.Negocio.Interfaces;

namespace ISFDyT93.Negocio.Logica
{
    public class EquivalenciasLogica : LogicaBase , IEquivalenciasLogica
    {
        EquivalenciasDao equivalenciasDao;

        public EquivalenciasLogica()
        {
            this.equivalenciasDao = new EquivalenciasDao();
        }

        public DataTable ObtenerCarreras(int carreraId)
        {
            return this.equivalenciasDao.ObtenerCarreras(carreraId);
        }

        public DataTable ObtenerMaterias(int CarreraId)
        {
            return this.equivalenciasDao.ObtenerMaterias(CarreraId);
        }

        public DataTable ObtenerEquivalencias(int CarreraId, int CarreraEquivalenciaId)
        {
            return this.equivalenciasDao.ObtenerEquivalencias(CarreraId, CarreraEquivalenciaId);
        }

        public int EliminarEquivalencia(int EquivalenciaId)
        {
            return this.equivalenciasDao.EliminarEquivalencia(EquivalenciaId);
        }

        public int AsignarEquivalencia(int CarreraId, int MateriaId, int CarreraEquivalenciaId, int MateriaEquivalenciaId)
        {
            return this.equivalenciasDao.AsignarEquivalencia(CarreraId, MateriaId, CarreraEquivalenciaId, MateriaEquivalenciaId);
        }

        /// <summary>
        /// Obtiene las materias de una carrera, filtrando aquellas que ya tienen 
        /// una equivalencia asignada con la carrera de comparación.
        /// </summary>
        public DataTable ObtenerMateriasDisponiblesParaEquivalencia(int carreraOrigenId, int carreraDestinoId)
        {
            // Buscamos todas las materias de la carrera de origen
            DataTable dtMaterias = this.equivalenciasDao.ObtenerMaterias(carreraOrigenId);

            // Buscamos qué equivalencias ya existen entre estas dos carreras
            DataTable dtEquivalenciasExistentes = this.equivalenciasDao.ObtenerEquivalencias(carreraOrigenId, carreraDestinoId);

            // Lógica de filtrado: Quitamos de la lista las que ya están asignadas
            // Lo hacemos aquí para que la Vista reciba los Datos preprocesados
            foreach (DataRow filaEq in dtEquivalenciasExistentes.Rows)
            {
                string idMateriaEq = filaEq["MateriaId"].ToString();

                for (int i = dtMaterias.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtMaterias.Rows[i]["MateriaId"].ToString() == idMateriaEq)
                    {
                        dtMaterias.Rows.RemoveAt(i);
                    }
                }
            }
            dtMaterias.AcceptChanges();
            return dtMaterias;
        }
    }
}
