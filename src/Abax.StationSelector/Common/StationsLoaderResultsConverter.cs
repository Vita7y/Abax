using System.Collections.Generic;
using System.Linq;

namespace Abax.StationSelector
{
    public class StationsLoaderResultsConverter : IStationsLoaderResultsConverter<Station>
    {
        public IEnumerable<string> ConvertFrom(IEnumerable<Station> source)
        {
            return source.Select(s => s.Name).Distinct().ToList();
        }
    }
}