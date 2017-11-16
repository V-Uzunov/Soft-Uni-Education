using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
    public class Planet
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int? SunId { get; set; }
        public virtual Star Sun { get; set; }
        public int? SolarSystemId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }
    }
}
