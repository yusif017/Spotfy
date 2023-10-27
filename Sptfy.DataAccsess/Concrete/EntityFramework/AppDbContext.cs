using Microsoft.EntityFrameworkCore;
using Spotfy.Entities.Concreate;
using Spotfy.Core.Configuration;
using Spotfy.Core.Entities.Concrete;
using Spotfy.Entities.Concrete;

namespace SpotfyDataAccess.Concrete.EntityFramework
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database= SpotfyDataBase; User Id=sa; Password=Password@12345;TrustServerCertificate=True;");
        }

        public DbSet<Alibom> Aliboms { get; set; }
        public DbSet<AlibomMusic> AlibomMusics { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlibomMusic>()
                .HasOne(x => x.Music)
                .WithMany()
                .HasForeignKey(x => x.MusicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WishList>()
                .HasOne(x => x.Music)
                .WithMany()
                .HasForeignKey(x => x.MusicId)
                .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Reaction>()
            //    .HasOne(x => x.User)
            //    .WithMany()
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
