using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        // Aquí definimos la tabla Zapatos
        public DbSet<Zapato> Zapatos { get; set; }

        // Nuevas Lineas
        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<DetallePedido> DetallesPedido {get; set;}
    }
}