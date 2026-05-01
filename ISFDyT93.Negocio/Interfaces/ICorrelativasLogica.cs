using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface ICorrelativasLogica
    {
        DataTable ObtenerCorreltividades(int IdMateria, int IdCarrera);
        int CorrelativaExisteCarrera(int CarreraId);
        DataTable ObtenerMateriasCorrelativas(int MateriaId);
        int AgregarCorrelativa(int IdMateria, int IdCorrelativa);
        int GuardarCorrelatividades(IList<CorrelatividadModel> modelos);
        int EliminarCorrelativa(int CorrelativaId);
        int EliminarCorrelativas(int MateriaId);
        DataTable Correlativaid(int CarreraId);
        DataTable ObtenerCorrelativasAnio(int AnioCarreraId);
        DataTable ObtenerCorrelativasCarrera(int CarreraId);
    }
}
