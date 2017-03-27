using Easy.Domain.Scopes;

namespace Easy.Domain.ValueObjects
{
    public class Cpf
    {
        public string Numero { get; private set; }

        protected Cpf()
        {
            
        }

        public Cpf(string numero)
        {
            Numero = numero;
            IsValid();
        }

        public void Alterar(string numero)
        {
            if(!this.AlterarSeEscopoValido(numero))
                return;

            Numero = numero;
        }

        public bool IsValid()
        {
            return this.CriarSeEscopoValido();
        }

        public bool IsValid(string cpf)
        {
            return this.AlterarSeEscopoValido(cpf);
        }

        public override string ToString()
        {
            return Numero;
        }
    }
}