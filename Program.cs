var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "A configura��o inicial!");

app.Run();
