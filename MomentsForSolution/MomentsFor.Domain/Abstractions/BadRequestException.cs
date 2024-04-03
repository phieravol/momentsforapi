namespace MomentsFor.Domain.Abstractions
{
    public abstract class BadRequestException : DomainException
    {
        protected BadRequestException(string title, string message) : base("Bad Request", message)
        {
        }
    }
}
