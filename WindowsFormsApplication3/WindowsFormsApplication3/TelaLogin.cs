using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Security.Cryptography;

namespace XMLBackOffice
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
            VGlobal.LogLocal.Text = "";
        }


        private void btConsulta_Click(object sender, EventArgs e)
        {
            if (GestaoUsuario.GerenciaProcessoDeLogin(ConsultaUsuario.Text, ConsultaSenha.Text))
            {
                ConsultaSenha.Text = "";
                this.Close();
            }
        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (GestaoUsuario.GerenciaProcessoDeLogin(ConsultaUsuario.Text, ConsultaSenha.Text))
                {
                    ConsultaSenha.Text = "";
                    this.Close();
                }
            }
        }
    }
}
