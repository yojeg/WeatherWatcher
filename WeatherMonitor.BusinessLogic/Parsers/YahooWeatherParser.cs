namespace WeatherMonitor.BusinessLogic.Parsers
{
    using System.Globalization;
    using System.Xml.Linq;
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
            IWeather weather = null;

            var xmlDocument = XDocument.Parse(content);

            XNamespace weatherNamespace = "http://xml.weather.yahoo.com/ns/rss/1.0";

            var currentWeatherNode = xmlDocument.Root.Element("channel");

            if (currentWeatherNode != null)
            {
                var windElement = currentWeatherNode.Element(weatherNamespace + "wind");
                var atmosphere = currentWeatherNode.Element(weatherNamespace + "atmosphere");

                weather = new Weather
                {
                    Degrees = int.Parse(windElement.Attribute("chill").Value),
                    Humidity = decimal.Parse(atmosphere.Attribute("humidity").Value, NumberStyles.AllowDecimalPoint, new NumberFormatInfo(){NumberDecimalSeparator = "."}),
                    Pressure = decimal.Parse(atmosphere.Attribute("pressure").Value, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    WindSpeed = decimal.Parse(windElement.Attribute("speed").Value, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() { NumberDecimalSeparator = "." })
                };
            }

            return weather;

        }
    }
}