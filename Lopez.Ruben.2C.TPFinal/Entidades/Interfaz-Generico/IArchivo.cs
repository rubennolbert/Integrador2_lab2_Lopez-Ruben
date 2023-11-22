using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    internal interface IArchivo<T> where T : class
    {
        T Leer(string nombreArchivo);
        void Escribir(string nombreArchivo, T elemento);
    }
}
