using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abax.StationSelector
{
    public interface IStationsLoader
    {
        Task<IEnumerable<string>> LoadAsync();
    }
}