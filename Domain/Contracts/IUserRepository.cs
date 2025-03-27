using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Storage
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash, CancellationToken token);
    }
}
