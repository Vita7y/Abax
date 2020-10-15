using System.Collections.Generic;
using System.Linq;

namespace Abax.StationSelector
{
    public class StationsSearchResult
    {
        private readonly HashSet<string> _cities;
        private readonly HashSet<char> _nextChar;

        public StationsSearchResult()
        {
            _cities = new HashSet<string>();
            _nextChar = new HashSet<char>();
        }

        public List<char> NextValidChars => _nextChar.ToList();

        public List<string> Cities => _cities.ToList();

        public void Add(string value, char? next)
        {
            _cities.Add(value);
            if (next.HasValue)
                _nextChar.Add(next.Value);
        }
    }
}