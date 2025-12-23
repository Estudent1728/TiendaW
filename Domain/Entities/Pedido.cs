using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string NombreCliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; } = string.Empty;

        public DateTime FechaPedido { get; set; } = DateTime.Now;
        public decimal Total { get; set; }

        // Relación: Un pedido tiene muchos detalles
        public List<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
    }
}