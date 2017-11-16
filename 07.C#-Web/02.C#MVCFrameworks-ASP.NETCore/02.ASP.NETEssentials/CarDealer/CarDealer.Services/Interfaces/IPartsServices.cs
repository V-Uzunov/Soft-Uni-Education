namespace CarDealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Data.Models;
    using Models.Parts;

    public interface IPartsServices
    {
        void Create(string name, double price, int quantity, int supplierId);

        void Delete(int id);

        void Edit(int id, string name, double price, int quantity);

        PartsDitailModel ById(int id);

        ListAllParts FindById(int id);

        IEnumerable<ListAllParts> AllParts(int page = 1, int pageSize = 10);

        IEnumerable<PartsIdModel> AllPartsIdModels();

        int Total();
        
    }
}
