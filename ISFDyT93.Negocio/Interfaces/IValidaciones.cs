using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IValidaciones
    {
        bool Obligatorio(object value);
        bool Obligatorio(decimal value);
        bool SoloNumeros(string Value);
        bool FormatoExpediente(string valor);
        bool SoloLetrasEspaciosyComas(string evaluado);
        bool Todo(string evaluado);
        bool SoloLetrasEspacios(string evaluado);
        bool SoloLetras(string evaluado);
        bool SoloNumerosYComa(string Value);
        bool SoloLetrasEspaciosyNumeros(string evaluado);
        bool SoloLetrasYNumeros(string evaluado);
        bool FormatoEmail(string evaluado);
        bool TextoParrafo(string evaluado);
        bool FormatoEmailValido(string evaluado);
        bool AlumnoNuevo(string Documento);
        bool ProfesorNuevo(string Documento);
    }
}
