using Microsoft.EntityFrameworkCore;
using AspSakilaBackEnd.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.RegularExpressions;

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
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // 1. テーブル名をスネークケース化（例: FilmCategory -> film_category）
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName))
            {
                entity.SetTableName(ToSnakeCase(tableName));
            }

            // 2. 全プロパティ（カラム）名をスネークケース化（例: StaffId -> staff_id, FirstName -> first_name）
            foreach (var property in entity.GetProperties())
            {
                var columnName = property.GetColumnName();
                if (!string.IsNullOrEmpty(columnName))
                {
                    property.SetColumnName(ToSnakeCase(columnName));
                }
            }
        }

        // 1. FilmActor の複合主キー設定 (actor_id + film_id)
        modelBuilder.Entity<FilmActor>(entity =>
        {
            entity.HasKey(e => new { e.ActorId, e.FilmId });
        });

        // 2. FilmCategory も同様に複合主キーを設定 (film_id + category_id)
        modelBuilder.Entity<FilmCategory>(entity =>
        {
            entity.HasKey(e => new { e.FilmId, e.CategoryId });
        });

        // 以前追加したリレーションの設定もそのまま残します
        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasOne(d => d.Store)
                .WithMany()
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasOne(d => d.ManagerStaff)
                .WithMany()
                .HasForeignKey(d => d.ManagerStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasOne(d => d.Language)
                .WithMany()
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OriginalLanguage)
                .WithMany()
                .HasForeignKey(d => d.OriginalLanguageId);
        });
        // 3. Film -> Language (言語のリレーション)
        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasOne(d => d.Language)
                .WithMany()
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OriginalLanguage)
                .WithMany()
                .HasForeignKey(d => d.OriginalLanguageId);
        });
    }
    /// <summary>
    /// 文字列をスネークケースに変換するヘルパーメソッド
    /// </summary>
    /// <param name="input">変換する文字列</param>
    /// <returns>スネークケースに変換された文字列</returns>
    private static string ToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return Regex.Replace(input, @"(?<!^)(?=[A-Z])", "_").ToLowerInvariant();
    }
}
