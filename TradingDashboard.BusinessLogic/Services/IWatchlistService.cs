using TradingDashboard.DataAccess.Entities;
using TradingDashboard.Shared.Dtos;

namespace TradingDashboard.BusinessLogic.Services
{
    public interface IWatchlistService
    {
        Task<IEnumerable<Watchlist>> GetAllWatchlistsAsync(int pageNumber, int pageSize);
        Task<Watchlist?> GetWatchlistByIdAsync(long id);
        Task<Watchlist> AddWatchlistAsync(CreateWatchlistDto dto);
        Task<Watchlist> UpdateWatchlistAsync(Watchlist watchlist);
        Task DeleteWatchlistAsync(long id);
    }
}
