using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.ResourceAccess.Models;
using WeatherProject.Services;

namespace WeatherProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteCitiesController : ControllerBase
    {
        //private const string API_KEY = "G6PZZpldr2JsnimjGjWRnCIzN6HV3L7r";
        //private const string WEATHER_API_URL = "http://dataservice.accuweather.com/";


        private readonly ILogger<FavoriteCitiesController> _logger;
        private readonly IFavoriteCitiesService _service;
        public FavoriteCitiesController(IFavoriteCitiesService service,ILogger<FavoriteCitiesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        //public async Task Search(string searchText)
        //{

        //}

        //[HttpGet("[action]/{cityKey}")]
        //public async Task GetCurrentWeather(string cityKey)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            client.BaseAddress = new Uri(WEATHER_API_URL);
        //            var response = await client.GetAsync($"currentconditions/v1/{cityKey}&apikey="+API_KEY);
        //            response.EnsureSuccessStatusCode();
        //            var result = await response.Content.ReadAsStringAsync();
        //            //var openWeather = JsonConvert.DeserializeObject(result);

        //            //var forecast = new
        //            //{
        //            //    Temp = openWeather.Main.Temp,
        //            //    Summary = string.Join(",", openWeather.Weather.Select(x => x.Main)),
        //            //    City = openWeather.Name
        //            //};

        //            //return Ok(forecast);
        //        }

        //        catch (HttpRequestException httpRequestException)
        //        {
        //            //return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
        //        }
        //    }
        //}

        [HttpGet]
        public async Task<ActionResult<List<FavoriteCity>>> Get()
        {
            var favorites = await _service.GetAllFavoriteCities();
            return favorites.ToList();
        }

        [HttpPost]
        public async Task Post([FromBody] string cityKey)
        {
            await _service.AddCityToFavorite(new FavoriteCity { CityKey = cityKey, IsActive = true });
        }
    }
}
