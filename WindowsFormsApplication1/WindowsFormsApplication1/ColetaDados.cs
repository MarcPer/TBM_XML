using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//meus
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Procura e extrai conteúdo de etiquetas específicas de arquivos XML.
    /// </summary>
    public static class ColetaDados
    {
        // Variáveis
        private static int iarq = 0;
        private static List<string> lista = new List<string>();
        private static Dictionary<string, List<string>> dict = new Dictionary<string,List<string>>();

        /// <summary>
        /// Retorna lista com conteúdo de etiquetas com nome 'nodeOut'
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <param name="nodeOut"></param>
        /// <returns></returns>
        public static List<string> Set(XmlDocument[] xmldoc, string nodeOut)
        {
            int nArq = xmldoc.Length;
            for (int i = 0; i < nArq - 1; i++)
            {
                XmlNode node = xmldoc[i].SelectSingleNode("//" + nodeOut);
                if (node != null) {lista.Add(node.InnerText);}
            }
            return lista;
        }

        public static Dictionary<string, List<string>> Set(XmlDocument[] xmldoc, string nodeOut, string commonNode)
        {
            int nArq = xmldoc.Length;
            for (int i = 0; i < nArq - 1; i++)
            {
                XmlNodeList nodes = xmldoc[i].SelectNodes("//carteira/*");
                foreach (XmlNode node in nodes)
                {
                    string loc_key, loc_value;

                    // O nó comum existe? Se não, considerar como vazio.
                    if (node[commonNode] != null)
                    {
                        loc_key = node[commonNode].InnerText;
                    }
                    else
                    {
                        loc_key = "vazio";
                    }
                    
                    // O nó de saída existe no contexto atual? Se não, não fazer nada.
                    if (node[nodeOut] != null)
                    {
                        loc_value = node[nodeOut].InnerText;
                        List<string> tmp_valList;

                        if (dict.TryGetValue(loc_key, out tmp_valList))
                        {
                            dict[loc_key].Add(loc_value);
                        }
                        else
                        {
                            dict[loc_key] = new List<string>();
                            dict[loc_key].Add(loc_value);
                        }
                    }
                }
            }
           
            return dict;
        }
        
    }
}
