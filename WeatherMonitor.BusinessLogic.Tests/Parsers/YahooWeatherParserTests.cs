namespace WeatherMonitor.BusinessLogic.Tests.Parsers
{
    using System.IO;
    using BusinessLogic.Parsers;
    using ContentManager;
    using Domain.Entities;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class YahooWeatherParserTests
    {
        private WeatherSource _weatherSource;
        private Mock<IContentManager> _contentManager;

        [SetUp]
        public void SetUp()
        {
            _contentManager = new Mock<IContentManager>();
            _contentManager.Setup(x => x.Get(It.IsAny<string>()))
                           .Returns(File.ReadAllText("Resources\\yahooWeatherRss.xml"));

            _weatherSource = new WeatherSource()
            {
                City = "Chelyabinsk",
                Name = "Weather.co.ua Chelyabinsk",
                Url = "test"
            };

        }

        [Test]
        public void ShouldParseWeatherWromSource()
        {
            var parser = new YahooWeatherParser(_contentManager.Object);

            var weather = parser.Parse(_weatherSource);

            Assert.AreEqual(weather.Degrees, 16);
            Assert.AreEqual(weather.Humidity, 63);
            Assert.AreEqual(weather.Pressure, 982.05);
            Assert.AreEqual(weather.WindSpeed, 20.92);
        }

        [Test]
        public void ShouldReturnNullIfContentIsEmpty()
        {
            _contentManager.Setup(x => x.Get(It.IsAny<string>()))
                           .Returns("");

            var parser = new YahooWeatherParser(_contentManager.Object);

            var weather = parser.Parse(_weatherSource);

            Assert.IsNull(weather);
        }
    }
}