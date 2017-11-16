namespace PlanetHunter.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Star
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public int Temperature { get; set; }

        [Required]
        public int StarSystemId { get; set; }
        public virtual StarSystem StarSystem { get; set; }

        public int? DiscoveryId { get; set; }

        public virtual Discovery Discovery { get; set; }
    }
}
