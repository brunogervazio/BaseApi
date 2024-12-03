namespace BaseApi.Domain.Exceptions
{
    public class PasswordValidationException(string message) : Exception(message) { }
}
