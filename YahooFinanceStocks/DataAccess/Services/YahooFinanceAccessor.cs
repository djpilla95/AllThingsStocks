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

        public async Task<StockListingResponse> GetStockListingsAsync(string stockSymbols)
        {
            var encodedString = HttpUtility.UrlEncode(stockSymbols, System.Text.Encoding.UTF8);
            var yahooRequest = new HttpRequestMessage(HttpMethod.Get, $"?region=US&lang=en&symbols={encodedString}");
            var result = await _client.SendAsync(yahooRequest);

            var response = new StockListingResponse
            {
                Stocks = new List<StockListing>()
            };


            if (result != null && result.IsSuccessStatusCode) {
                var stockListings = await result.Content.ReadFromJsonAsync<YahooFinanceDto>();
                if(stockListings != null && stockListings.QuoteResponse != null && stockListings.QuoteResponse.Error == null)
                {
                    foreach (var stock in stockListings.QuoteResponse.Result)
                    {
                        response.Stocks.Add(new StockListing
                        {
                            Symbol = stock.Symbol,
                            Price = stock.RegularMarketPrice,
                            MarketCap = stock.MarketCap
                        });
                    }
                }
                else
                {
                    response.Message = "Failed to retrieve stocks from Yahoo!";
                    return response;
                }
            }

            response.Success = true;
            return response;
        }
    }
}
