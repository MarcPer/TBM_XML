using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//meus
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public static class CarregaChecaXML
    {
        // Variáveis
        private static int iarq = 0;

        public static XDocument[] XMLdocs(FileInfo[] ListaArquivos)
        {
            int nArq = ListaArquivos.Length;
            XDocument[] XMLdocs = new XDocument[nArq];
            foreach (FileInfo arq in ListaArquivos)
            {
                XMLdocs[iarq] = XDocument.Load(arq.FullName);
                iarq++;
            }
            iarq = 0;

            return XMLdocs;
        }
    }
}
