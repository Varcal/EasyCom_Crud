using System;
using System.Collections.Generic;
using Easy.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Easy.Domain.Tests.Entities
{
    [TestClass]
    public class ProgramadorTest
    {
        private string _nome;
        string _cidade;
        string _estado;
        string _portifolio;
        int _pretensaoSalarial;
        private string _outros;
        private Contato _contato;
        private IList<Especialidade> _especialidades;
        private IList<Disponibilidade> _disponilibilidades;
        private IList<HorarioTrabalho> _horariosTrabalhos;
        string _gitHubLink;

        [TestInitialize]
        public void Initialize()
        {
            
            _nome = "Cleber Varçal";
            _cidade = "São Paulo";
            _estado = "SP";
            _portifolio = string.Empty;
            _pretensaoSalarial = 50;
            _outros = String.Empty;

            string email = "cleber.varcal@varcalsys.com.br";
            string skype = "varcalsys";
            string telefone = "11947771384";
            string linkedin = string.Empty;
            
            _contato = new Contato(email, skype, telefone, linkedin);
            _especialidades = new List<Especialidade>() { new Especialidade(1,3), new Especialidade(2,4) };
            _disponilibilidades = new List<Disponibilidade>(){new Disponibilidade("De 4 a 6 Horas"), new Disponibilidade("De 6 a 8 Horas")};
            _horariosTrabalhos = new List<HorarioTrabalho>(){new HorarioTrabalho("Das 9 as 18h"), new HorarioTrabalho("9 as 13")};
             _gitHubLink = String.Empty;

        }

        [TestMethod]
        [TestCategory("Entidades - Programador")]
        public void Quando_Criar_Um_Programador()
        {
            

            var programador = new Programador(_nome,_gitHubLink, _contato, _especialidades, _disponilibilidades, _horariosTrabalhos, _cidade, _estado, _portifolio, _pretensaoSalarial, _outros);

            Assert.IsNotNull(programador);
            Assert.AreEqual(_gitHubLink, programador.GitHubLink);
            Assert.IsNotNull(programador.DadosCadastro);
            Assert.IsTrue(_especialidades.Count > 0);
            Assert.IsTrue(programador.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Programador")]
        public void Quando_Criar_Um_Programador_Nome_Deve_Ser_Obrigatorio()
        {
            _nome = string.Empty;

            var programador = new Programador(_nome, _gitHubLink, _contato, _especialidades, _disponilibilidades, _horariosTrabalhos, _cidade, _estado, _portifolio, _pretensaoSalarial, _outros);


            Assert.IsFalse(programador.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Programador")]
        public void Quando_Criar_Um_Programador_Cidade_Deve_Ser_Obrigatorio()
        {
            _cidade = string.Empty;

            var programador = new Programador(_nome, _gitHubLink, _contato, _especialidades, _disponilibilidades, _horariosTrabalhos, _cidade, _estado, _portifolio, _pretensaoSalarial, _outros);


            Assert.IsFalse(programador.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Programador")]
        public void Quando_Criar_Um_Programador_Estado_Deve_Ser_Obrigatorio()
        {
            _estado = string.Empty;

            var programador = new Programador(_nome, _gitHubLink, _contato, _especialidades, _disponilibilidades, _horariosTrabalhos, _cidade, _estado, _portifolio, _pretensaoSalarial, _outros);


            Assert.IsFalse(programador.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Programador")]
        public void Quando_Criar_Um_Programador_PretensaoSalarial_Deve_Ser_Obrigatorio()
        {
            _pretensaoSalarial = 0;

            var programador = new Programador(_nome, _gitHubLink, _contato, _especialidades, _disponilibilidades, _horariosTrabalhos, _cidade, _estado, _portifolio, _pretensaoSalarial, _outros);


            Assert.IsFalse(programador.IsValid());
        }


        [TestMethod]
        [TestCategory("Entidades - Programador")]
        public void Quando_Criar_Um_Programador_DadosCasdastro_Deve_Ser_Obrigatorio()
        {
            _contato = null;

            var programador = new Programador(_nome, _gitHubLink, _contato, _especialidades, _disponilibilidades, _horariosTrabalhos, _cidade, _estado, _portifolio, _pretensaoSalarial, _outros);


            Assert.IsFalse(programador.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Programador")]
        public void Quando_Criar_Um_Programador_Especialidades_Deve_Ser_Obrigatorio()
        {
            _especialidades = null;

            var programador = new Programador(_nome, _gitHubLink, _contato, _especialidades, _disponilibilidades, _horariosTrabalhos, _cidade, _estado, _portifolio, _pretensaoSalarial, _outros);


            Assert.IsFalse(programador.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Programador")]
        public void Quando_Criar_Um_Programador_Disponilidades_Deve_Ser_Obrigatorio()
        {
            _disponilibilidades = null;

            var programador = new Programador(_nome, _gitHubLink, _contato, _especialidades, _disponilibilidades, _horariosTrabalhos, _cidade, _estado, _portifolio, _pretensaoSalarial, _outros);


            Assert.IsFalse(programador.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Programador")]
        public void Quando_Criar_Um_Programador_HorarioTrabalho_Deve_Ser_Obrigatorio()
        {
            _horariosTrabalhos = null;

            var programador = new Programador(_nome, _gitHubLink, _contato, _especialidades, _disponilibilidades, _horariosTrabalhos, _cidade, _estado, _portifolio, _pretensaoSalarial, _outros);


            Assert.IsFalse(programador.IsValid());
        }
    }
}
