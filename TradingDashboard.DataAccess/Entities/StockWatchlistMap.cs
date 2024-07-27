using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingDashboard.DataAccess.Entities
{
    public class StockWatchlistMap
    {
        [ForeignKey("Stock")]
        public long stockId { get; set; }
        public required Stock Stock { get; set; }
        [ForeignKey("Watchlist")]
        public long WatchlistId { get; set; }
        public required Watchlist Watchlist { get; set; }
    }
}
