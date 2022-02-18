using YahooFinanceStocks.Shared.Communication;
using YahooFinanceStocks.Shared.Models;

namespace YahooFinanceStocks.Shared.Interfaces
{
    public interface IStocksProcessor
    {
        Task<List<StockListing>> GetStockListingsAsync(string stockSymbols);
    }
}
