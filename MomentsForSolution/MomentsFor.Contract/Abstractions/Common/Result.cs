namespace MomentsFor.Contract.Abstractions.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailed => !IsSuccess;
        public Error? Error { get; }

        protected internal Result(bool isSuccess, Error? error)
        {
            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);
        public static Result<TValue> Success<TValue>(TValue value) => new(true, Error.None, value);
        public static Result Failed(Error error) => new(false, error);
        public static Result<TValue> Failed<TValue>(Error error) => new(false, error, default);
        public static Result<TValue> Create<TValue>(TValue? value) 
            => value is not null ? Success(value): Failed<TValue>(Error.NullValue);
    }
}
