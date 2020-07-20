using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vintri.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class BeerJson
    {

        public List<Beer> BeerList { get; set; }

    }

}
