namespace Core3.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetailTemp> OrderDetailTemps { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<OrderDetail>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<OrderDetailTemp>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
