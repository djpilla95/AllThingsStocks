using YahooFinanceStocks.Shared.Communication;

namespace YahooFinanceStocks.Shared.Interfaces
{
    public interface IStocksDataAccess
    {
        Task<StockListingResponse> GetStockListingsAsync(string stockSymbols);
    }
}
