using System;
using Agenda.DAO;
using NUnit.Framework;
using Agenda.Domain;
using AutoFixture;

namespace Agenda.Dao.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }


        [Test]
        public void AdicionarContatoTest()
        {
            var contato = new Contato()
            //var id = Guid.NewGuid().ToString();
            //var nome = "Marcos";
           
            {
                //O teste passou passando esse objeto
                // Id = Guid.NewGuid(), // até agora usavamos variáveis, agora usaremos a classe Contato() do projeto Agenda.Domain
                // Nome = "Marcos"

                //Usando fixture para não passar propriedades fixas
                Id = _fixture.Create<Guid>(),
                Nome = _fixture.Create<string>()
            };


            _contatos.Adicionar(contato); //passando a variável contato que recebeu uma instância da classe Contato do projeto Agenda.Domain

            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            // var contato = new Contato()
            //Usando o fixture para criar a classe toda
            Contato contato = _fixture.Create<Contato>();
            /*{
             *  //Criando a propriedades de maneira fixo- não é recomendado
                //Id = Guid.NewGuid(),
                //Nome = "Maria"

               //Usndo o fixture para criar as propriedade de maneira dinâmica
                Id = _fixture.Create<Guid>(), //usando a classe fixture não precisa mais passar cada propriedade
                Nome = _fixture.Create<String>() //usando a classe fixture não precisa mais passar cada propriedade
            };*/

            Contato contatoResultado;

            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);

        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }

}
