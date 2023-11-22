using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class FechaNacimientoInvalidaException : Exception
    {
        public FechaNacimientoInvalidaException(string? message) : base(message)
        {
        }

        public FechaNacimientoInvalidaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
