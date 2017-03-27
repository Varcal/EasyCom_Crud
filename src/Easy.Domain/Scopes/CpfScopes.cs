using Easy.Domain.ValueObjects;
using Easy.SharedKernel.Validations;

namespace Easy.Domain.Scopes
{
    public static class CpfScopes
    {
        public static bool CriarSeEscopoValido(this Cpf cpf)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertNotEmpty(cpf.Numero, "Número é obrigatório"),
                    AssertionConcern.AssertCpfIsValid(cpf.Numero, "Cpf inválido")
                );
        }


        public static bool AlterarSeEscopoValido(this Cpf cpf, string numero)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertNotEmpty(numero, "Número é obrigatório"),
                    AssertionConcern.AssertCpfIsValid(numero, "Cpf inválido")
                );
        }
    }
}
