using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.ResourceAccess.Models;

namespace WeatherProject.Services
{
    public interface IFavoriteCitiesService
    {
        Task<IList<FavoriteCity>> GetAllFavoriteCities();
        Task AddCityToFavorite(FavoriteCity favoriteCity);
    }
}
