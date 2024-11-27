using Microsoft.EntityFrameworkCore;
using PontosDeInteresse.Src.infra;
using PontosDeInteresse.Src.Modules.PointOfInterest;

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
app.MapGet("/pois/buscar", Service.FindByDistance).AddEndpointFilter<OnlyCoordinatePoisFilter>();
app.MapGet("/pois/ver/{id}", Service.FindBydId).AddEndpointFilter<OnlyIdPoisFilter>();
app.MapPut("/pois/{id}", Service.UpdatePois).AddEndpointFilter<UpdatePoisFilter>();
app.MapDelete("/pois/{id}", Service.DeletePois).AddEndpointFilter<OnlyIdPoisFilter>();
app.MapPost("/pois", Service.RegisterPois).AddEndpointFilter<RegisterPoisFilter>();

app.Run();
