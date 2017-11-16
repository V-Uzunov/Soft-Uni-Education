using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.Models
{
    public class Licence
    {
        public Licence()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Resource Resource { get; set; }
    }
}
