using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Sale> SalesInStore { get; set; }
    }
}
