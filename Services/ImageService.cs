using Microsoft.Extensions.Options;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Options;

namespace ResumeFinder.Services
{
    /// <summary>
    /// Сервис для работы с изображениями
    /// </summary>
    public class ImageService : IImageService
    {
        private readonly string _storagePath;

        public ImageService(IOptions<ImageOptions> options)
        {
            _storagePath = options.Value.StoragePath;
        }

        /// <summary>
        /// Метод для получения изображения
        /// </summary>
        /// <param name="imageUUID">Уникальный идентификатор изображения</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Изображение</returns>
        public Task<Stream> GetImageAsync(Guid imageUUID, CancellationToken token)
        {
            string fileName = $"{imageUUID}.jpg";
            string filePath = Path.Combine(_storagePath, fileName);
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            return Task.FromResult(stream);
        }

        /// <summary>
        /// Метод для удаления изображения
        /// </summary>
        /// <param name="imageUUID">Уникальный идентификатор изображения</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Результат удаления</returns>
        public Task RemoveImageAsync(Guid imageUUID, CancellationToken token)
        {
            string fileName = $"{imageUUID}.jpg";
            string filePath = Path.Combine(_storagePath, fileName);
            File.Delete(filePath);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Метод для загрузки изображения
        /// </summary>
        /// <param name="stream">Поток битов изображения</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Уникальный идентификатор изображения</returns>
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
