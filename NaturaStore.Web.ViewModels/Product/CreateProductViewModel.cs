using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NaturaStore.Web.ViewModels.Product
{
    using static NaturaStore.Data.Common.EntityConstants.Product;
    using static NaturaStore.GCommon.ApplicationConstants;

    public class CreateProductViewModel
    {
        [Required]
        [MinLength(NameMinLenght)]
        [MaxLength(NameMaxLenght)]
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

        
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Producers { get; set; } = new List<SelectListItem>();

        
        public string? NewProducerName { get; set; }

    }
}
