using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace XMLBackOffice
{
    class SQLXML
    {
        #region EMISSOR
        //EMISSOR
        public DataTable ConsultaEmissor(string TabelaEmissor, string CodigoEmissorTabelaEmissor, string CodigoEmissor, string NomeEmissorTabelaEmissor, string NomeEmissor, string CNPJEmissorTabelaEmissor, string CNPJEmissor, string DataEmissorTabelaEmissor, string DataEmissor)
        {

            #region Variáveis
            //variaveis
            DataTable dataTable = new DataTable();
            SqlConnection mySQLConnection = new SqlConnection(VGlobal.ParamConexSQL);
            SqlCommand myCommand = new SqlCommand("SELECT * FROM " + TabelaEmissor + " where " + CodigoEmissorTabelaEmissor + " LIKE \'%" + CodigoEmissor + "%\' and " + NomeEmissorTabelaEmissor + " LIKE \'%" + NomeEmissor + "%\' and " + CNPJEmissorTabelaEmissor + " LIKE \'%" + CNPJEmissor + "%\' and " + DataEmissorTabelaEmissor + " LIKE \'%" + DataEmissor + "%\' ;", mySQLConnection);
            //SELECT * FROM XMLProj.dbo.Emissor_Titulo where CNPJ_EMISSOR = '0164159';
            //"SELECT * FROM " + OQue + " where " + DeOnde + " = \'" + Valor + "\';"
            //column1 LIKE '%word1%'
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            #endregion

            try
            {

                mySQLConnection.Open();

                da.Fill(dataTable); //preenche tabela

                da.Dispose();
                mySQLConnection.Close();
            }
            catch (Exception e)
            {
                VGlobal.RetornoFalha = true;
                VGlobal.LogLocal.Text += e.ToString();
                dataTable = null;
            }

            return dataTable;
        }

        public void CadastraEmissor(string[,] Emissor)
        {
            #region Variáveis
            //variaveis
            SqlConnection mySQLConnection = new SqlConnection(VGlobal.ParamConexSQL);
            int ContadorEmissorCadastrado = 0;
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

            //limpa base de dados de Emissor - retirar tudo e acrescenta denovo os novos valores - evita lixo na BD
            SqlCommand myCommandDelete = new SqlCommand("DELETE FROM " + VGlobal.TabelaEmissor, mySQLConnection); //define a linha de comando
            myCommandDelete.ExecuteNonQuery();//executa a linha de comando que não possui retorno


            for (int i = 0; i < Emissor.GetUpperBound(0) + 1; i++)
            {
                #region LOOP
                try
                {
                    if (Emissor[i, 0] != "" && Emissor[i, 1] != "")
                    {

                        #region INSERT

                        SqlCommand myCommand = new SqlCommand("INSERT INTO " + VGlobal.TabelaEmissor + " (Codigo_Emissor, Nome_Emissor, CNPJ_Emissor, Data_Emissor) values ('" + Emissor[i, 0] + "','" + Emissor[i, 1] + "','" + Emissor[i, 2] + "','" + Emissor[i, 3] + "')", mySQLConnection);
                        myCommand.ExecuteNonQuery();
                        ContadorEmissorCadastrado++;

                        //"INSERT INTO Pessoa (nome, dataNascimento, sexo, email) values ( '" + newPessoa.Nome + "', '" + newPessoa.DataNascimento + "', '" + newPessoa.Sexo + "', '" + newPessoa.Sexo + "')";
                        #endregion
                    }
                    else
                    {
                        VGlobal.LogLocal.Text += "Não cadastrado. Algum campo VAZIO! Fundo: " + Emissor[i, 1] + "\r\n";
                    }
                }
                catch (Exception Error)
                {
                    VGlobal.LogLocal.Text += Error;
                    VGlobal.RetornoFalha = true;
                }



                #endregion
            }
            mySQLConnection.Close();
            VGlobal.LogLocal.Text += "Quantidade de Emissores cadastrados: " + ContadorEmissorCadastrado + "\r\n";
            VGlobal.LogLocal.Text += "Quantidade de Emissores não cadastrados: " + (Emissor.GetUpperBound(0) - ContadorEmissorCadastrado) + "\r\n";
        }
        #endregion

        #region Ativo
        //ATIVO
        public DataTable ConsultaAtivo(string TabelaAtivo, string ConsultaCategoriaTabelaAtivo, string ConsultaCategoria,string ConsultaSiglaTabelaAtivo, string ConsultaSigla,string ConsultaDescricaoTabelaAtivo, string ConsultaDescricao,string ConsultaTipoTabelaAtivo, string ConsultaTipo,string ConsultaSeq1TabelaAtivo, string ConsultaSeq1,string ConsultaSeq2TabelaAtivo, string ConsultaSeq2)
        {

            #region Variáveis
            //variaveis
            DataTable dataTable = new DataTable();
            SqlConnection mySQLConnection = new SqlConnection(VGlobal.ParamConexSQL);
            SqlCommand myCommand = new SqlCommand("SELECT * FROM " + TabelaAtivo + " where " + ConsultaCategoriaTabelaAtivo + " LIKE \'%" + ConsultaCategoria + "%\' and " + ConsultaSiglaTabelaAtivo + " LIKE \'%" + ConsultaSigla + "%\' and " + ConsultaDescricaoTabelaAtivo + " LIKE \'%" + ConsultaDescricao + "%\' and " + ConsultaTipoTabelaAtivo + " LIKE \'%" + ConsultaTipo + "%\' and " + ConsultaSeq1TabelaAtivo + " LIKE \'%" + ConsultaSeq1 + "%\' and " + ConsultaSeq2TabelaAtivo + " LIKE \'%" + ConsultaSeq2 + "%\';", mySQLConnection);
            //SELECT * FROM XMLProj.dbo.Emissor_Titulo where CNPJ_EMISSOR = '0164159';
            //"SELECT * FROM " + OQue + " where " + DeOnde + " = \'" + Valor + "\';"
            //column1 LIKE '%word1%'
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            #endregion

            try
            {

                mySQLConnection.Open();

                da.Fill(dataTable); //preenche tabela

                da.Dispose();
                mySQLConnection.Close();
            }
            catch (Exception e)
            {
                VGlobal.RetornoFalha = true;
                VGlobal.LogLocal.Text += e.ToString();
                dataTable = null;
            }

            return dataTable;
        }

        public void CadastraAtivo(string[,] Ativo)
        {
            #region Variáveis
            //variaveis
            SqlConnection mySQLConnection = new SqlConnection(VGlobal.ParamConexSQL);
            int ContadorAtivoCadastrado = 0;
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

            //limpa base de dados de Emissor - retirar tudo e acrescenta denovo os novos valores - evita lixo na BD
            SqlCommand myCommandDelete = new SqlCommand("DELETE FROM " + VGlobal.TabelaAtivo, mySQLConnection); //define a linha de comando
            myCommandDelete.ExecuteNonQuery();//executa a linha de comando que não possui retorno

            for (int i = 0; i < Ativo.GetUpperBound(0) + 1; i++)
            {
                #region LOOP
                try
                {
                    if (Ativo[i, 0] != "" && Ativo[i, 1] != "" && Ativo[i, 2] != "" && Ativo[i, 3] != "" && Ativo[i, 4] != "" && Ativo[i, 5] != "")
                    {

                        #region INSERT

                        if (Ativo[i, 3].Length < 3)//se for menor que 3 caracteres, é porque tem que completar com alguma sequencia
                        {
                            if (Ativo[i, 3].Length == 2)
                            {
                                char ElementoInicial = Convert.ToChar(Ativo[i, 5].Substring(0, 1));
                                char ElementoFinal = Convert.ToChar(Ativo[i, 5].Substring(2, 1));
                                char AuxContagem = ElementoInicial;
                                string AuxiliarTipoAtivo;
                                while (AuxContagem != ElementoFinal + 1)
                                {
                                    AuxiliarTipoAtivo = Ativo[i, 3] + Convert.ToString(AuxContagem);
                                    SqlCommand myCommand = new SqlCommand("INSERT INTO " + VGlobal.TabelaAtivo + " (Categoria_TipoAtivo, Sigla_TipoAtivo, Descricao_TipoAtivo, Tipo_TipoAtivo, Sequencia1, Sequencia2) values ('" + Ativo[i, 0] + "','" + Ativo[i, 1] + "','" + Ativo[i, 2] + "','" + AuxiliarTipoAtivo + "','" + Ativo[i, 4] + "','" + Ativo[i, 5] + "')", mySQLConnection);
                                    myCommand.ExecuteNonQuery();
                                    AuxContagem++;
                                    ContadorAtivoCadastrado++;
                                }
                            }
                            else if (Ativo[i, 3].Length == 1)
                            {
                                char ElementoInicial2 = Convert.ToChar(Ativo[i, 4].Substring(0, 1));
                                char ElementoFinal2 = Convert.ToChar(Ativo[i, 4].Substring(2, 1));
                                char ElementoInicial3 = Convert.ToChar(Ativo[i, 5].Substring(0, 1));
                                char ElementoFinal3 = Convert.ToChar(Ativo[i, 5].Substring(2, 1));
                                char AuxContagem2 = ElementoInicial2;
                                char AuxContagem3 = ElementoInicial3;
                                string AuxiliarTipoAtivo;
                                while (AuxContagem2 != ElementoFinal2 + 1)
                                {
                                    while (AuxContagem3 != ElementoFinal3 + 1)
                                    {
                                        AuxiliarTipoAtivo = Ativo[i, 3] + Convert.ToString(AuxContagem2) + Convert.ToString(AuxContagem3);
                                        SqlCommand myCommand = new SqlCommand("INSERT INTO " + VGlobal.TabelaAtivo + " (Categoria_TipoAtivo, Sigla_TipoAtivo, Descricao_TipoAtivo, Tipo_TipoAtivo, Sequencia1, Sequencia2) values ('" + Ativo[i, 0] + "','" + Ativo[i, 1] + "','" + Ativo[i, 2] + "','" + AuxiliarTipoAtivo + "','" + Ativo[i, 4] + "','" + Ativo[i, 5] + "')", mySQLConnection);
                                        myCommand.ExecuteNonQuery();
                                        AuxContagem3++;
                                        ContadorAtivoCadastrado++;
                                    }
                                    AuxContagem2++;
                                    AuxContagem3 = ElementoInicial3;
                                }
                            }
                            else
                            {
                                VGlobal.LogLocal.Text += "Não cadastrado. Algum problema no Tipo Ativo! Descricao: " + Ativo[i, 2] + "\r\nTipo Ativo: " + Ativo[i, 3] + "\r\n";
                            }

                        }
                        else //se nao for menor do 3 caracteres e porque ja esta completo
                        {

                            SqlCommand myCommand = new SqlCommand("INSERT INTO " + VGlobal.TabelaAtivo + " (Categoria_TipoAtivo, Sigla_TipoAtivo, Descricao_TipoAtivo, Tipo_TipoAtivo, Sequencia1, Sequencia2) values ('" + Ativo[i, 0] + "','" + Ativo[i, 1] + "','" + Ativo[i, 2] + "','" + Ativo[i, 3] + "','" + Ativo[i, 4] + "','" + Ativo[i, 5] + "')", mySQLConnection);
                            myCommand.ExecuteNonQuery();
                            ContadorAtivoCadastrado++;
                        }


                        #endregion

                    }
                    else
                    {
                        VGlobal.LogLocal.Text += "Não cadastrado. Algum campo VAZIO! Descricao: " + Ativo[i, 2] + "\r\nTipo Ativo: " + Ativo[i, 3] + "\r\n";
                    }
                }
                catch (Exception Error)
                {
                    VGlobal.LogLocal.Text += Error;
                    VGlobal.RetornoFalha = true;
                }
                #endregion
            }
            mySQLConnection.Close();
            VGlobal.LogLocal.Text += "Quantidade de Emissores cadastrados: " + ContadorAtivoCadastrado + "\r\n";
        }
        #endregion

        #region Especie
        //ESPECIE
        public DataTable ConsultaEspecie(string TabelaEspecie, string ConsultaDescricaoTabelaEspecie, string ConsultaDescricao, string ConsultaCodigoTabelaEspecie, string ConsultaCodigo)
        {

            #region Variáveis
            //variaveis
            DataTable dataTable = new DataTable();
            SqlConnection mySQLConnection = new SqlConnection(VGlobal.ParamConexSQL);
            SqlCommand myCommand = new SqlCommand("SELECT * FROM " + TabelaEspecie + " where " + ConsultaDescricaoTabelaEspecie + " LIKE \'%" + ConsultaDescricao + "%\' and " + ConsultaCodigoTabelaEspecie + " LIKE \'%" + ConsultaCodigo + "%\';", mySQLConnection);
            //SELECT * FROM XMLProj.dbo.Emissor_Titulo where CNPJ_EMISSOR = '0164159';
            //"SELECT * FROM " + OQue + " where " + DeOnde + " = \'" + Valor + "\';"
            //column1 LIKE '%word1%'
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            #endregion

            try
            {

                mySQLConnection.Open();

                da.Fill(dataTable); //preenche tabela

                da.Dispose();
                mySQLConnection.Close();
            }
            catch (Exception e)
            {
                VGlobal.RetornoFalha = true;
                VGlobal.LogLocal.Text += e.ToString();
                dataTable = null;
            }

            return dataTable;
        }

        public void CadastraEspecie(string[,] Especie)
        {
            #region Variáveis
            //variaveis
            SqlConnection mySQLConnection = new SqlConnection(VGlobal.ParamConexSQL);
            int ContadorEspecieCadastrado = 0;
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

            //limpa base de dados de Emissor - retirar tudo e acrescenta denovo os novos valores - evita lixo na BD
            SqlCommand myCommandDelete = new SqlCommand("DELETE FROM " + VGlobal.TabelaEspecie, mySQLConnection); //define a linha de comando
            myCommandDelete.ExecuteNonQuery();//executa a linha de comando que não possui retorno

            for (int i = 0; i < Especie.GetUpperBound(0) + 1; i++)
            {
                #region LOOP
                try
                {
                    if (Especie[i, 0] != "" && Especie[i, 1] != "")
                    {

                        #region INSERT

                        SqlCommand myCommand = new SqlCommand("INSERT INTO " + VGlobal.TabelaEspecie + " (Descricao_Especie, Codigo_Especie) values ('" + Especie[i, 0] + "','" + Especie[i, 1] + "')", mySQLConnection);
                        myCommand.ExecuteNonQuery();
                        ContadorEspecieCadastrado++;

                        //"INSERT INTO Pessoa (nome, dataNascimento, sexo, email) values ( '" + newPessoa.Nome + "', '" + newPessoa.DataNascimento + "', '" + newPessoa.Sexo + "', '" + newPessoa.Sexo + "')";
                        #endregion

                    }
                    else
                    {
                        VGlobal.LogLocal.Text += "Não cadastrado. Algum campo VAZIO! Descricao: " + Especie[i, 0] + "\r\nEspecie: " + Especie[i, 1] + "\r\n";
                    }
                }
                catch (Exception Error)
                {
                    VGlobal.LogLocal.Text += Error;
                    VGlobal.RetornoFalha = true;
                }
                #endregion
            }
            mySQLConnection.Close();
            VGlobal.LogLocal.Text += "Quantidade de Especies cadastradas: " + ContadorEspecieCadastrado + "\r\n";
        }
        #endregion
    }
}
