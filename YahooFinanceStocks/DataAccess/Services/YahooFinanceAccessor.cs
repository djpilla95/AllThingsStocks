using System.Web;
using YahooFinanceStocks.Shared.Communication;
using YahooFinanceStocks.Shared.Interfaces;
using YahooFinanceStocks.Shared.Models;

namespace YahooFinanceStocks.DataAccess.Services
{
    public class YahooFinanceAccessor : IStocksDataAccess
    {
        private readonly HttpClient _client;

        public YahooFinanceAccessor(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<StockListing>> GetStockListingsAsync(string stockSymbols)
        {
            var encodedString = HttpUtility.UrlEncode(stockSymbols, System.Text.Encoding.UTF8);
            var yahooRequest = new HttpRequestMessage(HttpMethod.Get, $"?region=US&lang=en&symbols={encodedString}");
            var response = await _client.SendAsync(yahooRequest);

            var listings = new List<StockListing>();

            if (response != null && response.IsSuccessStatusCode) {
                var stockListings = await response.Content.ReadFromJsonAsync<YahooFinanceDto>();
                if(stockListings != null && stockListings.QuoteResponse != null && stockListings.QuoteResponse.Error == null)
                {
                    foreach (var stock in stockListings.QuoteResponse.Result)
                    {
                        listings.Add(new StockListing
                        {
                            Symbol = stock.Symbol,
                            Price = stock.RegularMarketPrice
                        });
                    }
                }
                else
                {
                    // Return error to sender
                }
            }

            return listings;
        }
    }
}
