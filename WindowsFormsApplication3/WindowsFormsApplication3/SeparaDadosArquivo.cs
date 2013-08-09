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
                    LinhasEmissor[i] = LinhasEmissor[i].Replace("'", "");

                    //Pega valores cortando pela vírgula
                    if (LinhasEmissor[i].Split(',')[0] == "")
                    {//Se for vazio, coloca N/D (Nao Disponivel)
                        Emissor[i, 0] = "N/D";
                    }
                    else
                    {
                        Emissor[i, 0] = LinhasEmissor[i].Split(',')[0];
                    }

                    if (LinhasEmissor[i].Split(',')[1] == "")
                    {//Se for vazio, coloca N/D (Nao Disponivel)
                        Emissor[i, 1] = "N/D";
                    }
                    else
                    {
                        Emissor[i, 1] = LinhasEmissor[i].Split(',')[1];
                    }

                    if (LinhasEmissor[i].Split(',')[2] == "")
                    {//Se for vazio, coloca N/D (Nao Disponivel)
                        Emissor[i, 2] = "N/D";
                    }
                    else
                    {
                        Emissor[i, 2] = LinhasEmissor[i].Split(',')[2];
                    }

                    if (LinhasEmissor[i].Split(',')[3] == "")
                    {//Se for vazio, coloca N/D (Nao Disponivel)
                        Emissor[i, 3] = "N/D";
                    }
                    else
                    {
                        Emissor[i, 3] = LinhasEmissor[i].Split(',')[3];
                    }

                    //Emissor[i, 0] = LinhasEmissor[i].Split(',')[0];
                    //Emissor[i, 1] = LinhasEmissor[i].Split(',')[1];
                    //Emissor[i, 2] = LinhasEmissor[i].Split(',')[2];
                    //Emissor[i, 3] = LinhasEmissor[i].Split(',')[3];
                }
                #endregion
            }
            catch (Exception Error)
            {
                VGlobal.LogLocal.Text += Convert.ToString(Error);
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
                VGlobal.LogLocal.Text += Convert.ToString(Error);
                VGlobal.RetornoFalha = true;
            }

            return Ativo;
        }

        public string[,] SeparaEspecie(string[] LinhasEspecie)
        {
            #region Variaveis
            //Variaveis
            string[,] Especie = new string[LinhasEspecie.Length, 2]; // 1 - Categoria, 2 - Sigla, 3 - Descricao, 4 -TipoAtivo, 5 - Sequencia1, 6 - Sequencia2
            #endregion


            try
            {
                #region Separacao
                for (int i = 0; i < LinhasEspecie.Length; i++)
                {
                    //Limpa as aspas do arquivo.
                    //LinhasAtivo[i] = LinhasAtivo[i].Replace("\"", String.Empty);
                    //LinhasAtivo[i] = LinhasAtivo[i].Replace(", ", " ");

                    //Pega valores cortando pela vírgula
                    Especie[i, 0] = LinhasEspecie[i].Split(',')[0];
                    Especie[i, 1] = LinhasEspecie[i].Split(',')[1];
                }
                #endregion
            }
            catch (Exception Error)
            {
                VGlobal.LogLocal.Text += Convert.ToString(Error);
                VGlobal.RetornoFalha = true;
            }

            return Especie;
        }
    }
}
