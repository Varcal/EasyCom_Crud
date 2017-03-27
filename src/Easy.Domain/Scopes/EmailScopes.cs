using Easy.Domain.ValueObjects;
using Easy.SharedKernel.Validations;

namespace Easy.Domain.Scopes
{
    public static class EmailScopes
    {
        public static bool CriarSeEscopoValido(this Email email)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertNotEmpty(email.Endereco, "Endereço de e-mail é obrigatório"),
                    AssertionConcern.AssertEmailIsValid(email.Endereco, "Endereço de e-mail inválido")
                );
        }

        public static bool AlterarSeEscopoValido(this Email email, string endereco)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertNotEmpty(endereco, "Endereço de e-mail é obrigatório"),
                    AssertionConcern.AssertEmailIsValid(endereco, "Endereço de e-mail inválido")
                );
        }
    }
}
