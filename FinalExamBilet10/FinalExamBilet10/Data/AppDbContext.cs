using FinalExamBilet10.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExamBilet10.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Team>   Teams { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
    }
}
