namespace CarDealer.Services.Models.Parts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PartsModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Number must be between 1 and 1 000 000")]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; }

        public bool IsEdit { get; set; }
    }
}
