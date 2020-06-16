using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kolokwium2.Models
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

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<MusicLabel> MusicLabel { get; set; }
        public virtual DbSet<Musician> Musician { get; set; }
        public virtual DbSet<MusicianTrack> MusicianTrack { get; set; }
        public virtual DbSet<Track> Track { get; set; }

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
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.IdAlbum)
                    .HasName("Album_pk");

                entity.Property(e => e.IdAlbum).ValueGeneratedNever();

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MusicLabelIdMusicLabel).HasColumnName("MusicLabel_IdMusicLabel");

                entity.Property(e => e.PublishDate).HasColumnType("date");

                entity.HasOne(d => d.MusicLabelIdMusicLabelNavigation)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.MusicLabelIdMusicLabel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Album_MusicLabel");
            });

            modelBuilder.Entity<MusicLabel>(entity =>
            {
                entity.HasKey(e => e.IdMusicLabel)
                    .HasName("MusicLabel_pk");

                entity.Property(e => e.IdMusicLabel).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Musician>(entity =>
            {
                entity.HasKey(e => e.IdMusician)
                    .HasName("Musician_pk");

                entity.Property(e => e.IdMusician).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MusicianTrack>(entity =>
            {
                entity.HasKey(e => e.IdMusicianTrack)
                    .HasName("Musician_Track_pk");

                entity.ToTable("Musician_Track");

                entity.Property(e => e.IdMusicianTrack).ValueGeneratedNever();

                entity.Property(e => e.MusicianIdMusician).HasColumnName("Musician_IdMusician");

                entity.Property(e => e.TrackIdTrack).HasColumnName("Track_IdTrack");

                entity.HasOne(d => d.MusicianIdMusicianNavigation)
                    .WithMany(p => p.MusicianTrack)
                    .HasForeignKey(d => d.MusicianIdMusician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Musician_Track_Musician");

                entity.HasOne(d => d.TrackIdTrackNavigation)
                    .WithMany(p => p.MusicianTrack)
                    .HasForeignKey(d => d.TrackIdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Musician_Track_Track");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.IdTrack)
                    .HasName("Track_pk");

                entity.Property(e => e.IdTrack).ValueGeneratedNever();

                entity.Property(e => e.AlbumIdAlbum).HasColumnName("Album_IdAlbum");

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AlbumIdAlbumNavigation)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.AlbumIdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Track_Album");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
