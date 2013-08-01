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
        private static string Concat = "";              // String com todas as ocorrências concatenadas e separadas por '\n'
        static string[] Resultado = {""};
        private static int iarq = 0;
        private static Dictionary<string, List<string>> dict = new Dictionary<string,List<string>>();

        public static string[] Set(FileInfo[] ListaArquivos, string nodeOut)
        {
            // Carrega arquivos
            int nArq = ListaArquivos.Length;     // Numero de arquivos
            XmlDocument[] xmldoc = new XmlDocument[nArq];
            foreach(FileInfo arq in ListaArquivos) {
                xmldoc[iarq] = new XmlDocument();
                xmldoc[iarq].Load(arq.FullName);
                iarq++;
            }

            for (int i = 0; i < nArq - 1; i++)
            {
                XmlNode node = xmldoc[i].SelectSingleNode("//" + nodeOut);
                if (node != null)
                {
                    Concat = Concat + "\n" + node.InnerText;
                }
            }
            Concat = Concat.Remove(0, 1);       // Remove o primeiro '\n' da sequência
            Resultado = Concat.Split('\n');
            iarq = 0;
            return Resultado;
        }

        public static Dictionary<string, List<string>> Set(FileInfo[] ListaArquivos, string nodeOut, string commonNode)
        {
            // Carrega arquivos
            int nArq = ListaArquivos.Length;     // Numero de arquivos
            XmlDocument[] xmldoc = new XmlDocument[nArq];
            foreach (FileInfo arq in ListaArquivos)
            {
                xmldoc[iarq] = new XmlDocument();
                xmldoc[iarq].Load(arq.FullName);
                iarq++;
            }
            iarq = 0;

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
