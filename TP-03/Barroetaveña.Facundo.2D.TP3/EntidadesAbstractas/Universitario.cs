using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Fields

        private int _legajo;

        #endregion

        #region Methods

        public override bool Equals(object obj)
        {
            return this == (Universitario)obj;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append("LEGAJO NÚMERO: ");
            sb.AppendLine(this._legajo.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Dos universitarios son iguales si, y sólo si, su legajo o dni, y su tipo son iguales
        /// </summary>
        /// <param name="pg1">Primer universitario a comparar</param>
        /// <param name="pg2">Segundo universitario a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (!object.ReferenceEquals(pg1, null) && !object.ReferenceEquals(pg2, null))
            {
                if ((pg1.GetType() == pg1.GetType()) && ((pg1.DNI == pg2.DNI) || (pg1._legajo == pg2._legajo)))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Dos universitarios no son iguales si, y sólo si, su tipo, o dni y legajo, no son iguales
        /// </summary>
        /// <param name="pg1">Primer universitario a comparar</param>
        /// <param name="pg2">Segundo universitario a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        { 
            return !(pg1 == pg2);
        }

        protected abstract string ParticiparEnClase();

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion
    }
}
