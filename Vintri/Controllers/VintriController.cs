using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Vintri.Models;
using Vintri.Models.Factories;
using Vintri.Models.Validation;
using Vintri.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vintri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class VintriController : ControllerBase
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IUserResponseFactory _userResponseFactory;
        private readonly BaseClassDataBaseRepository _dataBaseRepository;

        public VintriController(IBeerRepository beerRepository, BaseClassDataBaseRepository dataBaseRepository,
             IUserResponseFactory userResponseFactory)
        {
            _beerRepository = beerRepository;
            _dataBaseRepository = dataBaseRepository;
            _userResponseFactory = userResponseFactory;
        }

        [NonAction]
        public async Task<IList<Beer>> AddRatingToBeer(int id, Beer punkAPIBeer, UserJson userRating)
        {
            var beers = await BaseClassDataBaseRepository.ReadFromDataBase();

            var beer = beers.Where(beer => beer.Id == id).FirstOrDefault();

            //Beer doesn't exist in database yet, create a new record
            if (beer == null)
            {
                punkAPIBeer.UserRatings.Add(userRating);
                beers.Add(punkAPIBeer);
            }
            else
            {
                beer.UserRatings.Add(userRating);
            }

            return beers;
        }

        // POST api/<VintriController>/id
        [HttpPost("{id}")]
        public async Task<IActionResult> Post(int id, UserJson userRating)
        {
            try
            {
                var punkAPIBeer = await _beerRepository.FindById(id);
                if(punkAPIBeer == null)
                {
                    throw new ArgumentException();
                }
                var databaseBeers = await AddRatingToBeer(id, punkAPIBeer, userRating);

                var returnMessage = "";

                returnMessage = _dataBaseRepository.WriteToDatabase(databaseBeers);

                if (returnMessage == string.Empty)
                {
                    return Ok();
                }
                else
                {
                    return ValidationProblem(returnMessage);
                }
            }
            catch (ArgumentException)
            {
                var dictionaryResponse = new ModelStateDictionary();
                dictionaryResponse.AddModelError("ID", "Could not find a beer with the provided ID.");
                return NotFound(dictionaryResponse);
            }
            catch (Exception ex)
            {
                var dictionaryResponse = new ModelStateDictionary();
                dictionaryResponse.AddModelError("", ex.Message);
                return ValidationProblem(dictionaryResponse);
            }
        }

        
        private IList<UserResponse> ConvertBeerListToRatingsList(IEnumerable<Beer> beerList)
        {
            IList<UserResponse> ratings = new List<UserResponse>();

            foreach (var beer in beerList)
            {

                var rating = _userResponseFactory.CreateInstance(
                    beer.Id, 
                    beer.Name, 
                    beer.Description, 
                    beer.UserRatings
                );
                    
                ratings.Add(rating);
            }

            return ratings;
        }

        // GET api/<VintriController>/beerName
        [HttpGet]
        public async Task<IActionResult> GetBeerByName(string beerName)
        {
            try
            {
                if (string.IsNullOrEmpty(beerName))
                {
                    throw new ArgumentException();
                }

                var punkAPIBeers = await _beerRepository.FindByName(beerName);

                if (punkAPIBeers != null && punkAPIBeers.Count() > 0)
                {
                    var databaseBeers = await BaseClassDataBaseRepository.ReadFromDataBase();

                    if(databaseBeers != null && databaseBeers.Count() > 0)
                    {
                        var beersMatched = databaseBeers.Intersect(punkAPIBeers);

                        if (beersMatched != null && beersMatched.Count() > 0)
                        {
                            var ratings = ConvertBeerListToRatingsList(beersMatched);
                            var response = JsonConvert.SerializeObject(ratings);
                            return Ok(response);
                        }
                    }

                }

                return NotFound($"No beer was found in the database with the name {beerName}.");

            }
            catch (ArgumentException)
            {
                var dictionaryResponse = new ModelStateDictionary();
                dictionaryResponse.AddModelError("beer_name", "Could not find a beer with the provided Name.");
                return NotFound(dictionaryResponse);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

    }
}
