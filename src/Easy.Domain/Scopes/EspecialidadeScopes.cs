using Easy.Domain.Entities;
using Easy.SharedKernel.Validations;

namespace Easy.Domain.Scopes
{
    public static class EspecialidadeScopes
    {
        public static bool CriarSeEscopoValido(this Especialidade especialidade)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertIsGreaterThan(especialidade.EspecialidadeTipoId, 0, "Tipo especialidade é obrigatória"),
                    AssertionConcern.AssertTrue(especialidade.Nota >= 0 && especialidade.Nota <= 5, "Nota deve ser entre 0 e 5")
                );
        }

        public static bool AlterarSeEscopoValido(this Especialidade especialidade, int nota)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertIsGreaterThan(especialidade.Id, 0, "Id é obrigatório"),
                    AssertionConcern.AssertIsGreaterThan(especialidade.EspecialidadeTipoId, 0, "Tipo especialidade é obrigatória"),
                    AssertionConcern.AssertTrue(especialidade.Nota >= 0 && especialidade.Nota <= 5, "Nota deve ser entre 0 e 5")
                );
        }
    }
}
