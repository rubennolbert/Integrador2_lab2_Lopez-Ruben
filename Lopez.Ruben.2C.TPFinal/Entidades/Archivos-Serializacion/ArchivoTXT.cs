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



        /// <summary>
        /// Recibe un string con el contenido a guardar y utilizando un StreamWriter escribe un archivo .txt en la ruta que tiene definida en
        /// la clase madre y con el nombre que recibe como string. 
        /// Si no se pudo escribir el archivo, arroja una exception. Y al final cierra el StreamWriter
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        /// <exception cref="ArchivoInvalidoException"></exception>
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
                throw new ArchivoInvalidoException("Error en intento de escriir archivo", e);
            }
        }

        /// <summary>
        /// Recibe un string con la ubicacion y nombre de un archivo y utilizando StreamReader intenta leer el contenido y
        /// de ser posible guardarlo en un string, si no se pudo arroja exception.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        /// <exception cref="ArchivoInvalidoException"></exception>
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
                throw new ArchivoInvalidoException("Error en lectura de archivo", e);
            }
        }


        /// <summary>
        /// Retorna en un string la ruta donde se guardan los archivos
        /// </summary>
        /// <returns></returns>
        public string PathEscritura() { return $"{pathBase}";  }
       

    }
}
