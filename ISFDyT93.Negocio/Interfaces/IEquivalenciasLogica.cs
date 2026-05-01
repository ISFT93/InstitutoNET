using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IEquivalenciasLogica
    {
        DataTable ObtenerCarreras(int carreraId);
        DataTable ObtenerMaterias(int CarreraId);
        DataTable ObtenerEquivalencias(int CarreraId, int CarreraEquivalenciaId);
        int EliminarEquivalencia(int EquivalenciaId);
        int AsignarEquivalencia(int CarreraId, int MateriaId, int CarreraEquivalenciaId, int MateriaEquivalenciaId);

    }
}
