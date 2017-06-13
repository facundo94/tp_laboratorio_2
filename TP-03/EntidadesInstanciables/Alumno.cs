using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Fields

        private Universidad.ECLases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region Methods

        public Alumno()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.ECLases clasesQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = clasesQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.ECLases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Retorna un string con todos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append("\nESTADO DE CUENTA: ");
            if (this._estadoCuenta == EEstadoCuenta.AlDia)
                sb.AppendLine("Cuota al día");
            else
                sb.AppendLine("Cuota atrasada");
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Un Alumno es igual a una EClase si, y solo si, el Alumno toma esa clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">EClase a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.ECLases clase)
        {
            if (!object.ReferenceEquals(a, null) && !object.ReferenceEquals(clase, null))
            {
                if ((a._claseQueToma == clase) && (a._estadoCuenta != EEstadoCuenta.Deudor))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Un Alumno no es igual a una EClase si, y solo si, el Alumno no toma esa clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">EClase a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.ECLases clase)
        {
            return !(a == clase);
        }

        /// <summary>
        /// Retorna un string indicando que clase toma 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Nested Types

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion
    }
}
