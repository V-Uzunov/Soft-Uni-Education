namespace CarDealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Data.Models;
    using Models.Suppliers;

    public interface ISuppliersServices
    {
        ICollection<FilterSuppliers> AllFilteredSupplierses(bool isInporter);

        IEnumerable<AllSuppliers> All();

        void Add(string name, bool isImporter);

        AllSuppliers FindId(int id);

        void Edit(int id, string name, bool isImporter);
        void Delete(int id);
    }
}
