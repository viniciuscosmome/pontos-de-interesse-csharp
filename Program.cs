using Microsoft.EntityFrameworkCore;
using PontosDeInteresse;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PoisDb>(opt =>
{
    opt.UseInMemoryDatabase("PointsOfInterest");
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/pois", () => "hello world!");

app.Run();
