using System;

namespace Easy.SharedKernel.DomainEvents.Contracts
{
    public interface IDomainEvent
    {
        DateTime DataOccurred { get; }
    }
}
