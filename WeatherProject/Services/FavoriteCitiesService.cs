using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.ResourceAccess.Models;
using Weather.ResourceAccess.Repositories;

namespace WeatherProject.Services
{
    public class FavoriteCitiesService : IFavoriteCitiesService
    {
        private readonly IFavoriteCityRepository _repository;
        private readonly ILogger _logger;
        public FavoriteCitiesService(IFavoriteCityRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task AddCityToFavorite(FavoriteCity favoriteCity)
        {
            await _repository.AddEntity(favoriteCity);
        }

        public async Task<IList<FavoriteCity>> GetAllFavoriteCities()
        {
            var favorites = await _repository.GetAllFavoriteCities();
            return favorites;
        }
    }
}
