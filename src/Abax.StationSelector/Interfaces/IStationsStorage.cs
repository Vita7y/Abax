using System.Threading.Tasks;

namespace Abax.StationSelector
{
    public interface IStationsStorage
    {
        StationsSearchResult FindLike(string like);
    }
}