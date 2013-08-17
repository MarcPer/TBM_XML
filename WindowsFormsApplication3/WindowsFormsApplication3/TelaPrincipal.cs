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
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btEmissor_Click(object sender, EventArgs e)
        {

            try
            {
                //Precisa criar uma nova thread para abrir uma nova tela
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProcEmissor));
                t.Start();
                rtLOG.Text += "Janela de Emissor aberta.\r\n";
            }
            catch (Exception E)
            {
                rtLOG.Text += E.ToString();
            }
        }

        private void btTipoAtivo_Click(object sender, EventArgs e)
        {
            try
            {
                //Precisa criar uma nova thread para abrir uma nova tela
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProcTipoAtivo));
                t.Start();
                rtLOG.Text += "Janela de Tipo Aitvo aberta.\r\n";
            }
            catch (Exception E)
            {
                rtLOG.Text += E.ToString();
            }
        }

        //Precisa criar uma nova thread para abrir uma nova tela
        #region Threads

        public static void ThreadProcEmissor()
        {

            Application.Run(new TelaEmissor());

        }

        public static void ThreadProcTipoAtivo()
        {

            Application.Run(new TelaAtivo());

        }

        public static void ThreadProcEspecie()
        {

            Application.Run(new TelaEspecie());

        }

        public static void ThreadProcIndexador()
        {

            Application.Run(new TelaIndexador());

        }

        #endregion

        private void btEspecie_Click(object sender, EventArgs e)
        {
            try
            {
                //Precisa criar uma nova thread para abrir uma nova tela
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProcEspecie));
                t.Start();
                rtLOG.Text += "Janela de Especie aberta.\r\n";
            }
            catch (Exception E)
            {
                rtLOG.Text += E.ToString();
            }
        }

        private void btIndexador_Click(object sender, EventArgs e)
        {
            try
            {
                //Precisa criar uma nova thread para abrir uma nova tela
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProcIndexador));
                t.Start();
                rtLOG.Text += "Janela de Indexador aberta.\r\n";
            }
            catch (Exception E)
            {
                rtLOG.Text += E.ToString();
            }
        }
    }

}
