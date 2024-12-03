using System;

namespace BaseApi.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetById(Guid id);

        Task<Guid> Create(T entity);

        Task Update(T entity);

        Task Delete(Guid id);
    }
}
