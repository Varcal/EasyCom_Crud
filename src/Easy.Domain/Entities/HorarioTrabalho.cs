using System.Collections.Generic;
using Easy.Domain.Entities.Base;

namespace Easy.Domain.Entities
{
    public sealed class HorarioTrabalho: EntityBase
    {
        public string Nome { get; private set; }
        public ICollection<Programador> Programadores { get; set; }


        internal HorarioTrabalho()
        {
            
        }

        public HorarioTrabalho(string nome)
        {
            Nome = nome;
            Ativar();
        }
    }
}