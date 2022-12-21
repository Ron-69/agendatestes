using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoFixture;
using Agenda.DAO;
using Agenda.Domain;

namespace Agenda.Dal.Test
{
    [TestFixture]
    public class Contatos2Test : BaseTest
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
        public void ObterTodosContatosTest()
        {
            //Monta
            // var contato1 = new Contato(){Id = Guid.NewGuid(),Nome = "Maria"}; 
            // var contato2 = new Contato() { Id = Guid.NewGuid(), Nome = "João" };
            var contato1 = _fixture.Create<Contato>(); //Não precisa mais ficar botando dados fixos
            var contato2 = _fixture.Create<Contato>(); //Não precisa mais ficar botando dados fixos
            //Executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var lstContato = _contatos.ObterTodos();
            var contatoResultado = lstContato.Where(o => o.Id == contato1.Id).FirstOrDefault();
            //Verifica
            //Assert.IsTrue(lstContato.Count() > 1);
            Assert.AreEqual(2, lstContato.Count());
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);

        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }

    }
}
