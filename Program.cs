global using Microsoft.EntityFrameworkCore;
using AspSakilaBackEnd.Data.Entities;
using Microsoft.Extensions.DependencyInjection; 

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);

// ⭕️ ジェネリック型引数を明示的に指定して DbContextOptions を解決できるようにします
builder.Services.AddDbContextPool<SakilaDbContext>((System.IServiceProvider provider, DbContextOptionsBuilder options) => {
    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
