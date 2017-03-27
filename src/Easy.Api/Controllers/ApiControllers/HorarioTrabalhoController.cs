using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Easy.Api.Controllers.ApiControllers.Base;
using Easy.Application.Contracts;

namespace Easy.Api.Controllers.ApiControllers
{
    public class HorarioTrabalhoController : BaseController
    {
        private readonly IHorarioTrabalhoAppService _horarioTrabalhoAppService;

        public HorarioTrabalhoController(IHorarioTrabalhoAppService horarioTrabalhoAppService)
        {
            _horarioTrabalhoAppService = horarioTrabalhoAppService;
        }

        [HttpGet]
        public Task<HttpResponseMessage> Get()
        {
            var horarios = _horarioTrabalhoAppService.SelecionarTodos();

            return CreateResponse(HttpStatusCode.OK, horarios);
        }
    }
}
