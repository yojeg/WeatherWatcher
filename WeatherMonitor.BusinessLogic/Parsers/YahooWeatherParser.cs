namespace WeatherMonitor.BusinessLogic.Parsers
{
    using ContentManager;
    using Domain.Entities;

    public class YahooWeatherParser : IWeatherParser
    {
        private readonly IContentManager _contentManager;

        public YahooWeatherParser(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public IWeather Parse(IWeatherSource weatherSource)
        {
            var content = _contentManager.Get(weatherSource.Url);

            if (!string.IsNullOrEmpty(content))
            {
                return ParseContent(content);
            }

            return null;
        }

        private IWeather ParseContent(string content)
        {
            return null;
        }
    }
}