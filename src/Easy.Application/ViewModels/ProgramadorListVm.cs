using Easy.Domain.Entities;

namespace Easy.Application.ViewModels
{
    public class ProgramadorListVm
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Ativo { get; set; }

        public ProgramadorListVm(Programador programador)
        {
            Id = programador.Id;
            Nome = programador.Nome;
            Ativo = programador.Ativo ? "Ativo" : "Inativo";
        }
    }
}
