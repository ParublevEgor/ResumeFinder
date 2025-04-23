namespace ResumeFinder.Domain.Contracts
{
    /// <summary>
    /// Сервис для работы с изображениями
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Загрузка изображения в папку
        /// </summary>
        /// <param name="stream">Поток с изображением</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>UUID картинки</returns>
        Task<Guid> UploadImageAsync(Stream stream, CancellationToken token);

        /// <summary>
        /// Получение изображения из папки
        /// </summary>
        /// <param name="imageUUID">Уникальный идентификатор изображения</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Картинку</returns>
        Task<Stream> GetImageAsync(Guid imageUUID, CancellationToken token);

        /// <summary>
        /// Удаление изображения из папки
        /// </summary>
        /// <param name="imageUUID">Уникальный идентификатор изображения</param>
        /// <param name="token">Токен отмены</param>
        /// <returns></returns>
        Task RemoveImageAsync(Guid imageUUID, CancellationToken token);
    }
}
