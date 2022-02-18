using YahooFinanceStocks.Shared.Models;

namespace YahooFinanceStocks.Shared.Interfaces
{
    public interface IStocksDataAccess
    {
        Task<List<StockListing>> GetStockListingsAsync(string stockSymbols);
    }
}
