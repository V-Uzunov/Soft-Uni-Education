namespace CarDealer.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class CustomersById
    {
        public string Name { get; set; }
        
        public bool IsYoungerDriver { get; set; }
        
        public ICollection<SalesModel> BoughtCars { get; set; }
        
        public double TotalMoneySpent
            => this.BoughtCars.Sum(c => c.Price * (1 - c.Discount))
            * (this.IsYoungerDriver ? 0.95 : 1);
    }
}
