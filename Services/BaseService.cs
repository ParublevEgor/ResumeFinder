using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    public class BaseService<T> : IBaseService<T> where T : IEntity
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual Task<T> AddAsync(T entity, CancellationToken token)
        {
            return _repository.AddAsync(entity, token);
        }

        public virtual Task<ICollection<T>> GetAllAsync(CancellationToken token)
        {
            return _repository.GetAllAsync(token);
        }

        public virtual Task<T?> GetAsync(long id, CancellationToken token)
        {
            return _repository.GetAsync(id, token);
        }

        public virtual Task RemoveAsync(long id, CancellationToken token)
        {
            return _repository.RemoveAsync(id, token);
        }

        public virtual Task<T> UpdateAsync(T entity, CancellationToken token)
        {
            return _repository.UpdateAsync(entity, token);
        }
    }
}
