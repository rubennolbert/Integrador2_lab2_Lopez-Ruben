using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extesiones
{
    public static class ClassExtendida
    {
        public static int CantidadDeDigitos(this int numero)
        {
            return numero.ToString().Length;
        }
    }
}
