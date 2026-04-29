using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ISFDyT93.Negocio.Logica;
using System.Text.RegularExpressions;

namespace ISFDyT93.Negocio
{
    public class Validaciones
    {
        const string NUMEROSLETRAS = "abcdefghijklmnñopqrstuvwxyzáéíóú0123456789 ";
        const string EMAIL= "abcdefghijklmnñopqrstuvwxyzáéíóú0123456789@_.";
        const string LETRAS = "abcdefghijklmnñopqrstuvwxyzáéíóú ";
        const string SOLOLETRAS = "abcdefghijklmnñopqrstuvwxyzáéíóú";
        const string LETRASYCOMA = "abcdefghijklmnñopqrstuvwxyzáéíóú ,";
        const string NUMEROS = "0123456789";
        const string NUMEROSCOMA = "0123456789,.";
        const string TODO = "abcdefghijklmnñopqrstuvwxyzáéíóú0123456789 .,-º";

        public bool Obligatorio(object value)
        {
            if (value == null)
                return false;

            if(value.GetType() == typeof( char ) && ((char)value) == (char)1)
            {
                return false;
            }

            if (value.GetType() == typeof(DateTime) && ((DateTime)value) == DateTime.MinValue)
            {
                return false;
            }

            return !string.IsNullOrEmpty(value.ToString()) && value.ToString().Trim() != "";
        }
        public bool Obligatorio(decimal value)
        {
            return value > 0;
        }

        public bool SoloNumeros(string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return true;
            }

            bool validado = true;
            foreach (char c in Value)
            {
                if (!NUMEROS.Contains(c.ToString()))
                {
                    validado = false;
                }
            }

            return validado;
        }

        public bool FormatoExpediente(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return true;
            }

            // 5801-3.279.866/03
            int index = valor.IndexOf("-");

            // Verifica que haya guión
            if (index < 0)
                return false;

            string bloque1 = valor.Substring(0, index);
            int intbloque1 = 0;

            // Verifica que haya un número antes del guión
            if (!int.TryParse(bloque1, out intbloque1))
            {
                return false;
            }

            // Obtengo el resto del string
            valor = valor.Substring(index + 1);

            // Obtengo el indice de la barra
            index = valor.IndexOf("/");
            if (index < 0)
                return false;

            // Obtengo el valor entre el guión y la barra
            string bloque2 = valor.Substring(0, index);


            // Verifico que se respete cada 3 números le sigue un punto
            int cant = 0;
            for (int i = bloque2.Length - 1; i > 0; i--)
            {
                char letra = bloque2[i];

                if (cant == 3 && letra != '.')
                {
                    return false;
                }
                else if (cant == 3 && letra == '.')
                {
                    cant = 0;
                }
                else
                {
                    cant++;
                }
            }

            // Le quito los puntos al bloque 2
            bloque2 = bloque2.Replace(".", "");
            long intbloque2 = 0;

            // Verifica que haya un número en el bloque 2
            if (!long.TryParse(bloque2, out intbloque2))
            {
                return false;
            }

            // Obtengo el bloque 3 despues de guión
            string bloque3 = valor.Substring(index + 1);
            int intbloque3 = 0;

            // Verifica que haya un número en el bloque 3
            if (!int.TryParse(bloque3, out intbloque3))
            {
                return false;
            }


            return true;
        }

        public bool SoloLetrasEspaciosyComas(string evaluado)//Evalua si solo tiene letras y espacios en un string
        {
            if (string.IsNullOrEmpty(evaluado))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in evaluado)
            {
                if (!LETRASYCOMA.Contains(c.ToString().ToLower()))
                {
                    validado = false;
                }
            }

            return validado;
        }
        public bool Todo(string evaluado)//Evalua si solo tiene letras y espacios en un string
        {
            if (string.IsNullOrEmpty(evaluado))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in evaluado)
            {
                if (!TODO.Contains(c.ToString().ToLower()))
                {
                    validado = false;
                }
            }

            return validado;
        }
        public static bool CantidadPalabras(string value, int cantidad)
        {
            var partes = value.Split(' ');
            if (partes.Length <= cantidad)
            {
                return true;
            }

            return false;
        }
          
        public bool SoloLetrasEspacios(string evaluado)//Evalua si solo tiene letras y espacios en un string
        {
            if (string.IsNullOrEmpty(evaluado))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in evaluado)
            {
                if (!LETRAS.Contains(c.ToString().ToLower()))
                {
                    validado = false;
                }
            }

            return validado;
        }
        public bool SoloLetras(string evaluado)//Evalua si solo tiene letras y espacios en un string
        {
            if (string.IsNullOrEmpty(evaluado))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in evaluado)
            {
                if (!SOLOLETRAS.Contains(c.ToString().ToLower()))
                {
                    validado = false;
                }
            }

            return validado;
        }

        

        
        public bool SoloNumerosYComa(string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return true;
            }

            bool validado = true;
            foreach (char c in Value)
            {
                if (!NUMEROSCOMA.Contains(c.ToString()))
                {
                    validado = false;
                }
            }

            return validado;
        }
        public bool SoloLetrasEspaciosyNumeros(string evaluado)
        {
            if (string.IsNullOrEmpty(evaluado))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in evaluado)
            {
                if(!NUMEROSLETRAS.Contains(c.ToString().ToLower()))
                { 
                    validado = false;
                }
            }
            return validado;
        }
        public bool SoloLetrasYNumeros(string evaluado)
        {
            if (string.IsNullOrEmpty(evaluado))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in evaluado)
            {
                if (!NUMEROSLETRAS.Contains(c.ToString().ToLower()) || c == ' ')
                {
                    validado = false;
                }
            }

            return validado;
        }
        public bool FormatoEmail(string evaluado)//Evalua si solo tiene letras y espacios en un string
        {
            if (string.IsNullOrEmpty(evaluado))
            {
                return true;
            }

            bool validado = true;

            foreach (char c in evaluado)
            {
                if (!EMAIL.Contains(c.ToString().ToLower()))
                {
                    validado = false;
                }
            }
            return validado;
        }
        public bool TextoParrafo(string evaluado)
        {
            if (string.IsNullOrEmpty(evaluado))
            {
                return true;
            }

            foreach (char c in evaluado)
            {
                if (!char.IsLetterOrDigit(c) &&     // letras y números
                    !char.IsWhiteSpace(c) &&        // espacios y saltos de línea
                    !char.IsPunctuation(c))         // signos .,;:!? etc.
                {
                    return false;
                }
            }

            return true;
        }
        public bool FormatoEmailValido(string evaluado)
        {
            if (string.IsNullOrEmpty(evaluado))
                return false;

            return Regex.IsMatch(evaluado, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool AlumnoNuevo(string Documento)
        {
            var alumnoLogica = new AlumnosLogica();

            return !alumnoLogica.AlumnoExiste(Documento);
        }
        public bool ProfesorNuevo(string Documento)
        {
            var profesorLogica = new PersonalLogica();

            return !profesorLogica.PersonalExiste(Documento);
        }

        public static string CrearSlug(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;

            string normalizado = texto.Normalize(NormalizationForm.FormD); // descompone acentos y los quita
            var sb = new StringBuilder();
            foreach (char c in normalizado)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) // si el tipo de caracter no es un acento lo agrego al sb
                    sb.Append(c);
            }

            string resultado = sb.ToString()
                .Normalize(NormalizationForm.FormC) // recompone los caracteres
                .ToLower() // pasa a minúsculas
                .Replace(" ", "-"); // remplaza los espacios por guiones

            resultado = Regex.Replace(resultado, @"[^a-z0-9\-]", ""); // elimina todo lo que no sea letra, número o guión
            resultado = Regex.Replace(resultado, @"-{2,}", "-"); // si hay 2 o mas guiones seguidos deja solo uno
            return resultado.Trim('-'); // elimina guiones al inicio y al final
        }

    }
}
