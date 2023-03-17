namespace Doctorly.Domain.Exceptions
{
    public class InvalidEmailFormatException : Exception
    {
        public InvalidEmailFormatException() { }

        public InvalidEmailFormatException(string message) : base(message) { }
    }
}
