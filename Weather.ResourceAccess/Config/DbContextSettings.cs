using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.ResourceAccess.Config
{
    public class DbContextSettings
    {
        /// <summary>
        /// DbConnectingString from appsettings.json
        /// </summary>
        public string DbConnectionString { get; set; }
    }
}
