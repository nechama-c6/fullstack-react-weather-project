using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Weather.ResourceAccess.Models
{
    public partial class WeatherDbContext : DbContext
    {
        public WeatherDbContext()
        {
        }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavoriteCity> FavoriteCities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<FavoriteCity>(entity =>
            {
                entity.ToTable("Favorite_Cities");

                entity.Property(e => e.FavoriteCityId).HasColumnName("Favorite_City_Id");

                entity.Property(e => e.CityKey)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("City_Key");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
