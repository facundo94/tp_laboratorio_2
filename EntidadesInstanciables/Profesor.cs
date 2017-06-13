using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Fields

        private Queue<Universidad.ECLases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region Methods

        /// <summary>
        /// Agrega dos EClase elegidas de forma aleatorea a la lista de clases
        /// </summary>
        private void _randomClases()
        {
            int i = 0;
            for (i = 0; i < 2; i++)
                this._clasesDelDia.Enqueue((Universidad.ECLases)Profesor._random.Next(0, 3));
        }

        /// <summary>
        /// Retorna un string con todos los datos del Profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Un Profesor es igual a una EClase si, y solo si, el Profesor da esa EClase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">EClase a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.ECLases clase)
        {
            if (!object.ReferenceEquals(i, null) && !object.ReferenceEquals(clase, null))
            {
                foreach (EntidadesInstanciables.Universidad.ECLases e in i._clasesDelDia)
                {
                    if (e == clase)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Un Profesor no es igual a una EClase si, y solo si, el Profesor no da esa EClase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">EClase a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.ECLases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Retorna un string indicando las clases que puede dar
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DE DÍA: ");
            foreach (EntidadesInstanciables.Universidad.ECLases i in this._clasesDelDia)
            {
                sb.AppendLine(i.ToString());
            }

            return sb.ToString();
        }

        public Profesor()
        { }

        static Profesor()
        {
            Profesor._random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.ECLases>();
            this._randomClases();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

    }
}
