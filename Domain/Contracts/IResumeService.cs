using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Contracts
{
    public interface IResumeService : IBaseService<Resume>
    {
        Task<ICollection<Resume>> GetByUserAsync(long userId, CancellationToken token);
    }
}
