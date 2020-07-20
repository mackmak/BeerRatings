using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Vintri.Models
{
    public class Beer 
    {
        public Beer()
        {
            UserRatings = new List<UserJson>();
        }

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("tagline")]
        public string Tagline;

        [JsonProperty("first_brewed")]
        public string FirstBrewed;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("image_url")]
        public string ImageUrl;

        [JsonProperty("abv")]
        public double Abv;

        [JsonProperty("ibu")]
        public int Ibu;

        [JsonProperty("target_fg")]
        public int TargetFg;

        [JsonProperty("target_og")]
        public int TargetOg;

        [JsonProperty("ebc")]
        public int Ebc;

        [JsonProperty("srm")]
        public double Srm;

        [JsonProperty("ph")]
        public double Ph;

        [JsonProperty("attenuation_level")]
        public double AttenuationLevel;

        [JsonProperty("volume")]
        public Volume Volume;

        [JsonProperty("boil_volume")]
        public BoilVolume BoilVolume;

        [JsonProperty("method")]
        public Method Method;

        [JsonProperty("ingredients")]
        public Ingredients Ingredients;

        [JsonProperty("food_pairing")]
        public IList<string> FoodPairing;

        [JsonProperty("brewers_tips")]
        public string BrewersTips;

        [JsonProperty("contributed_by")]
        public string ContributedBy;

        [JsonProperty("user_ratings")]
        public IList<UserJson> UserRatings;

        public override bool Equals(object other)
        {
            if(other is Beer)
            {
                return this.Name == ((Beer)other).Name;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }

}
