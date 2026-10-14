using System;
using Microsoft.EntityFrameworkCore;
using AspSakilaBackEnd.Data.Entities;

namespace AspSakilaBackEnd.Data.Entities
{
	[Table("film")]
	public class Film
	{
		[Key]
		[Column("film_id")]
		public ushort FilmId { get; set; }

		[Required]
		[Column("title")]
		[StringLength(128)]
		public string Title { get; set; } = null!;

		[Column("description", TypeName = "text")]
		public string? Description { get; set; }

		[Column("release_year")]
		public int? ReleaseYear { get; set; }

		[Required]
		[Column("language_id")]
		public byte LanguageId { get; set; }

		[Required]
		[Column("rental_duration")]
		public byte RentalDuration { get; set; }

		[Required]
		[Column("rental_rate", TypeName = "decimal(4,2)")]
		public decimal RentalRate { get; set; }

		[Required]
		[Column("last_update")]
		public DateTime LastUpdate { get; set; }
	}
}