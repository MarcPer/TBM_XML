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
using System.Security.Cryptography;

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
                dataTable = Consulta.ConsultaGenerica(LinhaComandoSQL, VGlobal.Uid_Admin, VGlobal.Pwd_Admin);

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
                dataTable = Consulta.ConsultaGenerica(LinhaComandoSQL, VGlobal.Uid_Admin, VGlobal.Pwd_Admin);

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
                dataTable = Consulta.ConsultaGenerica(LinhaComandoSQL, VGlobal.Uid_Admin, VGlobal.Pwd_Admin);

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
                dataTable = Consulta.ConsultaGenerica(LinhaComandoSQL, VGlobal.Uid_Admin, VGlobal.Pwd_Admin);
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

    #region Criptografia e tempero da senha
    ///////////////////////////////////////////////////////////////////////////////
    // SAMPLE: Hashing data with salt using MD5 and several SHA algorithms.
    //
    // To run this sample, create a new Visual C# project using the Console
    // Application template and replace the contents of the Class1.cs file with
    // the code below.
    //
    // THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
    // EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
    // WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
    // 
    // Copyright (C) 2002 Obviex(TM). All rights reserved.
    // 

    /// <summary>
    /// This class generates and compares hashes using MD5, SHA1, SHA256, SHA384, 
    /// and SHA512 hashing algorithms. Before computing a hash, it appends a
    /// randomly generated salt to the plain text, and stores this salt appended
    /// to the result. To verify another plain text value against the given hash,
    /// this class will retrieve the salt value from the hash string and use it
    /// when computing a new hash of the plain text. Appending a salt value to
    /// the hash may not be the most efficient approach, so when using hashes in
    /// a real-life application, you may choose to store them separately. You may
    /// also opt to keep results as byte arrays instead of converting them into
    /// base64-encoded strings.
    /// </summary>
    public class SimpleHash
    {
        /// <summary>
        /// Generates a hash for the given plain text value and returns a
        /// base64-encoded result. Before the hash is computed, a random salt
        /// is generated and appended to the plain text. This salt is stored at
        /// the end of the hash value, so it can be used later for hash
        /// verification.
        /// </summary>
        /// <param name="plainText">
        /// Plaintext value to be hashed. The function does not check whether
        /// this parameter is null.
        /// </param>
        /// <param name="hashAlgorithm">
        /// Name of the hash algorithm. Allowed values are: "MD5", "SHA1",
        /// "SHA256", "SHA384", and "SHA512" (if any other value is specified
        /// MD5 hashing algorithm will be used). This value is case-insensitive.
        /// </param>
        /// <param name="saltBytes">
        /// Salt bytes. This parameter can be null, in which case a random salt
        /// value will be generated.
        /// </param>
        /// <returns>
        /// Hash value formatted as a base64-encoded string.
        /// </returns>
        /// 
        public static byte[] Salt(string PWD)
        {
            string PwdSalt = null;

            for (int i = 0; i < PWD.Length; i++)
            {
                PwdSalt += PWD.Substring(i, 1) + Convert.ToString(Convert.ToByte(Convert.ToChar(PWD.Substring(i, 1)) + 1) + 2);
            }
            byte[] BytePwdSalt = Encoding.UTF8.GetBytes(PwdSalt);

            return BytePwdSalt;
        }

        public static string ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
        {
            // If salt is not specified, generate it on the fly.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            // Because we support multiple hashing algorithms, we must define
            // hash object as a common (abstract) base class. We will specify the
            // actual hashing algorithm class later during object creation.
            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithm.ToUpper())
            {
                case "SHA1":
                    hash = new SHA1Managed();
                    break;

                case "SHA256":
                    hash = new SHA256Managed();
                    break;

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        /// <summary>
        /// Compares a hash of the specified plain text value to a given hash
        /// value. Plain text is hashed with the same salt value as the original
        /// hash.
        /// </summary>
        /// <param name="plainText">
        /// Plain text to be verified against the specified hash. The function
        /// does not check whether this parameter is null.
        /// </param>
        /// <param name="hashAlgorithm">
        /// Name of the hash algorithm. Allowed values are: "MD5", "SHA1", 
        /// "SHA256", "SHA384", and "SHA512" (if any other value is specified,
        /// MD5 hashing algorithm will be used). This value is case-insensitive.
        /// </param>
        /// <param name="hashValue">
        /// Base64-encoded hash value produced by ComputeHash function. This value
        /// includes the original salt appended to it.
        /// </param>
        /// <returns>
        /// If computed hash mathes the specified hash the function the return
        /// value is true; otherwise, the function returns false.
        /// </returns>
        public static bool VerifyHash(string plainText, string hashAlgorithm, string hashValue, string Usuario)
        {
            string expectedHashString = null;

            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            // Make sure that hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Size of hash is based on the specified algorithm.
            switch (hashAlgorithm.ToUpper())
            {
                case "SHA1":
                    hashSizeInBits = 160;
                    break;

                case "SHA256":
                    hashSizeInBits = 256;
                    break;

                case "SHA384":
                    hashSizeInBits = 384;
                    break;

                case "SHA512":
                    hashSizeInBits = 512;
                    break;

                default: // Must be MD5
                    hashSizeInBits = 128;
                    break;
            }

            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            //string expectedHashString = ComputeHash(plainText, hashAlgorithm, saltBytes);
            GestaoUsuario.ConsultaDadosUsuario(Usuario);
            if (VGlobal.DadosCliente.senha_cliente != null)
            {
                expectedHashString = VGlobal.DadosCliente.senha_cliente;
            }
            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
        }
    }
    #endregion

    class GestaoUsuario
    {
        public static void ConsultaDadosUsuario(string Usuario)
        {
            #region Variáveis
            //variaveis
            VGlobal.RetornoFalha = false;
            string[,] DadosUsuario;
            DataTable dataTable = new DataTable();
            SQLXML Consulta = new SQLXML();
            VGlobal.LogLocal.Text = "";
            string LinhaComandoSQL;
            #endregion

            try
            {
                LinhaComandoSQL = "SELECT * FROM " + VGlobal.TabelaGestaoUsuario + " where " + VGlobal.CamposTabelaGestaoUsuario[1] + " = \'" + Usuario + "\';";
                //SELECT * FROM bdxmlproj.tbcredencial where Usuario_Cliente = 'a@b.com';
                dataTable = Consulta.ConsultaGenerica(LinhaComandoSQL, VGlobal.Uid_Login, VGlobal.Pwd_Login);

            }
            catch (Exception e)
            {
                VGlobal.rtLOG.Text += e.ToString();
                VGlobal.RetornoFalha = true;
            }

            if (VGlobal.RetornoFalha == true)
            {
                DialogResult dialogResult = MessageBox.Show("Usuario ou senha invalidos!", "ERROR", MessageBoxButtons.OK);
                VGlobal.LogLocal.Text += "Usuario ou senha inválidos! \r\nUsuario:" + Usuario + "\r\n";
                DadosUsuario = null;
                dataTable = null;
            }
            else
            {
                if (dataTable.Rows.Count != 0)
                {
                    DadosUsuario = new string[dataTable.Rows.Count, 5];
                    VGlobal.LogLocal.Text += "Total de colunas pesquisadas: " + dataTable.Rows.Count + "\r\n";
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        
                        VGlobal.DadosCliente.codigo_cliente = dataTable.Rows[i][0].ToString();
                        VGlobal.DadosCliente.usuario_cliente = dataTable.Rows[i][1].ToString();
                        VGlobal.DadosCliente.senha_cliente = dataTable.Rows[i][2].ToString();
                        string asdasd = dataTable.Rows[i][3].ToString();
                        VGlobal.DadosCliente.reset_senha = Convert.ToBoolean(dataTable.Rows[i][3]);
                        VGlobal.DadosCliente.contadesativada = Convert.ToBoolean(dataTable.Rows[i][3]);
                    }
                }
                else
                {
                    DadosUsuario = new string[1, 5];
                    DadosUsuario[0, 0] = null;
                    DadosUsuario[0, 1] = null;
                    DadosUsuario[0, 2] = null;
                    DadosUsuario[0, 3] = null;
                    DadosUsuario[0, 4] = null;
                    DialogResult dialogResult2 = MessageBox.Show("Usuario ou senha invalidos!", "ERROR", MessageBoxButtons.OK);
                    VGlobal.LogLocal.Text += "Usuario ou senha inválidos! \r\nUsuario:" + Usuario + "\r\n";
                    VGlobal.RetornoFalha = true;
                }
            }

            Generico.GravarLOG(VGlobal.LOGGestaoUsuario, VGlobal.LogLocal);
            //return DadosUsuario;
        }

        public static bool VerificaForcaSenha(string senha)
        {
            #region Variaveis
            //Variaveis
            bool eSenhaForte=false;
            bool TemLetraMaiuscula = false;
            bool TemLetraMinuscula = false;
            bool TemNumero = false;
            bool TemTamanho = false;
            char[] CharSenha = senha.ToCharArray();
            #endregion

            #region Verificacao de tamanho
            if (senha.Length >= 8)
            {
                TemTamanho = true;
            }
            else
            {
                TemTamanho = false;
            }
            #endregion

            #region Verificacao de caracteres
            //Numero
            for (int i = 0; i < CharSenha.Length; i++)
            {
                if (CharSenha[i] >= 48 && CharSenha[i] <= 57)
                {
                    TemNumero = true;
                }
                else if (i == CharSenha.Length - 1)
                {
                    TemNumero = false;
                }
            }

            //LetraMaiuscula
            for (int i = 0; i < CharSenha.Length; i++)
            {
                if (CharSenha[i] >= 58 && CharSenha[i] <= 96)
                {
                    TemLetraMaiuscula = true;
                }
                else if (i == CharSenha.Length - 1)
                {
                    TemLetraMaiuscula = false;
                }
            }

            //LetraMinuscula
            for (int i = 0; i < CharSenha.Length; i++)
            {
                if (CharSenha[i] >= 97 && CharSenha[i] <= 126)
                {
                    TemLetraMinuscula = true;
                }
                else if (i == CharSenha.Length - 1)
                {
                    TemLetraMinuscula = false;
                }
            }
            #endregion

            #region Checagem final
            //Checagem global
            if (TemTamanho & TemNumero & TemLetraMaiuscula & TemLetraMinuscula)
            {
                eSenhaForte = true;
                DialogResult dialogResult = MessageBox.Show("Senha alterada com sucesso!", "Sucesso", MessageBoxButtons.OK);
                
            }
            else
            {
                eSenhaForte = false;
                DialogResult dialogResult = MessageBox.Show("Falha no cadastramento de nova senha\r\nA senha não possui requerimentos minimos de seguranca.\r\nMinimo de 8 caracteres, contendo maiuscula, minuscula e numero!", "ERROR", MessageBoxButtons.OK);
            }
            #endregion

            return eSenhaForte;
        }

        public static bool GerenciaProcessoDeLogin(string Usuario, string Senha)
        {
            #region Variaveis
            bool AutorizaLogin = false;
            #endregion

            #region Checa Campos

            #region Checa Usuario
            if (Usuario == "")
            {
                DialogResult dialogResult2 = MessageBox.Show("Favor digitar usuário!", "ERROR", MessageBoxButtons.OK);
                goto PulaLogin;
            }

            #endregion

            #region Checa Senha
            if (Senha == "")
            {
                DialogResult dialogResult2 = MessageBox.Show("Favor digitar senha!", "ERROR", MessageBoxButtons.OK);
                goto PulaLogin;
            }

            #endregion

            #endregion

            AutorizaLogin = ChecaUsuarioSenha(Usuario, Senha);
            
            #region Abre Tela Principal
            if (AutorizaLogin)
            {
                try
                {
                    //Precisa criar uma nova thread para abrir uma nova tela
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProcPrincipal));
                    t.Start();
                    //rtLOG.Text += "Janela de Emissor aberta.\r\n";
                }
                catch (Exception E)
                {
                    VGlobal.LogLocal.Text += E.ToString();
                }
            }
            else if (VGlobal.DadosCliente.contadesativada)//Conta Desativada
            {
                int asd = 0;
            }
            else if (VGlobal.DadosCliente.reset_senha)//Reset de Senha
            {
                int asd = 0;
            }
#endregion

        PulaLogin:
            Generico.GravarLOG(VGlobal.LOGGestaoUsuario, VGlobal.LogLocal);

        return AutorizaLogin;
        }

        public static void ThreadProcPrincipal()
        {

            Application.Run(new TelaPrincipal());

        }

        public static bool ChecaUsuarioSenha(string Usuario, string Senha)
        {
            bool AutorizaLogin;

            #region Criptografia e tempero da senha
            string password = Senha;  // original password
            //string wrongPassword = "password";    // wrong password

            byte[] PwdSalt = SimpleHash.Salt(Senha);

            //string passwordHashMD5 = SimpleHash.ComputeHash(password, "MD5", null);
            //string passwordHashSha1 = SimpleHash.ComputeHash(password, "SHA1", null);
            //string passwordHashSha256 = SimpleHash.ComputeHash(password, "SHA256", null);
            //string passwordHashSha384 = SimpleHash.ComputeHash(password, "SHA384", null);
            string passwordHashSha512 = SimpleHash.ComputeHash(password, "SHA512", PwdSalt);

            //LOGLogin.Text += "COMPUTING HASH VALUES\r\n";
            //LOGLogin.Text += "MD5   : " + passwordHashMD5 + "\r\n";
            //LOGLogin.Text += "SHA1  : " + passwordHashSha1 + "\r\n";
            //LOGLogin.Text += "SHA256: " + passwordHashSha256 + "\r\n";
            //LOGLogin.Text += "SHA384: " + passwordHashSha384 + "\r\n";
            //LOGLogin.Text += "SHA512: " + passwordHashSha512 + "\r\n";
            //LOGLogin.Text += "";
            //LOGLogin.Text += "Senha digitada: " + Senha + "\r\n";
            //LOGLogin.Text += "";
            //LOGLogin.Text += "COMPARING PASSWORD HASHES\r\n";
            //LOGLogin.Text += "MD5    (good): " + SimpleHash.VerifyHash(password, "MD5", passwordHashMD5).ToString() + "\r\n";
            //LOGLogin.Text += "MD5    (bad) : " + SimpleHash.VerifyHash(wrongPassword, "MD5", passwordHashMD5).ToString() + "\r\n";
            //LOGLogin.Text += "SHA1   (good): " + SimpleHash.VerifyHash(password, "SHA1", passwordHashSha1).ToString() + "\r\n";
            //LOGLogin.Text += "SHA1   (bad) : " + SimpleHash.VerifyHash(wrongPassword, "SHA1", passwordHashSha1).ToString() + "\r\n";
            //LOGLogin.Text += "SHA256 (good): " + SimpleHash.VerifyHash(password, "SHA256", passwordHashSha256).ToString() + "\r\n";
            //LOGLogin.Text += "SHA256 (bad) : " + SimpleHash.VerifyHash(wrongPassword, "SHA256", passwordHashSha256).ToString() + "\r\n";
            //LOGLogin.Text += "SHA384 (good): " + SimpleHash.VerifyHash(password, "SHA384", passwordHashSha384).ToString() + "\r\n";
            //LOGLogin.Text += "SHA384 (bad) : " + SimpleHash.VerifyHash(wrongPassword, "SHA384", passwordHashSha384).ToString() + "\r\n";
            AutorizaLogin = SimpleHash.VerifyHash(password, "SHA512", passwordHashSha512, Usuario);
            //LOGLogin.Text += "SHA512 (good): " + AutorizaLogin.ToString() + "\r\n";
            //LOGLogin.Text += "SHA512 (bad) : " + SimpleHash.VerifyHash(wrongPassword, "SHA512", passwordHashSha512).ToString() + "\r\n";

            //
            // END OF FILE
            ///////////////////////////////////////////////////////////////////////////////

            return AutorizaLogin;
            #endregion
        }


    }

}

