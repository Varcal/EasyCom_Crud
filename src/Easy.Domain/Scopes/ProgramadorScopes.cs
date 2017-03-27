using System.Linq;
using Easy.Domain.Entities;
using Easy.SharedKernel.Validations;

namespace Easy.Domain.Scopes
{
    public static class ProgramadorScopes
    {
        public static bool CriarSeEscopoValido(this Programador programador)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertNotEmpty(programador.Nome, "Nome é obrigatório"),
                    AssertionConcern.AssertNotEmpty(programador.Cidade, "Cidade é obrigatória"),
                    AssertionConcern.AssertNotEmpty(programador.Estado, "Estado é obrigatório"),
                    AssertionConcern.AssertIsGreaterThan(programador.PretensaoSalarial, 0, "Pretensão salarial é obrigatório"),
                    AssertionConcern.AssertNotNull(programador.DadosCadastro, "Dados de cadastro são obrigatórios"),
                    AssertionConcern.AssertNotNull(programador.Especialidades, "Especialidades são obrigatórias"),
                    AssertionConcern.AssertTrue(programador.Disponibilidades != null && programador.Disponibilidades.Any(), "Disponibilidade é obrigatório"),
                    AssertionConcern.AssertTrue(programador.HorariosTrabalhos != null && programador.HorariosTrabalhos.Any(), "Horário de Trabalho é obrigatório"),
                    AssertionConcern.AssertTrue(programador.Especialidades != null && programador.Especialidades.Any(),  "Especialidades são obrigatórias")
                );
        }

        public static bool AlterarSeEscopoValido(this Programador programador, Programador programadorAlterar)
        {
            return AssertionConcern.IsValid(
                    AssertionConcern.AssertIsGreaterThan(programador.Id, 0, "Id é obrigatório"),
                    AssertionConcern.AssertNotEmpty(programadorAlterar.Nome, "Nome é obrigatório"),
                    AssertionConcern.AssertNotEmpty(programadorAlterar.Cidade, "Cidade é obrigatória"),
                    AssertionConcern.AssertNotEmpty(programadorAlterar.Estado, "Estado é obrigatório"),
                    AssertionConcern.AssertIsGreaterThan(programadorAlterar.PretensaoSalarial, 0, "Pretensão salarial é obrigatório"),
                    AssertionConcern.AssertNotNull(programadorAlterar.DadosCadastro, "Dados de cadastro são obrigatórios"),
                    AssertionConcern.AssertTrue(programadorAlterar.Disponibilidades != null && programadorAlterar.Disponibilidades.Any(), "Disponibilidade é obrigatório"),
                    AssertionConcern.AssertTrue(programadorAlterar.HorariosTrabalhos != null && programadorAlterar.HorariosTrabalhos.Any(), "Horário de Trabalho é obrigatório"),
                    AssertionConcern.AssertTrue(programadorAlterar.Especialidades.Any(), "Especialidades são obrigatórias")
                );
        }
    }
}
