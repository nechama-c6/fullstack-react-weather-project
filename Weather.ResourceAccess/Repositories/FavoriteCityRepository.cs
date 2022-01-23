using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.ResourceAccess.Models;

namespace Weather.ResourceAccess.Repositories
{
    public class FavoriteCityRepository : Repository<FavoriteCity>, IFavoriteCityRepository
    {
        public FavoriteCityRepository(IDbContextFactory dbContextFactory, ILogger logger) :
                                                          base(dbContextFactory, logger)
        {
        }
        public async Task<IList<FavoriteCity>> GetAllFavoriteCities()
        {
            var favorites = await DbContext.FavoriteCities.ToListAsync(); 
            return favorites;
        }
    }
}
