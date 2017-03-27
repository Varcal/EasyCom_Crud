using System;
using Easy.SharedKernel.DomainEvents.Contracts;

namespace Easy.SharedKernel.DomainEvents.Events.DomainNotifications
{
    public class DomainNotification: IDomainEvent
    {
        public DateTime DataOccurred { get; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            DataOccurred = DateTime.Now;
            Key = key;
            Value = value;
        }
    }
}
