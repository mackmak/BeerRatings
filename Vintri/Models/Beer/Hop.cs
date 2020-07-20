using Newtonsoft.Json;

namespace Vintri.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Hop
    {

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("amount")]
        public Amount Amount;

        [JsonProperty("add")]
        public string Add;

        [JsonProperty("attribute")]
        public string Attribute;

    }

}
