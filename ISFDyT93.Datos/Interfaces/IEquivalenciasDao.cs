using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IEquivalenciasDao
    {
        DataTable ObtenerCarreras(int CarreraId);
        DataTable ObtenerMaterias(int CarreraId);
        DataTable ObtenerEquivalencias(int CarreraId, int CarreraEquivalenciaId);
        int AsignarEquivalencia(int CarreraId, int MateriaId, int CarreraEquivalenciaId, int MateriaEquivalenciaId);
        int EliminarEquivalencia(int EquivalenciaId);
    }
}
