using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class RentalDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(typeof(decimal), "price");

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.PromoCodes)
                .WithOne(pc => pc.Movie)
                .HasForeignKey(e => e.MovieId);

            modelBuilder.Entity<PromoCode>()
                .HasOne(p => p.Movie)
                .WithMany(m => m.PromoCodes);

            modelBuilder.Entity<Customer>()
                .HasMany<MovieRental>()
                .WithOne()
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany<MoviePurchase>()
                .WithOne()
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Movie>()
                .HasMany<MoviePurchase>()
                .WithOne()
                .HasForeignKey(e => e.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany<MovieRental>()
                .WithOne()
                .HasForeignKey(e => e.MovieId);

            modelBuilder.Entity<MovieRental>()
                .HasKey(mr => new { mr.MovieId, mr.CustomerId });

            modelBuilder.Entity<MoviePurchase>()
                .HasKey(mp => new { mp.MovieId, mp.CustomerId });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.OwnsOne(e => e.CreditCard);
                entity.OwnsOne(e => e.FullName);
            });
        }
    }
}
