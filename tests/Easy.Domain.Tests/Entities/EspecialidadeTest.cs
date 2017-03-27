using Easy.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Easy.Domain.Tests.Entities
{
    [TestClass]
    public class EspecialidadeTest
    {
        [TestMethod]
        [TestCategory("Entidades - Especialidade")]
        public void Quando_Criar_Uma_Especialidade()
        {
            var especialidadeTipoId = 1;
            var nota = 0;

            var especialidade = new Especialidade(especialidadeTipoId, nota);

            Assert.IsNotNull(especialidade);
            Assert.AreEqual(especialidadeTipoId, especialidade.EspecialidadeTipoId);
            Assert.AreEqual(nota, especialidade.Nota);
            Assert.IsTrue(especialidade.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Especialidade")]
        public void Quando_Criar_Uma_Especialidade_EspecialidadeTipoId_Deve_Ser_Obrigatoria()
        {
            var especialidadeTipoId = 0;
            var nota = 0;

            var especialidade = new Especialidade(especialidadeTipoId, nota);

            
            Assert.IsFalse(especialidade.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Especialidade")]
        public void Quando_Criar_Uma_Especialidade_Nota_Deve_Ser_Maior_Igual_a_0()
        {
            var especialidadeTipoId = 0;
            var nota = -1;

            var especialidade = new Especialidade(especialidadeTipoId, nota);

            
            Assert.IsFalse(especialidade.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Especialidade")]
        public void Quando_Criar_Uma_Especialidade_Nota_Deve_Ser_Menor_Igual_a_5()
        {
            var especialidadeTipoId = 0;
            var nota = 6;

            var especialidade = new Especialidade(especialidadeTipoId, nota);

           
            Assert.IsFalse(especialidade.IsValid());
        }
    }
}
