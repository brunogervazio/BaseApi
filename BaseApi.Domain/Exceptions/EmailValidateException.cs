namespace BaseApi.Domain.Exceptions
{
    public class EmailValidateException : Exception
    {
        public EmailValidateException() : base("Invalid Email.") { }
    }
}
