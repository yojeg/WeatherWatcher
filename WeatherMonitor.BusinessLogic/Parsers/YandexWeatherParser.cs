namespace WeatherMonitor.BusinessLogic.Parsers
{
    using ContentManager;
    using Domain.Entities;

    public class YandexWeatherParser : IWeatherParser
    {
        private readonly IContentManager _contentManager;

        public YandexWeatherParser(IContentManager contentManager)
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