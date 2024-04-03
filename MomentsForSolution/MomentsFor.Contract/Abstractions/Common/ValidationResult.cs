namespace MomentsFor.Contract.Abstractions.Common
{
    public sealed class ValidationResult : Result, IValidationResult
    {
        public Error[] Errors { get; }
        public static ValidationResult WithError(Error[] errors) => new(errors);
        private ValidationResult(Error[] errors)
            : base(false, IValidationResult.ValidationError) =>
            Errors = errors;
    }
}
