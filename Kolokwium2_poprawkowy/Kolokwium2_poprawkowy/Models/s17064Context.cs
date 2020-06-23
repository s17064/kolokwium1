using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kolokwium2_poprawkowy.Models
{
    public partial class s17064Context : DbContext
    {
        public s17064Context()
        {
        }

        public s17064Context(DbContextOptions<s17064Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BreedType> BreedType { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }
        public virtual DbSet<VolunteerPet> VolunteerPet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17064;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BreedType>(entity =>
            {
                entity.HasKey(e => e.IdBreedType)
                    .HasName("BreedType_pk");

                entity.Property(e => e.IdBreedType).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.IdPet)
                    .HasName("Pet_pk");

                entity.Property(e => e.IdPet).ValueGeneratedNever();

                entity.Property(e => e.ApprocimateDateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateAdopted).HasColumnType("date");

                entity.Property(e => e.DateRegistered).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBreedTypeNavigation)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.IdBreedType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pet_BreedType");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer)
                    .HasName("Volunteer_pk");

                entity.Property(e => e.IdVolunteer).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartingDate).HasColumnType("date");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSupervisorNavigation)
                    .WithMany(p => p.InverseIdSupervisorNavigation)
                    .HasForeignKey(d => d.IdSupervisor)
                    .HasConstraintName("Volunteer_Volunteer");
            });

            modelBuilder.Entity<VolunteerPet>(entity =>
            {
                entity.HasKey(e => new { e.IdPet, e.IdVolunteer })
                    .HasName("Volunteer_Pet_pk");

                entity.ToTable("Volunteer_Pet");

                entity.Property(e => e.DateAccepted).HasColumnType("date");

                entity.HasOne(d => d.IdPetNavigation)
                    .WithMany(p => p.VolunteerPet)
                    .HasForeignKey(d => d.IdPet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Volunteer_Pet_Pet");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.VolunteerPet)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Volunteer_Pet_Volunteer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
