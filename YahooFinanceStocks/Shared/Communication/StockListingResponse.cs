using YahooFinanceStocks.Shared.Models;

namespace YahooFinanceStocks.Shared.Communication
{
    public class StockListingResponse : BaseResponse
    {
        public List<StockListing> Stocks { get; set; }
    }
}
