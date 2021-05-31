using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inredning.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        //public DbSet<User> Users { get; set; } // lives in base class
        public DbSet<Project> Projects { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed Users
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Email = "krille@ballong.se",
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 2,
                Email = "pelle@ballong.se",
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 3,
                Email = "kalle@ballong.se",
            });

            //seed Projects
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectId = 1,
                ProjectName = "Kontorslandskap X",
                DecoratorEmail = "pelle@ballong.se"
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectId = 2,
                ProjectName = "Restaurang Y",
                DecoratorEmail = "kalle@ballong.se"
            });

            //seed OrderItems
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                OrderItemId = 1,
                Name = "Kontorsstolen Gertrud",
                ProjectId = 1,
                Supplier = "Ikea",
                IndividualPrice = 1000,
                Amount = 1,
                Info = "www.ikea.se"
            }); 
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                OrderItemId = 2,
                Name = "Mattan Torsten",
                ProjectId = 1,
                Supplier = "Värnamo Furniture",
                IndividualPrice = 100,
                Amount = 3,
                Info = "www.varnf.se"
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                OrderItemId = 3,
                Name = "Hyllan Adam",
                ProjectId = 2,
                Supplier = "Axels möbler AB",
                IndividualPrice = 1500,
                Amount = 3,
                Info = "www.axmob.se"
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                OrderItemId = 4,
                Name = "Färgen Megasnygg, 10 liter dunk",
                ProjectId = 2,
                Supplier = "Färgfabriken",
                IndividualPrice = 200,
                Amount = 4,
                Info = "www.fargfab.se"
            });
        }
    }
}
