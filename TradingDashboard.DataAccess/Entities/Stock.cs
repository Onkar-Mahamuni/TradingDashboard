using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingDashboard.DataAccess.Entities
{
    public class Stock
    {
        [Key]
        public long StockId { get; set; }
        public required string Segment { get; set; }
        public required string Name { get; set; }
        public required string Exchange { get; set; }
        public required string Isin { get; set; }
        public required string InstrumentType { get; set; }
        public required string InstrumentKey { get; set; }
        public int LotSize { get; set; }
        public double FreezeQuantity { get; set; }
        public required string ExchangeToken { get; set; }
        public double TickSize { get; set; }
        public required string TradingSymbol { get; set; }
        public required string ShortName { get; set; }
        public required string SecurityType { get; set; }
        public string? Sector {  get; set; }
        public string? Description { get; set; }
    }
}
