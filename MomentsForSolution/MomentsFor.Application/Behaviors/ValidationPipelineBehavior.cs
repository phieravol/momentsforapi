using FluentValidation;
using MediatR;
using MomentsFor.Contract.Abstractions.Common;

namespace MomentsFor.Application.Behaviors
{
    public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            Error[] errors = validators
                .Select(validator => validator.Validate(context))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure is not null)
                .Select(failure => new Error(failure.PropertyName, failure.ErrorMessage))
                .Distinct()
                .ToArray();

            if (errors.Any())
                return CreateValidationResult<TResponse>(errors);

            return await next();
        }

        private static T CreateValidationResult<T>(Error[] errors) where T: Result
        {
            if (typeof(Result) == typeof(T))
            {
                return (ValidationResult.WithError(errors) as T)!;
            }

            object validationResult = typeof(ValidationResult<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(T).GetGenericTypeDefinition())
                .GetMethod(nameof(ValidationResult))!
                .Invoke(null, [errors])!;

            return (T) validationResult;
        }
    }
}
