using System.Collections.Generic;
using System.Security.AccessControl;

namespace Car_Dealer.Models
{
    public class Car
    {
        public Car()
        {
            this.Parts = new List<Part>();
        }
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

    }
}
