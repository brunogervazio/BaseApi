using BaseApi.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace BaseApi.Domain.ValueObjcts
{
    public class Email
    {
        public string Value { get; set; }

        public Email(string value)
        {
            if (!IsValid(value))
                throw new EmailValidateException();

            Value = value;
        }

        private static bool IsValid(string value)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(value, pattern);
        }
    }
}
