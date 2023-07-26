using Doctorly.Domain.Exceptions;
using System.Net.Mail;

namespace Doctorly.Domain.Common
{
    public class Email : ValueObject
    {
        protected Email() { }

        public Email(string value)
        {
            if (!IsValid(value))
            {
                throw new InvalidEmailFormatException("Email format is invalid.");
            }

            Value = value;
        }

        public string Value { get; private set; } = string.Empty;

        private static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
