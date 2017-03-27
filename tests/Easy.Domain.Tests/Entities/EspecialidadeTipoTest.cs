using Easy.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Easy.Domain.Tests.Entities
{
    [TestClass]  
    public class EspecialidadeTipoTest
    {
        [TestMethod]
        [TestCategory("Entidades - EspecialidadeTipo")]
        public void Quando_Criar_Uma_EspecialidadeTipo()
        {
            string descricao = "Asp Net MVC";
            bool obrigatoria = true;

            var especialidadeTipo = new EspecialidadeTipo(descricao, obrigatoria);


            Assert.IsNotNull(especialidadeTipo);
            Assert.AreEqual(descricao, especialidadeTipo.Descricao);
            Assert.AreEqual(obrigatoria, especialidadeTipo.Obrigatoria);
            Assert.IsTrue(especialidadeTipo.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - EspecialidadeTipo")]
        public void Quando_Criar_Uma_EspecialidadeTipo_Descricao_Deve_Ser_Obrigatoria()
        {
            string descricao = "";
            bool obrigatoria = true;

            var especialidadeTipo = new EspecialidadeTipo(descricao, obrigatoria);
            
            Assert.IsFalse(especialidadeTipo.IsValid());
        }
    }
}
