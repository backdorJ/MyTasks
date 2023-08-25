using FleaMarket.Data;
using FleaMarket.Enum;
using FleaMarket.Interfaces;
using FleaMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace FleaMarket.Implentashions;

public class SQLAnnouncementRepository : IAnnouncementsRepository
{
    private readonly ApplicationDbContext _context;

    public SQLAnnouncementRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<AnnouncementModel>> GetAnnouncementsAsync()
        => await _context.Announcements.ToListAsync();

    public async Task<List<AnnouncementModel>> GetListModelCategoryAnnouncementsAsync(string category)
        => await _context.Announcements
            .Where(filter => filter.Category == category)
            .ToListAsync();

    public async Task<AnnouncementModel> GetAnnouncementAsync(int id)
        => await _context.Announcements.FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddToFavouriteAsync(AnnouncementsUsers model)
    {
        await _context.AnnouncementsUsers.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AnnouncementModel>> GetAllAnnouncementsByIdUserAsync(string userId)
        => await _context
            .AnnouncementsUsers
            .Where(x => x.UserId == userId)
            .Select(x => x.Announcement)
            .ToListAsync();

    public async Task<bool> DeleteAnnouncementAsync(int announcementId, string userId)
    {
        var model = await _context
            .AnnouncementsUsers
            .Where(x => x.UserId == userId && x.AnnouncementId == announcementId)
            .FirstOrDefaultAsync();
        _context.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }
    
    private bool _disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            if (disposing)
                _context.Dispose();

            _disposed = true;
        }
    }
}