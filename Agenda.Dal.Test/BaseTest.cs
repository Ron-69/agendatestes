using System;
using NUnit.Framework;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Agenda.Dal.Test
{
    [TestFixture]
    public class BaseTest
    {
        //Três variáveis
        private string _script;
        private string _con;
        private string _catalogTest;

        public BaseTest()//Construtor da classe
        {
            _script = @"DBAgendaTest_Create.sql"; //script criado para o projeto de teste Agenda.Dal.Test
            _con = ConfigurationManager.ConnectionStrings["conSetUpTest"].ConnectionString; // leitura da string de connection que aponta para AgendaTest
            _catalogTest = ConfigurationManager.ConnectionStrings["conSetUpTest"].ProviderName;// leitura do ProviderName
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
           CreateDBTest();
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
           DeleteDBTest();
        }

        private void CreateDBTest() 
        {
            using(var con = new SqlConnection(_con))
            {
                con.Open();
                var scriptSql = File // classe File precisa
                    .ReadAllText($@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\{_script}")
                    .Replace("$(DefaultDataPath)", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    .Replace("$(DefaultLogPath)", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    .Replace("$(DefaultFilePrefix)", _catalogTest)
                    .Replace("$(DatabaseName)", _catalogTest)
                    .Replace("WITH (DATA_COMPRESSION = PAGE)", string.Empty)
                    .Replace("SET NOEXEC ON", string.Empty)
                    .Replace("GO\r\n", "|");
                ExecuteScriptSql(con, scriptSql);

            }
        }

        private void ExecuteScriptSql(SqlConnection con, string scriptSql)
        {
            using (var cmd = con.CreateCommand())
            {
                foreach(var sql in scriptSql.Split('|'))
                {
                    cmd.CommandText = sql;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(sql);
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        private void DeleteDBTest()
        {
            using(var con = new SqlConnection(_con))
            {
                con.Open();
                using(var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $@"USE [master];
                                        DECLARE @KILL varchar(8000) = '';
                                        SELECT @KILL = @KILL + 'KILL ' + CONVERT(varchar(5), session_id) + ';'
                                        FROM sys.dm_exec_sessions
                                        WERE database_id = db_id('{_catalogTest}')
                                        EXEC(@KILL);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"DROP DATABASE {_catalogTest}";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
