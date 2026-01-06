using Microsoft.EntityFrameworkCore;
using ProductivityOS.Entities;

namespace ProductivityOS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<DailyJournal> Journals { get; set; }
    }

}
