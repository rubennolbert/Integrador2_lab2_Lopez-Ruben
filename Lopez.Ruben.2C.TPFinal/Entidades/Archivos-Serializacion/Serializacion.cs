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

        public string RutaDeEscritura()
        {
            return $"{pathBase}";
        }
    }


}
