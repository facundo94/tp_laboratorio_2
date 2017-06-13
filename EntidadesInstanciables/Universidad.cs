using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Archivos;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Fields

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        #endregion

        #region Properties

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        public Jornada this[int i]
        {
            get { return this.jornadas[i]; }
            set { this.jornadas[i] = value; }
        }

        #endregion

        #region Methods

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Una Universidad es igual a un Alumno si, y solo si, este se encuentra en la lista de alumnos de la Universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            if (!object.ReferenceEquals(g, null) && !object.ReferenceEquals(a, null))
            {
                foreach (Alumno e in g.alumnos)
                {
                    if ((Universitario)e == (Universitario)a)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Una Universidad no es igual a un Alumno si, y solo si, este no se encuentra en la lista de alumnos de la Universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Una Universidad es igual a un Profesor si, y solo si, este se encuentra en la lista de profesores de la Universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            if (!object.ReferenceEquals(g, null) && !object.ReferenceEquals(i, null))
            {
                foreach (Profesor e in g.profesores)
                {
                    if ((Universitario)e == (Universitario)i)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Una Universidad no es igual a un Profesor si, y solo si, este no se 
        /// encuentra en la lista de profesores de la Universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega una Jornada a la lista de jornadas de la Universidad si, y solo si, hay un profesor disponible para la Jornada
        /// </summary>
        /// <param name="g">Universidad a la que se agrega la Jornada</param>
        /// <param name="clase">EClase que indica la materia de la jornada que se agrega</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, ECLases clase)
        {
            Jornada j = new Jornada(clase, (g == clase));

            foreach (Alumno a in g.alumnos)
            {
                if (a == clase)
                    j.Alumnos.Add(a);
            }

            g.jornadas.Add(j);

            return g;
        }

        /// <summary>
        /// Se agrega un Alumno a la lista de alumnos de la Universidad si, y solo si, el Alumno no se encuentra en esta
        /// </summary>
        /// <param name="g">Universidad a la que se agrega el Alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
                return g;
            }
            else
                throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Se agrega un Profesor a la lista de profesores de la Universidad si, y solo si, el Profesor no se encuentra en esta
        /// </summary>
        /// <param name="g">Universidad a la que se agrega el Profesor</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g.profesores.Add(i);

            return g;
        }

        /// <summary>
        /// Una Universidad es igual a una EClase si, y solo si, hay un Profesor 
        /// disponible para darla, es dicho caso, lo retorna
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">EClase a comparar</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, ECLases clase)
        {
            if (!object.ReferenceEquals(g, null) && !object.ReferenceEquals(clase, null))
            {
                foreach (Profesor i in g.profesores)
                {
                    if (i == clase)
                        return i;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Una Universidad no es igual a una EClase si, y solo si, hay un Profesor 
        /// no disponible para darla, es dicho caso, lo retorna
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">EClase a comparar</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, ECLases clase)
        {
            foreach (Profesor i in g.profesores)
            {
                if (i != clase)
                    return i;
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna un string con todos los datos de la Universidad
        /// </summary>
        /// <param name="gim">Universidad que contiene los datos a retornar</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            foreach (Jornada j in gim.Jornadas)
            {
                sb.AppendLine(j.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Guarda los datos de una Universidad en un archivo xml
        /// </summary>
        /// <param name="gim"Universidad que contiene los datos a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xmlUni = new Xml<Universidad>();
            if (xmlUni.guardar("Universidad.xml", gim))
                return true;

            return false;
        }

        /// <summary>
        /// Lee los datos de una Universidad desde un archivo xml, los carga en un objeto Universidad y lo retorna
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xmlUni = new Xml<Universidad>();
            Universidad g;

            xmlUni.leer("Universidad.xml", out g);

            return g;
        }

        #endregion

        #region Nested Types

        public enum ECLases
        {
            Laboratorio,
            Programacion,
            Legislacion,
            SPD
        }

        #endregion
    }
}
