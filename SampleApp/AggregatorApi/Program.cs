using AggregatorApi.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("TempApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://temp-api/");    
});
builder.Services.AddHttpClient("HumidApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://humid-api/");
});

builder.Services.AddScoped<ITempHttpAdapter, TempAdadpter>();
builder.Services.AddScoped<IHumidHttpAdapter, HumidAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
