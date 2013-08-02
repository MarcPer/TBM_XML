using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//meus
using System.Xml;
using System.IO;

namespace WindowsFormsApplication1
{
    class Programa
    {
        public void GerenciaProcesso()
        {
            //Variáveis Gerais
            string PastaXML = "c:\\Users\\MarceloP\\Documents\\Visual Studio 2012\\Projects\\XML_files";
            VGlobal.rtLOG = new RichTextBox();

            //Inicializa variáveis de relatorio
            //VGlobal.stInformacoesGerais rlInformacoesGerais = new VGlobal.stInformacoesGerais();
            //VGlobal.stFundosInvestimento rlFundosInvestimento = new VGlobal.stFundosInvestimento();
            //VGlobal.stCreditoPrivado rlCreditoPrivado = new VGlobal.stCreditoPrivado();
            //VGlobal.stTituloPublico rlTitPublico = new VGlobal.stTituloPublico();

            
            ManipulaXML obManipulaXML = new ManipulaXML();
            if (obManipulaXML.Arquivo() != "false")
            {
                DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura do arquivo XML. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                goto PulaGravaLOG;
            }


            ManipulaDados obManipulaDados = new ManipulaDados();
            if (obManipulaDados.Dados() != "false")
            {
                DialogResult dialogResult = MessageBox.Show("Encontrado erro na manipulação dos dados. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                goto PulaGravaLOG;
            }

        PulaGravaLOG: // Em caso de erro grave nos arquivos XML, finaliza programa
            #region GravaLOG
            ////Grava no LOG textBox
            System.IO.File.WriteAllText(PastaXML + "LOG.rtf", VGlobal.rtLOG.Text);
            #endregion
        }

    }


}
