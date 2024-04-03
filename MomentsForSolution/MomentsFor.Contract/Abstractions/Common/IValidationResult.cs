namespace MomentsFor.Contract.Abstractions.Common
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new("ValidationErro", "A validation problem occur");
        Error[] Errors { get; }
    }
}
