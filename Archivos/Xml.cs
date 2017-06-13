using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa en un archivo xml el objeto que recibe como parametro
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Objeto con los datos a serializar</param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter writer = new StreamWriter(archivo);
                serializer.Serialize(writer, datos);
                writer.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee desde un archivo xml los datos de un objeto que recibe por parametro
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Objeto en el que se cargand los datos leidos</param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader reader = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(reader);
                reader.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(T);
                return false;
            }
        }
    }
}
