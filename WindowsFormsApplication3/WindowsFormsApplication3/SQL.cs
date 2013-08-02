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

        public DataTable ConsultaEmissor(string OQue, string DeOnde, string Valor)
        {

            #region Variáveis
            //variaveis
            DataTable dataTable = new DataTable();
            SqlConnection mySQLConnection = new SqlConnection(VGlobal.ParamConexSQL);
            SqlCommand myCommand = new SqlCommand("SELECT * FROM " + OQue + " where " + DeOnde + " LIKE \'%" + Valor + "%\';", mySQLConnection);
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
                ProcessoEmissor.LogLocal.Text += e.ToString();
                dataTable = null;
            }

            return dataTable;
        }

        public void CadastraEmissor(string[,] Emissor)
        {
            #region Variáveis
            //variaveis
            string OQue = "BDXMLProj.dbo.tbEmissor_Titulo";
            SqlConnection mySQLConnection = new SqlConnection(VGlobal.ParamConexSQL);
            int ContadorEmissorCadastrado = 0;
            #endregion

            mySQLConnection.Open();//Abre coonexao com o banco

            //limpa base de dados de Emissor - retirar tudo e acrescenta denovo os novos valores - evita lixo na BD
            SqlCommand myCommandDelete = new SqlCommand("DELETE FROM " + OQue, mySQLConnection); //define a linha de comando
            myCommandDelete.ExecuteNonQuery();//executa a linha de comando que não possui retorno


            for (int i = 0; i < Emissor.GetUpperBound(0) + 1; i++)
            {
                #region LOOP
                try
                {
                    if (Emissor[i, 0] != "" && Emissor[i, 1] != "" && Emissor[i, 2] != "" && Emissor[i, 3] != "")
                    {

                            #region INSERT

                            SqlCommand myCommand = new SqlCommand("INSERT INTO " + OQue + " (Codigo_Emissor, Nome_Emissor, CNPJ_Emissor, Data_Emissor) values ('" + Emissor[i, 0] + "','" + Emissor[i, 1] + "','" + Emissor[i, 2] + "','" + Emissor[i, 3] + "')", mySQLConnection);
                            myCommand.ExecuteNonQuery();
                            ContadorEmissorCadastrado++;

                            //"INSERT INTO Pessoa (nome, dataNascimento, sexo, email) values ( '" + newPessoa.Nome + "', '" + newPessoa.DataNascimento + "', '" + newPessoa.Sexo + "', '" + newPessoa.Sexo + "')";
                            #endregion
                    }
                    else
                    {
                        ProcessoEmissor.LogLocal.Text += "Não cadastrado. Algum campo VAZIO! Fundo: " + Emissor[i, 1] + "\r\n";
                    }
                }
                catch (Exception Error)
                {
                    ProcessoEmissor.LogLocal.Text += Error;
                    VGlobal.RetornoFalha = true;
                }



                #endregion
            }
            mySQLConnection.Close();
            ProcessoEmissor.LogLocal.Text += "Quantidade de Emissores cadastrados: " + ContadorEmissorCadastrado + "\r\n";
            ProcessoEmissor.LogLocal.Text += "Quantidade de Emissores não cadastrados: " + (Emissor.GetUpperBound(0)-ContadorEmissorCadastrado) + "\r\n";
        }

    }
}
