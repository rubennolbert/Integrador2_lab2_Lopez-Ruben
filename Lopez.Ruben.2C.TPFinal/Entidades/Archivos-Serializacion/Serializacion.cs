using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades.Interfaces;
using Entidades.Excepciones;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades.Archivos_Serializacion
{
    public class Serializacion<T> : GestionArchivos, IArchivo<T> where T : class, new()
    {
        public Serializacion(ETipo tipo) : base(tipo) { }

        /// <summary>
        /// Recibe un objeto generico y utilizando un XmlTextWriter escribe un archivo xml en la ruta que tiene definida en
        /// la clase madre y con el nombre que recibe como string.
        /// Si el nombre del archivo no tiene la extension .xml arroja una exception.         
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="elemento"></param>
        /// <exception cref="ArchivoInvalidoException"></exception>
        public void Escribir(string nombreArchivo, T elemento)
        {
            try
            {
                if (Path.GetExtension(nombreArchivo) == ".xml")
                {
                    using (XmlTextWriter xmlTextWriter = new XmlTextWriter($"{pathBase}\\{nombreArchivo}", Encoding.UTF8))
                    {
                        xmlTextWriter.Formatting = Formatting.Indented;
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        serializer.Serialize(xmlTextWriter, elemento);
                    }
                }
                else
                {
                    throw new ArchivoInvalidoException("Extension invalida, se esperaba XML");
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoInvalidoException("Error al Serializar", ex);
            }
        }

        /// <summary>
        /// Recibe un nombre de archivo y utilizando XmlTextReader intenta leerlo y convertirlo a un objeto.
        /// Si el nombre del archivo no tiene la extension .xml arroja una exception.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        /// <exception cref="ArchivoInvalidoException"></exception>
        public T Leer(string nombreArchivo)
        {
            try
            {
                if (Path.GetExtension(nombreArchivo) == ".xml")
                {
                    using (XmlTextReader xmlTextReader = new XmlTextReader($"{pathBase}\\{nombreArchivo}"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        return serializer.Deserialize(xmlTextReader) as T;
                    }
                }
                else
                {
                    throw new ArchivoInvalidoException("Extension invalida, se esperaba XML");
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoInvalidoException("Error al DesSerializar", ex);
            }
        }

        /// <summary>
        /// Retorna en un string la ruta donde se guardan los archivos
        /// </summary>
        /// <returns></returns>
        public string RutaDeEscritura()
        {
            return $"{pathBase}";
        }
    }


}
