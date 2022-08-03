using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstProjet.Models
{
    public partial class DbothmanContext : DbContext
    {
        public  DbothmanContext()
        {
        }

        public DbothmanContext(DbContextOptions<DbothmanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipe> Equipes { get; set; } = null!;
        public virtual DbSet<Projet> Projets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // Directive #warning
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Dbothman;Trusted_Connection=True;");
#pragma warning restore CS1030 // Directive #warning
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipe>(entity =>
            {
                entity.ToTable("Equipe");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdProjet).HasColumnName("Id_projet");

                entity.Property(e => e.NomEquipe)
                    .HasMaxLength(20)
                    .HasColumnName("Nom_equipe");

                entity.HasOne(d => d.IdProjetNavigation)
                    .WithMany(p => p.Equipes)
                    .HasForeignKey(d => d.IdProjet)
                    .HasConstraintName("FK_Equipe_Projet");
            });

            modelBuilder.Entity<Projet>(entity =>
            {
                entity.ToTable("Projet");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateDebut)
                    .HasColumnType("date")
                    .HasColumnName("Date_debut");

                entity.Property(e => e.DateFin)
                    .HasColumnType("date")
                    .HasColumnName("Date_fin");

                entity.Property(e => e.Etat).HasMaxLength(20);

                entity.Property(e => e.Nom).HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEmbauche)
                    .HasMaxLength(50)
                    .HasColumnName("Date_embauche");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Fonctionnalite).HasMaxLength(50);

                entity.Property(e => e.IdEquipe).HasColumnName("Id_equipe");

                entity.Property(e => e.Nom).HasMaxLength(10);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Prenom).HasMaxLength(10);

                entity.Property(e => e.Sexe)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.IdEquipeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdEquipe)
                    .HasConstraintName("FK_User_Equipe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
