﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace XMLBackOffice
{
    class SQLXML
    {
        #region Cadastros
        //Região reservada para codigo de cadastros no Banco de Dados

        #region EMISSOR
        //EMISSOR
        public void CadastraEmissor(string[,] Emissor)
        {
            #region Variáveis
            //variaveis
            MySqlConnection mySQLConnection = new MySqlConnection(VGlobal.ParamConexMySQL(VGlobal.Uid_Admin, VGlobal.Pwd_Admin));
            int ContadorEmissorCadastrado = 0;
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

            //limpa base de dados de Emissor - retirar tudo e acrescenta denovo os novos valores - evita lixo na BD
            MySqlCommand myCommandDelete = new MySqlCommand("DELETE FROM " + VGlobal.TabelaEmissor, mySQLConnection); //define a linha de comando
            myCommandDelete.ExecuteNonQuery();//executa a linha de comando que não possui retorno


            for (int i = 0; i < Emissor.GetUpperBound(0) + 1; i++)
            {
                #region LOOP
                try
                {
                    if (Emissor[i, 0] != "" && Emissor[i, 1] != "")
                    {

                        #region INSERT

                        MySqlCommand myCommand = new MySqlCommand("INSERT INTO " + VGlobal.TabelaEmissor + " (" + VGlobal.CamposTabelaEmissor[0] + "," + VGlobal.CamposTabelaEmissor[1] + "," + VGlobal.CamposTabelaEmissor[2] + "," + VGlobal.CamposTabelaEmissor[3] + ") values (\"" + Emissor[i, 0] + "\",\"" + Emissor[i, 1] + "\",\"" + Emissor[i, 2] + "\",\"" + Emissor[i, 3] + "\")", mySQLConnection);

                        // SqlCommand myCommand = new SqlCommand("INSERT INTO " + VGlobal.TabelaEmissor + " ("+VGlobal.CamposTabelaEmissor[0]+","+VGlobal.CamposTabelaEmissor[1]+"," +VGlobal.CamposTabelaEmissor[2]+","+VGlobal.CamposTabelaEmissor[3]+") values ('" + Emissor[i, 0] + "','" + Emissor[i, 1] + "','" + Emissor[i, 2] + "','" + Emissor[i, 3] + "')", mySQLConnection);

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
        public void CadastraAtivo(string[,] Ativo)
        {
            #region Variáveis
            //variaveis
            MySqlConnection mySQLConnection = new MySqlConnection(VGlobal.ParamConexMySQL(VGlobal.Uid_Admin, VGlobal.Pwd_Admin));
            int ContadorAtivoCadastrado = 0;
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

            //limpa base de dados de Emissor - retirar tudo e acrescenta denovo os novos valores - evita lixo na BD
            MySqlCommand myCommandDelete = new MySqlCommand("DELETE FROM " + VGlobal.TabelaAtivo, mySQLConnection); //define a linha de comando
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

                                    MySqlCommand myCommand = new MySqlCommand("INSERT INTO " + VGlobal.TabelaAtivo + " (" + VGlobal.CamposTabelaAtivo[0] + "," + VGlobal.CamposTabelaAtivo[1] + "," + VGlobal.CamposTabelaAtivo[2] + "," + VGlobal.CamposTabelaAtivo[3] + "," + VGlobal.CamposTabelaAtivo[4] + "," + VGlobal.CamposTabelaAtivo[5] + ") values (\"" + Ativo[i, 0] + "\",\"" + Ativo[i, 1] + "\",\"" + Ativo[i, 2] + "\",\"" + AuxiliarTipoAtivo + "\",\"" + Ativo[i, 4] + "\",\"" + Ativo[i, 5] + "\")", mySQLConnection);

                                    //SqlCommand myCommand = new SqlCommand("INSERT INTO " + VGlobal.TabelaAtivo + " ("+VGlobal.CamposTabelaAtivo[0]+","+VGlobal.CamposTabelaAtivo[1]+","+VGlobal.CamposTabelaAtivo[2]+","+VGlobal.CamposTabelaAtivo[3]+","+VGlobal.CamposTabelaAtivo[4]+","+VGlobal.CamposTabelaAtivo[5]+") values ('" + Ativo[i, 0] + "','" + Ativo[i, 1] + "','" + Ativo[i, 2] + "','" + AuxiliarTipoAtivo + "','" + Ativo[i, 4] + "','" + Ativo[i, 5] + "')", mySQLConnection);

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
                                        MySqlCommand myCommand = new MySqlCommand("INSERT INTO " + VGlobal.TabelaAtivo + " (Categoria_TipoAtivo, Sigla_TipoAtivo, Descricao_TipoAtivo, Tipo_TipoAtivo, Sequencia1, Sequencia2) values (\"" + Ativo[i, 0] + "\",\"" + Ativo[i, 1] + "\",\"" + Ativo[i, 2] + "\",\"" + AuxiliarTipoAtivo + "\",\"" + Ativo[i, 4] + "\",\"" + Ativo[i, 5] + "\")", mySQLConnection);
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

                            MySqlCommand myCommand = new MySqlCommand("INSERT INTO " + VGlobal.TabelaAtivo + " (Categoria_TipoAtivo, Sigla_TipoAtivo, Descricao_TipoAtivo, Tipo_TipoAtivo, Sequencia1, Sequencia2) values (\"" + Ativo[i, 0] + "\",\"" + Ativo[i, 1] + "\",\"" + Ativo[i, 2] + "\",\"" + Ativo[i, 3] + "\",\"" + Ativo[i, 4] + "\",\"" + Ativo[i, 5] + "\")", mySQLConnection);
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
        public void CadastraEspecie(string[,] Especie)
        {
            #region Variáveis
            //variaveis
            MySqlConnection mySQLConnection = new MySqlConnection(VGlobal.ParamConexMySQL(VGlobal.Uid_Admin, VGlobal.Pwd_Admin));
            int ContadorEspecieCadastrado = 0;
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

            //limpa base de dados de Emissor - retirar tudo e acrescenta denovo os novos valores - evita lixo na BD
            MySqlCommand myCommandDelete = new MySqlCommand("DELETE FROM " + VGlobal.TabelaEspecie, mySQLConnection); //define a linha de comando
            myCommandDelete.ExecuteNonQuery();//executa a linha de comando que não possui retorno

            for (int i = 0; i < Especie.GetUpperBound(0) + 1; i++)
            {
                #region LOOP
                try
                {
                    if (Especie[i, 0] != "" && Especie[i, 1] != "")
                    {

                        #region INSERT

                        MySqlCommand myCommand = new MySqlCommand("INSERT INTO " + VGlobal.TabelaEspecie + " (" + VGlobal.CamposTabelaEspecie[0] + "," + VGlobal.CamposTabelaEspecie[1] + ") values (\"" + Especie[i, 0] + "\",\"" + Especie[i, 1] + "\")", mySQLConnection);
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

        #region Indexador
        //INDEXADOR
        public void CadastraIndexador(string[,] Indexador)
        {
            #region Variáveis
            //variaveis
            MySqlConnection mySQLConnection = new MySqlConnection(VGlobal.ParamConexMySQL(VGlobal.Uid_Admin, VGlobal.Pwd_Admin));
            int ContadorIndexadorCadastrado = 0;
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

            //limpa base de dados de Emissor - retirar tudo e acrescenta denovo os novos valores - evita lixo na BD
            MySqlCommand myCommandDelete = new MySqlCommand("DELETE FROM " + VGlobal.TabelaIndexador, mySQLConnection); //define a linha de comando
            myCommandDelete.ExecuteNonQuery();//executa a linha de comando que não possui retorno

            for (int i = 0; i < Indexador.GetUpperBound(0) + 1; i++)
            {
                #region LOOP
                try
                {
                    if (Indexador[i, 0] != "" && Indexador[i, 1] != "")
                    {

                        #region INSERT

                        MySqlCommand myCommand = new MySqlCommand("INSERT INTO " + VGlobal.TabelaIndexador + " (" + VGlobal.CamposTabelaIndexador[0] + "," + VGlobal.CamposTabelaIndexador[1] + "," + VGlobal.CamposTabelaIndexador[2] + ") VALUES (\"" + Indexador[i, 0] + "\",\"" + Indexador[i, 1] + "\",\"" + Indexador[i, 2] + "\")", mySQLConnection);
                                                
                        //INSERT INTO bdxmlproj.tbindexador (Relatorio_Indexador,Descricao_Indexador,XML_Indexador)VALUES ("A","B","C")
                        myCommand.ExecuteNonQuery();
                        ContadorIndexadorCadastrado++;
                                                
                        #endregion

                    }
                    else
                    {
                        VGlobal.LogLocal.Text += "Não cadastrado. Algum campo VAZIO! Descricao: " + Indexador[i, 0] + "\r\nEspecie: " + Indexador[i, 1] + "\r\n";
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
            VGlobal.LogLocal.Text += "Quantidade de Especies cadastradas: " + ContadorIndexadorCadastrado + "\r\n";
        }

        #endregion

        #endregion

        #region Consultas
        //Região reservada para codigo de consultas no Banco de Dados
        public DataTable ConsultaGenerica(string LinhaComando, string UsuarioBD, string SenhaBD)
        {

            #region Variáveis
            //variaveis
            DataTable dataTable = new DataTable();
            MySqlConnection mySQLConnection = new MySqlConnection(VGlobal.ParamConexMySQL(UsuarioBD, SenhaBD));
            MySqlCommand myCommand = new MySqlCommand(LinhaComando, mySQLConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(myCommand);
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

        #endregion

        #region Atualizacoes

        //Atualizacao do BIT de Reset de Senha
        public static void AtualizaResetSenha()
        {
            #region Variáveis
            //variaveis
            MySqlConnection mySQLConnection = new MySqlConnection(VGlobal.ParamConexMySQL(VGlobal.Uid_MudaSenha, VGlobal.Pwd_MudaSenha));
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

                try
                {
                    if (VGlobal.DadosCliente.reset_senha)
                    {

                        #region UPDATE
                        //UPDATE `bdxmlproj`.`tbcredencial` SET `Reset_Senha`=0 WHERE `Codigo_Cliente`='Cod1234567';
                        MySqlCommand myCommand = new MySqlCommand("UPDATE " + VGlobal.TabelaGestaoUsuario + " SET " + VGlobal.CamposTabelaGestaoUsuario[3] + "=0 " + "WHERE " + VGlobal.CamposTabelaGestaoUsuario[0] + "=\"" + VGlobal.DadosCliente.codigo_cliente + "\";", mySQLConnection);

                        myCommand.ExecuteNonQuery();
                        
                        #endregion
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Falha no cadastramento da nova senha. Contate o suporte tecnico!", "ERROR", MessageBoxButtons.OK);
                    }
                }
                catch (Exception Error)
                {
                    string asd = Error.ToString();
                }

            
            mySQLConnection.Close();
        }

        //Atualiza a senha do cliente no BD
        public static void AtualizaSenha(string NovaSenha)
        {
            #region Variáveis
            //variaveis
            MySqlConnection mySQLConnection = new MySqlConnection(VGlobal.ParamConexMySQL(VGlobal.Uid_MudaSenha, VGlobal.Pwd_MudaSenha));
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

            try
            {
                if (VGlobal.DadosCliente.reset_senha)
                {

                    #region UPDATE
                    //UPDATE `bdxmlproj`.`tbcredencial` SET `Reset_Senha`=0 WHERE `Codigo_Cliente`='Cod1234567';
                    MySqlCommand myCommand = new MySqlCommand("UPDATE " + VGlobal.TabelaGestaoUsuario + " SET " + VGlobal.CamposTabelaGestaoUsuario[2] + "= \""+NovaSenha+ "\" " + "WHERE " + VGlobal.CamposTabelaGestaoUsuario[0] + "=\"" + VGlobal.DadosCliente.codigo_cliente + "\";", mySQLConnection);

                    myCommand.ExecuteNonQuery();

                    #endregion
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Falha no cadastramento da nova senha. Contate o suporte tecnico!", "ERROR", MessageBoxButtons.OK);
                }
            }
            catch (Exception Error)
            {
                string asd = Error.ToString();
            }

            mySQLConnection.Close();
        }

        #endregion
    }
}
