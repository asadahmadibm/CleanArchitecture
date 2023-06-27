using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class StoreDbContext :DbContext
    {
        public DbSet<Member> Memberss { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Member>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);
        //        entity.Property(e => e.Id);
        //        entity.Property(e => e.Name).HasMaxLength(30);
        //        entity.Property(e => e.Type).HasMaxLength(500);
        //        entity.Property(e => e.Address).HasMaxLength(250);
              
        //        entity.HasData(new Member
        //        {
        //            Id=1,
        //            Name = "Cookies",
        //            Type = "bob@admonex.com",
        //            Address = "bob",
                
        //        });

        //    });
        //}
    }
}
