using TradingDashboard.DataAccess.Entities;
using TradingDashboard.DataAccess.Repositories;
using TradingDashboard.Shared.Dtos;

namespace TradingDashboard.BusinessLogic.Services
{
    public class WatchlistService(IWatchlistRepository repository) : IWatchlistService
    {
        private readonly IWatchlistRepository _repository = repository;

        public async Task<IEnumerable<Watchlist>> GetAllWatchlistsAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedAsync(pageNumber, pageSize);
        }

        public async Task<Watchlist?> GetWatchlistByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Watchlist> AddWatchlistAsync(CreateWatchlistDto dto)
        {
            var watchlist = new Watchlist() { Name = dto.Name, Description = dto.Description };
            return await _repository.AddAsync(watchlist);
        }

        public async Task<Watchlist> UpdateWatchlistAsync(Watchlist watchlist)
        {
            return await _repository.UpdateAsync(watchlist);
        }

        public async Task DeleteWatchlistAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
