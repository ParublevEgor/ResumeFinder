using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    public class ResumeService : BaseService<Resume>, IResumeServices
    {
        public ResumeService(IResumeRepository repository) : base(repository)
        {
        }
    }
}
