using System.ComponentModel.DataAnnotations;

namespace Server.Core.src.Entity;

public class ProductImage : BaseEntity
{
    [Required(ErrorMessage = "Product id is required")]
    public Guid ProductId { get; set; }
    [Required(ErrorMessage = "Product image url is required")]
    public string Url { get; set; }
}