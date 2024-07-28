using TradingDashboard.DataAccess.Entities;
using TradingDashboard.DataAccess.Repositories;
using TradingDashboard.Shared.Dtos;

namespace TradingDashboard.BusinessLogic.Services
{
    public class StockService(IStockRepository repository) : IStockService
    {
        private readonly IStockRepository _repository = repository;

        public async Task<IEnumerable<Stock>> GetAllStocksAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedAsync(pageNumber, pageSize);
        }

        public async Task<Stock?> GetStockByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Stock> AddStockAsync(CreateStockDto dto)
        {
            var stock = new Stock()
            {
                Segment = dto.Segment,
                Name = dto.Name,
                Exchange = dto.Exchange,
                Isin = dto.Isin,
                InstrumentType = dto.InstrumentType,
                InstrumentKey = dto.InstrumentKey,
                LotSize = dto.LotSize,
                FreezeQuantity = dto.FreezeQuantity,
                ExchangeToken = dto.ExchangeToken,
                TickSize = dto.TickSize,
                TradingSymbol = dto.TradingSymbol,
                ShortName = dto.ShortName,
                SecurityType = dto.SecurityType,
                Sector = dto.Sector,
                Description = dto.Description
            };
            return await _repository.AddAsync(stock);
        }

        public async Task<IEnumerable<Stock>> AddStockRangeAsync(IEnumerable<CreateStockDto> dtos)
        {
            List<Stock> stocks = new List<Stock>();

            foreach (var dto in dtos)
            {
                var stock = new Stock()
                {
                    Segment = dto.Segment,
                    Name = dto.Name,
                    Exchange = dto.Exchange,
                    Isin = dto.Isin,
                    InstrumentType = dto.InstrumentType,
                    InstrumentKey = dto.InstrumentKey,
                    LotSize = dto.LotSize,
                    FreezeQuantity = dto.FreezeQuantity,
                    ExchangeToken = dto.ExchangeToken,
                    TickSize = dto.TickSize,
                    TradingSymbol = dto.TradingSymbol,
                    ShortName = dto.ShortName,
                    SecurityType = dto.SecurityType,
                    Sector = dto.Sector,
                    Description = dto.Description
                };

                stocks.Add(stock);
            }
            return await _repository.AddRangeAsync(stocks);
        }

        public async Task<Stock> UpdateStockAsync(Stock stock)
        {
            return await _repository.UpdateAsync(stock);
        }

        public async Task DeleteStockAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
