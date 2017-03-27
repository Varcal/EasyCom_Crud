using Easy.Domain.Entities;

namespace Easy.Application.ViewModels
{
    public class DadosBancarioVm
    {
        public int? Id { get; set; }
        public string Nome { get;  set; }
        public string Cpf { get;  set; }
        public string Banco { get;  set; }
        public string Agencia { get;  set; }
        public int? ContaTipo { get;  set; }
        public string NumeroConta { get;  set; }

        public DadosBancarioVm()
        {
            
        }

        public DadosBancarioVm(DadoBancario dadosBancario)
        {
            Id = dadosBancario.Id;
            Nome = dadosBancario.Nome;
            Cpf = dadosBancario.Cpf.ToString();
            Banco = dadosBancario.NomeBanco;
            Agencia = dadosBancario.Agencia;
            ContaTipo = (int)dadosBancario.TipoConta;
            NumeroConta = dadosBancario.NumeroConta;
        }
    }
}