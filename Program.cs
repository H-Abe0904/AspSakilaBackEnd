global using Microsoft.EntityFrameworkCore;
using AspSakilaBackEnd.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 1. CORSポリシー設定
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClientApp", policy =>
    {
        policy.AllowAnyOrigin()   // 開発時はすべて許可
              .AllowAnyMethod()   // GET, POST, PUT, DELETE 等を許可
              .AllowAnyHeader();  // ヘッダーを許可
    });
});

// 2. コントローラーの追加
builder.Services.AddControllers();

// 3. appsettings.json から接続文字列を取得
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ★ 4. DbContext を DI コンテナに登録（これが抜けていたため InvalidOperationException が発生していました）
builder.Services.AddDbContext<SakilaDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);

var app = builder.Build();

// 5. CORS ミドルウェアの有効化
app.UseCors("AllowClientApp");

app.MapControllers();

app.Run();