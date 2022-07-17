
using Microsoft.EntityFrameworkCore;
using MobileSubsApp.Models;

namespace MobileSubsApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
