namespace MomentsFor.Contract.Abstractions.Common
{
    public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
    {
        private ValidationResult(Error[] errors)
            : base(false, IValidationResult.ValidationError, default) =>
            Errors = errors;
        public Error[] Errors { get; }
        public static ValidationResult<TValue> WithError(Error[] errors) => new(errors);
        
    }
}
