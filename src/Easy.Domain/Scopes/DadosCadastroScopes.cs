using Easy.Domain.Entities;
using Easy.SharedKernel.Validations;

namespace Easy.Domain.Scopes
{
    public static class DadosCadastroScopes
    {
        public static bool CriarSeEscopoValido(this Contato dadosCadastro)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertNotNull(dadosCadastro.Email, "E-mail é obrigatório"),
                    AssertionConcern.AssertEmailIsValid(dadosCadastro.Email?.ToString(), "E-mail inválido"),
                    AssertionConcern.AssertNotEmpty(dadosCadastro.Skype, "Skype é obrigatório"),
                    AssertionConcern.AssertNotEmpty(dadosCadastro.Telefone, "Telefone é obrigatório")
                );
        }

        public static bool AlterarSeEscopoValido(this Contato dadosCadastro, Contato dadosCadastroAlterar)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertIsGreaterThan(dadosCadastro.Id, 0, "Id é obrigatório"),
                    AssertionConcern.AssertNotNull(dadosCadastroAlterar.Email, "E-mail é obrigatório"),
                    AssertionConcern.AssertEmailIsValid(dadosCadastroAlterar.Email?.ToString(), "E-mail inválido"),
                    AssertionConcern.AssertNotEmpty(dadosCadastroAlterar.Skype, "Skype é obrigatório"),
                    AssertionConcern.AssertNotEmpty(dadosCadastroAlterar.Telefone, "Telefone é obrigatório")
                );
        }
    }
}
