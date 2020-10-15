using System.IO;
using System.Threading.Tasks;

namespace Abax.StationSelector
{
    public class LoadStationsFromFileSource : ILoadStationsFromSource
    {
        private readonly string _sourceAddress;

        public LoadStationsFromFileSource(string fileName)
        {
            _sourceAddress = fileName;
        }

        public Task<string> LoadDataAsync()
        {
            return File.ReadAllTextAsync(_sourceAddress);
        }
    }
}