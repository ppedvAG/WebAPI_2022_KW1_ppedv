namespace WebAPISamples.Services
{


    public class VideoService : IVideoService
    {
        private HttpClient _httpClient;

        public VideoService(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }
        public async Task<Stream> GetVideoByName(string name)
        {
            string url = string.Empty;

            switch (name)
            {
                case "fugees":
                    url = "http://gartner.gosimian.com/assets/videos/Fugees_ReadyOrNot_278-WIREDRIVE.mp4";
                    break;
                case "xyz":
                    url = "http://gartner.gosimian.com/assets/videos/George_Michael_MV-WIREDRIVE.mp4";
                    break;
                default:
                    url = "abc";
                    break;
            }

            return await _httpClient.GetStreamAsync(url);
        }
    }
}
