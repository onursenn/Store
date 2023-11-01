using System.ComponentModel.DataAnnotations;
namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        [Required(ErrorMessage = "Ürün Adı Boş Bırakılamaz.")]
        public string? ProductName { get; init; }
        [Required(ErrorMessage = "Fiyat Alanı Boş Bırakılamaz.")]
        public decimal Price { get; init; }
        public string? Summary { get; init; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; init; }   // Foreing key
    }
}
