using Microsoft.EntityFrameworkCore;
using ResumeFinder.Entities;
using ResumeFinder.Repositories.Interfaces;

namespace ResumeFinder.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity, new()
    {
        private readonly ResumeFinderContext _context;

        public BaseRepository(ResumeFinderContext context)
        {
            _context = context;
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken token)
        {
            DbSet<T> dbSet = _context.Set<T>();
            var addedEntity = await dbSet.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);
            return addedEntity.Entity;
        }

        public virtual async Task<ICollection<T>> GetAllAsync(CancellationToken token)
        {
            DbSet<T> dbSet = _context.Set<T>();
            return await dbSet.AsNoTracking().ToListAsync(token);
        }

        public virtual async Task<T?> GetAsync(long id, CancellationToken token)
        {
            DbSet<T> dbSet = _context.Set<T>();
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, token);
        }

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

        public virtual async Task<T> UpdateAsync(T entity, CancellationToken token)
        {
            DbSet<T> dbSet = _context.Set<T>();
            var updatedEntity = dbSet.Update(entity);
            await _context.SaveChangesAsync(token);
            return updatedEntity.Entity;
        }
    }
}
