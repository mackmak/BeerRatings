using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Vintri.Models;

namespace Vintri.Repositories
{
    public class DataBaseRepository : BaseClassDataBaseRepository
    {
        

        /// <summary>
        /// This method MUST be synchronous for concurrency control
        /// </summary>
        public override string WriteToDatabase(IList<Beer> beers)
        {

            try
            {
                var jsonFile = JsonConvert.SerializeObject(beers, Formatting.Indented);

                File.WriteAllText(Path, jsonFile);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
