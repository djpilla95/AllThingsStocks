namespace YahooFinanceStocks.Shared.Models
{
    public class StockListing
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public long MarketCap { get; set; }
    }
}
