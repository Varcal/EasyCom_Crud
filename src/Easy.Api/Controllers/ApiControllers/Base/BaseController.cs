using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Easy.SharedKernel.DomainEvents;
using Easy.SharedKernel.DomainEvents.Events.DomainNotifications;
using Easy.SharedKernel.DomainEvents.Handlers.Base;

namespace Easy.Api.Controllers.ApiControllers.Base
{
    public class BaseController : ApiController
    {
        public Handler<DomainNotification> Notifications;
        public new HttpResponseMessage ResponseMessage;
        
        public BaseController()
        { 
            Notifications = DomainEvent.Container.GetService<Handler<DomainNotification>>();
        }

        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            ResponseMessage = Notifications.HasNotification()
                ? Request.CreateResponse(HttpStatusCode.BadRequest, new {errors = Notifications.Notify()})
                : Request.CreateResponse(code, result);

            return Task.FromResult(ResponseMessage);
        }

        protected override void Dispose(bool disposing)
        {
            Notifications.Dispose();
        }
    }
}