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
    }
}
