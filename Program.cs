global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
