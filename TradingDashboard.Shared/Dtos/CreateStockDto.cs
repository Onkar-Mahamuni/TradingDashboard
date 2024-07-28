namespace TradingDashboard.Shared.Dtos
{
    public class CreateStockDto
    {
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
        public string? Sector { get; set; }
        public string? Description { get; set; }
    }
}
