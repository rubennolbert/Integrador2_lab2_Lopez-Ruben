using Entidades.Excepciones;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Archivos_Serializacion
{
    public class ArchivoTXT : GestionArchivos, IArchivo<string>
    {
        public ArchivoTXT() : base(ETipo.TXT) { }

        public void Escribir(string nombreArchivo, string contenido)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter($"{pathBase}\\{nombreArchivo}"))
                {
                    streamWriter.WriteLine(contenido);
                }
            }
            catch (Exception e)
            {
                throw new ArchivoInvalidoExcepcion("Error en intento de escriir archivo", e);
            }
        }

        public string Leer(string nombreArchivo)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader($"{pathBase}\\{nombreArchivo}\\"))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new ArchivoInvalidoExcepcion("Error en lectura de archivo", e);
            }
        }

        public string PathEscritura() { return $"{pathBase}";  }
       

    }
}
