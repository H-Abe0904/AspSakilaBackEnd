using Microsoft.EntityFrameworkCore;
using AspSakilaBackEnd.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AspSakilaBackEnd.Data.Entities;

/// <summary>
/// Represents the database context for the Sakila database.
/// </summary>
public class SakilaDbContext : DbContext
{
    /// <summary>
    /// アプリケーション実行時にDIコンテナからオプションを受け取るコンストラクタ
    /// </summary>
    public SakilaDbContext(DbContextOptions<SakilaDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// 設計時ツールがインスタンス化するためのパラメータなしコンストラクタ
    /// </summary>
    public SakilaDbContext()
    {
    }

    // コントローラー等で利用する DbSet を定義
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Film> Films { get; set; } = null!;
    public DbSet<FilmActor> FilmActors { get; set; } = null!;
    public DbSet<FilmCategory> FilmCategories { get; set; } = null!;
    public DbSet<Inventory> Inventories { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<Rental> Rentals { get; set; } = null!;
    public DbSet<Staff> Staffs { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;

    /// <summary>
    /// 設計時ツール向けに自力でプロバイダーを設定するフォールバック処理
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (!string.IsNullOrEmpty(connectionString))
            {
                var serverVersion = ServerVersion.AutoDetect(connectionString);
                optionsBuilder.UseMySql(connectionString, serverVersion);
            }
        }
    }

    /// <summary>
    /// SakilaDbContext のモデルを構成するためのメソッド
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 全エンティティの中から "LastUpdate" プロパティを持つものを自動検出し一括設定
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var property = entityType.FindProperty("LastUpdate");
            if (property != null)
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("LastUpdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
            }
        }

        // Film エンティティの特定ナビゲーションプロパティを無視
        modelBuilder.Entity<Film>().Ignore(f => f.Language);
        modelBuilder.Entity<Film>().Ignore(f => f.OriginalLanguage);
    }
}