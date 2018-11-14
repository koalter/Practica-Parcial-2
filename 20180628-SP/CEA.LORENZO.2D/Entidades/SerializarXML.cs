using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Entidades
{
    public class SerializarXML<T> : IArchivos<T>
    {
        public bool Guardar(string rutaArchivo, T objeto)
        {
            if (objeto != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(rutaArchivo, Encoding.UTF8);

                serializer.Serialize(writer, objeto);

                writer.Close();
                return true;
            }
            else
            {
                throw new ErrorArchivoException("Error al generar el archivo.");
            }
        }

        public T Leer(string rutaArchivo)
        {
            T obj;

            if (File.Exists(rutaArchivo))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextReader reader = new XmlTextReader(rutaArchivo);

                obj = (T)serializer.Deserialize(reader);

                reader.Close();

                return obj;
            }
            else
            {
                throw new ErrorArchivoException("Error al leer el archivo.");
            }
        }
    }
}
