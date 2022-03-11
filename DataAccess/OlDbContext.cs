using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OlDbContext:DbContext
    {
        public OlDbContext(DbContextOptions<OlDbContext> opt):base(opt)
        {
        }
        public DbSet<Section1> Section1s { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Reserv> Reservs { get; set; }
        public DbSet<ReservCategory> ReservCategories { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Service> Services { get; set; }

    }
}
