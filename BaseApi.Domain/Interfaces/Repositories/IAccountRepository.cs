using BaseApi.Domain.Entities;

namespace BaseApi.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Guid> Create(UserEntity user);

        Task<UserEntity?> SelectByEmail(string email);
    }
}
