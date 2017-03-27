using Easy.Domain.Entities;

namespace Easy.Application.ViewModels
{
    public class HorarioTrabalhoVm
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public HorarioTrabalhoVm(int id, string nome)
        {
            Id = id;
            Descricao = nome;
        }

        public HorarioTrabalhoVm(HorarioTrabalho horarioTrabalho)
        {
            Id = horarioTrabalho.Id;
            Descricao = horarioTrabalho.Nome;
        }
    }
}
