using Newtonsoft.Json;

namespace Vintri.Models
{
    public class Temp
    {

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("unit")]
        public string Unit;

    }

}
