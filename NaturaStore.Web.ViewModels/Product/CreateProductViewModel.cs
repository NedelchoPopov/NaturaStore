using System.ComponentModel.DataAnnotations;

namespace NaturaStore.Web.ViewModels.Product
{
    using static NaturaStore.Data.Common.EntityConstants.Product;
    using static NaturaStore.GCommon.ApplicationConstants;

    public class CreateProductViewModel
    {
        [Required]
        [MinLength(NameMinLenght)]
        [MaxLength(NameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLenght)]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;

        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Display(Name = "Снимка (URL)")]
        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }
            = $"/images/{NoImageUrl}";

        [Required]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Производител")]
        public int ProducerId { get; set; }

        
    }
}
