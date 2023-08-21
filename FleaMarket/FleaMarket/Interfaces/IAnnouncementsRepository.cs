using FleaMarket.Enum;
using FleaMarket.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FleaMarket.Interfaces;

public interface IAnnouncementsRepository : IDisposable
{
    Task<List<AnnouncementModel>> GetAnnouncementsAsync();

    Task<List<AnnouncementModel>> GetListModelCategoryAnnouncementsAsync(string category);
}