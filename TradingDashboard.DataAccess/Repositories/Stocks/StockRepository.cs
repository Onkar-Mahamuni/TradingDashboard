using TradingDashboard.DataAccess.Entities;

namespace TradingDashboard.DataAccess.Repositories
{
    public class StockRepository(ApplicationDbContext context) : Repository<Stock>(context), IStockRepository
    {
        private readonly ApplicationDbContext _context = context;

    }
}

