using BaseApi.Domain.Entities;

namespace BaseApi.Domain.Interfaces.Factories
{
    public interface IUserFactory
    {
        public UserEntity CreateUser(string name, string email, string password);
    }
}
