using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroetaveña.facundo.TP1
{
    class Numero
    {
        private double numero;

        #region Constructores

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        #endregion

        #region Metodos

        private void setNumero(string numero)
        {
            this.numero = this.validarNumero(numero);
        }

        public double getNumero()
        {
            return this.numero;
        }

        private double validarNumero(string numeroString)
        {
            double numero;

            if (double.TryParse(numeroString, out numero))
                return numero;
            else
                return 0;
        }

        public void Limpiar()
        {
            this.setNumero("0");
        }

        #endregion
    }
}
