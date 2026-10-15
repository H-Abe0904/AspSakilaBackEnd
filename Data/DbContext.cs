using Microsoft.EntityFrameworkCore;
using AspSakilaBackEnd.Data.Entities;

namespace AspSakilaBackEnd.Data
{
	/// <summary>
	/// Represents the database context for the Sakila database.
	/// </summary>
	public class SakilaDbContext : DbContext
	{
		public SakilaDbContext(DbContextOptions<SakilaDbContext> options) : base(options)
		{
		}

		public DbSet<Film> Films { get; set; } = null!;
		// Add other DbSet properties for other entities as needed

		/// <summary>
		/// Configures the entity mappings and relationships for the Sakila database context.
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configure entity mappings and relationships here if needed

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

		}
	}
}