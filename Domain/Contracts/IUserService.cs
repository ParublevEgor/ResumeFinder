using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Contracts
{
    public interface IUserService : IBaseService<User>
    {
        Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash, CancellationToken token);
    }
}
