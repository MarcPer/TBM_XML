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
    public partial class TelaAlteraSenha : Form
    {
        public TelaAlteraSenha()
        {
            InitializeComponent();
            SQLXML.AtualizaResetSenha();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            #region Variaveis
            //Variáveis

            #endregion
            if (GestaoUsuario.CadastraNovaSenha(ConsultaNovaSenha.Text, ConsultaRepitaSenha.Text))
            {
                this.Close();
            }

        }

    }
}
