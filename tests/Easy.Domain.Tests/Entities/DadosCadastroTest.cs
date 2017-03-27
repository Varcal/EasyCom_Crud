using Easy.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Easy.Domain.Tests.Entities
{
    [TestClass]
    public class ContatoTest
    {
        string _email;
        string _skype;
        string _telefone;
        string _linkedin;


        [TestInitialize]
        public void Initialize()
        {
            _email = "cleber.varcal@varcalsys.com.br";
            _skype = "varcalsys";
            _telefone = "11947771384";
            _linkedin = string.Empty;
        }



        [TestMethod]
        [TestCategory("Entidades - Contato")]
        public void Quando_Criar_Contato()
        {

            var contato = new Contato(_email, _skype, _telefone, _linkedin);


            Assert.IsNotNull(contato);
            Assert.AreEqual(_email, contato.Email.ToString());
            Assert.AreEqual(_skype, contato.Skype);
            Assert.AreEqual(_telefone, contato.Telefone);
            Assert.AreEqual(_linkedin, contato.Linkedin);
            Assert.IsTrue(contato.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Contato")]
        public void Quando_Criar_Contato_Email_Deve_Ser_Obrigatorio()
        {
            _email = string.Empty;

            var contato = new Contato(_email, _skype, _telefone, _linkedin);

            Assert.IsFalse(contato.IsValid());
        }
        

        [TestMethod]
        [TestCategory("Entidades - Contato")]
        public void Quando_Criar_Contato_Skype_Deve_Ser_Obrigatorio()
        {
            _skype = string.Empty;

            var contato = new Contato(_email, _skype, _telefone, _linkedin);

            Assert.IsFalse(contato.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Contato")]
        public void Quando_Criar_Contato_Telefone_Deve_Ser_Obrigatorio()
        {
            _telefone = string.Empty;

            var contato = new Contato(_email, _skype, _telefone, _linkedin);

            Assert.IsFalse(contato.IsValid());
        }
    }
}
