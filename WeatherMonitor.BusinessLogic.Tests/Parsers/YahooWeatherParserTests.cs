namespace WeatherMonitor.BusinessLogic.Tests.Parsers
{
    using System.IO;
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
                           .Returns(File.ReadAllText("Resources\\weather.co.ua1515.xml"));

            _weatherSource = new WeatherSource()
            {
                City = "Chelyabinsk",
                Name = "Weather.co.ua Chelyabinsk",
                Url = "test"
            };

        }
    }
}