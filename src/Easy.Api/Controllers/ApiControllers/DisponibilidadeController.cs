using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Easy.Api.Controllers.ApiControllers.Base;
using Easy.Application.Contracts;

namespace Easy.Api.Controllers.ApiControllers
{
    public class DisponibilidadeController : BaseController
    {
        private readonly IDisponibilidadeAppService _disponibilidadeAppService;

        public DisponibilidadeController(IDisponibilidadeAppService disponibilidadeAppService)
        {
            _disponibilidadeAppService = disponibilidadeAppService;
        }

        [HttpGet]
        public Task<HttpResponseMessage> Get()
        {
            var disponibilidades = _disponibilidadeAppService.SelecionarTodos();

            return CreateResponse(HttpStatusCode.OK, disponibilidades);
        }
    }
}
