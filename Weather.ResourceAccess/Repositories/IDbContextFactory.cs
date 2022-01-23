using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.ResourceAccess.Models;

namespace Weather.ResourceAccess.Repositories
{
    public interface IDbContextFactory
    {
        WeatherDbContext DbContext { get; }
    }
}
