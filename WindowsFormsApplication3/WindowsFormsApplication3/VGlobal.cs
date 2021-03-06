﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//meus
using System.Windows.Forms;
using System.IO;

namespace XMLBackOffice
{
    public static class VGlobal
    {
        #region Variaveis Constantes
        //Regiao de variaveis contantes
        public static bool RetornoFalha = false;
        public static RichTextBox LogLocal = new RichTextBox();
        #endregion

        #region Variaveis SQL
        //Regiao de variaveis contantes
        //public static string ParamConexSQL = "User Id=WIN-9OBDOK4FG8Q\\XMLConsultUser;Password=XMLConsultUser;Server=192.168.74.133\\SQLEXPRESS;Trusted_Connection=yes;Integrated Security=SSPI;Database=BDXMLProj;connection timeout=5";
        //"User Id=sa;Password=senha123;Server=WIN-9OBDOK4FG8Q\\SQLEXPRESS;Trusted_Connection=yes;Database=BDXMLProj;connection timeout=5"; - FUNCIONA

        //"User Id=WIN-9OBDOK4FG8Q\\XMLConsultUser;Password=XMLConsultUser;Server=192.168.74.133\\SQLEXPRESS;Trusted_Connection=yes;Database=BDXMLProj;connection timeout=5"; - ERRO  de dominio Windows
        //"User Id=WIN-9OBDOK4FG8Q\\XMLConsultUser;Password=XMLConsultUser;Server=192.168.74.133\\SQLEXPRESS;Network Library=DBMSSOCN;Initial Catalog=BDXMLProj;Integrated Security=SSPI;connection timeout=5"; - ERRO de dominio Windows
        //"User Id=sa;Password=senha123;Server=192.168.74.133,1433;Data Source=.\\SQLEXPRESS;Trusted_Connection=yes;Database=BDXMLProj;User Instance=True;connection timeout=5"; - ERRO, nao foi possivel conectar ao BDXMLProj - Falha de logon de usuario do windows

        //"User Id=WIN-9OBDOK4FG8Q\\XMLConsultUser;Password=XMLConsultUser;Server=192.168.74.133\\SQLEXPRESS;Trusted_Connection=yes;Integrated Security=SSPI;Database=BDXMLProj;connection timeout=5"; - ERRO  de dominio Windows
        //"User Id=WIN-9OBDOK4FG8Q\\XMLConsultUser;Password=XMLConsultUser;Server=192.168.74.133\\SQLEXPRESS;Network Library=DBMSSOCN;Initial Catalog=BDXMLProj;Integrated Security=SSPI;connection timeout=5"; - ERRO de dominio Windows

        //@"Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername; Password=myPassword";
        //Data Source=190.190.200.100,1433;Network Library=DBMSSOCN; Initial Catalog=myDataBase
        //en teste: @"User Id=sa;Password=senha123;Data Source=192.168.74.133,1433\SQLEXPRESS;Network Library=DBMSSOCN;Trusted_Connection=no;Initial Catalog=BDXMLProj;connection timeout=5";
        //CE device: Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI; User ID=myDomain\myUsername;Password=myPassword;
        //TCP: Data Source=190.190.200.100,1433;Network Library=DBMSSOCN; Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;

        #endregion

        #region Variaveis MySQL
        //Regiao de variaveis contantes
        public static string  Server = "localhost";//xmlproject.no-ip.org
        public static string Port = "3306";
        public static string Database = "bdxmlproj";
        public static string ConnectionTimeout = "Connection Timeout=5";
        //Usuarios
        public static string Uid_Login = "ChecaLoginCli";
        public static string Pwd_Login = "senha123";
        public static string Uid_MudaSenha = "MudaSenhaCli";
        public static string Pwd_MudaSenha = "senha123";
        public static string Uid_Usuario = "UsuarioXML";
        public static string Pwd_Usuario = "senha123";
        public static string Uid_Admin = "AdminBackEnd";
        public static string Pwd_Admin = "senha123";

        public static string ParamConexMySQL(string Usuario, string Senha)
        {

            string conexao = "Server=" + Server + ";Port=" + Port + ";Database=" + Database + ";Uid=" + Usuario + ";Pwd=" + Senha + ";" + ConnectionTimeout + ";";
            return conexao;
        }
        
        //"Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";


        #endregion

        #region Variaveis Tela Inicial
        //Regiao de variaveis provenientes das telas
        public static RichTextBox rtLOG;
        #endregion

        #region Variaveis do Emissor.txt
        public static string[,] Emissor;
        public static int EmissorContagem;
        public static string EndEmissor;
        public static string LOGEmissor = "LOG_Emissor.rtf";
        public static string[] CamposTabelaEmissor = { "Codigo_Emissor", "Nome_Emissor", "CNPJ_Emissor", "Data_Emissor" };
        public static string TabelaEmissor = "bdxmlproj.tbemissor_titulo";
        #endregion

        #region Variaveis do TipoAtivo.txt
        public static string[,] Ativo;
        public static int AtivoContagem;
        public static string EndAtivo;
        public static string LOGAtivo = "LOG_Ativo.rtf";
        public static string[] CamposTabelaAtivo = { "Categoria_TipoAtivo", "Sigla_TipoAtivo", "Descricao_TipoAtivo", "Tipo_TipoAtivo", "Sequencia1", "Sequencia2" };
        public static string TabelaAtivo = "bdxmlproj.tbtipodeativo";
        #endregion

        #region Variaveis do Especie.txt
        public static string[,] Especie;
        public static int EspecieContagem;
        public static string EndEspecie;
        public static string LOGEspecie = "LOG_Especie.rtf";
        public static string[] CamposTabelaEspecie = { "Descricao_Especie", "Codigo_Especie" };
        public static string TabelaEspecie = "bdxmlproj.tbespecie";
        #endregion

        #region Variaveis do Indexador.txt
        //public static string[,] Indexador;
        public static int IndexadorContagem;
        public static string EndIndexador;
        public static string LOGIndexador = "LOG_Indexador.rtf"; //c:\\input\\LOG_Indexador.rtf
        public static string[] CamposTabelaIndexador = { "XML_Indexador", "Relatorio_Indexador", "Descricao_Indexador" };
        public static string TabelaIndexador = "bdxmlproj.tbindexador";//"BDXMLProj.dbo.tbIndexador";
        public static string[,] Indexador;
        #endregion

        #region Variaveis GestaoUsuario
        #region GestaoGeral
        public static string LOGGestaoUsuario = "LOGGestaoUsuario.rtf";
        public static string[] CamposTabelaGestaoUsuario = { "Codigo_Cliente", "Usuario_Cliente", "Senha_Cliente", "Reset_Senha", "ContaDesativada" };
        public static string TabelaGestaoUsuario = "bdxmlproj.tbcredencial";
        public static string[,] GestaoUsuario;
        //public static string[,] DadosUsuario;
        public static bool UsuarioAutorizado;
        #endregion

        #region Login
        public struct DadosCliente
        {
        public static string codigo_cliente;
        public static string usuario_cliente;
        public static string senha_cliente;
        public static bool reset_senha;
        public static bool contadesativada;
        };
        #endregion

        #endregion
    }
}
