using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> categories { get; set; } 

        public DbSet<Product> products { get; set; }

        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRoles> userRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasData(new User() {id=1, Email = "admin@gmail.com", Password = "123456" });
            modelBuilder.Entity<User>()
                .HasData(new User() {id=2, Email = "user@gmail.com", Password = "123456" });


            modelBuilder.Entity<Role>()
                  .HasData(new Role() {Id=1,    Name="admin" });
            modelBuilder.Entity<Role>().HasData(new Role() { Id=2, Name="user"});



            modelBuilder.Entity<UserRoles>()
                .HasData(new UserRoles() {Id=1,   UserId=1,RoleId=1 });
            modelBuilder.Entity<UserRoles>()
                .HasData(new UserRoles() {Id = 2, UserId=2,RoleId=2});
        }
    }
}
