namespace CarDealer.Services.Models.Suppliers
{
    using System.Collections.Generic;

    public class SuppliersModel
    {
        public string Type { get; set; }
        
        public IEnumerable<FilterSuppliers> Suppliers { get; set; }
    }
}
