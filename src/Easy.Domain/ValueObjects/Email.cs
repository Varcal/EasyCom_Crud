using Easy.Domain.Scopes;

namespace Easy.Domain.ValueObjects
{
    public class Email
    {
        public string Endereco { get; private set; }

        protected Email()
        {
            
        }

        public Email(string endereco)
        {
            Endereco = endereco;
            IsValid();
        }

        public override string ToString()
        {
            return Endereco;
        }

        public bool IsValid()
        {
            return this.CriarSeEscopoValido();
        }

        public bool IsValid(string email)
        {
            return this.AlterarSeEscopoValido(email);
        }
    }
}
