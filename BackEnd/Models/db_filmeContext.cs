using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd.Models
{
    public partial class db_filmeContext : DbContext
    {
        public db_filmeContext()
        {
        }

        public db_filmeContext(DbContextOptions<db_filmeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAtor> TbAtors { get; set; }
        public virtual DbSet<TbDiretor> TbDiretors { get; set; }
        public virtual DbSet<TbFilme> TbFilmes { get; set; }
        public virtual DbSet<TbFilmeAtor> TbFilmeAtors { get; set; }
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=db_filme", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<TbAtor>(entity =>
            {
                entity.HasKey(e => e.IdAtor)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<TbDiretor>(entity =>
            {
                entity.HasKey(e => e.IdDiretor)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<TbFilme>(entity =>
            {
                entity.HasKey(e => e.IdFilme)
                    .HasName("PRIMARY");

                entity.Property(e => e.NrNota).HasPrecision(15, 2);

                entity.HasOne(d => d.FkDiretorNavigation)
                    .WithMany(p => p.TbFilmes)
                    .HasForeignKey(d => d.FkDiretor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_filme_ibfk_1");
            });

            modelBuilder.Entity<TbFilmeAtor>(entity =>
            {
                entity.HasKey(e => e.IdFilmeAtor)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.FkAtorNavigation)
                    .WithMany(p => p.TbFilmeAtors)
                    .HasForeignKey(d => d.FkAtor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_filme_ator_ibfk_2");

                entity.HasOne(d => d.FkFilmeNavigation)
                    .WithMany(p => p.TbFilmeAtors)
                    .HasForeignKey(d => d.FkFilme)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_filme_ator_ibfk_1");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
