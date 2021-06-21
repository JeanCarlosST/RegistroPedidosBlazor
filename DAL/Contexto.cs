using Microsoft.EntityFrameworkCore;
using RegistroPedidosBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidosBlazor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data source=Data\Ordenes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Productos>().HasData(new List<Productos>()
            {
                new Productos() { ProductoID = 1, Descripcion = "Samsung TV 50 inch", Costo = 23000, Inventario = 10},
                new Productos() { ProductoID = 2, Descripcion = "Estufa electrica", Costo = 50000, Inventario = 30},
                new Productos() { ProductoID = 3, Descripcion = "Microondas", Costo = 30000, Inventario = 25}
            });

            modelBuilder.Entity<Suplidores>().HasData(new List<Suplidores>()
            {
                new Suplidores() { SuplidorID = 1, Nombres = "Ricardo Estevez" },
                new Suplidores() { SuplidorID = 2, Nombres = "Manuel María" },
                new Suplidores() { SuplidorID = 3, Nombres = "Gilberto Gomez" }
            });
        }
    }
}
