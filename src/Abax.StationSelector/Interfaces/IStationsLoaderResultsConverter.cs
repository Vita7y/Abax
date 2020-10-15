using System.Collections.Generic;

namespace Abax.StationSelector
{
    public interface IStationsLoaderResultsConverter<T>
    {
        IEnumerable<string> ConvertFrom(IEnumerable<T> source);
    }
}