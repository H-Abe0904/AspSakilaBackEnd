using Microsoft.EntityFrameworkCore;
using AspSakilaBackEnd.Models;
using Microsoft.Extensions.Configuration; // ⭕️ 追加
using System.IO; // ⭕️ 追加

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
    /// 設計時ツール (codegenerator) がインスタンス化するためのパラメータなしコンストラクタ
    /// </summary>
    public SakilaDbContext()
    {
    }

    public DbSet<Film> Films { get; set; } = null!;

    /// <summary>
    /// 設計時ツール向けに自力でプロバイダーを設定するフォールバック処理
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Program.cs 等で既にセットアップ済みの場合は何もしない
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

        // Actorエンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Address エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Category エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // City エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Country エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Customer エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Filmエンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Film>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // FilmActor エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<FilmActor>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // FilmCategory エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<FilmCategory>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Inventory エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Language エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Language>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Payment エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Rental エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Rental>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Staff エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Store エンティティの LastUpdate プロパティにタイムスタンプ値を設定
        modelBuilder.Entity<Store>(entity =>
        {
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        });

        // Film エンティティの Language および OriginalLanguage プロパティを無視する
        modelBuilder.Entity<Film>().Ignore(f => f.Language);
        modelBuilder.Entity<Film>().Ignore(f => f.OriginalLanguage);
    }
}
