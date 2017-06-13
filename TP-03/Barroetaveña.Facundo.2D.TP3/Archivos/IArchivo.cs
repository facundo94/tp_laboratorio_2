using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        bool guardar(string archivo, T dato);
        bool leer(string archivo, out T dato);
    }
}
