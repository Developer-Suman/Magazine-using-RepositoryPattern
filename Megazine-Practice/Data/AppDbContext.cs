using Megazine_Practice.Models;
using Megazine_Practice.Services.ServiceImpl;
using Microsoft.EntityFrameworkCore;

namespace Megazine_Practice.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Journal> journals { get; set; }
        public DbSet<Articles> articles { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<News> news { get; set; }
    }
}
