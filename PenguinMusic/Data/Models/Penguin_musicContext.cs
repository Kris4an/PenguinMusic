using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PenguinMusic.Data.Models
{
    public partial class Penguin_musicContext : DbContext
    {
        public Penguin_musicContext()
        {
        }

        public Penguin_musicContext(DbContextOptions<Penguin_musicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Concerts> Concerts { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Halls> Halls { get; set; }
        public virtual DbSet<Performers> Performers { get; set; }
        public virtual DbSet<Ticket> SoldTickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=COMP7\\MSSQLSERVERNEW;Database=Penguin_music;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("CIty_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Concerts>(entity =>
            {
                entity.HasKey(e => e.ConcertId);

                entity.Property(e => e.ConcertId).HasColumnName("Concert_ID");

                entity.Property(e => e.DateAndTime)
                    .HasColumnName("Date_And_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.HallId).HasColumnName("Hall_ID");

                entity.Property(e => e.PerformerId).HasColumnName("Performer_ID");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Concerts)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hall");

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.Concerts)
                    .HasForeignKey(d => d.PerformerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Performer");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.HasKey(e => e.DonationId);

                entity.Property(e => e.DonationId).HasColumnName("Donation_ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("PK_Genre");

                entity.Property(e => e.GenreId).HasColumnName("Genre_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Halls>(entity =>
            {
                entity.Property(e => e.HallsId).HasColumnName("Halls_ID");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.HallName)
                    .IsRequired()
                    .HasColumnName("Hall_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfSeats).HasColumnName("No_Of_Seats");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City1");
            });

            modelBuilder.Entity<Performers>(entity =>
            {
                entity.HasKey(e => e.PerformerId);

                entity.Property(e => e.PerformerId).HasColumnName("Performer_ID");

                entity.Property(e => e.GenreId).HasColumnName("Genre_ID");

                entity.Property(e => e.PerformerName)
                    .IsRequired()
                    .HasColumnName("Performer_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Performers)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genre");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketId);

                entity.ToTable("Sold_Tickets");

                entity.Property(e => e.TicketId)
                    .HasColumnName("Ticket_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConcertId).HasColumnName("Concert_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Concert)
                    .WithMany(p => p.SoldTickets)
                    .HasForeignKey(d => d.ConcertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Concert");
            });
        }
    }
}
