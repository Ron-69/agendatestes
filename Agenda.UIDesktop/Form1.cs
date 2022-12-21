using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            //txtContatoSalvo.Text = nome;

            //atribuindo a string de conexão a uma variavel que será passada no parâmetro do objeto que faz a conexão como o banco
            string strCon = @"Data Source=.\sqlexpress;Initial Catalog=Agenda;Integrated Security=True;";
            string id =  Guid.NewGuid().ToString();

            //Instanciando um objeto chamado con do classe SqlConnection
            SqlConnection con = new SqlConnection(strCon);
            //abrindo a sessão com banco
            con.Open();

            //Guid -> identificador global exclusivo e ToString() pois ele vai ser gravado como texto
            //string sql = string.Format("insert into Contato (Id, Nome) values ('{0}', '{1}');", Guid.NewGuid().ToString(), nome );
            string sql = string.Format("insert into Contato (Id, Nome) values ('{0}', '{1}');",id , nome);

            SqlCommand cmd = new SqlCommand(sql, con);

            //executando o comando
            cmd.ExecuteNonQuery();

            //fechando a sessão com o banco

            sql = String.Format("select Nome from Contato where Id ='{0}';", id);

            cmd = new SqlCommand(sql, con);

            txtContatoSalvo.Text =  cmd.ExecuteScalar().ToString();

            con.Close();
        }
    }
}
