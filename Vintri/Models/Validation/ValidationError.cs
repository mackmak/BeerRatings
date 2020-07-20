using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Vintri.Models.Validation
{
    public class ValidationError
    {
        //Field will not be serialized in case of a null value
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        public string Message { get; }

        public ValidationError(string field, string message)
        {
            //If string is empty, convert it to null so it will not be serialized
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}
