using YahooFinanceStocks.Shared.Communication;

namespace YahooFinanceStocks.Shared.Interfaces
{
    public interface IStocksProcessor
    {
        Task<StockListingResponse> GetStockListingsAsync(string stockSymbols);
    }
}
