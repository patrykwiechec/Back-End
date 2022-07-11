using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ObiektySportowe.Models
{
    public partial class ObiektyContext : DbContext
    {
        public ObiektyContext()
        {
        }

        public ObiektyContext(DbContextOptions<ObiektyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Obiekt> Obiekts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Obiekty;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Obiekt>(entity =>
            {
                entity.HasKey(e => e.IdObiekt)
                    .HasName("PK__obiekt__4DB25A0C40E50CC4");

                entity.ToTable("obiekt");

                entity.Property(e => e.CenaBiletu).HasColumnName("Cena_biletu");

                entity.Property(e => e.CenaBiletuVip).HasColumnName("Cena_biletu_vip");

                entity.Property(e => e.IloscMiejsc).HasColumnName("Ilosc_miejsc");

                entity.Property(e => e.Lokalizacja)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lokalizacja");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
