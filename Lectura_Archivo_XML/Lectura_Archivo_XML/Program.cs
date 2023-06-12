using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Lectura_Archivo_XML
{
    public class Program
    {
        static void Main(string[] args)
        {
            string rutaArchivo = "D:/Trabajo/Ejercicios/Configuraciones.xml";


            LeerXML xmlReader = new LeerXML(rutaArchivo);
            xmlReader.RecorrerXml();

            Console.ReadKey();
        }

        
    }

}