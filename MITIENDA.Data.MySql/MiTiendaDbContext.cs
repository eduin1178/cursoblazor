using Microsoft.EntityFrameworkCore;
using MITIENDA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.Data.SqlServer
{
    public class MiTiendaDbContext : DbContext
    {
        public MiTiendaDbContext(DbContextOptions<MiTiendaDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleFactura> DetallesFacturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Categorias
            var categorias = modelBuilder.Entity<Categoria>();
            categorias.HasKey(x => x.Id);
            categorias.Property(x => x.Id).ValueGeneratedOnAdd();

            categorias.HasMany(x => x.Productos)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.IdCategoria);

            //Clientes
            var clientes = modelBuilder.Entity<Cliente>();
            clientes.HasKey(x => x.Id);
            clientes.Property(x => x.Id).ValueGeneratedOnAdd();

            clientes.HasMany(x => x.Facturas)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.IdCliente);

            //Roles
            var roles = modelBuilder.Entity<Rol>();
            roles.HasKey(x => x.Id);
            roles.Property(x => x.Id).ValueGeneratedOnAdd();

            roles.HasMany(x => x.Usuarios)
                .WithOne(x => x.Rol)
                .HasForeignKey(x => x.IdRol);

            //Productos
            var productos = modelBuilder.Entity<Producto>();
            productos.HasKey(x => x.Id);
            productos.Property(x => x.Id).ValueGeneratedOnAdd();

            productos.HasMany(x => x.DetallesFacturas)
                .WithOne(x => x.Producto)
                .HasForeignKey(x => x.IdProducto);

            //Facturas
            var facturas = modelBuilder.Entity<Factura>();
            facturas.HasKey(x => x.Id);
            facturas.Property(x => x.Id).ValueGeneratedOnAdd();

            facturas.HasMany(x => x.DetallesFacturas)
                .WithOne(x => x.Factura)
                .HasForeignKey(x => x.IdFactura);

            //Detalles Facturas
            var detalles = modelBuilder.Entity<DetalleFactura>();
            detalles.HasKey(x => x.Id);
            detalles.Property(x => x.Id).ValueGeneratedOnAdd();

            //Usuarios
            var usuarios = modelBuilder.Entity<Usuario>();
            usuarios.HasKey(x => x.Id);
            usuarios.Property(x => x.Id).ValueGeneratedOnAdd();

        }
    }
}
