using FleaMarket.API.Models.Recipe;
using FleaMarket.Authoriz;
using FleaMarket.Models;

namespace FleaMarket.Data;


public class AnnouncementsUsers
{
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public int AnnouncementId { get; set; }
    public AnnouncementModel Announcement { get; set; }

    public bool IsAdded { get; set; }
}