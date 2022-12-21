using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Agenda.Domain;
using Dapper;

namespace Agenda.DAO
{
    public class Contatos
    {
        string _strCon;
       // SqlConnection _con; //Estamos usando variável local
         

        public Contatos() 
        {
            //String para acessar o Database usando a conexão con que aponta para obanco de teste
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //_con = new SqlConnection(_strCon);
           

        }

        public void Adicionar(Contato contato) 
        {
            using(var con = new SqlConnection(_strCon))
            {
                con.Execute("insert into Contato (Id, Nome) values (@Id, @Nome)", contato);//reduzimos para uma única linha usando Dapper e LINQ
                //con.Open();

                //var sql = string.Format("insert into Contato (Id, Nome) values ('{0}', '{1}');", contato.Id, contato.Nome); //usando classe Contato() do projeto Agenda.Domain

                //var cmd = new SqlCommand(sql, con); 

                //cmd.ExecuteNonQuery(); //devolve o número de linhas afetadas
            }
            //_con.Close(); //Não precisa mais do Close() pois agora o escopo já interropnpe o Open()
        }

        public Contato Obter(Guid id)
        {
            Contato contato; //veio para fora
            using (var con = new SqlConnection(_strCon))
            {
                // _strCon.Open(); pode tirar pois estamos usando a variável local
                //_con.Open(); 
               
                contato = con.QueryFirst<Contato>("select Id, Nome from Contato where Id = @Id", new { Id = id });//objeto anônimo pois nós só temos um parametro Guid
               
                //Fizemos este código antes de usar o Dapper
                /*con.Open();//Estomos usando o con agora, varável local

                var sql = String.Format("select Id, Nome from Contato where Id ='{0}';", id);

                var cmd = new SqlCommand(sql, con);

                var sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                //instancia de contato para retornar
                var contato = new Contato()
                {
                    Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                    Nome = sqlDataReader["Nome"].ToString() //ToString porque o sqlDataReader() retorna um object
                };*/
            }
            return contato;


        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                contatos = con.Query<Contato>("select Id, Nome from Contato").ToList(); //usando Dapper e Linq
               /* con.Open();

                var sql = String.Format("select Id, Nome from Contato");

                var cmd = new SqlCommand(sql, con);

                var sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var contato = new Contato()
                    {
                        Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                        Nome = sqlDataReader["Nome"].ToString()
                    };
                    contatos.Add(contato);

                }*/
            }
            return contatos;
        }
    }
}
