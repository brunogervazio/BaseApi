using BaseApi.Domain.Entities;
using BaseApi.Domain.Interfaces.Repositories;
using BaseApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Infra.Data.Repositories
{
    public class AccountRepository : RepositoryBase<UserEntity>, IAccountRepository
    {
        private readonly AppDbContext _dbContext;
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity?> SelectByEmail(string email)
        {
            return await _dbContext.Set<UserEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email.Value == email);
        }
    }
}
