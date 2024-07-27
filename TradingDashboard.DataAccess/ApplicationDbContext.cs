using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDashboard.DataAccess.Entities;

namespace TradingDashboard.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<StockWatchlistMap> WatchlistStocksMap { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=testdb;Username=postgres;Password=Transflash").LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().ToTable("stocks");
            modelBuilder.Entity<Watchlist>().ToTable("watchlists");
            modelBuilder.Entity<StockWatchlistMap>().ToTable("stocks_watchlist_map");

            modelBuilder.Entity<StockWatchlistMap>().HasKey(u => new { u.stockId, u.WatchlistId });
        }
    }
}
