using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region fields

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #endregion

        #region Properties

        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                if (this.ValidarNombreApellido(value) != "")
                    this._apellido = value;
            }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = value; }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if (this.ValidarNombreApellido(value) != "")
                    this._nombre = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                //try
                //{
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
                //}
                //catch (NacionalidadInvalidaException ex)
                //{
                //    //throw new NacionalidadInvalidaException();
                //    Console.WriteLine(ex.Message);
                //}
                //catch (DniInvalidoException ex)
                //{
                //    /*throw new DniInvalidoException*/Console.WriteLine(ex.Message);
                //}                
            }
        }

        #endregion

        #region Methods

        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni; ;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("NOMBRE COMPLETO: ");
            sb.AppendLine(this.Apellido + ", " + this.Nombre);
            sb.Append("NACIONALIDAD: ");
            sb.AppendLine(this.Nacionalidad.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// El dato es valido si este es mayor a 0 y menor a 90000000, y la nacionalidad es 'Argentino' o
        /// si el dato es mayor a 90000000 y la nacionalidad es 'Extranjero'
        /// </summary>
        /// <param name="nacionalidad">En base a este dato se determina si el dni ingresado es correcto</param>
        /// <param name="dato">dato a validar</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato > 0)
            {
                if (dato > 90000000)
                {
                    if (nacionalidad == ENacionalidad.Argentino)
                        throw new DniInvalidoException("El numero exede al maximo permitido.");
                }
                else if (nacionalidad == ENacionalidad.Extranjero)
                    throw new NacionalidadInvalidaException("La nacionalidad no coincide con el número de DNI");
            }
            else
                throw new DniInvalidoException("El numero esta por debajo del minimo permitido.");

            return dato;
        }

        /// <summary>
        /// El dato es valido si este es mayor a 0 y menor a 90000000, y la nacionalidad es 'Argentino' o
        /// si el dato es mayor a 90000000 y la nacionalidad es 'Extranjero'
        /// </summary>
        /// <param name="nacionalidad">En base a este dato se determina si el dni ingresado es correcto</param>
        /// <param name="dato">dato a validar</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int salida;
            if (!int.TryParse(dato, out salida))
                throw new DniInvalidoException("El DNI contiene caracteres invalidos.");

            return this.ValidarDni(nacionalidad, salida);
        }

        /// <summary>
        /// Valida que el string recibido solo contenga letras
        /// </summary>
        /// <param name="dato">string a validar</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex reg = new Regex(@"[^a-zA-ZñÑ]");

            if (!reg.IsMatch(dato))
                return dato;

            return "";
        }

        #endregion

        #region Nested Types

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion
    }
}
