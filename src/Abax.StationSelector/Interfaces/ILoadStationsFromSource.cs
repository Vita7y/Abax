using System.Threading.Tasks;

namespace Abax.StationSelector
{
    public interface ILoadStationsFromSource
    {
        Task<string> LoadDataAsync();
    }
}