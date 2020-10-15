using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Abax.StationSelector.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        [Category("Integration")]
        public async Task TestLoadDataFromFile()
        {
            const string fileName = @".\Resources\station_codes.json";
            var sourceLoader = new LoadStationsFromFileSource(fileName);
            var citiesLoader = new StationsLoader(sourceLoader, new StationsLoaderResultsConverter());
            var result = await citiesLoader.LoadAsync();
            Assert.IsTrue(result.Any());
        }

        [Test]
        [Category("Integration")]
        public async Task TestLoadDataFromUrl()
        {
            const string url = @"https://raw.githubusercontent.com/abax-as/coding-challenge/master/station_codes.json";
            var sourceLoader = new LoadStationsFromWebSource(url);
            var citiesLoader = new StationsLoader(sourceLoader, new StationsLoaderResultsConverter());
            var result = await citiesLoader.LoadAsync();
            Assert.IsTrue(result.Any());
        }
    }
}