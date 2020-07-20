using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Vintri.Models;
using Vintri.Static;

namespace Vintri.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private static HttpClient _client;
        public BeerRepository()
        {
            _client = new HttpClient();
        }
        public async Task<Beer> FindById(int id)
        {
            IList<Beer> beers = null;

            var url = $"{EndPoints.PunkApiUrl}/{id}";
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var JsonResult = response.Content.ReadAsStringAsync().Result;

                beers = JsonConvert.DeserializeObject<IList<Beer>>(JsonResult);
            }

            return beers.FirstOrDefault();
        }

        public async Task<IList<Beer>> FindByName(string beerName)
        {
            IList<Beer> beers = null;

            var url = $"{EndPoints.PunkApiUrl}?beer_name={beerName}";
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var JsonResult = response.Content.ReadAsStringAsync().Result;

                beers = JsonConvert.DeserializeObject<IList<Beer>>(JsonResult);
            }

            return beers.ToList();

        }
    }
}
