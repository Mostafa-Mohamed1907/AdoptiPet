using AdoptiPet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdoptiPet.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<PetCategory> PetCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PetCategory>()
                    .HasKey(pc => new { pc.PetId, pc.CategoryId });
            modelBuilder.Entity<PetCategory>()
                    .HasOne(p => p.Pet)
                    .WithMany(pc => pc.PetCategories)
                    .HasForeignKey(p => p.PetId);
            modelBuilder.Entity<PetCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.PetCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PetOwner>()
                    .HasKey(po => new { po.PetId, po.OwnerId });
            modelBuilder.Entity<PetOwner>()
                    .HasOne(p => p.Pet)
                    .WithMany(pc => pc.PetOwners)
                    .HasForeignKey(p => p.PetId);
            modelBuilder.Entity<PetOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(pc => pc.PetOwners)
                    .HasForeignKey(c => c.OwnerId);
        }
    }
}
