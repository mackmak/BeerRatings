using Newtonsoft.Json;

namespace Vintri.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Fermentation
    {

        [JsonProperty("temp")]
        public Temp Temp;

    }

}
