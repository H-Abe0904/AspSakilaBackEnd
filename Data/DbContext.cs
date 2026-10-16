using Microsoft.EntityFrameworkCore;
using AspSakilaBackEnd.Models;

namespace AspSakilaBackEnd.Data.Entities;
    /// <summary>
    /// Represents the database context for the Sakila database.
    /// </summary>
    public class SakilaDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SakilaDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public SakilaDbContext(DbContextOptions<SakilaDbContext> options) : base(options)
        {
        }

        public DbSet<Film> Films { get; set; } = null!;

        /// <summary>
        /// SakilaDbContext のモデルを構成するためのメソッド
        /// </summary>
        /// <param name="modelBuilder">モデルビルダー</param>
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
