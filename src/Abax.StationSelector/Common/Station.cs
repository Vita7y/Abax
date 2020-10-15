using Newtonsoft.Json;

namespace Abax.StationSelector
{
    public class Station
    {
        [JsonProperty("stationCode")] public string Code { get; set; }

        [JsonProperty("stationName")] public string Name { get; set; }
    }
}