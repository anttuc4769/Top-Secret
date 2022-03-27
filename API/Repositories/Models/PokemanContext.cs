using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Repositories.Models
{
    public partial class PokemanContext : DbContext
    {
        public PokemanContext()
        {
        }

        public PokemanContext(DbContextOptions<PokemanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblPokemon> TblPokemons { get; set; } = null!;
        public virtual DbSet<TblRawPokemonUpload> TblRawPokemonUploads { get; set; } = null!;
        public virtual DbSet<TblTest> TblTests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPokemon>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PK__TblPokem__FBDF78E986B984D0");

                entity.ToTable("TblPokemon");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type1).HasMaxLength(20);

                entity.Property(e => e.Type2).HasMaxLength(20);
            });

            modelBuilder.Entity<TblRawPokemonUpload>(entity =>
            {
                entity.ToTable("TblRawPokemonUpload");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName).HasMaxLength(50);

                entity.Property(e => e.Generation).HasMaxLength(10);

                entity.Property(e => e.Legendary).HasMaxLength(10);

                entity.Property(e => e.PokemonAttack).HasMaxLength(20);

                entity.Property(e => e.PokemonDefense).HasMaxLength(20);

                entity.Property(e => e.PokemonHp)
                    .HasMaxLength(20)
                    .HasColumnName("PokemonHP");

                entity.Property(e => e.PokemonId).HasMaxLength(20);

                entity.Property(e => e.PokemonName).HasMaxLength(50);

                entity.Property(e => e.PokemonSpAttack).HasMaxLength(20);

                entity.Property(e => e.PokemonSpDefense).HasMaxLength(20);

                entity.Property(e => e.PokemonSpeed).HasMaxLength(20);

                entity.Property(e => e.PokemonTotal).HasMaxLength(20);

                entity.Property(e => e.PokemonType1).HasMaxLength(20);

                entity.Property(e => e.PokemonType2).HasMaxLength(20);
            });

            modelBuilder.Entity<TblTest>(entity =>
            {
                entity.ToTable("TblTest");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
