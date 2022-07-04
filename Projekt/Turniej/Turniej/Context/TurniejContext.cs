using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Turniej.Models;

namespace Turniej.Context
{
    public partial class TurniejContext : DbContext
    {
        public TurniejContext()
        {
        }

        public TurniejContext(DbContextOptions<TurniejContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Trenerzy> Trenerzies { get; set; } = null!;
        public virtual DbSet<Uczestnictwo> Uczestnictwos { get; set; } = null!;
        public virtual DbSet<Zawodnicy> Zawodnicies { get; set; } = null!;
        public virtual DbSet<Zawody> Zawodies { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trenerzy>(entity =>
            {
                entity.HasKey(e => e.IdTrenera)
                    .HasName("PK__trenerzy__E25E0CF801356BA1");

                entity.ToTable("trenerzy");

                entity.Property(e => e.IdTrenera).HasColumnName("id_trenera");

                entity.Property(e => e.IleMedaliT).HasColumnName("ile_medali_t");

                entity.Property(e => e.ImieT)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("imie_t");

                entity.Property(e => e.NazwiskoT)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nazwisko_t");
            });

            modelBuilder.Entity<Uczestnictwo>(entity =>
            {
                entity.HasKey(e => e.IdUczestnictwa)
                    .HasName("PK__uczestni__79BC730BAA104BC4");

                entity.ToTable("uczestnictwo");

                entity.Property(e => e.IdUczestnictwa).HasColumnName("id_uczestnictwa");

                entity.Property(e => e.IdZawodnika).HasColumnName("id_zawodnika");

                entity.Property(e => e.IdZawodow).HasColumnName("id_zawodow");

                entity.HasOne(d => d.IdZawodnikaNavigation)
                    .WithMany(p => p.Uczestnictwos)
                    .HasForeignKey(d => d.IdZawodnika)
                    .HasConstraintName("FK__uczestnic__id_za__2B3F6F97");

                entity.HasOne(d => d.IdZawodowNavigation)
                    .WithMany(p => p.Uczestnictwos)
                    .HasForeignKey(d => d.IdZawodow)
                    .HasConstraintName("FK__uczestnic__id_za__2C3393D0");
            });

            modelBuilder.Entity<Zawodnicy>(entity =>
            {
                entity.HasKey(e => e.IdZawodnika)
                    .HasName("PK__zawodnic__96B2F8BC6BADB5CD");

                entity.ToTable("zawodnicy");

                entity.Property(e => e.IdZawodnika).HasColumnName("id_zawodnika");

                entity.Property(e => e.IdTrenera).HasColumnName("id_trenera");

                entity.Property(e => e.IleMedaliT).HasColumnName("ile_medali_t");

                entity.Property(e => e.Imie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("imie");

                entity.Property(e => e.Kraj)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("kraj");

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nazwisko");

                entity.HasOne(d => d.IdTreneraNavigation)
                    .WithMany(p => p.Zawodnicies)
                    .HasForeignKey(d => d.IdTrenera)
                    .HasConstraintName("FK__zawodnicy__id_tr__286302EC");
            });

            modelBuilder.Entity<Zawody>(entity =>
            {
                entity.HasKey(e => e.IdZawodow)
                    .HasName("PK__zawody__4E37E54B3297864F");

                entity.ToTable("zawody");

                entity.Property(e => e.IdZawodow).HasColumnName("id_zawodow");

                entity.Property(e => e.Lokalizacja)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lokalizacja");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nazwa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
