using Easy.Domain.Entities.Base;
using Easy.Domain.Enums;
using Easy.Domain.Scopes;
using Easy.Domain.ValueObjects;

namespace Easy.Domain.Entities
{
    public sealed class DadoBancario: EntityBase
    {
        public string Nome { get; private set; }
        public Cpf Cpf { get; private set; }
        public string NomeBanco { get; private set; }
        public string Agencia { get; private set; }
        public TipoConta TipoConta { get; private set; }
        public string NumeroConta { get; private set; }

        internal DadoBancario()
        {
        }

        public DadoBancario(string nome, string cpf, string nomeBanco, string agencia, TipoConta tipoConta, string numeroConta)
        {
            Nome = nome;
            Cpf = new Cpf(cpf);
            NomeBanco = nomeBanco;
            Agencia = agencia;
            TipoConta = tipoConta;
            NumeroConta = numeroConta;
            Ativar();
            IsValid();
        }

        public void Alterar(DadoBancario dadosBancario)
        {
            if(dadosBancario == null || !this.AlterarSeEscopoValido(dadosBancario))
                return;

            Nome = dadosBancario.Nome;
            Cpf = dadosBancario.Cpf;
            NomeBanco = dadosBancario.NomeBanco;
            Agencia = dadosBancario.Agencia;
            TipoConta = dadosBancario.TipoConta;
            NumeroConta = dadosBancario.NumeroConta;
        }

        public bool IsValid()
        {
           return this.CriarSeEscopoValido();
        }

        public bool IsValid(DadoBancario dadosBancario)
        {
            return this.AlterarSeEscopoValido(dadosBancario);
        }
    }
}