using System;

namespace Easy.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public bool Ativo { get; protected set; }

        protected EntityBase()
        {
            DataCadastro = DateTime.Now;
        }


        public virtual void Ativar()
        {
            Ativo = true;
        }

        public virtual void Desativar()
        {
            Ativo = false;
        }
    }
}