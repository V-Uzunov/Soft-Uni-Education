using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.Models
{
    public enum ResourceType
    {
        Video, Presentation, Document, Other
    }

    public class Resource
    {
        public Resource()
        {
            this.Course = new HashSet<Course>();
            this.Licence = new HashSet<Licence>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType Type { get; set; }

        public string Url { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Licence> Licence { get; set; }
    }
}
