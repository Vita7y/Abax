using System.Net.Http;
using System.Threading.Tasks;

namespace Abax.StationSelector
{
    public class LoadStationsFromWebSource : ILoadStationsFromSource
    {
        private readonly string _sourceAddress;

        public LoadStationsFromWebSource(string url)
        {
            _sourceAddress = url;
        }

        public Task<string> LoadDataAsync()
        {
            var client = new HttpClient();
            return client.GetStringAsync(_sourceAddress);
        }
    }
}