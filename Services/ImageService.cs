using Microsoft.Extensions.Options;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Options;

namespace ResumeFinder.Services
{
    public class ImageService : IImageService
    {
        private readonly string _storagePath;

        public ImageService(IOptions<ImageOptions> options)
        {
            _storagePath = options.Value.StoragePath;
        }

        public Task<Stream> GetImageAsync(Guid imageUUID, CancellationToken token)
        {
            string fileName = $"{imageUUID}.jpg";
            string filePath = Path.Combine(_storagePath, fileName);
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            return Task.FromResult(stream);
        }

        public Task RemoveImageAsync(Guid imageUUID, CancellationToken token)
        {
            string fileName = $"{imageUUID}.jpg";
            string filePath = Path.Combine(_storagePath, fileName);
            File.Delete(filePath);

            return Task.CompletedTask;
        }

        public async Task<Guid> UploadImageAsync(Stream stream, CancellationToken token)
        {
            Guid imageUUID = Guid.NewGuid();
            string fileName = $"{imageUUID}.jpg";
            string filePath = Path.Combine(_storagePath, fileName);

            using FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            await stream.CopyToAsync(fileStream, token);

            return imageUUID;
        }
    }
}
