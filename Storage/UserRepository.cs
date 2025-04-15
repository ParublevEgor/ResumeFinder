using Microsoft.EntityFrameworkCore;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ResumeFinderContext _context;
        public UserRepository(ResumeFinderContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash, CancellationToken token)
        {
            DbSet<User> dbSet = _context.Set<User>();
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login && u.PasswordHash == passwordHash, token);
        }
    }
}
