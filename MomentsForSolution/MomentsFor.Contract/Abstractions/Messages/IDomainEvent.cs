using MediatR;

namespace MomentsFor.Contract.Abstractions.Messages
{
    public interface IDomainEvent: INotification
    {
        public Guid EventId { get; }
    }
}
