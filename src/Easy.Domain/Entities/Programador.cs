using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Easy.Domain.Entities.Base;
using Easy.Domain.Scopes;

namespace Easy.Domain.Entities
{
    public sealed class Programador: EntityBase
    {
        public string Nome { get; private set; }
        public string GitHubLink { get; private set; }
        public int DadosCadastroId { get; private set; }
        public int? DadosBancarioId { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Portifolio { get; private set; }
        public int PretensaoSalarial { get; private set; }
        public string Outros { get; private set; }

        public Contato DadosCadastro { get; private set; }
        public DadoBancario DadosBancario { get; private set; }
        public ICollection<Especialidade> Especialidades { get; private set; }
        public ICollection<Disponibilidade> Disponibilidades { get; private set; }
        public ICollection<HorarioTrabalho> HorariosTrabalhos { get; private set; }

        internal Programador()
        {
            
        }

        public Programador(string nome, string gitHubLink, Contato dadosCadastro, ICollection<Especialidade> especialidades, IList<Disponibilidade> disponibilidades, IList<HorarioTrabalho> horariosTrabalhos, string cidade, string estado, string portifolio, int pretensaoSalarial, string outros, [Optional] DadoBancario dadosBancario)
        {
            Nome = nome;
            GitHubLink = gitHubLink;
            Cidade = cidade;
            Estado = estado;
            Portifolio = portifolio;
            PretensaoSalarial = pretensaoSalarial;
            Outros = outros;
            DadosCadastro = dadosCadastro;
            DadosBancario = dadosBancario;
            Especialidades = especialidades;
            Disponibilidades = disponibilidades;
            HorariosTrabalhos = horariosTrabalhos;
            Ativar();
            IsValid();
        }

        public bool IsValid()
        {
            return this.CriarSeEscopoValido();
        }

        public void Alterar(string nome, string gitHubLink, Contato dadosCadastro, DadoBancario dadosBancario, IList<Disponibilidade> disponibilidades, IList<HorarioTrabalho> horarios, IList<Especialidade> especialidades, string cidade, string estado, string portifolio, int pretensaoSalarial, string outros)
        {
            Nome = nome;
            GitHubLink = gitHubLink;
            Cidade = cidade;
            Estado = estado;
            Portifolio = portifolio;
            PretensaoSalarial = pretensaoSalarial;
            Outros = outros;
            DadosCadastro.Alterar(dadosCadastro);
            DadosBancario?.Alterar(dadosBancario);
            Disponibilidades = disponibilidades;
            HorariosTrabalhos = horarios;
            AtualizarEspecialidades(especialidades);
        }

        private void AtualizarEspecialidades(IList<Especialidade> especialidades)
        {
            foreach (var especialidade in Especialidades)
            {
                foreach (var especialidadeTela in especialidades)
                {
                    if (especialidade.Id == especialidadeTela.Id)
                    {
                        especialidade.AlterarNota(especialidadeTela.Nota);
                    }
                }
            }

            var especialidadesNovas = especialidades.Where(x => x.Id == 0).ToList();

            if(!especialidadesNovas.Any()) return;

            foreach (var especialidadesNova in especialidadesNovas)
            {
                Especialidades.Add(especialidadesNova);
            }
        }
    }
}