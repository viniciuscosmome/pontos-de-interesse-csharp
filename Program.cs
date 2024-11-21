using Microsoft.EntityFrameworkCore;
using PontosDeInteresse;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PoisDb>(opt =>
{
    opt.UseInMemoryDatabase("PointsOfInterest");
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

PoisService Service = new();

app.MapGet("/pois", Service.GetAll);
app.MapGet("/pois/ver/{id}", Service.FindBydId);
app.MapPost("/pois", Service.RegisterPois);

app.Run();
