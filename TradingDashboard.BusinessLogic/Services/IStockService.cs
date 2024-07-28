using TradingDashboard.DataAccess.Entities;
using TradingDashboard.Shared.Dtos;

namespace TradingDashboard.BusinessLogic.Services
{
    public interface IStockService
    {
        Task<Stock> AddStockAsync(CreateStockDto dto);
        Task<IEnumerable<Stock>> AddStockRangeAsync(IEnumerable<CreateStockDto> dtos);
        Task DeleteStockAsync(long id);
        Task<IEnumerable<Stock>> GetAllStocksAsync(int pageNumber, int pageSize);
        Task<Stock?> GetStockByIdAsync(long id);
        Task<Stock> UpdateStockAsync(Stock stock);
    }
}