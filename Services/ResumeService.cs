using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    public class ResumeService : BaseService<Resume>, IResumeService
    {
        private readonly IResumeRepository _resumeRepository;
        public ResumeService(IResumeRepository repository) : base(repository)
        {
            _resumeRepository = repository;
        }

        public async Task<ICollection<Resume>> GetByUserAsync(long userId, CancellationToken token)
        {
            return await _resumeRepository.GetByUserAsync(userId, token);
        }
    }
}
