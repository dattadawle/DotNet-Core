using Microsoft.EntityFrameworkCore;

namespace FirstCoreWebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
            base(options) 
        {


        }

        public DbSet<Category> categories { get; set; }
    }
      
    }

