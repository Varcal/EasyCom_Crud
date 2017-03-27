using System.Collections.Generic;
using System.Linq;
using Easy.Domain.Entities;

namespace Easy.Application.ViewModels
{
    public class ProgramadorVm
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string LinkCrud { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Portifolio { get; private set; }
        public int PretensaoSalarial { get; private set; }
        public string Outros { get; private set; }
        public DadosCadastroVm DadosCadastro { get; private set; }
        public DadosBancarioVm DadosBancarios { get; private set; }
        public ICollection<EspecialidadeVm> Especialidades { get; private set; }
        public ICollection<DisponibilidadeVm> Disponibilidades { get; private set; }
        public ICollection<HorarioTrabalhoVm> Horarios { get; private set; }


        public ProgramadorVm(int? id, string nome, string gitHubLink, DadosCadastroVm dadosCadastro, DadosBancarioVm dadosBancario, ICollection<EspecialidadeVm> especialidades, ICollection<DisponibilidadeVm> disponibilidades, ICollection<HorarioTrabalhoVm> horariosTrabalhos, string cidade, string estado, string portifolio, int pretensaoSalarial, string outros)
        {
            Id = id ?? 0;
            Nome = nome;
            Cidade = cidade;
            Estado = estado;
            Portifolio = portifolio;
            PretensaoSalarial = pretensaoSalarial;
            LinkCrud = gitHubLink;
            DadosCadastro = dadosCadastro;
            DadosBancarios = dadosBancario ;
            Especialidades = especialidades;
            Disponibilidades = disponibilidades;
            Horarios = horariosTrabalhos;
            Outros = outros;
        }

        public ProgramadorVm(Programador programador)
        {
            Id = programador.Id;
            Nome = programador.Nome;
            Cidade = programador.Cidade;
            Estado = programador.Estado;
            Portifolio = programador.Portifolio;
            PretensaoSalarial = programador.PretensaoSalarial;
            Outros = programador.Outros;
            LinkCrud = programador.GitHubLink;
            DadosCadastro =  new DadosCadastroVm(programador.DadosCadastro) ;
            DadosBancarios = programador.DadosBancario != null ?  new DadosBancarioVm(programador.DadosBancario) : null;
            Especialidades = programador.Especialidades.Select(e => new EspecialidadeVm(e)).ToList();
            Disponibilidades = programador.Disponibilidades.Select(d => new DisponibilidadeVm(d)).ToList();
            Horarios = programador.HorariosTrabalhos.Select(ht => new HorarioTrabalhoVm(ht)).ToList();
        }
    }
}
