var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "A configuração inicial!");

app.Run();
