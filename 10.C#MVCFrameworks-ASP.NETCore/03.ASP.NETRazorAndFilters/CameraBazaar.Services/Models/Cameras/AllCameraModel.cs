namespace CameraBazaar.Services.Models.Cameras
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class AllCameraModel
    {
        public int Id { get; set; }
        
        public CameraMake Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Display(Name = "Image URL")]
        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public string ImageUrl { get; set; }
    }
}
