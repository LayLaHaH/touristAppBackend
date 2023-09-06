using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBContextTourist.Models
{
    public partial class touristsContext : IdentityDbContext
    {
        public touristsContext()
        {
        }

        public touristsContext(DbContextOptions<touristsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Destination> Destinations { get; set; } = null!;
        public virtual DbSet<DestinationPicture> DestinationPictures { get; set; } = null!;
        public virtual DbSet<Exclude> Excludes { get; set; } = null!;
        public virtual DbSet<Governorate> Governorates { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Include> Includes { get; set; } = null!;
        public virtual DbSet<Itinerary> Itineraries { get; set; } = null!;
        public virtual DbSet<Market> Markets { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<Tour> Tours { get; set; } = null!;
        public virtual DbSet<TourCompany> TourCompanies { get; set; } = null!;
        public virtual DbSet<TourHasActivity> TourHasActivities { get; set; } = null!;
        public virtual DbSet<TourHasDestination> TourHasDestinations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-EI6TDPB\\SQLEXPRESS;Database=tourists;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("Activity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CloseTime)
                    .HasColumnType("datetime")
                    .HasColumnName("closeTime");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.EndingDay)
                    .HasColumnType("date")
                    .HasColumnName("endingDay");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.Property(e => e.StartingDay)
                    .HasColumnType("date")
                    .HasColumnName("startingDay");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.GovernerateId).HasColumnName("governerateID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Picture)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.HasOne(d => d.Governerate)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.GovernerateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Governorate");
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.ToTable("Destination");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Theme)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("theme");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Destinations)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Destination_City");
            });

            modelBuilder.Entity<DestinationPicture>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DestId).HasColumnName("destID");

                entity.Property(e => e.Picture)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.HasOne(d => d.Dest)
                    .WithMany(p => p.DestinationPictures)
                    .HasForeignKey(d => d.DestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DestinationPictures_Destination");
            });

            modelBuilder.Entity<Exclude>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Excludes)
                    .HasColumnType("text")
                    .HasColumnName("excludes");

                entity.Property(e => e.TourId).HasColumnName("tourID");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Excludes)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Excludes_Tour");
            });

            modelBuilder.Entity<Governorate>(entity =>
            {
                entity.ToTable("Governorate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Picture)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("picture");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.ClassStar).HasColumnName("classStar");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contactNumber");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Url)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hotel_City");
            });

            modelBuilder.Entity<Include>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Includes)
                    .HasColumnType("text")
                    .HasColumnName("includes");

                entity.Property(e => e.TourId).HasColumnName("tourID");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Includes)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Includes_Tour");
            });

            modelBuilder.Entity<Itinerary>(entity =>
            {
                entity.ToTable("Itinerary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EachDayDescription)
                    .HasColumnType("text")
                    .HasColumnName("eachDayDescription");

                entity.Property(e => e.TourId).HasColumnName("tourID");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Itineraries)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Itinerary_Tour");
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.ToTable("Market");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Markets)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Market_City");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.ClassStar).HasColumnName("classStar");

                entity.Property(e => e.ClosingHour)
                    .HasColumnType("datetime")
                    .HasColumnName("closingHour");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contactNumber");

                entity.Property(e => e.Cuisine)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cuisine");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.OpeningHour)
                    .HasColumnType("datetime")
                    .HasColumnName("openingHour");

                entity.Property(e => e.Url)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_City");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("Tour");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.DaysNnights)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("daysNnights");

                entity.Property(e => e.GuidLanguage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("guidLanguage");

                entity.Property(e => e.IsPrivate).HasColumnName("isPrivate");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Theme)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("theme");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tour_TourCompany");
            });

            modelBuilder.Entity<TourCompany>(entity =>
            {
                entity.ToTable("TourCompany");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contactNumber");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TourHasActivity>(entity =>
            {
                entity.ToTable("tourHasActivities");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.TourId).HasColumnName("tourID");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TourHasActivities)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tourHasActivities_Activity");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourHasActivities)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tourHasActivities_Tour");
            });

            modelBuilder.Entity<TourHasDestination>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DestId).HasColumnName("destID");

                entity.Property(e => e.TourId).HasColumnName("tourID");

                entity.HasOne(d => d.Dest)
                    .WithMany(p => p.TourHasDestinations)
                    .HasForeignKey(d => d.DestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TourHasDestinations_Destination");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourHasDestinations)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TourHasDestinations_Tour");
            });

            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<IdentityUser>().Property(x => x.Id).HasMaxLength(225);
            modelBuilder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(225);
            modelBuilder.Entity<IdentityUserLogin<string>>().Property(x => x.ProviderKey).HasMaxLength(225);
            base.OnModelCreating(modelBuilder);

           /* modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });*/
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
