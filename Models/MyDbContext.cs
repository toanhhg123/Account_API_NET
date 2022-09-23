using Microsoft.EntityFrameworkCore;

namespace AccountApi.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<User>().Property(u => u.Id).HasDefaultValueSql("NEWID()");
            optionsBuilder.Entity<User>().Property(u => u.CreateAt).HasDefaultValueSql("getdate()");
            optionsBuilder.Entity<User>(E =>
            {
                E.HasIndex(u => u.Email).IsUnique();
            });
        }

        public DbSet<DetailUser> Detail { set; get; }
        public DbSet<User> Users { set; get; } = default!;



    }
}