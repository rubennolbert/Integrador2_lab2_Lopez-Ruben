using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Archivos_Serializacion
{
    public abstract class GestionArchivos
    {
        public enum ETipo { TXT, XML}

        protected string? pathBase;
        protected ETipo tipo;

        protected GestionArchivos(ETipo tipo)
        {
            DirectoryInfo path;
            if(tipo == ETipo.TXT)
            {
                path = Directory.CreateDirectory($"{Environment.CurrentDirectory}\\EstadosDeCuenta\\"); //probar getCurrentDirectory
            }
            else
            {
                path = Directory.CreateDirectory($"{Environment.CurrentDirectory}\\ListaSociosBackUp");
            }
            pathBase = path.FullName;
            this.tipo = tipo;
        }
    }
}
