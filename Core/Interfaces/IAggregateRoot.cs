using System;
namespace Core.Interfaces
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
