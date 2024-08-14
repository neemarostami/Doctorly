using System.Net.Mail;

using Doctorly.Domain.Exceptions;

namespace Doctorly.Domain.ValueObjects
{
    public class Email : IEquatable<Email>
    {
        // ReSharper disable once UnusedMember.Global
        protected Email() { }

        public Email(string value)
        {
            if (!IsValid(value))
            {
                throw new InvalidEmailFormatException("Email format is invalid.");
            }

            Value = value;
        }

        public string Value { get; } = string.Empty;

        private static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                _ = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        #region Implementation of IEquatable<Email>

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(Email? other)
        {
            if (other is null)
            {
                return false;
            }

            return Value == other.Value;
        }

        #endregion
    }
}