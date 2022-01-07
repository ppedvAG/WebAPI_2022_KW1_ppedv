namespace WebAPISamples.Services
{
    public interface IVideoService
    {
        Task<Stream> GetVideoByName(string name);
    }
}
