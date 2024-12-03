namespace BaseApi.Domain.Interfaces.Services
{
    public interface IPasswordEncryptService
    {
        string Encrypt(string password);

        bool PasswordVerify(string passwordEncripted, string password);
    }
}
