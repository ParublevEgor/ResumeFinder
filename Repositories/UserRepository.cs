using ResumeFinder.Entities;
using ResumeFinder.Repositories.Interfaces;

namespace ResumeFinder.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ResumeFinderContext context) : base(context)
        {
        }

        public Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
