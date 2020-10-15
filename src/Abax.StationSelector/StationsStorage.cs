using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abax.StationSelector
{
    /// <summary>
    /// Main class to store and find stations on condition Starting With
    /// return stations and list of next chars
    /// </summary>
    public class StationsStorage : IStationsStorage
    {
        private readonly IStationsLoader _stationsLoader;
        private readonly TstDictionary<string> _tstDictionary;

        public StationsStorage(IStationsLoader stationsLoader)
        {
            _stationsLoader = stationsLoader;
            _tstDictionary = new TstDictionary<string>();
            InitializeAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeAsync()
        {
            var stations = await _stationsLoader.LoadAsync();
            _tstDictionary.Clear();
            AddRange(stations);
        }

        public StationsSearchResult FindLike(string like)
        {
            if (string.IsNullOrWhiteSpace(like))
                return null;
            var result = new StationsSearchResult();
            foreach (var item in _tstDictionary.StartingWith(like.ToUpper()))
            {
                var nextChar = item.Value.Length > like.Length ? item.Value[like.Length] : (char?) null;
                result.Add(item.Value, nextChar);
            }

            return result;
        }

        public void AddRange(IEnumerable<string> array)
        {
            foreach (var word in array)
            {
                var upper = word.ToUpper();
                _tstDictionary.Add(upper, upper);
            }
        }
    }
}