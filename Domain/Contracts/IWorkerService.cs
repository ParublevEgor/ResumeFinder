using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Contracts
{
    public interface IWorkerService : IBaseService<Worker>
    {
        Task UploadAvatarImageAsync(Stream image, long workerId, CancellationToken token);

        Task<Stream> GetAvatarAsync(long workerId, CancellationToken token);

        Task RemoveAvatarAsync(long workerId, CancellationToken token);
    }
}
