using Newtonsoft.Json;

namespace Vintri.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Malt
    {

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("amount")]
        public Amount Amount;

    }

}
