using Easy.Domain.Entities;
using Easy.SharedKernel.Validations;

namespace Easy.Domain.Scopes
{
    public static class DadosBancariosScope
    {
        public static bool CriarSeEscopoValido(this DadoBancario dadosBancario)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertNotEmpty(dadosBancario.Nome, "Nome é obrigatorio"),
                    AssertionConcern.AssertNotEmpty(dadosBancario.Cpf?.Numero, "CPF é obrigatório"),
                    AssertionConcern.AssertNotEmpty(dadosBancario.Agencia, "Agência é obrigatória"),
                    AssertionConcern.AssertNotEmpty(dadosBancario.NomeBanco, "Nome do banco é obrigatório"),
                    AssertionConcern.AssertIsGreaterThan((int)dadosBancario.TipoConta, 0, "Tipo de conta é obrigatório"),
                    AssertionConcern.AssertNotEmpty(dadosBancario.NumeroConta, "Número da conta é obrigatório")
                );
        }

        public static bool AlterarSeEscopoValido(this DadoBancario dadosBancario, DadoBancario dadosBancarioAlterar)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertIsGreaterThan(dadosBancario.Id, 0, "Id é obrigatório"),
                    AssertionConcern.AssertNotEmpty(dadosBancarioAlterar.Nome, "Nome é obrigatorio"),
                    AssertionConcern.AssertNotEmpty(dadosBancarioAlterar.Cpf?.Numero, "CPF é obrigatório"),
                    AssertionConcern.AssertNotEmpty(dadosBancarioAlterar.NomeBanco, "Nome do banco é obrigatório"),
                    AssertionConcern.AssertIsGreaterThan((int)dadosBancarioAlterar.TipoConta, 0, "Tipo de conta é obrigatório"),
                    AssertionConcern.AssertNotEmpty(dadosBancarioAlterar.NumeroConta, "Número da conta é obrigatório")
                );
        }
    }
}
