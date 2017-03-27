using Easy.Domain.Entities;
using Easy.SharedKernel.Validations;

namespace Easy.Domain.Scopes
{
    public static class EspecialidadeTipoScopes
    {
        public static bool CriarSeEscopoValido(this EspecialidadeTipo especialidadeTipo)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertNotEmpty(especialidadeTipo.Descricao, "Descrição é obrigatória")
                );
        }

        public static bool AlterarSeEscopoValido(this EspecialidadeTipo especialidadeTipo, EspecialidadeTipo especialidadeTipoAlterar)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertIsGreaterThan(especialidadeTipo.Id, 0, "Id é obrigatório"),
                    AssertionConcern.AssertNotEmpty(especialidadeTipoAlterar.Descricao, "Descrição é obrigatória")
                );
        }
    }
}
