using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroetaveña.facundo.TP1
{
    class Calculadora
    {  

        public double Operar(Numero numero1, Numero numero2, string operador)
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
        
        
    }
}
