using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace Vintri.Models
{
    public enum Rating
    {
        Poor = 1,
        Bad = 2,
        Average = 3,
        Good = 4,
        Great = 5
    }
    [JsonObject]
    public class UserJson
    {
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "Email is required and must be properly formatted.")]
        [Required]
        [JsonProperty("username")]
        public string UserName { get; set; }
        [Required]
        [Range(1, 5)]
        [JsonProperty("rating")]
        public Rating Rating { get; set; }
       // [Required(AllowEmptyStrings = true)]
        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}


