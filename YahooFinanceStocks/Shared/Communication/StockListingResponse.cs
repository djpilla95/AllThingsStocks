using YahooFinanceStocks.Shared.Models;

namespace YahooFinanceStocks.Shared.Communication
{
    public class StockListingResponse
    {
        public List<StockListing> Stocks { get; set; }
    }
}
