namespace CarDealer.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CarByMake
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum characters must be 50.")]
        public string Make { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maximum characters must be 50.")]
        public string Model { get; set; }

        [Display(Name = "Travelled Distance")]
        [Range(0, long.MaxValue, ErrorMessage = "The number must be positive!")]
        public long TravelledDistance { get; set; }
    }
}
