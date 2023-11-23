using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class IngresoAlBoxException : Exception
    {
        public IngresoAlBoxException(string? message) : base(message)
        {
        }

        public IngresoAlBoxException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
