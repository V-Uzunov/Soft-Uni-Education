namespace CarDealer.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Is Young Driver")]
        public bool IsYoungDriver { get; set; }
    }
}
