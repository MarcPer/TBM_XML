using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLBackOffice
{
    class SeparaDadosArquivo
    {
        public string[,] SeparaEmissor(string[] LinhasEmissor)
        {
            #region Variaveis
            //Variaveis
            string[,] Emissor = new string[LinhasEmissor.Length, 4]; // 1 - CodigoEmissor, 2 - NomeEmissor, 3 - CNPJEmissor, 4 -DataEmissor
            #endregion


            try
            {
                #region Separacao
                for (int i = 0; i < LinhasEmissor.Length; i++)
                {
                    //Limpa as aspas do arquivo.
                    LinhasEmissor[i] = LinhasEmissor[i].Replace("\"", String.Empty);
                    LinhasEmissor[i] = LinhasEmissor[i].Replace(", ", " ");

                    //Pega valores cortando pela vírgula
                    Emissor[i, 0] = LinhasEmissor[i].Split(',')[0];
                    Emissor[i, 1] = LinhasEmissor[i].Split(',')[1];
                    Emissor[i, 2] = LinhasEmissor[i].Split(',')[2];
                    Emissor[i, 3] = LinhasEmissor[i].Split(',')[3];
                }
                #endregion
            }
            catch (Exception Error)
            {
                ProcessoEmissor.LogLocal.Text += Convert.ToString(Error);
                VGlobal.RetornoFalha = true;
            }

            return Emissor;
        }

        public string[,] SeparaAtivo(string[] LinhasAtivo)
        {
            #region Variaveis
            //Variaveis
            string[,] Ativo = new string[LinhasAtivo.Length, 6]; // 1 - Categoria, 2 - Sigla, 3 - Descricao, 4 -TipoAtivo, 5 - Sequencia1, 6 - Sequencia2
            #endregion


            try
            {
                #region Separacao
                for (int i = 0; i < LinhasAtivo.Length; i++)
                {
                    //Limpa as aspas do arquivo.
                    //LinhasAtivo[i] = LinhasAtivo[i].Replace("\"", String.Empty);
                    //LinhasAtivo[i] = LinhasAtivo[i].Replace(", ", " ");

                    //Pega valores cortando pela vírgula
                    Ativo[i, 0] = LinhasAtivo[i].Split(',')[0];
                    Ativo[i, 1] = LinhasAtivo[i].Split(',')[1];
                    Ativo[i, 2] = LinhasAtivo[i].Split(',')[2];
                    Ativo[i, 3] = LinhasAtivo[i].Split(',')[3];
                    Ativo[i, 4] = LinhasAtivo[i].Split(',')[4];
                    Ativo[i, 5] = LinhasAtivo[i].Split(',')[5];
                }
                #endregion
            }
            catch (Exception Error)
            {
                ProcessoEmissor.LogLocal.Text += Convert.ToString(Error);
                VGlobal.RetornoFalha = true;
            }

            return Ativo;
        }
    }
}
