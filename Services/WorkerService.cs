using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    public class WorkerService : BaseService<Worker>, IWorkerService
    {
        private readonly IImageService _imageService;
        public WorkerService(IWorkerRepository repository, IImageService imageService) : base(repository)
        {
            _imageService = imageService;
        }

        public async Task<Stream> GetAvatarAsync(long workerId, CancellationToken token)
        {
            Worker? worker = await GetAsync(workerId, token);
            if (worker is null)
                throw new Exception("Пользователь не найден.");

            if (!worker.ImageUUID.HasValue)
                throw new Exception("У пользователя нет изображения.");

            return await _imageService.GetImageAsync(worker.ImageUUID.Value, token);
        }

        public Task RemoveAvatarAsync(long workerId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task UploadAvatarImageAsync(Stream image, long workerId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
