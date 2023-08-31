using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using core7_mvc_mssql.Data;

namespace core7_mvc_mssql.Areas.Identity.Data;

public class IdentityDataContext : IdentityDbContext<IdentityUser>
{
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<Product>().Property(b => b.Prod_createdat).HasDefaultValueSql("getutcdate()");
        // builder.Entity<Product>().Property(b => b.Prod_updatedat).HasDefaultValueSql("getutcdate()");
        // builder.Entity<Product>().Property(b => b.Prod_createdat).ValueGeneratedOnAddOrUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        // builder.Entity<Product>().Property(b => b.Prod_updatedat).ValueGeneratedOnAddOrUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

        // builder.Entity<UserProfile>().Property(b => b.Created_at).HasDefaultValueSql("getutcdate()");
        // builder.Entity<UserProfile>().Property(b => b.Updated_at).HasDefaultValueSql("getutcdate()");
        // builder.Entity<UserProfile>().Property(b => b.Created_at).ValueGeneratedOnAddOrUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        // builder.Entity<UserProfile>().Property(b => b.Updated_at).ValueGeneratedOnAddOrUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

        base.OnModelCreating(builder);
        // this.SeedRoles(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    // private void SeedRoles(ModelBuilder builder) {
    //     builder.Entity<IdentityRole>().HasData
    //     (
    //         new IdentityRole() { Name = "Admin", ConcurrencyStamp ="1", NormalizedName = "Admin" },
    //         new IdentityRole() { Name = "Hr", ConcurrencyStamp ="1", NormalizedName = "Hr" },
    //         new IdentityRole() { Name = "Manager", ConcurrencyStamp ="1", NormalizedName = "Manager" },
    //         new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
    //     );
    // }


    public DbSet<UserProfile> UserProfiles {get; set;}
    public DbSet<Product> Products {get; set;}

}
