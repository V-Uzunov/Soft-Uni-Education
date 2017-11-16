using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Data.DTO
{
    public class AnomalyVictimDTO
    {
        public string OriginPlanet { get; set; }
        public string TeleportPlanet { get; set; }
        public ICollection<string> Victims { get; set; }
    }
}
