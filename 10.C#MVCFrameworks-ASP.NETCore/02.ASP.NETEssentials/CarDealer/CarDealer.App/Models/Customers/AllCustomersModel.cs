namespace CarDealer.App.Models.Customers
{
    using System.Collections.Generic;
    using Services.Models;

    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customer { get; set; }

        public OrderType Type { get; set; }
    }
}
