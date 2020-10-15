using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Abax.StationSelector
{
    /// <summary>
    /// Load stations from source, convert results, and return the list of unique stations
    /// </summary>
    public class StationsLoader : IStationsLoader
    {
        private readonly IStationsLoaderResultsConverter<Station> _converter;
        private readonly ILoadStationsFromSource _loadStationsFromSource;

        public StationsLoader(ILoadStationsFromSource loadStationsFromSource, IStationsLoaderResultsConverter<Station> converter)
        {
            _loadStationsFromSource = loadStationsFromSource;
            _converter = converter;
        }

        public async Task<IEnumerable<string>> LoadAsync()
        {
            var stationJson = await _loadStationsFromSource.LoadDataAsync();
            var stationsArray = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Station>>(stationJson));
            return _converter.ConvertFrom(stationsArray);
        }
    }
}