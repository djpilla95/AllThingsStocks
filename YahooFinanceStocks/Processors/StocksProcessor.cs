using YahooFinanceStocks.Shared.Communication;
using YahooFinanceStocks.Shared.Interfaces;

namespace YahooFinanceStocks.Processors
{
    public class StocksProcessor : IStocksProcessor
    {
        private readonly IStocksDataAccess _stocksDataAccess;

        public StocksProcessor(IStocksDataAccess stocksDataAccess)
        {
            _stocksDataAccess = stocksDataAccess;
        }

        public async Task<StockListingResponse> GetStockListingsAsync(string stockSymbols)
        {
            return await _stocksDataAccess.GetStockListingsAsync(stockSymbols);
        }
    }
}
