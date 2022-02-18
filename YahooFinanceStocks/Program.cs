using YahooFinanceStocks.DataAccess.Services;
using YahooFinanceStocks.Processors;
using YahooFinanceStocks.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IStocksDataAccess, YahooFinanceAccessor>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["YahooFinanceApiUri"]);
    client.DefaultRequestHeaders.Add("x-api-key", builder.Configuration["YahooApiKey"]);
});

builder.Services.AddScoped<IStocksProcessor, StocksProcessor>();
//builder.Services.AddScoped<IStocksDataAccess, YahooFinanceAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
