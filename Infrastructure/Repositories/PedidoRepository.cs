using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Pedido pedido)
        {
            // 1. Agregamos el pedido (y sus detalles) a la memoria de EF
            _context.Pedidos.Add(pedido);

            // 2. RESTAR STOCK: Recorremos los productos comprados
            foreach (var detalle in pedido.Detalles)
            {
                var zapato = await _context.Zapatos.FindAsync(detalle.ZapatoId);
                if (zapato != null)
                {
                    // Restamos la cantidad comprada al stock actual
                    zapato.Stock -= detalle.Cantidad;
                }
            }

            // 3. Guardamos TODO en la base de datos en una sola transacción
            await _context.SaveChangesAsync();

            return pedido.Id;
        }

        public async Task<IList<Pedido>>
        GetPedidosAsync()
        {
            return await _context.Pedidos
            .Include(p => p.Detalles)  //Trae los detalles del pedido
            .ThenInclude(d => d.Zapato) // Y dentro del detalle trae la info del Zapato
            .OrderByDescending(p => p.FechaPedido) //Ordena por fecha los (nuevos primeros)
            .ToListAsync();

        }
    }
}