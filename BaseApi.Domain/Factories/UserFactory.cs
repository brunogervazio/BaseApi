using BaseApi.Domain.Entities;
using BaseApi.Domain.Interfaces.Factories;
using BaseApi.Domain.Interfaces.Services;
using BaseApi.Domain.ValueObjcts;

namespace BaseApi.Domain.Factories
{
    public class UserFactory(IPasswordEncryptService passwordEncryptService) : IUserFactory
    {
        private readonly IPasswordEncryptService _passwordEncryptService = passwordEncryptService;

        public UserEntity CreateUser(string name, string email, string password)
        {
            var pass = new Password(password, _passwordEncryptService.Encrypt(password));
            return new UserEntity(name, email, pass);
        }
    }
}