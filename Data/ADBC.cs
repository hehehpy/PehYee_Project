using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PehYee_Project.Models;

namespace PehYee_Project.Data
{
    public class ADBC: IdentityDbContext<IdentityUser>
    {
        public ADBC(DbContextOptions<ADBC> options) : base(options) { }
        public DbSet<Booking> Bookings { get; set; }  // <-- DbSet matches class
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
