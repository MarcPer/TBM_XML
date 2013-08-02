﻿using System;
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
    class ManipulaDados
    {
        public string Dados()
        {

            string[] teste = ColetaDados.Set(VGlobal.ListaArquivos, "cnpjcpf");
            Dictionary<string, List<string>> teste2 = ColetaDados.Set(VGlobal.ListaArquivos, "isin", "codativo");
            int a = 0;
            

            #region Variaveis
            //Variaveis Gerais
            int i = 0;
            string Retorno = "false";
            string stErro = null;
            string[] carteira;



            #endregion

            try
            {

                #region Levantamento dos dados XML

                //Abre arquivo
                foreach (FileInfo ArquivosXML in VGlobal.ListaArquivos)
                {
                    #region Header
                    carteira = ManipulaDados_Header.cnpjcpf(ArquivosXML);
                    #endregion


                    i++; //passa para proximo arquivo
                }

                #endregion

                #region Processamento dos dados XML


                #endregion

            }
            catch (Exception MsgErro)
            {
                stErro = Convert.ToString(MsgErro);
                Retorno = "true";
                VGlobal.rtLOG.Text += stErro;
                goto SaiFuncao;
            }

        SaiFuncao:

            #region Retorno
            VGlobal.rtLOG.Text += "===========================================================================\r\n";//Separação de arquivos XML no LOG.
            VGlobal.rtLOG.Text += "Fim do levantamento do XML. Funcao ManipulaDaods.Dados retornou: " + Retorno + "\r\n";
            VGlobal.rtLOG.Text += "===========================================================================\r\n";//Separação de arquivos XML no LOG.
            return "false";
            #endregion



        }
    }
}

