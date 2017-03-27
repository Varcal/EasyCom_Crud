using System;
using Easy.Domain.Entities;
using Easy.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Easy.Domain.Tests.Entities
{
    [TestClass]
    public class DadoBancarioTest
    {
        private string nome;
        string cpf;
        string nomeBanco;
        string agencia;
        TipoConta tipoConta;
        private string numeroConta;


        [TestInitialize]
        public void Initialize()
        {
            nome = "Cleber Varçal";
            cpf = "28643670847";
            nomeBanco = "Itau";
            agencia = "9252";
            tipoConta = TipoConta.Corrente;
            numeroConta = "090486";
        }

        [TestMethod]
        [TestCategory("Entidades - DadoBancario")]
        public void Quando_Criar_Um_DadoBancario()
        {

            var dadoBancario = new DadoBancario(nome, cpf, nomeBanco, agencia, tipoConta, numeroConta);

            Assert.IsNotNull(dadoBancario);
            Assert.AreEqual(nome, dadoBancario.Nome);
            Assert.AreEqual(cpf, dadoBancario.Cpf.ToString());
            Assert.AreEqual(nomeBanco, dadoBancario.NomeBanco);
            Assert.AreEqual(agencia, dadoBancario.Agencia);
            Assert.AreEqual(tipoConta, dadoBancario.TipoConta);
            Assert.AreEqual(numeroConta, dadoBancario.NumeroConta);
            Assert.IsTrue(dadoBancario.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - DadoBancario")]
        public void Quando_Criar_Um_DadoBancario_Nome_Deve_Ser_Obrigatorio()
        {
            nome = string.Empty;


            var dadoBancario = new DadoBancario(nome, cpf, nomeBanco, agencia, tipoConta, numeroConta);


            Assert.IsFalse(dadoBancario.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - DadoBancario")]
        public void Quando_Criar_Um_DadoBancario_Cpf_Deve_Ser_Obrigatorio()
        {
            cpf = string.Empty;

            var dadoBancario = new DadoBancario(nome, cpf, nomeBanco, agencia, tipoConta, numeroConta);

            Assert.IsFalse(dadoBancario.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - DadoBancario")]
        public void Quando_Criar_Um_DadoBancario_NomeBanco_Deve_Ser_Obrigatorio()
        {
            nomeBanco = String.Empty;

            var dadoBancario = new DadoBancario(nome, cpf, nomeBanco, agencia, tipoConta, numeroConta);

            Assert.IsFalse(dadoBancario.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - DadoBancario")]
        public void Quando_Criar_Um_DadoBancario_Agencia_Deve_Ser_Obrigatorio()
        {
            agencia = string.Empty;

            var dadoBancario = new DadoBancario(nome, cpf, nomeBanco, agencia, tipoConta, numeroConta);

            Assert.IsFalse(dadoBancario.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - DadoBancario")]
        public void Quando_Criar_Um_DadoBancario_TipoConta_Deve_Ser_Obrigatorio()
        {
            tipoConta = 0;

            var dadoBancario = new DadoBancario(nome, cpf, nomeBanco, agencia, tipoConta, numeroConta);

            Assert.IsFalse(dadoBancario.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - DadoBancario")]
        public void Quando_Criar_Um_DadoBancario_NumeroConta_Deve_Ser_Obrigatorio()
        {
            numeroConta = String.Empty;

            var dadoBancario = new DadoBancario(nome, cpf, nomeBanco, agencia, tipoConta, numeroConta);

            Assert.IsFalse(dadoBancario.IsValid());
        }
    }
}
