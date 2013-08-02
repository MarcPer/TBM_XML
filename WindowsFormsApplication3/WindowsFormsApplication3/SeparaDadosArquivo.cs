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
        public string[,] Separa(string[] LinhasEmissor)
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
    }
}
