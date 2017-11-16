﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
    public class Anomaly
    {
        public Anomaly()
        {
            this.Victims = new HashSet<Person>();
        }
        public int Id { get; set; }

        public int? OriginPlanetId { get; set; }
        public virtual Planet OriginPlanet { get; set; }

        public int? TeleportPlanetId { get; set; }
        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Victims { get; set; }

    }
}
