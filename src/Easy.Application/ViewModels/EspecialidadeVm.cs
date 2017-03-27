using Easy.Domain.Entities;

namespace Easy.Application.ViewModels
{
    public class EspecialidadeVm
    {
        public int Id { get; set; }
        public int EspecialidadeTipoId { get; set; }
        public string Nome { get; set; }
        public int Nota { get; set; }
        public bool Obrigatoria { get; set; }

        public EspecialidadeVm()
        {
            
        }

        public EspecialidadeVm(int? id, int especialidadeTipoId, string descricao, int nota)
        {
            Id = id ?? 0;
            EspecialidadeTipoId = especialidadeTipoId;
            Nome = descricao;
            Nota = nota;
        }

        public EspecialidadeVm(Especialidade especialidade)
        {
            Id = especialidade.Id;
            EspecialidadeTipoId = especialidade.EspecialidadeTipoId;
            Nome = especialidade.EspecialidadeTipo.Descricao;
            Nota = especialidade.Nota;
        }

        public EspecialidadeVm(EspecialidadeTipo especialidade)
        {
            EspecialidadeTipoId = especialidade.Id;
            Nome = especialidade.Descricao;
            Nota = -1;
            Obrigatoria = especialidade.Obrigatoria;
        }
    }
}