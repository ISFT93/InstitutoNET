using System.Data;
using System.Text;
using System.IO;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class CargaMasivaLogica : LogicaBase
    {
        public DataTable ImportarExel(string nombre)
        {
            var SumaxVuelta = 0;
            var Suma = 0;
            DataTable Dtable = new DataTable();
            string Cadena;
            var leer = new StreamReader(File.OpenRead(@nombre), Encoding.Default);

            while ((!leer.EndOfStream))
            {
                var linea = leer.ReadLine();
                var valor = linea.Split(',');

                string[] SeparaxComas = valor[0].Split(';');
                int cantidadPalabras = int.Parse(SeparaxComas.Length.ToString());

                //Si es la primera vueltas Carga el encabezado 
                if (SumaxVuelta == 0)
                {
                    for (int i = 0; i < cantidadPalabras; i++)
                    {

                        Cadena = (SeparaxComas[i].ToString());
                        Dtable.Columns.Add(Cadena.ToString(), typeof(string));
                    }
                    SumaxVuelta += 1;
                }
                else
                {
                    if (SeparaxComas[0].ToString() == " ")
                        break;
                    else
                    {
                        for (int i = 0; i < valor.Length; i++)
                        {
                            Dtable.Rows.Add();
                            SeparaxComas = valor[0].Split(';');

                            if ((i % cantidadPalabras) == 0)
                            {

                                for (int y = 0; y < cantidadPalabras; y++)
                                {

                                    Cadena = (SeparaxComas[y].ToString());

                                    Dtable.Rows[Suma][y] = (Cadena.ToString());

                                }

                                SumaxVuelta += 1;
                                Suma += 1;
                            }

                        }
                    }
                }

            }               
            return Dtable;

        }

    }
}

        

