namespace PlanetHunter.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Telescope
    {
        public Telescope()
        {
            this.Telescopes = new HashSet<Discovery>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Location { get; set; }

        public float? MirrorDiameter { get; set; }

        public virtual ICollection<Discovery> Telescopes { get; set; }
    }
}
