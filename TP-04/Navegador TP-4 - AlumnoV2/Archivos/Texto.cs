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
        private string _archivo;

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        /// <summary>
        /// Guarda los datos recibidos por parametro en un archivo de texto
        /// </summary>
        /// <param name="datos">Los datos a guardar en el archivo</param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(this._archivo, true);
                writer.WriteLine(datos);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Lee datos de un archivo de texto
        /// </summary>
        /// <param name="datos">Lista donde se guardan los datos leidos</param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            try
            {
                string auxRead;
                datos = new List<string>();
                StreamReader reader = new StreamReader(this._archivo);
                while ((auxRead = reader.ReadLine()) != null)
                {
                    datos.Add(auxRead);
                }
                
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
