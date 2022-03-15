namespace YahooFinanceStocks.Shared.Communication
{
    public class YahooFinanceDto
    {
        public QuoteResponse QuoteResponse { get; set; }
    }

    public class QuoteResponse
    {
        public string Error { get; set; }
        public List<ResultObject> Result { get; set; }
    }

    public class ResultObject
    {
        public string Symbol { get; set; }
        public double RegularMarketPrice { get; set; }
        public long MarketCap { get; set; }
    }
}

