using Microsoft.EntityFrameworkCore;
using PontosDeInteresse;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PoisDb>(opt =>
{
    opt.UseInMemoryDatabase("PointsOfInterest");
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
{
    using var scope = app.Services.CreateScope();

    var context = scope.ServiceProvider.GetRequiredService<PoisDb>();
    var seeder = new PoisSeed(context);
    seeder.SeedData();
}

PoisService Service = new();

app.MapGet("/pois", Service.GetAll);
app.MapGet("/pois/ver/{id}", Service.FindBydId);
app.MapGet("/pois/buscar", Service.FindByDistance);
app.MapPut("/pois/{id}", Service.UpdatePois);
app.MapPost("/pois", Service.RegisterPois);

app.Run();
