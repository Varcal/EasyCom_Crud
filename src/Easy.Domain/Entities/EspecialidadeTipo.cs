using Easy.Domain.Entities.Base;
using Easy.Domain.Scopes;

namespace Easy.Domain.Entities
{
    public sealed class EspecialidadeTipo: EntityBase
    {
        public string Descricao { get; private set; }
        public bool Obrigatoria { get; private set; }


        internal EspecialidadeTipo()
        {
            
        }

        public EspecialidadeTipo(string descricao, bool obrigatoria)
            :this()
        {
            Descricao = descricao;
            Obrigatoria = obrigatoria;
            Ativar();
        }


        public bool IsValid()
        {
            return this.CriarSeEscopoValido();
        }
    }
}