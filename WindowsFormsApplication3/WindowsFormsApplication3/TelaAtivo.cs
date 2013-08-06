using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            EnderecoCadastro.Text = "c:\\input\\EMISSOR.txt";
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
        }

        private void btCadastra_Click(object sender, EventArgs e)
        {
            #region Variaveis
            VGlobal.RetornoFalha = false;
            VGlobal.EndAtivo = @EnderecoCadastro.Text;
            #endregion
            if (EnderecoCadastro.Text != "")
            {
                ProcessoEmissor obProgramaEmissor = new ProcessoEmissor();
                obProgramaEmissor.GerenciaProcessoCadastroTipoAtivo();

                LOGEmissor.Text += ProcessoEmissor.LogLocal.Text;
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
            VGlobal.EmissorContagem = 0;
            VGlobal.RetornoFalha = false;
            #endregion

            ProcessoEmissor obProgramaEmissor = new ProcessoEmissor();
            VGlobal.Emissor = obProgramaEmissor.GerenciaProcessoConsultaEmissor(ConsultaCodigo.Text, ConsultaNome.Text, ConsultaCNPJ.Text, ConsultaData.Text);

            if (VGlobal.RetornoFalha == false)
            {
                if (VGlobal.Emissor.GetUpperBound(0) != 0)
                {
                    btEsquerda.Enabled = true;
                    btDireita.Enabled = true;

                }
                ConsultaCodigo.Text = VGlobal.Emissor[VGlobal.Emissor.GetLowerBound(0), 0];
                ConsultaNome.Text = VGlobal.Emissor[VGlobal.Emissor.GetLowerBound(0), 1];
                ConsultaCNPJ.Text = VGlobal.Emissor[VGlobal.Emissor.GetLowerBound(0), 2];
                ConsultaData.Text = VGlobal.Emissor[VGlobal.Emissor.GetLowerBound(0), 3];
                lbPrimeiro.Text = Convert.ToString(VGlobal.Emissor.GetLowerBound(0) + 1);
                lbUltimo.Text = Convert.ToString(VGlobal.Emissor.GetUpperBound(0) + 1);
            }

            LOGEmissor.Text += ProcessoEmissor.LogLocal.Text;
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
            ConsultaCodigo.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 0];
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
            ConsultaCodigo.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 0];
            ConsultaNome.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 1];
            ConsultaCNPJ.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 2];
            ConsultaData.Text = VGlobal.Emissor[VGlobal.EmissorContagem, 3];
            lbPrimeiro.Text = Convert.ToString(VGlobal.EmissorContagem + 1);
        }

    }
}
