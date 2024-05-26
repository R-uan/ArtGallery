﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ArtGallery.Models {
	public class Artist {
		public int ArtistId { get; set; }
		public string? Country { get; set; }
		public string? Movement { get; set; }
		public string? Biography { get; set; }
		public string? Profession { get; set; }
		public required string Name { get; set; }
		public required string Slug { get; set; }
		public DateTime? Date_of_birth { get; set; }
		public DateTime? Date_of_death { get; set; }
		[JsonIgnore] public ICollection<Artwork>? Artworks { get; set; }
	}
}
