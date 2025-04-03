using Microsoft.EntityFrameworkCore;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Repositories
{
    public class ResumeRepository : BaseRepository<Resume>, IResumeRepository
    {
        private readonly ResumeFinderContext _context;
        public ResumeRepository(ResumeFinderContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Resume>> GetByUserAsync(long userId, CancellationToken token)
        {
            DbSet<Resume> dbSet = _context.Set<Resume>();
            return await dbSet.AsNoTracking()
                .Include(r => r.WorkPlaces)
                    .ThenInclude(w => w.Specialization)
                .Where(r => r.WorkerId == userId)
                .ToListAsync(token);
        }

        public override async Task<ICollection<Resume>> GetAllAsync(CancellationToken token)
        {
            DbSet<Resume> dbSet = _context.Set<Resume>();
            return await dbSet.AsNoTracking()
                .Include(r => r.WorkPlaces)
                    .ThenInclude(w => w.Specialization)
                .ToListAsync(token);
        }

        public override async Task<Resume?> GetAsync(long id, CancellationToken token)
        {
            DbSet<Resume> dbSet = _context.Set<Resume>();
            return await dbSet.AsNoTracking()
                .Include(r => r.WorkPlaces)
                    .ThenInclude(w => w.Specialization)
                .FirstOrDefaultAsync(r => r.Id == id,token);
        }

        public override async Task<Resume> AddAsync(Resume entity, CancellationToken token)
        {
            DbSet<Resume> dbSet = _context.Set<Resume>();
            foreach (WorkPlace workPlace in entity.WorkPlaces)
            {
                _context.Attach(workPlace.Specialization);
                _context.Entry(workPlace.Specialization).State = EntityState.Unchanged;
            }
            var addedEntity = await dbSet.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);
            return addedEntity.Entity;
        }
    }
}
