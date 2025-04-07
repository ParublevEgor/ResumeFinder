namespace ResumeFinder.Domain.Contracts
{
    public interface IImageService
    {
        Task<Guid> UploadImageAsync(Stream stream, CancellationToken token);

        Task<Stream> GetImageAsync(Guid imageUUID, CancellationToken token);

        Task RemoveImageAsync(Guid imageUUID, CancellationToken token);
    }
}
