using System.Collections.Generic;
using Easy.Domain.Entities.Base;

namespace Easy.Domain.Entities
{
    public sealed class Disponibilidade: EntityBase
    {
        public string Nome { get; private set; }
        public ICollection<Programador> Programadores { get; private set; }



        internal Disponibilidade()
        {
            
        }

        public Disponibilidade(string nome)
            //:this()
        {
            Nome = nome;
            Ativar();
        }
    }
}