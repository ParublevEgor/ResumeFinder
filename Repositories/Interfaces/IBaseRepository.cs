﻿using ResumeFinder.Entities;

namespace ResumeFinder.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task<T> AddAsync(T entity, CancellationToken token);

        Task<T> UpdateAsync(T entity, CancellationToken token);

        Task RemoveAsync(long id, CancellationToken token);

        Task<T?> GetAsync(long id, CancellationToken token);

        Task<ICollection<T>> GetAllAsync(CancellationToken token);
    }
}
