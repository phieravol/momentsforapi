namespace MomentsFor.Contract.Abstractions.Common
{
    public class Error(string code, string message) : IEquatable<Error>
    {
        public string Code { get; } = code;
        public string Message { get; } = message;

        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullValue = new("Error.NullValue", "The specified result is null");

        public static implicit operator string (Error error) => error.Code;

        public static bool operator == (Error? a, Error? b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator != (Error? a, Error? b) => !(a == b);

        public bool Equals(Error? other)
        {
            if (other is null)
            {
                return false;
            }
            return other.Code == Code && other.Message == Message;
        }

        public override bool Equals(object? obj) => obj is Error other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Code, Message);
    }
}
