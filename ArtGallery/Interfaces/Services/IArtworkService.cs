﻿using ArtGallery.DTO;
using ArtGallery.Models;
using ArtGallery.Utils;

namespace ArtGallery.Interfaces {
    public interface IArtworkService : IBaseService<Artwork, ArtworkDTO, UpdateArtworkDTO, PartialArtworkDTO> {
        public Task<PaginatedResponse<PartialArtworkDTO>> GetAllPartialPaginated(int page_index, int page_size);

    }
}
