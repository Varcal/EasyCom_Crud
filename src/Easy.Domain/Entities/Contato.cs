using Easy.Domain.Entities.Base;
using Easy.Domain.Scopes;
using Easy.Domain.ValueObjects;

namespace Easy.Domain.Entities
{
    public sealed class Contato: EntityBase
    {
        public Email Email { get; private set; }     
        public string Skype { get; private set; }
        public string Telefone { get; private set; }
        public string Linkedin { get; private set; }
       

        internal Contato()
        {
            
        }

        public Contato(string email, string skype, string telefone, string linkedin)
            :this()
        {
            Email = new Email(email);
            Skype = skype;
            Telefone = telefone;
            Linkedin = linkedin;
            Ativar();
            IsValid();
        }

        public bool IsValid()
        {
            return this.CriarSeEscopoValido();
        }

        public bool IsValid(Contato contato)
        {
            return this.AlterarSeEscopoValido(contato);
        }

        public void Alterar(Contato contato)
        {
            if(!this.AlterarSeEscopoValido(contato))
                return;
            
            Email = contato.Email;
            Skype = contato.Skype;
            Telefone = contato.Telefone;
            Linkedin = contato.Linkedin;
        }
    }
}
