using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Vintri.Models;

namespace Vintri.Repositories
{
    public abstract class BaseClassDataBaseRepository
    {
        protected static string Path = $"{Environment.CurrentDirectory}\\App_Data\\database.json";

        /// <summary>
        /// As controllers are not supposed to have instantiations, 
        /// I decided to create an abtract class to have a static method
        /// since interfaces don't accept static methods
        /// </summary>
        public static async Task<IList<Beer>> ReadFromDataBase()
        {
            IList<Beer> beers = null;
            using (var streamReader = new StreamReader(Path, true))
            {
                var jsonFile = await streamReader.ReadToEndAsync();
                beers = JsonConvert.DeserializeObject<List<Beer>>(jsonFile);

                streamReader.Close();
            }

            return beers;
        }

        public abstract string WriteToDatabase(IList<Beer> beers);
    }
}
