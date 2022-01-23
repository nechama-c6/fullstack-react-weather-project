using System;
using System.Collections.Generic;

#nullable disable

namespace Weather.ResourceAccess.Models
{
    public partial class FavoriteCity
    {
        public int FavoriteCityId { get; set; }
        public string CityKey { get; set; }
        public bool IsActive { get; set; }
    }
}
