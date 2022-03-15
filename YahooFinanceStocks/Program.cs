using YahooFinanceStocks.DataAccess.Services;
using YahooFinanceStocks.Processors;
using YahooFinanceStocks.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IStocksDataAccess, YahooFinanceAccessor>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["YahooFinanceApiUri"]);
    client.DefaultRequestHeaders.Add("x-api-key", builder.Configuration["YahooApiKey"]);
});

builder.Services.AddScoped<IStocksProcessor, StocksProcessor>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
