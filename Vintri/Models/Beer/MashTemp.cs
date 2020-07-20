using Newtonsoft.Json;

namespace Vintri.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class MashTemp
    {

        [JsonProperty("temp")]
        public Temp Temp;

        [JsonProperty("duration")]
        public int? Duration;

    }

}
