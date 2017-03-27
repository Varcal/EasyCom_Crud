using Easy.Domain.Entities;

namespace Easy.Application.ViewModels
{
    public class DadosCadastroVm
    {
        public int Id { get; set; }

        public string Email { get;  set; }
        public string Skype { get;  set; }
        public string Telefone { get;  set; }
        public string Linkedin { get;  set; }
       

        public DadosCadastroVm()
        {
            
        }

      
        public DadosCadastroVm(Contato contato)
        {
            Id = contato.Id;
            Email = contato.Email?.ToString();
            Skype = contato.Skype;
            Telefone = contato.Telefone;
            Linkedin = contato.Linkedin;
           
        }
    }
}