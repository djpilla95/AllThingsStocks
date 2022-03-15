using Microsoft.AspNetCore.Mvc;
using YahooFinanceStocks.Shared.Communication;
using YahooFinanceStocks.Shared.Interfaces;

namespace YahooFinanceStocks.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStocksProcessor _stocksProcessor;

        public StocksController(IStocksProcessor stocksProcessor)
        {
            _stocksProcessor = stocksProcessor;
        }

        [HttpGet("GetStockListingsAsync")]
        public async Task<IActionResult> GetStockListingsAsync([FromQuery] string stockSymbols)
        {
            if(stockSymbols == null || stockSymbols.Length == 0)
            {
                return BadRequest("No stock symbols provided.");
            }

            try
            {
                var result = await _stocksProcessor.GetStockListingsAsync(stockSymbols);
                if (result.Stocks != null && result.Stocks.Count > 0)
                {
                    return Ok(result);
                }
            }
            catch(Exception ex)
            {
                // Log exception
                return StatusCode(500, ex.Message);
            }            

            return BadRequest("No stocks were found provided the given symbols.");
        }
    }
}
