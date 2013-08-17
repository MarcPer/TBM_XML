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

                Generico.GravarLOG(VGlobal.LOGEmissor, VGlobal.LogLocal);

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
                string LinhaComandoSQL;
                #endregion

                try
                {
                    LinhaComandoSQL = "SELECT * FROM " + VGlobal.TabelaEmissor + " where " + VGlobal.CamposTabelaEmissor[0] + " LIKE \'%" + CodigoEmissor + "%\' and " + VGlobal.CamposTabelaEmissor[1] + " LIKE \'%" + NomeEmissor + "%\' and " + VGlobal.CamposTabelaEmissor[2] + " LIKE \'%" + CNPJEmissor + "%\' and " + VGlobal.CamposTabelaEmissor[3] + " LIKE \'%" + DataEmissor + "%\' ;";
                    dataTable = Consulta.ConsultaGenerica(LinhaComandoSQL);

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

                Generico.GravarLOG(VGlobal.LOGEmissor, VGlobal.LogLocal);
                return Emissor;
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
                string LinhaComandoSQL;
                #endregion

                try
                {
                    LinhaComandoSQL = "SELECT * FROM " + VGlobal.TabelaAtivo + " where " + VGlobal.CamposTabelaAtivo[0] + " LIKE \'%" + ConsultaCategoria + "%\' and " + VGlobal.CamposTabelaAtivo[1] + " LIKE \'%" + ConsultaSigla + "%\' and " + VGlobal.CamposTabelaAtivo[2] + " LIKE \'%" + ConsultaDescricao + "%\' and " + VGlobal.CamposTabelaAtivo[3] + " LIKE \'%" + ConsultaTipo + "%\' and " + VGlobal.CamposTabelaAtivo[4] + " LIKE \'%" + ConsultaSeq1 + "%\' and " + VGlobal.CamposTabelaAtivo[5] + " LIKE \'%" + ConsultaSeq2 + "%\';";
                    //"SELECT * FROM " + TabelaAtivo + " where " + ConsultaCategoriaTabelaAtivo + " LIKE \'%" + ConsultaCategoria + "%\' and " + ConsultaSiglaTabelaAtivo + " LIKE \'%" + ConsultaSigla + "%\' and " + ConsultaDescricaoTabelaAtivo + " LIKE \'%" + ConsultaDescricao + "%\' and " + ConsultaTipoTabelaAtivo + " LIKE \'%" + ConsultaTipo + "%\' and " + ConsultaSeq1TabelaAtivo + " LIKE \'%" + ConsultaSeq1 + "%\' and " + ConsultaSeq2TabelaAtivo + " LIKE \'%" + ConsultaSeq2 + "%\';"
                    dataTable = Consulta.ConsultaGenerica(LinhaComandoSQL);

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

                Generico.GravarLOG(VGlobal.LOGAtivo, VGlobal.LogLocal);
                return Ativo;


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

                Generico.GravarLOG(VGlobal.LOGAtivo, VGlobal.LogLocal);

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
                string LinhaComandoSQL;
                #endregion

                try
                {
                    LinhaComandoSQL = "SELECT * FROM " + VGlobal.TabelaEspecie + " where " + VGlobal.CamposTabelaEspecie[0] + " LIKE \'%" + ConsultaDescricao + "%\' and " + VGlobal.CamposTabelaEspecie[1] + " LIKE \'%" + ConsultaCodigo + "%\';";
                    dataTable = Consulta.ConsultaGenerica(LinhaComandoSQL);
                    
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

                Generico.GravarLOG(VGlobal.LOGEspecie, VGlobal.LogLocal);
                return Especie;


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

                Generico.GravarLOG(VGlobal.LOGEspecie, VGlobal.LogLocal);

            }
        }

        class ProcessoIndexador
        {
            public string[,] GerenciaProcessoConsultaIndexador(string XML_Indexador, string Relatorio_Indexador, string Descricao_Indexador)
            {
                #region Variáveis
                //variaveis
                VGlobal.RetornoFalha = false;
                string[,] Indexador;
                DataTable dataTable = new DataTable();
                SQLXML Consulta = new SQLXML();
                VGlobal.LogLocal.Text = "";
                string LinhaComandoSQL;
                #endregion

                try
                {
                    LinhaComandoSQL = "SELECT * FROM " + VGlobal.TabelaIndexador + " where " + VGlobal.CamposTabelaIndexador[0] + " LIKE \'%" + XML_Indexador + "%\' and " + VGlobal.CamposTabelaIndexador[1] + " LIKE \'%" + Relatorio_Indexador + "%\' and " + VGlobal.CamposTabelaIndexador[2] + " LIKE \'%" + Descricao_Indexador + "%\' ;";
                    dataTable = Consulta.ConsultaGenerica(LinhaComandoSQL);
                }
                catch (Exception e)
                {
                    VGlobal.rtLOG.Text += e.ToString();
                    VGlobal.RetornoFalha = true;
                }

                if (VGlobal.RetornoFalha == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Falha na consulta do Indexador!", "ERROR", MessageBoxButtons.OK);
                    VGlobal.LogLocal.Text += "Falha na consulta do Emissor: \r\nXML:" + XML_Indexador + "\r\nRelatorio:" + Relatorio_Indexador + "\r\nDescricao:" + Descricao_Indexador + "\r\n";
                    Indexador = null;
                    dataTable = null;
                }
                else
                {
                    Indexador = new string[dataTable.Rows.Count, 3];

                    if (dataTable.Rows.Count != 0)
                    {
                        VGlobal.LogLocal.Text += "Total de colunas pesquisadas: " + dataTable.Rows.Count + "\r\n";
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Indexador[i, 0] = dataTable.Rows[i][0].ToString();
                            Indexador[i, 1] = dataTable.Rows[i][1].ToString();
                            Indexador[i, 2] = dataTable.Rows[i][2].ToString();
                        }
                    }
                    else
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Não foram encontrados resultados para esta busca!", "ERROR", MessageBoxButtons.OK);
                        VGlobal.rtLOG.Text += "Não foram encontrados resultados para esta busca:\r\nXML:" + XML_Indexador + "\r\nRelatorio:" + Relatorio_Indexador + "\r\nDescricao:" + Descricao_Indexador + "\r\n";
                        VGlobal.RetornoFalha = true;
                    }
                }

                Generico.GravarLOG(VGlobal.LOGIndexador, VGlobal.LogLocal);
                return Indexador;


            }

            public void GerenciaProcessoCadastroIndexador()
            {
                #region Variaveis
                string[] LinhasIndexador;
                string[,] Indexador;
                VGlobal.RetornoFalha = false;
                VGlobal.LogLocal.Text = "";

                #endregion

                #region AbreArquivo - Indexador.txt
                AbreArquivo obAbreArquivo = new AbreArquivo();
                LinhasIndexador = obAbreArquivo.AbreTXT(VGlobal.EndIndexador);
                if (VGlobal.RetornoFalha != false)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura do Indexador.txt. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGIndexador;
                }
                #endregion

                #region SeparaDadosArquivo - Indexador.txt
                SeparaDadosArquivo obSeparaDadosArquivo = new SeparaDadosArquivo();
                Indexador = obSeparaDadosArquivo.SeparaIndexador(LinhasIndexador);
                if (VGlobal.RetornoFalha != false)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura de separação dos dados do Arquivo. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGIndexador;
                }
                #endregion

                #region SQL - Especie.txt
                SQLXML obSQLXML = new SQLXML();
                obSQLXML.CadastraIndexador(Indexador);
                if (VGlobal.RetornoFalha == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro no SQL. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                    goto PulaGravaLOGIndexador;
                }
                #endregion
            PulaGravaLOGIndexador:

                Generico.GravarLOG(VGlobal.LOGIndexador, VGlobal.LogLocal);
            }
        }

        public static class Generico
        {//Colocar funcoes genericas aqui que precisam estar dentro de uma classe

            public static void GravarLOG(string NomeArquivo, RichTextBox Conteudo)
            {//Funcao para gravar log no arquivo
                #region GravaLOG
                ////Grava no LOG textBox
                File.AppendAllText(NomeArquivo, Conteudo.Text);
                #endregion
            }
        }
}

