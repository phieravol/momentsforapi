namespace MomentsFor.Domain.Abstractions
{
    public abstract class NotFoundException : DomainException
    {
        protected NotFoundException(string title, string message) : base("Not Found: ", message)
        {
        }
    }
}
