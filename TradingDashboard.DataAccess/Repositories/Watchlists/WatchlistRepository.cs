using TradingDashboard.DataAccess.Entities;

namespace TradingDashboard.DataAccess.Repositories
{
    public class WatchlistRepository(ApplicationDbContext context) : Repository<Watchlist>(context), IWatchlistRepository 
    {
        private readonly ApplicationDbContext _context = context;
    }
}
