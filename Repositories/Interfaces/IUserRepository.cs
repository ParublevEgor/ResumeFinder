using ResumeFinder.Entities;

namespace ResumeFinder.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash, CancellationToken token);
    }
}
