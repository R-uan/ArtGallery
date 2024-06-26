﻿using ArtGallery.DTO;
using ArtGallery.Models;
using ArtGallery.Utils;
namespace ArtGallery.Interfaces.Services
{
    public interface IArtistService : IBaseService<Artist, ArtistDTO, UpdateArtistDTO, PartialArtistDTO>
    {
        Task<PaginatedResponse<PartialArtistDTO>> PaginatedQuery(ArtistQueryParams queryParams, int page);
    }
}

