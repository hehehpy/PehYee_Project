using Microsoft.EntityFrameworkCore;
using PehYee_Project.Models;

namespace PehYee_Project.Data
{
    public class ADBC: DbContext
    {
        public ADBC(DbContextOptions<ADBC> options) : base(options) { }
        public DbSet<Booking> Bookings { get; set; }  // <-- DbSet matches class
    }
}
