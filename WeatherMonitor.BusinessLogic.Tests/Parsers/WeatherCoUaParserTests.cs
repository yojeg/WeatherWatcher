namespace WeatherMonitor.BusinessLogic.Tests.Parsers
{
    using System.IO;
    using BusinessLogic.Parsers;
    using ContentManager;
    using Domain.Entities;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class WeatherCoUaParserTests
    {
        private Mock<IContentManager> _contentManager;
        private WeatherSource _weatherSource;

        [SetUp]
        public void SetUp()
        {
            _contentManager = new Mock<IContentManager>();
            _contentManager.Setup(x => x.Get(It.IsAny<string>()))
                           .Returns(File.ReadAllText("Resources\\weather.co.ua1515.xml"));
            
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
            var parser = new WeatherCoUaParser(_contentManager.Object);

            var weather = parser.Parse(_weatherSource);

            Assert.AreEqual(weather.Degrees, 15);
            Assert.AreEqual(weather.Humidity, 67);
            Assert.AreEqual(weather.Pressure, 737);
            Assert.AreEqual(weather.WindSpeed, 5);
        }

        [Test]
        public void ShouldReturnNullIfContentIsEmpty()
        {
            _contentManager.Setup(x => x.Get(It.IsAny<string>()))
                           .Returns("");

            var parser = new WeatherCoUaParser(_contentManager.Object);

            var weather = parser.Parse(_weatherSource);

            Assert.IsNull(weather);
        }
    }
}