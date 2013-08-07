using System;
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
        #endregion

        #region Variaveis SQL
        //Regiao de variaveis contantes
        public static string ParamConexSQL = "User Id=sa;Password=senha123;Server=WIN-9OBDOK4FG8Q\\SQLEXPRESS;Trusted_Connection=yes;Database=BDXMLProj;connection timeout=5";
        //"User Id=sa;Password=senha123;Server=WIN-9OBDOK4FG8Q\\SQLEXPRESS;Trusted_Connection=yes;Database=BDXMLProj;connection timeout=5"; - FUNCIONA
        //"User Id=WIN-9OBDOK4FG8Q\\XMLConsultUser;Password=XMLConsultUser;Server=192.168.74.133\\SQLEXPRESS;Trusted_Connection=yes;Database=BDXMLProj;connection timeout=5"; - ERRO  de dominio Windows
        //@"Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername; Password=myPassword";
        //Data Source=190.190.200.100,1433;Network Library=DBMSSOCN; Initial Catalog=myDataBase
        //en teste: @"User Id=sa;Password=senha123;Data Source=192.168.74.133,1433\SQLEXPRESS;Network Library=DBMSSOCN;Trusted_Connection=no;Initial Catalog=BDXMLProj;connection timeout=5";
        #endregion

        #region Variaveis Tela
        //Regiao de variaveis provenientes das telas
        public static RichTextBox rtLOG;
        #endregion

        #region Variaveis do Emissor.txt
        public static string[,] Emissor;
        public static int EmissorContagem;
        public static string EndEmissor;
        public static string LOGEmissor = "c:\\input\\LOG_Emissor.rtf";
        public static string[] CamposTabelaEmissor = { "Codigo_Emissor", "Nome_Emissor", "CNPJ_Emissor", "Data_Emissor" };
        public static string TabelaEmissor = "BDXMLProj.dbo.tbEmissor_Titulo";
        #endregion

        #region Variaveis do TipoAtivo.txt
        public static string[,] Ativo;
        public static int AtivoContagem;
        public static string EndAtivo;
        public static string LOGAtivo = "c:\\input\\LOG_Ativo.rtf";
        public static string[] CamposTabelaAtivo = { "Categoria_TipoAtivo", "Sigla_TipoAtivo", "Descricao_TipoAtivo", "Tipo_TipoAtivo", "Sequencia1", "Sequencia2" };
        public static string TabelaAtivo = "BDXMLProj.dbo.tbTipoDeAtivo";
        #endregion
    }
}
