using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Abax.StationSelector.Tests
{
    public class UnitTestsStations
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestCheckStation_DART_HasKeyAndCities()
        {
            var stationsLoaderMock = new Mock<IStationsLoader>();
            stationsLoaderMock
                .Setup(x => x.LoadAsync())
                .ReturnsAsync(await Task.FromResult(new List<string> { "DARTFORD", "DARTON", "TOWER HILL", "DERBY" }));

            var cityStorage = new StationsStorage(stationsLoaderMock.Object);
            var result = cityStorage.FindLike("DART");

            CollectionAssert.AreEqual(new[] {'F', 'O'}, result.NextValidChars);
            CollectionAssert.AreEqual(new[] {"DARTFORD", "DARTON"}, result.Cities);
        }

        [Test]
        public async Task TestCheckStation_LIVERPOOL_HasCities()
        {
            var stationsLoaderMock = new Mock<IStationsLoader>();
            stationsLoaderMock
                .Setup(x => x.LoadAsync())
                .ReturnsAsync(await Task.FromResult(new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" }));

            var cityStorage = new StationsStorage(stationsLoaderMock.Object);
            var result = cityStorage.FindLike("LIVERPOOL");

            CollectionAssert.AreEqual(new[] {' '}, result.NextValidChars);
            CollectionAssert.AreEqual(new[] {"LIVERPOOL", "LIVERPOOL LIME STREET"}, result.Cities);
        }

        [Test]
        public async Task TestCheckStation_KINGSCROSS_HasNothing()
        {
            var stationsLoaderMock = new Mock<IStationsLoader>();
            stationsLoaderMock
                .Setup(x => x.LoadAsync())
                .ReturnsAsync(await Task.FromResult(new List<string> { "EUSTON", "LONDON BRIDGE", "VICTORIA" }));

            var cityStorage = new StationsStorage(stationsLoaderMock.Object);
            var result = cityStorage.FindLike("KINGS CROSS");

            CollectionAssert.AreEqual(Array.Empty<object>(), result.NextValidChars);
            CollectionAssert.AreEqual(Array.Empty<object>(), result.Cities);
        }
    }
}