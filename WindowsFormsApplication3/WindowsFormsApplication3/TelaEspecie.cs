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
    public partial class TelaEspecie : Form
    {
        public TelaEspecie()
        {
            InitializeComponent();
        }

        private void TelaEspecie_Load(object sender, EventArgs e)
        {
            //Inicializa variaveis com valor padrao
            EnderecoCadastro.Text = "c:\\input\\ESPECIE.txt";
            ConsultaDescricao.Text = "";
            ConsultaCodigo.Text = "";
            lbPrimeiro.Text = "0";
            lbUltimo.Text = "0";
            btEsquerda.Enabled = false;
            btDireita.Enabled = false;
            VGlobal.rtLOG = new RichTextBox();

            //Apaga LOG antigo.
            File.Delete(VGlobal.LOGEspecie);
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {

        }

        private void btLimpa_Click(object sender, EventArgs e)
        {
            EnderecoCadastro.Text = "";
            ConsultaDescricao.Text = "";
            ConsultaCodigo.Text = "";
            lbPrimeiro.Text = "0";
            lbUltimo.Text = "0";
            btEsquerda.Enabled = false;
            btDireita.Enabled = false;
        }

        private void btConsulta_Click(object sender, EventArgs e)
        {
            #region Variaveis
            VGlobal.EspecieContagem = 0;
            VGlobal.RetornoFalha = false;
            #endregion

            ProcessoEspecie obProgramaEspecie = new ProcessoEspecie();
            VGlobal.Especie = obProgramaEspecie.GerenciaProcessoConsultaEspecie(ConsultaDescricao.Text, ConsultaCodigo.Text);

            if (VGlobal.RetornoFalha == false)
            {
                if (VGlobal.Especie.GetUpperBound(0) != 0)
                {
                    btEsquerda.Enabled = true;
                    btDireita.Enabled = true;

                }
                ConsultaDescricao.Text = VGlobal.Especie[VGlobal.Especie.GetLowerBound(0), 0];
                ConsultaCodigo.Text = VGlobal.Especie[VGlobal.Especie.GetLowerBound(0), 1];
                lbPrimeiro.Text = Convert.ToString(VGlobal.Especie.GetLowerBound(0) + 1);
                lbUltimo.Text = Convert.ToString(VGlobal.Especie.GetUpperBound(0) + 1);
            }

            LOGEspecie.Text += VGlobal.LogLocal.Text;
        }

        private void btEsquerda_Click(object sender, EventArgs e)
        {
            if (VGlobal.EspecieContagem == 0)
            {
                VGlobal.EspecieContagem = VGlobal.Especie.GetUpperBound(0);
            }
            else
            {
                VGlobal.EspecieContagem--;
            }
            ConsultaDescricao.Text = VGlobal.Especie[VGlobal.EspecieContagem, 0];
            ConsultaCodigo.Text = VGlobal.Especie[VGlobal.EspecieContagem, 1];
            lbPrimeiro.Text = Convert.ToString(VGlobal.EspecieContagem + 1);
        }

        private void btDireita_Click(object sender, EventArgs e)
        {
            if (VGlobal.EspecieContagem == VGlobal.Especie.GetUpperBound(0))
            {
                VGlobal.EspecieContagem = 0;
            }
            else
            {
                VGlobal.EspecieContagem++;
            }
            ConsultaDescricao.Text = VGlobal.Especie[VGlobal.EspecieContagem, 0];
            ConsultaCodigo.Text = VGlobal.Especie[VGlobal.EspecieContagem, 1];
            lbPrimeiro.Text = Convert.ToString(VGlobal.EspecieContagem + 1);
        }

        private void btCadastra_Click(object sender, EventArgs e)
        {
            {
                #region Variaveis
                VGlobal.RetornoFalha = false;
                VGlobal.EndEspecie = @EnderecoCadastro.Text;
                #endregion
                if (EnderecoCadastro.Text != "")
                {
                    ProcessoEspecie obProgramaEspecie = new ProcessoEspecie();
                    obProgramaEspecie.GerenciaProcessoCadastroEspecie();

                    LOGEspecie.Text += VGlobal.LogLocal.Text;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Selecionar arquivo de Especie primeiro!", "ERROR", MessageBoxButtons.OK);
                    VGlobal.rtLOG.Text += "Selecionar arquivo de Especie primeiro!\r\n";
                }
            }
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            LOGEspecie.Text += "===========================HELP===========================\r\n";
            LOGEspecie.Text += "Para o cadastramento da Especie deverá haver um arquivo tipo .TXT contendo as informações descritas, separadas por virgula e sem espacos,sendo que cada linha e um item novo.\r\n";
            LOGEspecie.Text += "Para os ativos sao 2 itens no total.\r\n";
            LOGEspecie.Text += "1 - Descricao, 2 - Codigo\r\nEx.:\r\n";
            LOGEspecie.Text += "Preferenciais Classe A,PA\r\n";
            LOGEspecie.Text += "===========================HELP===========================\r\n";
        }
    }
}
