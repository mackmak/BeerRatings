using Newtonsoft.Json;

namespace Vintri.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Amount
    {

        [JsonProperty("value")]
        public double Value;

        [JsonProperty("unit")]
        public string Unit;

    }

}
