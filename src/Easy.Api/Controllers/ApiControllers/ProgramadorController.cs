using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Easy.Api.Controllers.ApiControllers.Base;
using Easy.Application.Contracts;
using Easy.Application.ViewModels;
using Newtonsoft.Json.Linq;

namespace Easy.Api.Controllers.ApiControllers
{
    public class ProgramadorController : BaseController
    {
        private readonly IProgramadorAppService _programadorAppService;

        public ProgramadorController(IProgramadorAppService programadorAppService)
        {
            _programadorAppService = programadorAppService;
        }


        [HttpPost]
        public Task<HttpResponseMessage> Post([FromBody] dynamic body)
        {
            var programador = CriarVm(body);

            _programadorAppService.Registrar(programador);

            return CreateResponse(HttpStatusCode.OK, null);
        }

        [HttpPut]
        public Task<HttpResponseMessage> Put([FromBody] dynamic body)
        {
            var programador = CriarVm(body);

            _programadorAppService.Alterar(programador);

            return CreateResponse(HttpStatusCode.OK, null);
        }

        [HttpDelete]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _programadorAppService.Excluir(id);

            return CreateResponse(HttpStatusCode.OK, null);
        }

        [HttpGet]
        public Task<HttpResponseMessage> Get()
        {
            var programadores = _programadorAppService.SelecionarTodos();

            return CreateResponse(HttpStatusCode.OK, programadores);
        }

        [HttpGet]
        public Task<HttpResponseMessage> Get(int id)
        {
            var programador = _programadorAppService.ObterParaEdicaoPorId(id);

            return CreateResponse(HttpStatusCode.OK, programador);
        }

        #region Métodos Auxiliares
        private static ProgramadorVm CriarVm(dynamic body)
        {
            
            var dataCadastro = new DadosCadastroVm()
            {
                Email = (string)body.dadosCadastro.email,
                Skype = (string)body.dadosCadastro.skype,
                Telefone = (string)body.dadosCadastro.telefone,
                Linkedin = (string)body.dadosCadastro.linkedin,               
            };


            DadosBancarioVm dadosBancarios = null;

            if (body.dadosBancarios != null && ((string) body.dadosBancarios.nome != null && (string) body.dadosBancarios.cpf != null))
            {
                dadosBancarios = new DadosBancarioVm
                {
                    Nome = (string)body.dadosBancarios.nome,
                    Agencia = (string)body.dadosBancarios.agencia,
                    Cpf = (string)body.dadosBancarios.cpf,
                    Banco = (string)body.dadosBancarios.banco,
                    NumeroConta = (string)body.dadosBancarios.numeroConta,
                    ContaTipo = (int?)body.dadosBancarios.contaTipo
                };
            }
            
            

            var especialidades = ((JArray)body.especialidades)
                    .Select(x => new EspecialidadeVm((int?)x["id"], (int)x["especialidadeTipoId"], (string)x["nome"], (int)x["nota"])).ToList();

            var disponibilidades = ((JArray)body.disponibilidades).Select(x => new DisponibilidadeVm((int)x["id"], (string)x["nome"])).ToList();

            var horarios = ((JArray)body.horarios).Select(x => new HorarioTrabalhoVm((int)x["id"], (string)x["nome"])).ToList();

            var programador = new ProgramadorVm((int?)body.id, (string)body.nome, (string)body.linkCrud, dataCadastro, dadosBancarios, especialidades, disponibilidades,
                horarios, (string)body.cidade, (string)body.estado, (string)body.portifolio, (int)body.pretensaoSalarial, (string)body.outros);

            return programador;
        } 
        #endregion
    }
}
