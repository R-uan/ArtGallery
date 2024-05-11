﻿using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Models {
	public class Artwork {
		public int ArtworkId { get; set; }
		public int? Year { get; set; }

		[Required] public required string Slug { get; set; }
		[Required] public required string Title { get; set; }
		[Required] public required string Description { get; set; }
		[Required] public required string ImageURL { get; set; }

		public int ArtistId { get; set; }
		public Artist? Artist { get; set; }

		public int MuseumId { get; set; }
		public Museum? Museum { get; set; }
	}
}
