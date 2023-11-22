using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class IngresoAlClubException : Exception
    {
        public IngresoAlClubException(string? message) : base(message)
        {
        }

        public IngresoAlClubException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
