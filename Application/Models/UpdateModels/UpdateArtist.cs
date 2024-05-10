﻿namespace ArtGallery.Models {
	public class UpdateArtist {
		public string? Name { get; set; }
		public string? Slug { get; set; }
		public string? Country { get; set; }
		public string? Movement { get; set; }
		public string? Description { get; set; }
		public string? Profession { get; set; }
		public DateTime? Date_of_birth { get; set; }
		public DateTime? Date_of_death { get; set; }
	}
}