using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lectura_Archivo_XML
{
    public class LeerXML
    {
        private XmlDocument docXML;
        public LeerXML(string filePath)
        {
            docXML = new XmlDocument();
            try
            {
                docXML.Load(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar el archivo XML: " + ex.Message);
            }
        }

        public void RecorrerXml()
        {
            XmlNode nodoRaiz = docXML.DocumentElement;
            LeerNodo(nodoRaiz);
        }

        private void LeerNodo(XmlNode node, int depth = 0)
        {
            string identacion = new string(' ', depth * 4);
            string nodoInfo = $"{identacion} Nodo: { node.Name} ";

            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                nodoInfo += " (Atributos: ";

                foreach (XmlAttribute atributo in node.Attributes)
                {
                    nodoInfo += $"{atributo.Name} = {atributo.Value} , ";
                }

                nodoInfo = nodoInfo.TrimEnd(',', ' ') + ")";
            }

            Console.WriteLine(nodoInfo);

            if (node.HasChildNodes)
            {
                foreach (XmlNode nodoHijo in node.ChildNodes)
                {
                    if (nodoHijo.NodeType == XmlNodeType.Element)
                    {
                        LeerNodo(nodoHijo, depth + 1);
                    }
                    else if (nodoHijo.NodeType == XmlNodeType.Text || nodoHijo.NodeType == XmlNodeType.CDATA)
                    {
                        Console.WriteLine($"{identacion} Contenido: {nodoHijo.Value.Trim()}");
                    }
                }
            }
        }
    }
}
