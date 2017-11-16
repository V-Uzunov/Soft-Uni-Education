namespace CarDealer.Services.Models.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    public class AllSuppliers
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Improter")]
        public bool IsImporter { get; set; }

        public bool IsEdit { get; set; }
    }
}
