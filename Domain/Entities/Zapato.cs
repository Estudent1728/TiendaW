using System.ComponentModel.DataAnnotations; // 👈 IMPORTANTE: Agrega esto
namespace Domain.Entities
{
    public class Zapato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Modelo es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El modelo debe tener entre 2 y 100 caracteres.")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Marca es obligatoria.")]
        [StringLength(50, ErrorMessage = "La marca no puede exceder los 50 caracteres.")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Talla es obligatoria.")]
        [Range(15, 55, ErrorMessage = "La talla debe estar entre 15 y 55.")]
        public decimal Talla { get; set; }

        [Required(ErrorMessage = "El Color es obligatorio.")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Precio es obligatorio.")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe ser mayor a 0 y menor a 10,000.")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El Stock es obligatorio.")]
        [Range(0, 5000, ErrorMessage = "El stock no puede ser negativo ni mayor a 5000.")]
        public int Stock { get; set; }

        [Display(Name = "Imagen (URL)")] //Agregamos Imagen
        public string? UrlImagen { get; set; } // Puede ser nulo por si no tiene foto
    }
}