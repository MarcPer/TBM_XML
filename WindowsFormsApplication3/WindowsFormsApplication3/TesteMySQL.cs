using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Meu
using MySql.Data.MySqlClient;

namespace XMLBackOffice
{
    public partial class TesteMySQL : Form
    {
        public TesteMySQL()
        {
            InitializeComponent();
        }

        private void btConsulta_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(VGlobal.ParamConexMySQL);

            string query = "SELECT * FROM city";

            connection.Open();

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();
            //cmd.ExecuteNonQuery();
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            while (myReader.Read())
            {
                list[0].Add(myReader["Id"] + "");
                list[1].Add(myReader["Name"] + "");
                list[2].Add(myReader["CountryCode"] + "");
            }

            //close Data Reader
            myReader.Close();

            VGlobal.MySQLContagem = list[0].Count;
            VGlobal.MyList = list;

            VGlobal.MySQLContagem = 0;
            ConsultaCategoria.Text = VGlobal.MyList[0][VGlobal.MySQLContagem];
            ConsultaDescricao.Text = VGlobal.MyList[1][VGlobal.MySQLContagem];
            ConsultaSigla.Text = VGlobal.MyList[2][VGlobal.MySQLContagem];

            connection.Close();

        }

        private void btDireita_Click(object sender, EventArgs e)
        {
            if (VGlobal.MySQLContagem == VGlobal.MyList[0].Count)
            {
                VGlobal.MySQLContagem = 0;
            }
            else
            {
                VGlobal.MySQLContagem++;
            }
            ConsultaCategoria.Text = VGlobal.MyList[0][VGlobal.MySQLContagem];
            ConsultaDescricao.Text = VGlobal.MyList[1][VGlobal.MySQLContagem];
            ConsultaSigla.Text = VGlobal.MyList[2][VGlobal.MySQLContagem];
            lbPrimeiro.Text = Convert.ToString(VGlobal.MySQLContagem + 1);
        }

        private void btEsquerda_Click(object sender, EventArgs e)
        {
            if (VGlobal.MySQLContagem == 0)
            {
                VGlobal.MySQLContagem = VGlobal.MyList[0].Count;
            }
            else
            {
                VGlobal.MySQLContagem--;
            }
            ConsultaCategoria.Text = VGlobal.MyList[0][VGlobal.MySQLContagem];
            ConsultaDescricao.Text = VGlobal.MyList[1][VGlobal.MySQLContagem];
            ConsultaSigla.Text = VGlobal.MyList[2][VGlobal.MySQLContagem];
            lbPrimeiro.Text = Convert.ToString(VGlobal.MySQLContagem + 1);
        }
    }
}
