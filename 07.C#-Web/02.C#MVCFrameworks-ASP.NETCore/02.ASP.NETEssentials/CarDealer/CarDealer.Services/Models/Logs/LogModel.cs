namespace CarDealer.Services.Models.Logs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LogModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string User { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Operation { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        [Display(Name = "Modified Table")]
        public string ModifiedTable { get; set; }

        public DateTime Time { get; set; }

        public string Search { get; set; }
    }
}
