using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vintri.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Method
    {

        [JsonProperty("mash_temp")]
        public List<MashTemp> MashTemp;

        [JsonProperty("fermentation")]
        public Fermentation Fermentation;

        [JsonProperty("twist")]
        public object Twist;

    }

}
