using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Interfaces.Repositories;
using BaseApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Infra.Data.Repositories
{
    public abstract class RepositoryBase<T>(AppDbContext dbContext) : IRepositoryBase<T> where T : class, IEntity
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Guid> Create(T entity)
        {
            try
            {
                var result = await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return result.Entity.Uuid;
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(Guid uuid)
        {
            var entity = await GetById(uuid);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Guid uuid)
        {
            return await _dbContext.Set<T>()
                .AsNoTracking()
                .FirstAsync(e => e.Uuid == uuid);
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
