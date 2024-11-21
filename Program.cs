using Microsoft.EntityFrameworkCore;
using PontosDeInteresse;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PoisDb>(opt =>
{
    opt.UseInMemoryDatabase("PointsOfInterest");
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

PoisRepository Repository = new();

app.MapGet("/pois", Repository.GetAll);
app.MapPost("/pois", Repository.RegisterPois);

app.Run();
