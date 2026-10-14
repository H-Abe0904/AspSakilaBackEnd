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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configure entity mappings and relationships here if needed
				// 映画エンティティの LastUpdate プロパティにタイムスタンプ値を設定
			modelBuilder.Entity<Film>(entity =>
			{
				entity.Property(e => e.LastUpdate)
					.HasDefaultValueSql("CURRENT_TIMESTAMP")
					.ValueGeneratedOnAddOrUpdate();
			});

// 演者エンティティの LastUpdate プロパティにタイムスタンプ値を設定
			modelBuilder.Entity<Actor>(entity =>
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
		}
	}
}