using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion indicada entre los objetos Numero que recibe
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operacion o 0 en caso de division por 0</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;

            if (operador == "+")
                resultado = numero1.getNumero() + numero2.getNumero();

            else if (operador == "-")
                resultado = numero1.getNumero() - numero2.getNumero();

            else if (operador == "*")
                resultado = numero1.getNumero() * numero2.getNumero();

            else if ((operador == "/") && (numero2.getNumero() != 0))
                resultado = numero1.getNumero() / numero2.getNumero();

            return resultado;
        }

        /// <summary>
        /// Valida que el operador que recibe por parametro sea alguno de los esperados
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador ingresado si este es valido, en caso contrario retorna "+"</returns>
        public static string validarOperador(string operador)
        {
            if(operador != "+" && operador != "-" && operador != "*" && operador != "/")
                operador = "+";

            return operador;
        }
                        
    }
}
