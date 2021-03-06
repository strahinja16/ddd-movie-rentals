﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApi.Migrations
{
    [DbContext(typeof(RentalDbContext))]
    [Migration("20200530140529_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Core.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Genre");

                    b.Property<string>("Name");

                    b.Property<decimal>("price");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Core.Models.MoviePurchase", b =>
                {
                    b.Property<Guid>("MovieId");

                    b.Property<Guid>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.HasKey("MovieId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("MoviePurchase");
                });

            modelBuilder.Entity("Core.Models.MovieRental", b =>
                {
                    b.Property<Guid>("MovieId");

                    b.Property<Guid>("CustomerId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("MovieId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("MovieRental");
                });

            modelBuilder.Entity("Core.Models.PromoCode", b =>
                {
                    b.Property<Guid>("PromoCodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("MovieId");

                    b.Property<int>("Percentage");

                    b.Property<DateTime>("PromoEnd");

                    b.Property<DateTime>("PromoStart");

                    b.HasKey("PromoCodeId");

                    b.HasIndex("MovieId");

                    b.ToTable("PromoCode");
                });

            modelBuilder.Entity("Core.Models.Customer", b =>
                {
                    b.OwnsOne("Core.Models.CreditCard", "CreditCard", b1 =>
                        {
                            b1.Property<Guid>("CustomerId");

                            b1.Property<bool>("IsValid");

                            b1.Property<string>("Value");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.HasOne("Core.Models.Customer")
                                .WithOne("CreditCard")
                                .HasForeignKey("Core.Models.CreditCard", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Core.Models.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("CustomerId");

                            b1.Property<string>("LastName");

                            b1.Property<string>("Name");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.HasOne("Core.Models.Customer")
                                .WithOne("FullName")
                                .HasForeignKey("Core.Models.FullName", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Core.Models.MoviePurchase", b =>
                {
                    b.HasOne("Core.Models.Customer", "Customer")
                        .WithMany("MoviePurchases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Models.MovieRental", b =>
                {
                    b.HasOne("Core.Models.Customer", "Customer")
                        .WithMany("MovieRentals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Models.PromoCode", b =>
                {
                    b.HasOne("Core.Models.Movie", "Movie")
                        .WithMany("PromoCodes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
