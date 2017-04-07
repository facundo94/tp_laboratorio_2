using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores

        /// <summary>
        /// Construtor por defecto, no recibe parametros
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe un double 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) :this()
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que recibe un string
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Asigna el valor que recibe al atributo numero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        private void setNumero(string numero)
        {
            this.numero = Numero.validarNumero(numero);
        }

        /// <summary>
        /// Retorna el valor del atributo numero
        /// </summary>
        /// <returns>Retorna el valor del atributo numero</returns>
        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Intenta convertir el string recibido a double
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns> si puede coventir el string retorna el numero correspondiente,
        /// en caso contrario retorna 0</returns>
        private static double validarNumero(string numeroString)
        {
            double numero;

            if (!double.TryParse(numeroString, out numero))
                numero = 0;

            return numero;
        }

        #endregion
    }
}
