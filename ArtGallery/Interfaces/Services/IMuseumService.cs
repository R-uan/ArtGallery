﻿using ArtGallery.DTO;
using ArtGallery.Models;
using ArtGallery.Utils;

namespace ArtGallery.Interfaces {
	public interface IMuseumService : IBaseService<Museum, MuseumDTO, UpdateMuseumDTO, PartialMuseumDTO> { }
}
