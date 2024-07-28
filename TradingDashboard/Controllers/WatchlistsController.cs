using Microsoft.AspNetCore.Mvc;
using TradingDashboard.BusinessLogic.Services;
using TradingDashboard.DataAccess.Entities;
using TradingDashboard.Shared.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingDashboard.WebApi.Controllers
{
    [Route("api/watchlists")]
    [ApiController]
    public class WatchlistsController(IWatchlistService watchlistService) : ControllerBase
    {
        private readonly IWatchlistService _watchlistService = watchlistService;

        // GET: api/<WatchlistsController>
        [HttpGet]
        public async Task<IEnumerable<Watchlist>> GetPagedAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            return await _watchlistService.GetAllWatchlistsAsync(pageNumber, pageSize);
        }

        // GET api/<WatchlistsController>/5
        [HttpGet("{id}")]
        public async Task<Watchlist?> GetAsync(long id)
        {
            return await _watchlistService.GetWatchlistByIdAsync(id);
        }

        // POST api/<WatchlistsController>
        [HttpPost]
        public async Task<Watchlist> PostAsync([FromBody] CreateWatchlistDto dto)
        {
            return await _watchlistService.AddWatchlistAsync(dto);
            //return CreatedAtAction(nameof(GetAsync), watchlist);
        }

        // PUT api/<WatchlistsController>/5
        [HttpPut("{id}")]
        public async Task<Watchlist> PutAsync(long id, [FromBody] Watchlist entity)
        {
            entity.WatchlistId = id;
            return await _watchlistService.UpdateWatchlistAsync(entity);
        }

        // DELETE api/<WatchlistsController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            await _watchlistService.DeleteWatchlistAsync(id);

        }
    }
}
