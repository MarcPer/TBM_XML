﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XMLBackOffice
{
    public partial class TelaAtivo : Form
    {
        public TelaAtivo()
        {
            InitializeComponent();

        }

        private void TelaAtivo_Load(object sender, EventArgs e)
        {
            //Inicializa variaveis com valor padrao
            EnderecoCadastro.Text = "c:\\input\\TIPOATIVO.txt";
            ConsultaCategoria.Text = "";
            ConsultaDescricao.Text = "";
            ConsultaSigla.Text = "";
            ConsultaTipo.Text = "";
            ConsultaSeq1.Text = "";
            ConsultaSeq2.Text = "";
            lbPrimeiro.Text = "0";
            lbUltimo.Text = "0";
            btEsquerda.Enabled = false;
            btDireita.Enabled = false;
            VGlobal.rtLOG = new RichTextBox();

            //Apaga LOG antigo.
            File.Delete(VGlobal.LOGAtivo);
        }

        private void btCadastra_Click(object sender, EventArgs e)
        {
            #region Variaveis
            VGlobal.RetornoFalha = false;
            VGlobal.EndAtivo = @EnderecoCadastro.Text;
            #endregion
            if (EnderecoCadastro.Text != "")
            {
                ProcessoAtivo obProgramaAtivo = new ProcessoAtivo();
                obProgramaAtivo.GerenciaProcessoCadastroTipoAtivo();

                LOGAtivo.Text += VGlobal.LogLocal.Text;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Selecionar arquivo de Tipo de Ativo primeiro!", "ERROR", MessageBoxButtons.OK);
                VGlobal.rtLOG.Text += "Selecionar arquivo de Tipo de Ativo primeiro!\r\n";
            }
        }

        private void btLimpa_Click(object sender, EventArgs e)
        {
            ConsultaCategoria.Text = "";
            ConsultaDescricao.Text = "";
            ConsultaSigla.Text = "";
            ConsultaTipo.Text = "";
            ConsultaSeq1.Text = "";
            ConsultaSeq2.Text = "";
            lbPrimeiro.Text = "0";
            lbUltimo.Text = "0";
            btEsquerda.Enabled = false;
            btDireita.Enabled = false;
        }

        private void btConsulta_Click(object sender, EventArgs e)
        {
            #region Variaveis
            VGlobal.AtivoContagem = 0;
            VGlobal.RetornoFalha = false;
            #endregion

            ProcessoAtivo obProgramaAtivo = new ProcessoAtivo();
            VGlobal.Ativo = obProgramaAtivo.GerenciaProcessoConsultaAtivo(ConsultaCategoria.Text, ConsultaSigla.Text, ConsultaDescricao.Text, ConsultaTipo.Text, ConsultaSeq1.Text, ConsultaSeq2.Text);

            if (VGlobal.RetornoFalha == false)
            {
                if (VGlobal.Ativo.GetUpperBound(0) != 0)
                {
                    btEsquerda.Enabled = true;
                    btDireita.Enabled = true;
                    
                }
                ConsultaCategoria.Text = VGlobal.Ativo[VGlobal.Ativo.GetLowerBound(0), 0];
                ConsultaSigla.Text = VGlobal.Ativo[VGlobal.Ativo.GetLowerBound(0), 1];
                ConsultaDescricao.Text = VGlobal.Ativo[VGlobal.Ativo.GetLowerBound(0), 2];
                ConsultaTipo.Text = VGlobal.Ativo[VGlobal.Ativo.GetLowerBound(0), 3];
                ConsultaSeq1.Text = VGlobal.Ativo[VGlobal.Ativo.GetLowerBound(0), 4];
                ConsultaSeq2.Text = VGlobal.Ativo[VGlobal.Ativo.GetLowerBound(0), 5];
                lbPrimeiro.Text = Convert.ToString(VGlobal.Ativo.GetLowerBound(0) + 1);
                lbUltimo.Text = Convert.ToString(VGlobal.Ativo.GetUpperBound(0) + 1);
            }

            LOGAtivo.Text += VGlobal.LogLocal.Text;
        }

        private void btEsquerda_Click(object sender, EventArgs e)
        {
            if (VGlobal.AtivoContagem == 0)
            {
                VGlobal.AtivoContagem = VGlobal.Ativo.GetUpperBound(0);
            }
            else
            {
                VGlobal.AtivoContagem--;
            }
            ConsultaCategoria.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 0];
            ConsultaSigla.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 1];
            ConsultaDescricao.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 2];
            ConsultaTipo.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 3];
            ConsultaSeq1.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 4];
            ConsultaSeq2.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 5];
            lbPrimeiro.Text = Convert.ToString(VGlobal.AtivoContagem + 1);
        }

        private void btDireita_Click(object sender, EventArgs e)
        {
            if (VGlobal.AtivoContagem == VGlobal.Ativo.GetUpperBound(0))
            {
                VGlobal.AtivoContagem = 0;
            }
            else
            {
                VGlobal.AtivoContagem++;
            }
            ConsultaCategoria.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 0];
            ConsultaSigla.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 1];
            ConsultaDescricao.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 2];
            ConsultaTipo.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 3];
            ConsultaSeq1.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 4];
            ConsultaSeq2.Text = VGlobal.Ativo[VGlobal.AtivoContagem, 5];
            lbPrimeiro.Text = Convert.ToString(VGlobal.AtivoContagem + 1);
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            LOGAtivo.Text += "===========================HELP===========================\r\n";
            LOGAtivo.Text += "Para o cadastramento do Tipo de Ativo deverá haver um arquivo tipo .TXT contendo as informações descritas, separadas por virgula e sem espacos,sendo que cada linha e um item novo.\r\n";
            LOGAtivo.Text += "Para os ativos sao 6 itens no total.\r\n";
            LOGAtivo.Text += "1 - Categoria, 2 - Sigla, 3 -Descricao, 4 - Tipo, 5 - Sequencia 1, 6 - Seguencia 2\r\nEx.:\r\n";
            LOGAtivo.Text += "Renda Fixa,ADA,ALONGAMENTO DA DIVIDA AGRICOLA,ADA,0a0,0a0\r\n";
            LOGAtivo.Text += "===========================HELP===========================\r\n";

        }

    }
}
