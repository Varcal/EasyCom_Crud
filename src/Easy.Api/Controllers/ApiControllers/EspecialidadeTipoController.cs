using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Easy.Api.Controllers.ApiControllers.Base;
using Easy.Application.Contracts;

namespace Easy.Api.Controllers.ApiControllers
{
    public class EspecialidadeTipoController : BaseController
    {
        private IEspecialidadeTipoAppService _especialidadeTipoAppService;

        public EspecialidadeTipoController(IEspecialidadeTipoAppService especialidadeTipoAppService)
        {
            _especialidadeTipoAppService = especialidadeTipoAppService;
        }


        [HttpGet]
        public Task<HttpResponseMessage> Get()
        {
            var especialidadesTipos = _especialidadeTipoAppService.SelecionarTodos();

            return CreateResponse(HttpStatusCode.OK, especialidadesTipos);
        }
    }
}
