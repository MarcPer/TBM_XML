using System;
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
    public partial class TelaIndexador : Form
    {
        public TelaIndexador()
        {
            InitializeComponent();
             }

        private void TelaIndexador_Load(object sender, EventArgs e)
        {
            //Inicializa variaveis com valor padrao
            EnderecoCadastro.Text = "c:\\input\\Indexador.txt";
            ConsultaXML.Text = "";
            ConsultaRelatorio.Text = "";
            ConsultaDescricao.Text = "";
            lbPrimeiro.Text = "0";
            lbUltimo.Text = "0";
            btEsquerda.Enabled = false;
            btDireita.Enabled = false;
            VGlobal.rtLOG = new RichTextBox();

            //Apaga LOG antigo.
            File.Delete(VGlobal.LOGIndexador);
        }

        private void btLimpa_Click(object sender, EventArgs e)
        {
            EnderecoCadastro.Text = "c:\\input\\Indexador.txt";
            ConsultaXML.Text = "";
            ConsultaRelatorio.Text = "";
            ConsultaDescricao.Text = "";
            lbPrimeiro.Text = "0";
            lbUltimo.Text = "0";
            btEsquerda.Enabled = false;
            btDireita.Enabled = false;
        }

        private void btConsulta_Click(object sender, EventArgs e)
        {
            #region Variaveis
            VGlobal.IndexadorContagem = 0;
            VGlobal.RetornoFalha = false;
            #endregion

            ProcessoIndexador obProgramaIndexador = new ProcessoIndexador();
            VGlobal.Indexador = obProgramaIndexador.GerenciaProcessoConsultaIndexador(ConsultaXML.Text, ConsultaRelatorio.Text, ConsultaDescricao.Text);

            if (VGlobal.RetornoFalha == false)
            {
                if (VGlobal.Indexador.GetUpperBound(0) != 0)
                {
                    btEsquerda.Enabled = true;
                    btDireita.Enabled = true;

                }
                ConsultaXML.Text = VGlobal.Indexador[VGlobal.IndexadorContagem, 0];
                ConsultaRelatorio.Text = VGlobal.Indexador[VGlobal.IndexadorContagem, 1];
                ConsultaDescricao.Text = VGlobal.Indexador[VGlobal.IndexadorContagem, 2];
                lbPrimeiro.Text = Convert.ToString(VGlobal.Indexador.GetLowerBound(0) + 1);
                lbUltimo.Text = Convert.ToString(VGlobal.Indexador.GetUpperBound(0) + 1);
            }

            LOGIndexador.Text += VGlobal.LogLocal.Text;
        }

        private void btEsquerda_Click(object sender, EventArgs e)
        {
            if (VGlobal.IndexadorContagem == 0)
            {
                VGlobal.IndexadorContagem = VGlobal.Indexador.GetUpperBound(0);
            }
            else
            {
                VGlobal.IndexadorContagem--;
            }
            ConsultaXML.Text = VGlobal.Indexador[VGlobal.IndexadorContagem, 0];
            ConsultaRelatorio.Text = VGlobal.Indexador[VGlobal.IndexadorContagem, 1];
            ConsultaDescricao.Text = VGlobal.Indexador[VGlobal.IndexadorContagem, 2];
            lbPrimeiro.Text = Convert.ToString(VGlobal.IndexadorContagem + 1);
        }

        private void btDireita_Click(object sender, EventArgs e)
        {
            if (VGlobal.IndexadorContagem == VGlobal.Indexador.GetUpperBound(0))
            {
                VGlobal.IndexadorContagem = 0;
            }
            else
            {
                VGlobal.IndexadorContagem++;
            }
            ConsultaXML.Text = VGlobal.Indexador[VGlobal.IndexadorContagem, 0];
            ConsultaRelatorio.Text = VGlobal.Indexador[VGlobal.IndexadorContagem, 1];
            ConsultaDescricao.Text = VGlobal.Indexador[VGlobal.IndexadorContagem, 2];
            lbPrimeiro.Text = Convert.ToString(VGlobal.IndexadorContagem + 1);
        }

        private void btCadastra_Click(object sender, EventArgs e)
        {
            #region Variaveis
            VGlobal.RetornoFalha = false;
            VGlobal.EndIndexador = @EnderecoCadastro.Text;
            #endregion
            if (EnderecoCadastro.Text != "")
            {
                ProcessoIndexador obProgramaIndexador = new ProcessoIndexador();
                obProgramaIndexador.GerenciaProcessoCadastroIndexador();

                LOGIndexador.Text += VGlobal.LogLocal.Text;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Selecionar arquivo de Indexador primeiro!", "ERROR", MessageBoxButtons.OK);
                VGlobal.rtLOG.Text += "Selecionar arquivo de Indexador primeiro!\r\n";
            }
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            LOGIndexador.Text += "===========================HELP===========================\r\n";
            LOGIndexador.Text += "Para o cadastramento do Indexador deverá haver um arquivo tipo .TXT contendo as informações descritas, separadas por virgula,sendo que cada linha e um item novo.\r\n";
            LOGIndexador.Text += "Para os indexadores sao 3 itens no total.\r\n";
            LOGIndexador.Text += "1 - XML, 2 - Relatorio, 3 -Descricao\r\nEx.:\r\n";
            LOGIndexador.Text += "IBR,IBrX-50,Índice Brasil-50 (IBrX-50)\r\n";
            LOGIndexador.Text += "===========================HELP===========================\r\n";
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {

        }
    }
}
