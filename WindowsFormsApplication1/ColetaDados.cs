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
    public class ColetaDados
    {
        // Variáveis
        private string Concat = "";              // String com todas as ocorrências concatenadas e separadas por '\n'
        string[] Resultado = {""};
        private int iarq = 0;

        public string[] Set(FileInfo[] ListaArquivos, string nodeOut)
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
            return Resultado;
        }

        
    }
}
