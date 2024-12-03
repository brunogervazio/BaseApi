using BaseApi.Domain.Exceptions;

namespace BaseApi.Domain.ValueObjcts
{
    public class Password
    {
        public string EncryptedValue { get; private set; }

        private Password() { }

        public Password(string plainPassword, string encryptedValue)
        {
            Validate(plainPassword);
            EncryptedValue = encryptedValue;
        }

        private static void Validate(string value)
        {
            if (value.Length < 9)
                throw new PasswordValidationException("Password must contain at least 9 characters.");

            if (!value.Any(char.IsUpper) || !value.Any(char.IsLower))
                throw new PasswordValidationException("Password must contain uppercase and lowercase characters.");

            if (!value.Any(e => !char.IsLetterOrDigit(e)))
                throw new PasswordValidationException("Password must contain special character.");

            if (!value.Any(char.IsDigit))
                throw new PasswordValidationException("Password must contain number.");
        }
    }
}
