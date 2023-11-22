using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public  class CampoVacioException :Exception
    {
        public CampoVacioException(string? message) : base(message)
        {
        }

        public CampoVacioException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
