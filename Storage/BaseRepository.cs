using Microsoft.EntityFrameworkCore;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Repositories
{
    /// <inheritdoc cref="IBaseRepository{T}"/>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity, new()
    {
        private readonly ResumeFinderContext _context;

        public BaseRepository(ResumeFinderContext context)
        {
            _context = context;
        }

        /// <inheritdoc cref="IBaseRepository{T}.AddAsync(T, CancellationToken)"/>
        public virtual async Task<T> AddAsync(T entity, CancellationToken token)
        {
            DbSet<T> dbSet = _context.Set<T>();
            var addedEntity = await dbSet.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);
            return addedEntity.Entity;
        }

        /// <inheritdoc cref="IBaseRepository{T}.GetAllAsync(CancellationToken)"/>
        public virtual async Task<ICollection<T>> GetAllAsync(CancellationToken token)
        {
            DbSet<T> dbSet = _context.Set<T>();
            return await dbSet.AsNoTracking().ToListAsync(token);
        }

        /// <inheritdoc cref="IBaseRepository{T}.GetAsync(long, CancellationToken)"/>
        public virtual async Task<T?> GetAsync(long id, CancellationToken token)
        {
            DbSet<T> dbSet = _context.Set<T>();
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, token);
        }

        /// <inheritdoc cref="IBaseRepository{T}.RemoveAsync(long, CancellationToken)"/>
        public virtual async Task RemoveAsync(long id, CancellationToken token)
        {
            DbSet<T> dbSet = _context.Set<T>();
            T entity = new T()
            {
                Id = id
            };
            dbSet.Remove(entity);
            await _context.SaveChangesAsync(token);
        }

        /// <inheritdoc cref="IBaseRepository{T}.UpdateAsync(T, CancellationToken)"/>
        public virtual async Task<T> UpdateAsync(T entity, CancellationToken token)
        {
            DbSet<T> dbSet = _context.Set<T>();
            var updatedEntity = dbSet.Update(entity);
            await _context.SaveChangesAsync(token);
            return updatedEntity.Entity;
        }
    }
}
