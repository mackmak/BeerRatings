using Newtonsoft.Json;

namespace Vintri.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class BoilVolume
    {

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("unit")]
        public string Unit;

    }

}
