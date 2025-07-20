using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NaturaStore.Web.ViewModels.Product
{
    public class EditProductViewModel
    {
        public Guid Id { get; set; }  // Оставяме Guid за Id на продукта

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }  

        [Display(Name = "Производител")]
        public Guid ProducerId { get; set; }  

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Producers { get; set; } = new List<SelectListItem>();
    }
}
