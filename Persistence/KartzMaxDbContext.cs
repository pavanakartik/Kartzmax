using kartzmax.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace kartzmax.Persistence
{
    public class KartzMaxDbContext : DbContext
    {

         public KartzMaxDbContext(DbContextOptions<KartzMaxDbContext> options) : base(options)
         {
             
         }

         public DbSet<Feature> Features { get; set; }
        
    }
}