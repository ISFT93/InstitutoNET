using ISFDyT93.Entidades.Modelos;
using System.Collections.Generic;
using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IEspaciosLogica
    {
        IList<EspaciosModelo> ObtenerEspacios();

        int ActualizarEspacios(IList<EspaciosModelo> ltsEspacios);

        bool EspaciosActivos();

        bool EspaciosInactivos();

        void HabilitarEspacio(int EspacioId);
        DataTable EspaciosHabilitados();

        DataTable EspaciosDeshabilitados();

        void DeshabilitarEspacio(int EspacioId);

        void AgregarEspacio(string Descripcion);
    }
}