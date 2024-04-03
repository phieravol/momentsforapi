using MomentsFor.Domain.Abstractions;

namespace MomentsFor.Application.Exceptions
{
    public sealed class ValidationException : DomainException
    {
        public IReadOnlyCollection<ValidationError> Errors { get; set; }

        public ValidationException(IReadOnlyCollection<ValidationError> errors)
            : base("Validation Error", "One or more validation errors occured")
        {
            Errors = errors;
        }
    }
    public record ValidationError(string PropertyName, string ErrorMessage);
}
