using Microsoft.EntityFrameworkCore;

namespace OleevAppK310.Models
{
    public class OlDbContext:DbContext
    {
        public OlDbContext(DbContextOptions<OlDbContext> opt):base(opt)
        {
        }
        public DbSet<Section1Left> Section1Lefts { get; set; }
    }
}
