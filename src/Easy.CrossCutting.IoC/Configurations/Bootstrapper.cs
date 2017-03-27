using Easy.Application.Contracts;
using Easy.Application.Services;
using Easy.Domain.Contracts.Repositories;
using Easy.Infra.Data.Contexts;
using Easy.Infra.Data.Repositories;
using Easy.Infra.Data.Repositories.Base;
using Easy.Infra.Data.UoW;
using Easy.SharedKernel.DomainEvents.Events.DomainNotifications;
using Easy.SharedKernel.DomainEvents.Handlers.Base;
using Easy.SharedKernel.DomainEvents.Handlers.DomainNotifications;
using SimpleInjector;

namespace Easy.CrossCutting.IoC.Configurations
{
    public class Bootstrapper
    {
        public static void RegisterServices(Container container)
        {
            #region Application Services
            container.Register<IProgramadorAppService, ProgramadorAppService>(Lifestyle.Scoped);
            container.Register<IEspecialidadeTipoAppService, EspecialidadeTipoAppService>(Lifestyle.Scoped);
            container.Register<IDisponibilidadeAppService, DisponibilidadeAppService>(Lifestyle.Scoped);
            container.Register<IHorarioTrabalhoAppService, HorarioTraballhoAppService>(Lifestyle.Scoped);
            #endregion
            
            #region Domain Events
            container.Register<Handler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
            #endregion

            #region Domain Services

            #endregion

            #region Repositories
            container.Register<IProgramadorRepository, ProgramadorRepository>(Lifestyle.Scoped);
            container.Register<IDisponibilidadeRepository, DisponibilidadeRepository>(Lifestyle.Scoped);
            container.Register<IHorarioTrabalhoRepository, HorarioTrabalhoRepository>(Lifestyle.Scoped);
            container.Register<IEspecialidadeTipoRepository, EspecialidadeTipoRepository>(Lifestyle.Scoped);
            #endregion

            #region Contexts
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<EfContext>(Lifestyle.Scoped);
            #endregion
        }
    }
}
