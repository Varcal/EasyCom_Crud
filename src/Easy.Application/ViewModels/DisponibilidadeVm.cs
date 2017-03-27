using Easy.Domain.Entities;

namespace Easy.Application.ViewModels
{
    public class DisponibilidadeVm
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }


        public DisponibilidadeVm(int id, string nome)
        {
            Id = id;
            Descricao = nome;
        }

        public DisponibilidadeVm(Disponibilidade disponibilidade)
        {
            Id = disponibilidade.Id;
            Descricao = disponibilidade.Nome;
        }
    }
}
