using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPedidoRepository
    {
        // Devuelve el ID del pedido creado
        Task<int> CreateAsync(Pedido pedido);
        // Metodo Nuevo
        Task<IList<Pedido>> GetPedidosAsync();
    }
}