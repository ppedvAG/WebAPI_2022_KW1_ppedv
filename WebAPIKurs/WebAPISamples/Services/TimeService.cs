namespace WebAPISamples.Services
{
    public class TimeService : ITimeService
    {
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
