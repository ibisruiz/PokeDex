 using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Contexts
{

    /// <summary>
    /// 02/27/2024-33
    /// </summary>
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }



        /// <summary>
        /// Create Pokemones
        /// </summary>
        public DbSet<Pokemon> Pokemones { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API

            #region tables
            modelBuilder.Entity<Pokemon>()
                .ToTable("Pokemones");

            modelBuilder.Entity<Region>()
                .ToTable("Regiones");

            modelBuilder.Entity<Tipo>()
                .ToTable("Tipos");

            #endregion


            #region "primary keys"
            modelBuilder.Entity<Pokemon>()
                .HasKey(pokemon => pokemon.Id);

            modelBuilder.Entity<Region>()
                .HasKey(region => region.Id);

            modelBuilder.Entity<Tipo>()
                .HasKey(tipo => tipo.Id);
            #endregion


            #region relationships
            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(region => region.Pokemones)
                .WithOne(pokemon => pokemon.Region)
                .HasForeignKey(pokemon => pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tipo>()
                .HasMany<Pokemon>(tipo => tipo.Pokemones)
                .WithOne(pokemon => pokemon.Tipo)
                .HasForeignKey(pokemon => pokemon.TipoId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion


            #region "Property and configurations"

            #region Pokemon
            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Nombre)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.ImageUrl)
                .IsRequired();
            #endregion

            #region Region
            modelBuilder.Entity<Region>()
                .Property(region => region.Name)
                .IsRequired();
            #endregion

            #region Tipo
            modelBuilder.Entity<Tipo>()
                .Property(tipo => tipo.Name)
                .IsRequired();
            #endregion



            #endregion

        }

    }
}
