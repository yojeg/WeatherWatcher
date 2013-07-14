namespace WeatherMonitor.BusinessLogic.Parsers
{
    using System.Xml.Linq;
    using ContentManager;
    using Domain.Entities;

    public class WeatherCoUaParser : IWeatherParser
    {
        private readonly IContentManager _contentManager;

        public WeatherCoUaParser(IContentManager contentManager)
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
            IWeather weather = null;

            var xmlDocument = XDocument.Parse(content);

             var currentWeatherNode = xmlDocument.Root.Element("current");

            if (currentWeatherNode != null)
            {
                weather = new Weather
                    {
                        Degrees = int.Parse(currentWeatherNode.Element("t").Value),
                        Humidity = int.Parse(currentWeatherNode.Element("h").Value),
                        Pressure = int.Parse(currentWeatherNode.Element("p").Value),
                        WindSpeed = int.Parse(currentWeatherNode.Element("w").Value)
                    };
            }

            return weather;
        }
    }
}