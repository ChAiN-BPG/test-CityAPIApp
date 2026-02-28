using CityApiApp.Interfaces;
using CityApiApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICityDataService, CityDataService>();

var app = builder.Build();

string DataPath = builder.Configuration["AppSettings:DataPath"] ?? string.Empty;

using var scope = app.Services.CreateScope();
var cityService = app.Services.GetRequiredService<ICityDataService>();
await cityService.Initial(DataPath);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();

public partial class Program { }
