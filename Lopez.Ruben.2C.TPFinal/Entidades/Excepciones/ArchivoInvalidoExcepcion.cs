using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class ArchivoInvalidoExcepcion : Exception
    {
        public ArchivoInvalidoExcepcion(string? message) : base(message)
        {
        }

        public ArchivoInvalidoExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
