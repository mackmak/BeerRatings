using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vintri.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Ingredients
    {

        [JsonProperty("malt")]
        public IList<Malt> Malt;

        [JsonProperty("hops")]
        public IList<Hop> Hops;

        [JsonProperty("yeast")]
        public string Yeast;

    }

}
