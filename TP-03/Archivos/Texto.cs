using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda en un archivo de texto los datos que recibe como parametro
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">String con los datos a serializar</param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(archivo, true))
                {
                    file.WriteLine(datos);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Lee desde un archivo de texto los datos y los guarda en el string que recibe como parametro
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">String donde se cargan los datos leidos</param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader file = new StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = "";
                return false;
            }
        }
    }
}
