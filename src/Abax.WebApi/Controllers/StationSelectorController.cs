using Abax.StationSelector;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET api/<StationSelector>/5
        [HttpGet()]
        public StationsSearchResult Get([FromQuery] string station)
        {
            return _stationsStorage.FindLike(station);
        }
    }
}