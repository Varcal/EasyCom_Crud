using Easy.Domain.Entities.Base;
using Easy.Domain.Scopes;

namespace Easy.Domain.Entities
{
    public sealed class Especialidade : EntityBase
    {
        public int EspecialidadeTipoId { get; private set; }
        public int ProgramadorId { get; private set; }
        public int Nota { get; private set; }
        public EspecialidadeTipo EspecialidadeTipo { get; private set; }
        


        internal Especialidade()
        {
            
        }

        public Especialidade(int especialidadeTipoId, int nota)
        {
            EspecialidadeTipoId = especialidadeTipoId;
            Nota = nota;
            Ativar();
            IsValid();
        }

        public Especialidade(int id, int especialidadeTipoId, int nota)
            :this(especialidadeTipoId, nota)
        {
            Id = id;

        }

        public bool IsValid()
        {
            return this.CriarSeEscopoValido();
        }

        public bool IsValid(int nota)
        {
            return this.AlterarSeEscopoValido(nota);
        }

        public void AlterarNota(int nota)
        {

            if(!this.AlterarSeEscopoValido(nota))
                return;
            
            Nota = nota;
        }
    }
}
