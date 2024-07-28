using Microsoft.AspNetCore.Mvc;
using TradingDashboard.BusinessLogic.Services;
using TradingDashboard.DataAccess.Entities;
using TradingDashboard.Shared.Dtos;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace TradingDashboard.WebApi.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StocksController(IStockService stockService) : Controller
    {
        private readonly IStockService _stockService = stockService;

        // GET: api/<StocksController>
        [HttpGet]
        public async Task<IEnumerable<Stock>> GetPagedAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            return await _stockService.GetAllStocksAsync(pageNumber, pageSize);
        }

        // GET api/<StocksController>/5
        [HttpGet("{id}")]
        public async Task<Stock?> GetAsync(long id)
        {
            return await _stockService.GetStockByIdAsync(id);
        }

        // POST api/<StocksController>
        [HttpPost]
        public async Task<Stock> PostAsync([FromBody] CreateStockDto dto)
        {
            return await _stockService.AddStockAsync(dto);
            //return CreatedAtAction(nameof(GetAsync), stock);
        }

        // PUT api/<StocksController>/5
        [HttpPut("{id}")]
        public async Task<Stock> PutAsync(long id, [FromBody] Stock entity)
        {
            entity.StockId = id;
            return await _stockService.UpdateStockAsync(entity);
        }

        // DELETE api/<StocksController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            await _stockService.DeleteStockAsync(id);

        }

        [HttpPost("upload-scripts")]
        public async Task<IActionResult> UploadJson()
        {
            using var reader = new StreamReader(Request.Body);
            var json = await reader.ReadToEndAsync();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };

            var options = JsonConvert.DeserializeObject<List<CreateStockDto>>(json, settings);

            List<CreateStockDto> filteredOptions = options.Where(o => o.Segment == "BSE_EQ" || o.Segment == "NSE_EQ").ToList();

            await _stockService.AddStockRangeAsync(filteredOptions);

            return Ok(new { Count = filteredOptions.Count });
        }

    }
}
