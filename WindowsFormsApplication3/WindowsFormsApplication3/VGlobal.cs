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
        public static string ParamConexSQL = "User Id=sa;Password=senha123;Data Source=win-9obdok4fg8q\\sqlexpress;Trusted_Connection=yes;Database=BDXMLProj;connection timeout=10";
        //"User Id=sa;Password=faika123;Server=WIN-VFN6FLHC64A\\SQLEXPRESS;Trusted_Connection=yes;Database=XMLProj;connection timeout=10";
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
        #endregion

        #region Variaveis do TipoAtivo.txt
        public static string[,] Ativo;
        public static int AtivoContagem;
        public static string EndAtivo;
        public static string LOGAtivo = "c:\\input\\LOG_Ativo.rtf";
        #endregion
    }
}
