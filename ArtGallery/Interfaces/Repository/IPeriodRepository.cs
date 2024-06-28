﻿using ArtGallery.Data.DataTransferObjects.Period;
using ArtGallery.Models;

namespace ArtGallery.Interfaces.Repository
{
    public interface IPeriodRepository
    {
        Task<bool?> Delete(int id);
        Task<List<Period>> Find();
        Task<Period?> FindById(int id);
        Task<Period?> Save(Period period);
        Task<List<PartialPeriod>> FindPartial();
        Task<bool?> Update(int id, UpdatePeriod period);
    }
}