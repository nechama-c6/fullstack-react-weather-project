using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.ResourceAccess.Repositories
{
    public static class RepositoryInjectionModule
    {
        public static IServiceCollection InjectResourceAccess(this IServiceCollection services)
        {
            services.AddScoped<IDbContextFactory, DbContextFactory>();
            services.AddTransient<IFavoriteCityRepository, FavoriteCityRepository>();
            return services;
        }
    }
}
