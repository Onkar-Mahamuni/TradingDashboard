using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace TradingDashboard.DataAccess.Entities
{
    public class Watchlist
    {
        public long WatchlistId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<StockWatchlistMap> StockWatchlistMaps { get; set; }
    }
}
