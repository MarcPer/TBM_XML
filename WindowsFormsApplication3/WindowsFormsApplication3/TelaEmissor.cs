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
    public partial class TelaEmissor : Form
    {
        public TelaEmissor()
        {
            InitializeComponent();
        }

        private void TelaEmissor_Load(object sender, EventArgs e)
        {
            //Inicializa variaveis com valor padrao
            EnderecoCadastro.Text = "c:\\input\\EMISSOR.txt";
            ConsultaTipo.Text = "";
            ConsultaNome.Text = "";
            ConsultaCNPJ.Text = "";
            ConsultaData.Text = "";
            lbPrimeiro.Text = "0";
            lbUltimo.Text = "0";
            btEsquerda.Enabled = false;
            btDireita.Enabled = false;
            VGlobal.rtLOG = new RichTextBox();

            //Apaga LOG antigo.
            File.Delete(VGlobal.LOGEmissor);
        }

        private void btCadastra_Click(object sender, EventArgs e)
        {
            #region Variaveis
            VGlobal.RetornoFalha = false;
            VGlobal.EndEmissor = @EnderecoCadastro.Text;
            #endregion
            if (EnderecoCadastro.Text != "")
            {
                ProcessoEmissor obProgramaEmissor = new ProcessoEmissor();
                obProgramaEmissor.GerenciaProcessoCadastroEmissor();

                LOGEmissor.Text += ProcessoEmissor.LogLocal.Text;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Selecionar arquivo de Emissor primeiro!", "ERROR", MessageBoxButtons.OK);
                VGlobal.rtLOG.Text += "Selecionar arquivo de Emissor primeiro!\r\n";
            }
        }

        private void btConsulta_Click(object sender, EventArgs e)
        {
            #region Variaveis
            VGlobal.EmissorContagem = 0;
            VGlobal.RetornoFalha = false;
            #endregion

            ProcessoEmissor obProgramaEmissor = new ProcessoEmissor();
            VGlobal.Emissor = obProgramaEmissor.GerenciaProcessoConsultaEmissor(ConsultaCNPJ.Text);

            if (VGlobal.RetornoFalha == false)
            {
                if (VGlobal.Emissor.GetUpperBound(0) != 0)
                {
                    btEsquerda.Enabled = true;
                    btDireita.Enabled = true;

                }
                ConsultaTipo.Text = VGlobal.Emissor[VGlobal.Emissor.GetLowerBound(0), 0];
                ConsultaNome.Text = VGlobal.Emissor[VGlobal.Emissor.GetLowerBound(0), 1];
                ConsultaCNPJ.Text = VGlobal.Emissor[VGlobal.Emissor.GetLowerBound(0), 2];
                ConsultaData.Text = VGlobal.Emissor[VGlobal.Emissor.GetLowerBound(0), 3];
                lbPrimeiro.Text = Convert.ToString(VGlobal.Emissor.GetLowerBound(0) + 1);
                lbUltimo.Text = Convert.ToString(VGlobal.Emissor.GetUpperBound(0) + 1);
            }

            LOGEmissor.Text += ProcessoEmissor.LogLocal.Text;
        }

        private void btLimpa_Click(object sender, EventArgs e)
        {
            EnderecoCadastro.Text = "";
            ConsultaTipo.Text = "";
            ConsultaNome.Text = "";
            ConsultaCNPJ.Text = "";
            ConsultaData.Text = "";
            lbPrimeiro.Text = "0";
            lbUltimo.Text = "0";
            btEsquerda.Enabled = false;
            btDireita.Enabled = false;
        }

        private void btEsquerda_Click(object sender, EventArgs e)
        {
            if (VGlobal.EmissorContagem == 0)
            {
                VGlobal.EmissorContagem = VGlobal.Emissor.GetUpperBound(0);
            }
            else
            {
                VGlobal.EmissorContagem--;
            }
            ConsultaTipo.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 0];
            ConsultaNome.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 1];
            ConsultaCNPJ.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 2];
            ConsultaData.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 3];
            lbPrimeiro.Text = Convert.ToString(VGlobal.EmissorContagem + 1);
        }

        private void btDireita_Click(object sender, EventArgs e)
        {
            if (VGlobal.EmissorContagem == VGlobal.Emissor.GetUpperBound(0))
            {
                VGlobal.EmissorContagem = 0;
            }
            else
            {
                VGlobal.EmissorContagem++;
            }
            ConsultaTipo.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 0];
            ConsultaNome.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 1];
            ConsultaCNPJ.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 2];
            ConsultaData.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 3];
            lbPrimeiro.Text = Convert.ToString(VGlobal.EmissorContagem + 1);
        }


    }
}
