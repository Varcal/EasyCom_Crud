using System;
using Easy.SharedKernel.DomainEvents.Contracts;
using Easy.SharedKernel.DomainEvents.Handlers.Base;

namespace Easy.SharedKernel.DomainEvents
{
    public static class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            try
            {
                if (Container == null) return;
                var obj = Container.GetService(typeof(Handler<T>));
                ((Handler<T>)obj).Handle(args);
            }
            catch (NullReferenceException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
