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

namespace XMLBackOffice
{
        
        class ProcessoEmissor
        {
            public void GerenciaProcessoCadastroEmissor()
            {
                #region Variaveis
                string[] LinhasEmissor;
                string[,] Emissor;
                VGlobal.RetornoFalha = false;
                VGlobal.LogLocal.Text = "";

                #endregion

                #region AbreArquivo - Emissor.txt
                AbreArquivo obAbreArquivo = new AbreArquivo();
                LinhasEmissor = obAbreArquivo.AbreTXT(VGlobal.EndEmissor);
                if (VGlobal.RetornoFalha != false)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura do EMISSOR.txt. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGEmissor;
                }
                #endregion

                #region SeparaDadosArquivo - Emissor.txt
                SeparaDadosArquivo obSeparaDadosArquivo = new SeparaDadosArquivo();
                Emissor = obSeparaDadosArquivo.SeparaEmissor(LinhasEmissor);
                if (VGlobal.RetornoFalha != false)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura de separação dos dados do Arquivo. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGEmissor;
                }
                #endregion

                #region SQL - Emissor.txt
                SQLXML obSQLXML = new SQLXML();
                obSQLXML.CadastraEmissor(Emissor);
                if (VGlobal.RetornoFalha == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro no SQL. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGEmissor;
                }
                #endregion
            PulaGravaLOGEmissor:

                GravaLog(VGlobal.LogLocal);

            }

            public string[,] GerenciaProcessoConsultaEmissor(string CodigoEmissor, string NomeEmissor, string CNPJEmissor, string DataEmissor)
            {
                #region Variáveis
                //variaveis
                VGlobal.RetornoFalha = false;
                string[,] Emissor;
                DataTable dataTable = new DataTable();
                SQLXML Consulta = new SQLXML();
                VGlobal.LogLocal.Text = "";
                #endregion

                try
                {

                    dataTable = Consulta.ConsultaEmissor(VGlobal.TabelaEmissor, VGlobal.CamposTabelaEmissor[0], CodigoEmissor, VGlobal.CamposTabelaEmissor[1], NomeEmissor, VGlobal.CamposTabelaEmissor[2], CNPJEmissor, VGlobal.CamposTabelaEmissor[3], DataEmissor);

                }
                catch (Exception e)
                {
                    VGlobal.rtLOG.Text += e.ToString();
                    VGlobal.RetornoFalha = true;
                }

                if (VGlobal.RetornoFalha == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Falha na consulta do Emissor!", "ERROR", MessageBoxButtons.OK);
                    VGlobal.LogLocal.Text += "Falha na consulta do Emissor: \r\nCodigo:" + CodigoEmissor + "\r\nNome:" + NomeEmissor + "\r\nCNPJ:" + CNPJEmissor + "\r\nData:" + DataEmissor + "\r\n";
                    Emissor = null;
                    dataTable = null;
                }
                else
                {
                    Emissor = new string[dataTable.Rows.Count, 4];

                    if (dataTable.Rows.Count != 0)
                    {
                        VGlobal.LogLocal.Text += "Total de colunas pesquisadas: " + dataTable.Rows.Count + "\r\n";
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Emissor[i, 0] = dataTable.Rows[i][0].ToString();
                            Emissor[i, 1] = dataTable.Rows[i][1].ToString();
                            Emissor[i, 2] = dataTable.Rows[i][2].ToString();
                            Emissor[i, 3] = dataTable.Rows[i][3].ToString();
                        }
                    }
                    else
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Não foram encontrados resultados para esta busca!", "ERROR", MessageBoxButtons.OK);
                        VGlobal.rtLOG.Text += "Não foram encontrados resultados para esta busca:\r\nCodigo:" + CodigoEmissor + "\r\nNome:" + NomeEmissor + "\r\nCNPJ:" + CNPJEmissor + "\r\nData:" + DataEmissor + "\r\n";
                        VGlobal.RetornoFalha = true;
                    }
                }

                GravaLog(VGlobal.LogLocal);
                return Emissor;


            }

            public static void GravaLog(RichTextBox Log)
            {
                #region GravaLOG
                ////Grava no LOG textBox
                File.AppendAllText(VGlobal.LOGEmissor, Log.Text);
                #endregion
            }

        }

        class ProcessoAtivo
        {
            public string[,] GerenciaProcessoConsultaAtivo(string ConsultaCategoria, string ConsultaSigla, string ConsultaDescricao, string ConsultaTipo, string ConsultaSeq1, string ConsultaSeq2)
            {
                #region Variáveis
                //variaveis
                VGlobal.RetornoFalha = false;
                string[,] Ativo;
                DataTable dataTable = new DataTable();
                SQLXML Consulta = new SQLXML();
                VGlobal.LogLocal.Text = "";
                #endregion

                try
                {

                    dataTable = Consulta.ConsultaAtivo(VGlobal.TabelaAtivo, VGlobal.CamposTabelaAtivo[0], ConsultaCategoria, VGlobal.CamposTabelaAtivo[1], ConsultaSigla, VGlobal.CamposTabelaAtivo[2], ConsultaDescricao, VGlobal.CamposTabelaAtivo[3], ConsultaTipo, VGlobal.CamposTabelaAtivo[4], ConsultaSeq1, VGlobal.CamposTabelaAtivo[5], ConsultaSeq2);

                }
                catch (Exception e)
                {
                    VGlobal.rtLOG.Text += e.ToString();
                    VGlobal.RetornoFalha = true;
                }

                if (VGlobal.RetornoFalha == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Falha na consulta do Emissor!", "ERROR", MessageBoxButtons.OK);
                    VGlobal.LogLocal.Text += "Falha na consulta do Emissor: \r\nCategoria:" + ConsultaCategoria + "\r\nSigla:" + ConsultaSigla + "\r\nDescricao:" + ConsultaDescricao + "\r\nTipo:" + ConsultaTipo + "\r\n";
                    Ativo = null;
                    dataTable = null;
                }
                else
                {
                    Ativo = new string[dataTable.Rows.Count, 6];

                    if (dataTable.Rows.Count != 0)
                    {
                        VGlobal.LogLocal.Text += "Total de colunas pesquisadas: " + dataTable.Rows.Count + "\r\n";
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Ativo[i, 0] = dataTable.Rows[i][0].ToString();
                            Ativo[i, 1] = dataTable.Rows[i][1].ToString();
                            Ativo[i, 2] = dataTable.Rows[i][2].ToString();
                            Ativo[i, 3] = dataTable.Rows[i][3].ToString();
                            Ativo[i, 4] = dataTable.Rows[i][4].ToString();
                            Ativo[i, 5] = dataTable.Rows[i][5].ToString();
                        }
                    }
                    else
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Não foram encontrados resultados para esta busca!", "ERROR", MessageBoxButtons.OK);
                        VGlobal.rtLOG.Text += "Não foram encontrados resultados para esta busca:\r\nCategoria:" + ConsultaCategoria + "\r\nSigla:" + ConsultaSigla + "\r\nDescricao:" + ConsultaDescricao + "\r\nTipo:" + ConsultaTipo + "\r\n";
                        VGlobal.RetornoFalha = true;
                    }
                }

                GravaLog(VGlobal.LogLocal);
                return Ativo;


            }

            public static void GravaLog(RichTextBox Log)
            {
                #region GravaLOG
                ////Grava no LOG textBox
                File.AppendAllText(VGlobal.LOGAtivo, Log.Text);
                #endregion
            }

            public void GerenciaProcessoCadastroTipoAtivo()
            {
                #region Variaveis
                string[] LinhasAtivo;
                string[,] Ativo;
                VGlobal.RetornoFalha = false;
                VGlobal.LogLocal.Text = "";

                #endregion

                #region AbreArquivo - Ativo.txt
                AbreArquivo obAbreArquivo = new AbreArquivo();
                LinhasAtivo = obAbreArquivo.AbreTXT(VGlobal.EndAtivo);
                if (VGlobal.RetornoFalha != false)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura do TIPOATIVO.txt. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGAtivo;
                }
                #endregion

                #region SeparaDadosArquivo - Ativo.txt
                SeparaDadosArquivo obSeparaDadosArquivo = new SeparaDadosArquivo();
                Ativo = obSeparaDadosArquivo.SeparaAtivo(LinhasAtivo);
                if (VGlobal.RetornoFalha != false)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura de separação dos dados do Arquivo. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGAtivo;
                }
                #endregion

                #region SQL - TipoAtivo.txt
                SQLXML obSQLXML = new SQLXML();
                obSQLXML.CadastraAtivo(Ativo);
                if (VGlobal.RetornoFalha == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro no SQL. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGAtivo;
                }
                #endregion
            PulaGravaLOGAtivo:

                GravaLog(VGlobal.LogLocal);

            }
        }

        class ProcessoEspecie
        {
            public string[,] GerenciaProcessoConsultaEspecie(string ConsultaDescricao, string ConsultaCodigo)
            {
                #region Variáveis
                //variaveis
                VGlobal.RetornoFalha = false;
                string[,] Especie;
                DataTable dataTable = new DataTable();
                SQLXML Consulta = new SQLXML();
                VGlobal.LogLocal.Text = "";
                #endregion

                try
                {

                    dataTable = Consulta.ConsultaEspecie(VGlobal.TabelaEspecie, VGlobal.CamposTabelaEspecie[0], ConsultaDescricao, VGlobal.CamposTabelaEspecie[1], ConsultaCodigo);

                }
                catch (Exception e)
                {
                    VGlobal.rtLOG.Text += e.ToString();
                    VGlobal.RetornoFalha = true;
                }

                if (VGlobal.RetornoFalha == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Falha na consulta do Emissor!", "ERROR", MessageBoxButtons.OK);
                    VGlobal.LogLocal.Text += "Falha na consulta do Emissor: \r\nDescricao:" + ConsultaDescricao + "\r\nCodigo:" + ConsultaCodigo + "\r\n";
                    Especie = null;
                    dataTable = null;
                }
                else
                {
                    Especie = new string[dataTable.Rows.Count, 2];

                    if (dataTable.Rows.Count != 0)
                    {
                        VGlobal.LogLocal.Text += "Total de colunas pesquisadas: " + dataTable.Rows.Count + "\r\n";
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Especie[i, 0] = dataTable.Rows[i][0].ToString();
                            Especie[i, 1] = dataTable.Rows[i][1].ToString();
                        }
                    }
                    else
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Não foram encontrados resultados para esta busca!", "ERROR", MessageBoxButtons.OK);
                        VGlobal.rtLOG.Text += "Não foram encontrados resultados para esta busca:\r\nDescricao:" + ConsultaDescricao + "\r\nCodigo:" + ConsultaCodigo + "\r\n";
                        VGlobal.RetornoFalha = true;
                    }
                }

                GravaLog(VGlobal.LogLocal);
                return Especie;


            }

            public static void GravaLog(RichTextBox Log)
            {
                #region GravaLOG
                ////Grava no LOG textBox
                File.AppendAllText(VGlobal.LOGEspecie, Log.Text);
                #endregion
            }

            public void GerenciaProcessoCadastroEspecie()
            {
                #region Variaveis
                string[] LinhasEspecie;
                string[,] Especie;
                VGlobal.RetornoFalha = false;
                VGlobal.LogLocal.Text = "";

                #endregion

                #region AbreArquivo - Especie.txt
                AbreArquivo obAbreArquivo = new AbreArquivo();
                LinhasEspecie = obAbreArquivo.AbreTXT(VGlobal.EndEspecie);
                if (VGlobal.RetornoFalha != false)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura do ESPECIE.txt. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGEspecie;
                }
                #endregion

                #region SeparaDadosArquivo - Especie.txt
                SeparaDadosArquivo obSeparaDadosArquivo = new SeparaDadosArquivo();
                Especie = obSeparaDadosArquivo.SeparaEspecie(LinhasEspecie);
                if (VGlobal.RetornoFalha != false)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura de separação dos dados do Arquivo. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGEspecie;
                }
                #endregion

                #region SQL - Especie.txt
                SQLXML obSQLXML = new SQLXML();
                obSQLXML.CadastraEspecie(Especie);
                if (VGlobal.RetornoFalha == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro no SQL. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGEspecie;
                }
                #endregion
            PulaGravaLOGEspecie:

                GravaLog(VGlobal.LogLocal);

            }
        }

}

