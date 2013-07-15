namespace WeatherMonitor.BusinessLogic.ContentManager
{
    using System.Net;

    public class ContentManager : IContentManager
    {
        public string Get(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}