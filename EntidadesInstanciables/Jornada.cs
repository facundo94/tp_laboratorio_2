using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Archivos;
using Excepciones;


namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Fields

        private List<Alumno> _alumnos;
        private Universidad.ECLases _clase;
        private Profesor _instructor;

        #endregion

        #region Properties

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.ECLases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        #endregion

        #region Methods

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.ECLases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        /// <summary>
        /// Una Jornada es igual a un Alumno si, y solo si, el Alumno esta en la lista de alumnos de la Jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (!object.ReferenceEquals(j, null) && !object.ReferenceEquals(a, null))
            {
                foreach (Alumno i in j._alumnos)
                {
                    if (i == a)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Una Jornada no es igual a un Alumno si, y solo si, el Alumno no esta en la lista de alumnos de la Jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un Alumno a la Jornada si, y solo si, el Alumno no se encuentra en la lista de alumnos de esta
        /// </summary>
        /// <param name="j">Jornada a la que se agrega el alumno</param>
        /// <param name="a">Alumno que se agrega a la jornada</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);

            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASES DE ");
            sb.Append(this._clase.ToString());
            sb.Append(" POR ");
            sb.Append(this._instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno i in this._alumnos)
            {
                sb.Append(i.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        /// <summary>
        /// Guarda los datos de una Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">La Jornada a guardar en el archivo</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto txt = new Texto();
                txt.guardar("Jornada.txt", jornada.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Lee y retorna los datos de una Jornada desde un archivo de texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            try
            {
                Texto txt = new Texto();
                string datos;
                txt.leer("Jornada.txt", out datos);
                return datos;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        #endregion
    }
}
