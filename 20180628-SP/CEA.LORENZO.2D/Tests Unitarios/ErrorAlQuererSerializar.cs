using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Entidades;
using System.Collections.Generic;

namespace Tests_Unitarios
{
    [TestClass]
    public class ErrorAlQuererSerializar
    {
        [TestMethod]
        [ExpectedException(typeof(ErrorArchivoException))]
        public void ReferenciaNulaXML()
        {
            Votacion votacion = null;
            SerializarXML<Votacion> xml = new SerializarXML<Votacion>();

            xml.Guardar("Test.xml", votacion);
        }

        [TestMethod]
        public void ObjetoCorrectamenteInstanciadoXML()
        {
            Dictionary<string, Votacion.EVoto> listado = new Dictionary<string, Votacion.EVoto>();
            for (int i = 1; i <= 72; i++)
            {
                listado.Add(i.ToString(), Votacion.EVoto.Esperando);
            }
            Votacion votacion = new Votacion("test", listado);
            
        }
    }
}
