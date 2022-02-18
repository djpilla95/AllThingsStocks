using YahooFinanceStocks.Shared.Interfaces;
using YahooFinanceStocks.Shared.Models;

namespace YahooFinanceStocks.Processors
{
    public class StocksProcessor : IStocksProcessor
    {
        private readonly IStocksDataAccess _stocksDataAccess;

        public StocksProcessor(IStocksDataAccess stocksDataAccess)
        {
            _stocksDataAccess = stocksDataAccess;
        }

        public async Task<List<StockListing>> GetStockListingsAsync(string stockSymbols)
        {
            return await _stocksDataAccess.GetStockListingsAsync(stockSymbols);
        }
    }
}
