namespace Domain.Entities
{
    public class DetallePedido
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        public int ZapatoId { get; set; }
        public Zapato? Zapato { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; } // Guardamos el precio del momento de la compra
    }
}