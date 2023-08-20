using FleaMarket.Data;
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

    public async Task<List<AnnouncementModel>> GetAnnouncements()
        => await _context.Announcements.ToListAsync();

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