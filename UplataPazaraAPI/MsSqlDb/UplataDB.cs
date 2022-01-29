using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UplataPazaraAPI.MsSqlDb
{
    public partial class UplataDB : DbContext
    {
        public UplataDB()
        {
        }

        public UplataDB(DbContextOptions<UplataDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Korisnik> Korisniks { get; set; } = null!;
        public virtual DbSet<Kurir> Kurirs { get; set; } = null!;
        public virtual DbSet<Trgovac> Trgovacs { get; set; } = null!;
        public virtual DbSet<Uplatum> Uplata { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Connection string bi trebalo sakriti
                optionsBuilder.UseSqlServer("Data Source=KRIS\\SQLDEVELOPER2014;Initial Catalog=UplataPazaraDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("Korisnik");

                entity.Property(e => e.KorisnickoIme)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lozinka)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kurir>(entity =>
            {
                entity.ToTable("Kurir");

                entity.Property(e => e.KurirId).HasColumnName("KurirID");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DatumAutorizacije).HasColumnType("date");

                entity.Property(e => e.DatumUnosa).HasColumnType("date");

                entity.Property(e => e.Drzava)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Grad)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Jmbg)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("JMBG");

                entity.Property(e => e.Mail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trgovac)
                    .WithMany(p => p.Kurirs)
                    .HasForeignKey(d => d.TrgovacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kurir_Trgovac");
            });

            modelBuilder.Entity<Trgovac>(entity =>
            {
                entity.ToTable("Trgovac");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BrojRacuna)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.DatumUnosa).HasColumnType("date");

                entity.Property(e => e.Drzava)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Grad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mb)
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .HasColumnName("MB");

                entity.Property(e => e.NazivTrgovca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pib)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PIB");
            });

            modelBuilder.Entity<Uplatum>(entity =>
            {
                entity.HasKey(e => e.UplataId);

                entity.Property(e => e.UplataId).ValueGeneratedOnAdd();

                entity.Property(e => e.AdresaUplatioca)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DatumTransakcije).HasColumnType("date");

                entity.Property(e => e.DatumUnosa).HasColumnType("date");

                entity.Property(e => e.GradUplatioca)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IznosProvizije).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IznosUplate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NazivUplatioca)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RacunPrimaoca)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UkupnaUplata).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Uplata)
                    .WithOne(p => p.Uplatum)
                    .HasForeignKey<Uplatum>(d => d.UplataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Uplata_Kurir");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
