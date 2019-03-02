using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Data.Sqlite;

namespace telephonedb.Models
{
    public partial class telephonedbchangesContext : DbContext
    {
        public telephonedbchangesContext()
        {
        }

        public telephonedbchangesContext(DbContextOptions<telephonedbchangesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NumberOwners> NumberOwners { get; set; }
        public virtual DbSet<TelephoneNumber> TelephoneNumber { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=telephonedbchanges;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<NumberOwners>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            });

            modelBuilder.Entity<TelephoneNumber>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CountryCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsOnNet)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StringValue).HasMaxLength(20);

                entity.HasOne(d => d.OwnedByNavigation)
                    .WithMany(p => p.TelephoneNumber)
                    .HasForeignKey(d => d.OwnedBy)
                    .HasConstraintName("FK_TelephoneNumber_ToNumberOwners");
            });
        }
    }
}
