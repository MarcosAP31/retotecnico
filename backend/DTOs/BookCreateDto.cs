using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class BookCreateDto
    {
        [Required]
        [StringLength(250)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Author { get; set; } = null!;

        [Range(0, 3000, ErrorMessage = "El año debe ser válido.")]
        public int Year { get; set; }

        [Required]
        [StringLength(200)]
        public string Publisher { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Debe tener al menos 1 página.")]
        public int Pages { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; } = null!;

        [StringLength(50)]
        public string? Isbn { get; set; }  // opcional
    }
}
