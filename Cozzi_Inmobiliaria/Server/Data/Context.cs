using Cozzi_Inmobiliaria.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cozzi_Inmobiliaria.Server.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<Inmueble> Inmuebles { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildAlquileresModel(modelBuilder);
            BuildClientesModel(modelBuilder);
        }
        private static void BuildAlquileresModel(ModelBuilder builder)
        {
            builder.Entity<Inquilino>()
                .HasMany(p => p.Alquileres)
                .WithOne(pj => pj.Inquilino)
                .HasForeignKey(pj => pj.InquilinoId);

            builder.Entity<Inmueble>()
                .HasMany(p => p.Alquileres)
                .WithOne(pj => pj.Inmueble)
                .HasForeignKey(pj => pj.InmuebleId);
        }
        private static void BuildClientesModel(ModelBuilder builder)
        {
            builder.Entity<Inmueble>()
                .HasOne(p => p.Cliente)
                .WithMany(pj => pj.Inmuebles)
                .HasForeignKey(pj => pj.ClienteId);            
        }
    }
}
