using FleaMarket.Data;
using FleaMarket.Enum;
using FleaMarket.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FleaMarket.Interfaces;

public interface IAnnouncementsRepository : IDisposable
{
    Task<List<AnnouncementModel>> GetAnnouncementsAsync();

    Task<List<AnnouncementModel>> GetListModelCategoryAnnouncementsAsync(string category);
    Task<AnnouncementModel> GetAnnouncementAsync(int id);

    Task AddToFavouriteAsync(AnnouncementsUsers model);
    Task<List<AnnouncementModel>> GetAllAnnouncementsByIdUserAsync(string userId);

    Task<bool> DeleteAnnouncementAsync(int announcementId, string userId);

}