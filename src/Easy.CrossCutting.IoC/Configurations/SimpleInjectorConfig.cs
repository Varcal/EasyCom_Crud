using System.Web.Http;
using Easy.CrossCutting.IoC.Containers;
using Easy.SharedKernel.DomainEvents;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;

namespace Easy.CrossCutting.IoC.Configurations
{
    public class SimpleInjectorConfig
    {
        private static Container _container;

        public static void Initialize(HttpConfiguration config)
        {
            _container = new Container();

            _container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(_container);

            _container.RegisterWebApiControllers(config);

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);
            DomainEvent.Container = new IoCContainer(config.DependencyResolver);


            _container.Verify();
        }

        public static object GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        private static void InitializeContainer(Container container)
        {
            Bootstrapper.RegisterServices(container);
        }
    }
}
