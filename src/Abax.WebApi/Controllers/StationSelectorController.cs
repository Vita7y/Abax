using Abax.StationSelector;
using Microsoft.AspNetCore.Mvc;

namespace Abax.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationSelectorController : ControllerBase
    {
        private readonly IStationsStorage _stationsStorage;

        public StationSelectorController(IStationsStorage stationsStorage)
        {
            _stationsStorage = stationsStorage;
        }

        // GET api/StationSelector?Station=Aber
        [HttpGet()]
        public StationsSearchResult Get([FromQuery] string station)
        {
            return _stationsStorage.FindLike(station);
        }
    }
}