namespace TradingDashboard.Shared.Dtos
{
    public class CreateWatchlistDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
