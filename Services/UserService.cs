using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash, CancellationToken token)
        {
            return _repository.GetByLoginAndPasswordAsync(login, passwordHash, token);
        }
    }
}
